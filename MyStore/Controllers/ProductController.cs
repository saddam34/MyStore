using MyStore.Models;
using MyStore.ViewModels;
using PagedList;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MyStore.Controllers
{
    public class ProductController : Controller
    {
        private ProductDB _context;

        public ProductController()
        {
            _context = new ProductDB();
        }

        //Get: ProductMaster
        public ActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        //Add New Product
        public ActionResult Create()
        {
            var category = _context.Categories.ToList();

            var viewModel = new ProductViewModel
            {
                Categories = category
            };
            return View("Create", viewModel);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }

            ModelState.Clear();

            return RedirectToAction("Index", "Product");
        }

        //Get Product Details
        public ActionResult Details(int id)
        {
            var product = _context.Products.Include(p => p.Category).SingleOrDefault(p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        //Edit Record
        public ActionResult Edit(int id)
        {
            var product = _context.Products.Include(p => p.Category).SingleOrDefault(p => p.Id == id);
            var category = _context.Categories.ToList();

            var viewModel = new ProductViewModel
            {
                Categories = category,
                Product = product
            };

            if (product == null)
                return HttpNotFound();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            var data = _context.Products.Find(product.Id);

            if (data == null)
            {
                return HttpNotFound();
            }
            else if (ModelState.IsValid)
            {
                data.Id = product.Id;
                data.ProductName = product.ProductName;
                data.CategoryId = product.CategoryId;

                _context.SaveChanges();
            }

            ModelState.Clear();
            return RedirectToAction("Index", "Product"); ;
        }

        // Delete Record
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var product = _context.Products.Include(p => p.Category).SingleOrDefault(p => p.Id == id);

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteRequest(int id)
        {
            var product = _context.Products.Where(p => p.Id == id).First();

            _context.Products.Remove(product);
            _context.SaveChanges();

            var list = _context.Products.ToList();

            return View("Index", list);
        }

        // GET: ProductList with Pagination
        public ActionResult ProductList(int page = 1)
        {
            const int pageSize = 10;

            var products = _context.Products.Include(p => p.Category).ToList().ToPagedList(page, pageSize);

            return View(products);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}