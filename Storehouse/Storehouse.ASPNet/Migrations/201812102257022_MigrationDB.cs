namespace Storehouse.ASPNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Position", c => c.String());
            DropColumn("dbo.AspNetUsers", "Year");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Year", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "Position");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
