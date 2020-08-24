namespace Lib.io.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDateReturned : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Borrowings", "DateReturned", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Borrowings", "DateReturned", c => c.DateTime(nullable: false));
        }
    }
}
