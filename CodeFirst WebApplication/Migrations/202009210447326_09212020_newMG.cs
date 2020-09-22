using System.Data.Entity.Migrations;

namespace CodeFirst_WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _09212020_newMG : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Address");
        }
    }
}
