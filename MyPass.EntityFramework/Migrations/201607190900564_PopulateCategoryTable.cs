namespace MyPass.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories ( Name, CreatedById ,CreatedOn,Deleted) VALUES ('Web','15d7cb21-46c8-4c02-9e30-b62a0fce3e6f','2016-07-17','false')");
            Sql("INSERT INTO Categories ( Name, CreatedById ,CreatedOn,Deleted) VALUES ('Credit Card','15d7cb21-46c8-4c02-9e30-b62a0fce3e6f','2016-07-17','false')");
            Sql("INSERT INTO Categories ( Name, CreatedById ,CreatedOn,Deleted) VALUES ('Identites','15d7cb21-46c8-4c02-9e30-b62a0fce3e6f','2016-07-17','false')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Categories WHERE Id IN (1, 2, 3)");
        }
    }
}
