namespace VNScience.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CoverImage = c.String(),
                        Homepage = c.String(),
                        Description = c.String(),
                        Target = c.String(maxLength: 50),
                        DisplayOrder = c.Int(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Description = c.String(),
                        CoverImage = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        CategoryId = c.Int(),
                        ProductCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.ProductCategory", t => t.ProductCategory_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.ProductCategory_Id);
            
            //AddColumn("dbo.ProductCategory", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Product", "ProductCategory_Id", "dbo.ProductCategory");
            DropForeignKey("dbo.Product", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customer", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customer", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Product", new[] { "ProductCategory_Id" });
            DropIndex("dbo.Product", new[] { "UpdatedBy" });
            DropIndex("dbo.Product", new[] { "CreatedBy" });
            DropIndex("dbo.Customer", new[] { "UpdatedBy" });
            DropIndex("dbo.Customer", new[] { "CreatedBy" });
            DropColumn("dbo.ProductCategory", "Description");
            DropTable("dbo.Product");
            DropTable("dbo.Customer");
        }
    }
}
