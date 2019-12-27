namespace InvoiceSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer", "City_Id", "dbo.City");
            DropIndex("dbo.Customer", new[] { "City_Id" });
            DropColumn("dbo.Customer", "CityId");
            RenameColumn(table: "dbo.Customer", name: "City_Id", newName: "CityId");
            AlterColumn("dbo.Customer", "CityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customer", "CityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customer", "CityId");
            AddForeignKey("dbo.Customer", "CityId", "dbo.City", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "CityId", "dbo.City");
            DropIndex("dbo.Customer", new[] { "CityId" });
            AlterColumn("dbo.Customer", "CityId", c => c.Int());
            AlterColumn("dbo.Customer", "CityId", c => c.String(nullable: false));
            RenameColumn(table: "dbo.Customer", name: "CityId", newName: "City_Id");
            AddColumn("dbo.Customer", "CityId", c => c.String(nullable: false));
            CreateIndex("dbo.Customer", "City_Id");
            AddForeignKey("dbo.Customer", "City_Id", "dbo.City", "Id");
        }
    }
}
