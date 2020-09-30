namespace CodeFirst_WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColFistName : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Students", name: "FirstMidName", newName: "FirstName");
            AlterColumn("dbo.Students", "FirstName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "FirstName", c => c.String());
            RenameColumn(table: "dbo.Students", name: "FirstName", newName: "FirstMidName");
        }
    }
}
