namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandID = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                    })
                .PrimaryKey(t => t.BrandID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CatID = c.Int(nullable: false, identity: true),
                        CatName = c.String(),
                    })
                .PrimaryKey(t => t.CatID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductImage = c.String(),
                        ProductPrice = c.Int(),
                        BrandID = c.Int(),
                        CatID = c.Int(),
                        ProductDescription = c.String(),
                        ProductQuantity = c.Int(),
                        ProductStatus = c.String(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Brands", t => t.BrandID)
                .ForeignKey("dbo.Categories", t => t.CatID)
                .Index(t => t.BrandID)
                .Index(t => t.CatID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CatID", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "CatID" });
            DropIndex("dbo.Products", new[] { "BrandID" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
        }
    }
}
