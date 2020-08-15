namespace Lib.io.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableBirthDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
