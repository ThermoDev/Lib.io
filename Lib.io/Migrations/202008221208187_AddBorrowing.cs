namespace Lib.io.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBorrowing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Borrowings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateBorrowed = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Book_Id = c.Int(),
                        Member_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .ForeignKey("dbo.Members", t => t.Member_Id, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.Member_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Borrowings", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.Borrowings", "Book_Id", "dbo.Books");
            DropIndex("dbo.Borrowings", new[] { "Member_Id" });
            DropIndex("dbo.Borrowings", new[] { "Book_Id" });
            DropTable("dbo.Borrowings");
        }
    }
}
