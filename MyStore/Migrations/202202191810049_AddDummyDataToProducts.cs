namespace MyStore.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddDummyDataToProducts : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Products(ProductName, CategoryId) VALUES('Zoho-TShirt',15), " +
                "('Jara-Shirt', 15)," +
                "('Levis-Jeans',16)," +
                "('Zara-LadiesShirt',17)," +
                "('WildCraft-Jacket',15)," +
                "('Tradional-Kurta',19)," +
                "('Zara-LadiesKurta',20)," +
                "('Chroma-LadiesWatch',24)," +
                "('H&M-LadiesShirts',17)," +
                "('Fashion-Ladies',18)");
        }

        public override void Down()
        {
        }
    }
}