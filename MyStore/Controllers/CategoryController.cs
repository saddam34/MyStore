using MyStore.Models;
using System.Linq;
using System.Web.Mvc;

namespace MyStore.Controllers
{
    public class CategoryController : Controller
    {
        private ProductDB _context;

        public CategoryController()
        {
            _context = new ProductDB();
        }

        // GET: CategoryMaster
        public ActionResult Index()
        {
            var category = _context.Categories.ToList();
            return View(category);
        }

        // Add New Category
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
            }

            ModelState.Clear();

            return RedirectToAction("Index", "Category");
        }

        // Edit Record
        public ActionResult Edit(int id)
        {
            var product = _context.Categories.SingleOrDefault(c => c.Id == id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            var data = _context.Categories.Find(category.Id);

            if (data == null)
                return HttpNotFound();
            else if (ModelState.IsValid)
            {
                data.Id = category.Id;
                data.CategoryName = category.CategoryName;

                _context.SaveChanges();
            }

            ModelState.Clear();
            return RedirectToAction("Index", "Category");
        }

        // Get Details
        public ActionResult Details(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);

            if (category == null)
                return HttpNotFound();

            return View(category);
        }

        // Delete Record
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Category category = _context.Categories.Find(id);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteRequest(int id)
        {
            var category = _context.Categories.Where(p => p.Id == id).First();

            var product = _context.Products.Where(p => p.CategoryId == id).FirstOrDefault();

            if (product != null)
            {
                if (category.Id == product.CategoryId)
                    TempData["AlertMessage"] = "This record is referred by product table. First Delete from there...";
            }
            else
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }

            var list = _context.Categories.ToList();

            return View("Index", list);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}