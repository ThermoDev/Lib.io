namespace Lib.io.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Members", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Members", "MembershipTypeId");
            AddForeignKey("dbo.Members", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Members", new[] { "MembershipTypeId" });
            DropColumn("dbo.Members", "MembershipTypeId");
            DropTable("dbo.MembershipTypes");
        }
    }
}
