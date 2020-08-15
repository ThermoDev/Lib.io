namespace Lib.io.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "BirthDate");
        }
    }
}
