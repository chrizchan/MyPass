namespace MyPass.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodifiedIdofEntrytable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entries", "CreatedById", "dbo.Users");
            DropIndex("dbo.Entries", new[] { "CreatedById" });
            RenameColumn(table: "dbo.Entries", name: "ModifiedBy_Id", newName: "ModifiedById");
            CreateIndex("dbo.Entries", "CreatedById");
            AddForeignKey("dbo.Entries", "CreatedById", "dbo.Users", "Id");
            DropColumn("dbo.Entries", "ModifiedId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entries", "ModifiedId", c => c.Guid());
            DropForeignKey("dbo.Entries", "CreatedById", "dbo.Users");
            DropIndex("dbo.Entries", new[] { "CreatedById" });
            RenameColumn(table: "dbo.Entries", name: "ModifiedById", newName: "ModifiedBy_Id");
            CreateIndex("dbo.Entries", "CreatedById");
            AddForeignKey("dbo.Entries", "CreatedById", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
