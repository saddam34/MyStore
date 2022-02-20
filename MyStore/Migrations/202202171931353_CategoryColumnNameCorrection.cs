namespace MyStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryColumnNameCorrection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
            DropColumn("dbo.Categories", "ProductName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "ProductName", c => c.String(nullable: false));
            DropColumn("dbo.Categories", "CategoryName");
        }
    }
}
