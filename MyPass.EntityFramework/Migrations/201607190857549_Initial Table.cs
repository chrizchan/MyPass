namespace MyPass.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        CreatedById = c.Guid(nullable: false),
                        ModifiedById = c.Guid(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Email = c.String(nullable: false, maxLength: 256),
                        PasswordHash = c.String(nullable: false),
                        SecurityStamp = c.String(nullable: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        AccessFailedCount = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        ClaimId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.ClaimId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ExternalLogins",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                        CreatedById = c.Guid(nullable: false),
                        ModifiedId = c.Guid(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        Deleted = c.Boolean(nullable: false),
                        ModifiedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Users", t => t.CreatedById, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ModifiedBy_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedBy_Id);
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_RoleId = c.Guid(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_RoleId, t.User_Id })
                .ForeignKey("dbo.Roles", t => t.Role_RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Role_RoleId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.Entries", "ModifiedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Entries", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Entries", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.ExternalLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.Claims", "UserId", "dbo.Users");
            DropIndex("dbo.Categories", new[] { "ModifiedById" });
            DropIndex("dbo.Entries", new[] { "ModifiedBy_Id" });
            DropIndex("dbo.Entries", new[] { "CreatedById" });
            DropIndex("dbo.Entries", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "CreatedById" });
            DropIndex("dbo.RoleUsers", new[] { "User_Id" });
            DropIndex("dbo.RoleUsers", new[] { "Role_RoleId" });
            DropIndex("dbo.ExternalLogins", new[] { "UserId" });
            DropIndex("dbo.Claims", new[] { "UserId" });
            DropTable("dbo.RoleUsers");
            DropTable("dbo.Entries");
            DropTable("dbo.Roles");
            DropTable("dbo.ExternalLogins");
            DropTable("dbo.Claims");
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
        }
    }
}
