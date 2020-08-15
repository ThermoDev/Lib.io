namespace Lib.io.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubToMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "IsSubscribedToNewsletter");
        }
    }
}
