namespace Lib.io.Migrations {
    using System;
    using System.Data.Entity.Migrations;

    public partial class UpdateNamesInMembershipType : DbMigration {
        public override void Up() {
            Sql("UPDATE MembershipTypes SET Name= 'PAY AS YOU GO' WHERE DurationInMonths=0");
            Sql("UPDATE MembershipTypes SET Name= 'Month' WHERE DurationInMonths=1");
            Sql("UPDATE MembershipTypes SET Name= 'Quarterly' WHERE DurationInMonths=3");
            Sql("UPDATE MembershipTypes SET Name= 'Yearly' WHERE DurationInMonths=12");
        }

        public override void Down() {
        }
    }
}
