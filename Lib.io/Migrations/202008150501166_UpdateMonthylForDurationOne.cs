namespace Lib.io.Migrations {
    using System;
    using System.Data.Entity.Migrations;

    public partial class UpdateMonthylForDurationOne : DbMigration {
        public override void Up() {
            Sql("UPDATE MembershipTypes SET Name= 'Monthly' WHERE DurationInMonths=1");
        }

        public override void Down() {
        }
    }
}
