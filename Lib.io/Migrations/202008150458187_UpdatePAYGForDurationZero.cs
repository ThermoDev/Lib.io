namespace Lib.io.Migrations {
    using System;
    using System.Data.Entity.Migrations;

    public partial class UpdatePAYGForDurationZero : DbMigration {
        public override void Up() {
            Sql("UPDATE MembershipTypes SET Name= 'Pay As You Go' WHERE DurationInMonths=0");
        }

        public override void Down() {
        }
    }
}
