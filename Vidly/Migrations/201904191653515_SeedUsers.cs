namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0972bde3-5ff3-474c-b5e3-e709c7acfcce', N'admin@vidly.com', 0, N'ACOOobm1de7WzAvUPtUiejNWLrgVTXC43wQZE5fjgsrcJOGIxoJ4/FQkm0438L4l+w==', N'01465b32-b3ea-4b12-867c-7ad9e748547e', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5480707f-728e-4830-8628-46cd36252b35', N'guest@vidly.com', 0, N'AIOmYZXtwX0tYBX7vnvWb9AhOBiC2KSHhCNyJThIinkL1v6potkMGJmcDqorZE+R1g==', N'e2915f48-91b3-4b3c-9d06-7bcdd2c6b164', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'67a890ba-2746-4f2c-ad7d-45d678680f35', N'CanManageMovie')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0972bde3-5ff3-474c-b5e3-e709c7acfcce', N'67a890ba-2746-4f2c-ad7d-45d678680f35')

");
        }
        
        public override void Down()
        {
        }
    }
}
