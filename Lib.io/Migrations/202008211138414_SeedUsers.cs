namespace Lib.io.Migrations {
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration {
        public override void Up() {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'398c8ac9-9e10-4e50-8975-174842fb9161', N'michael.pegios@hotmail.com', 0, N'AAoR2FP2cB5N7tBpLXOfVdHDXOCOKMzJ5+bzd9lZtilKkyFchtYZllT4ovf5GhfNuQ==', N'8fe1ba3e-ffd2-4155-89c1-bdf2adb53e8b', NULL, 0, 0, NULL, 1, 0, N'michael.pegios@hotmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'72469970-6bf0-4f44-a7d0-16c1074e17d3', N'admin@lib.io', 0, N'AMZp1GFK06SKH57BNae/v6o7vrPSRn3hhdTpnzmk19MX05OaT/bfesRXtVRP0j3Erg==', N'662b8fe2-ee46-44be-9a78-37fb3633fd69', NULL, 0, 0, NULL, 1, 0, N'admin@lib.io')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a0d106b2-7b7f-4f8e-8a14-2036594f318a', N'guest@lib.io', 0, N'AHJgAKxBcF6LrpSmGcB3lBTs+AcOXE8dzm61d9ix/V9xdg7IkAwyY7zWuFdMfBvHtw==', N'c0d352b2-20fd-4c1a-8a37-6b465c602099', NULL, 0, 0, NULL, 1, 0, N'guest@lib.io')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f827832f-bbc5-4aff-8f82-0ad784babf95', N'CanManageBooks')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'72469970-6bf0-4f44-a7d0-16c1074e17d3', N'f827832f-bbc5-4aff-8f82-0ad784babf95')
                ");
        }

        public override void Down() {
        }
    }
}
