namespace Lib.io.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHasReturnedToBorrowings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Borrowings", "HasReturned", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Borrowings", "HasReturned");
        }
    }
}
