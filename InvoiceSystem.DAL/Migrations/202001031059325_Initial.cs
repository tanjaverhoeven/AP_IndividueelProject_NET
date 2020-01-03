namespace InvoiceSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Postal = c.String(nullable: false, maxLength: 20, unicode: false),
                        CityName = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Mail = c.String(nullable: false, maxLength: 50),
                        Street = c.String(nullable: false, maxLength: 200, unicode: false),
                        HouseNr = c.String(nullable: false, maxLength: 4, unicode: false),
                        Bus = c.String(maxLength: 4, unicode: false),
                        CityId = c.Int(nullable: false),
                        PhoneNr = c.String(nullable: false, maxLength: 90, unicode: false),
                        VAT = c.String(nullable: false, maxLength: 90, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustumorId = c.Int(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false),
                        Code = c.String(nullable: false, maxLength: 20),
                        State = c.Boolean(),
                        IsActive = c.Boolean(nullable: false),
                        DeleteMessage = c.String(maxLength: 300),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.DetailLine",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        Item = c.String(nullable: false, maxLength: 8000, unicode: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 0),
                        VATPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoice", t => t.InvoiceId, cascadeDelete: true)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        IdU = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Street = c.String(nullable: false, maxLength: 200, unicode: false),
                        HouseNr = c.String(nullable: false, maxLength: 4, unicode: false),
                        Bus = c.String(maxLength: 4, unicode: false),
                        CityId = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        Id = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.IdU)
                .ForeignKey("dbo.City", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_IdU = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_IdU)
                .Index(t => t.User_IdU);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(),
                        User_IdU = c.Int(),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.UserId })
                .ForeignKey("dbo.User", t => t.User_IdU)
                .Index(t => t.User_IdU);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        User_IdU = c.Int(),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.User", t => t.User_IdU)
                .Index(t => t.User_IdU);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        User_IdU = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_IdU)
                .Index(t => t.RoleId)
                .Index(t => t.User_IdU);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "User_IdU", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.IdentityUserRole", "User_IdU", "dbo.User");
            DropForeignKey("dbo.IdentityUserLogin", "User_IdU", "dbo.User");
            DropForeignKey("dbo.IdentityUserClaims", "User_IdU", "dbo.User");
            DropForeignKey("dbo.User", "CityId", "dbo.City");
            DropForeignKey("dbo.DetailLine", "InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.Invoice", "Customer_Id", "dbo.Customer");
            DropForeignKey("dbo.Customer", "CityId", "dbo.City");
            DropIndex("dbo.UserRole", new[] { "User_IdU" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.IdentityUserRole", new[] { "User_IdU" });
            DropIndex("dbo.IdentityUserLogin", new[] { "User_IdU" });
            DropIndex("dbo.IdentityUserClaims", new[] { "User_IdU" });
            DropIndex("dbo.User", new[] { "CityId" });
            DropIndex("dbo.DetailLine", new[] { "InvoiceId" });
            DropIndex("dbo.Invoice", new[] { "Customer_Id" });
            DropIndex("dbo.Customer", new[] { "CityId" });
            DropTable("dbo.UserRole");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.User");
            DropTable("dbo.Role");
            DropTable("dbo.DetailLine");
            DropTable("dbo.Invoice");
            DropTable("dbo.Customer");
            DropTable("dbo.City");
        }
    }
}
