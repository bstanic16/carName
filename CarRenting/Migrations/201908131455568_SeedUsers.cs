namespace CarRenting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'42fd403a-647b-43b8-9070-707aaea07006', N'admin@car.com', 0, N'ACF2Q8UU7be8W1vHZJ09eW7/MV+/c25zyb0UJ82zz5Zl8eE3D14p068M2rv1XjHaJw==', N'2f24c4fd-775b-41c4-8600-dd97123551cb', NULL, 0, 0, NULL, 1, 0, N'admin@car.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7abf0685-470f-40a8-96d7-e586f64d37e1', N'guest@carrenting.com', 0, N'AIq2KMw6m7GqLqcYHGCjq3DG1q89LE4sirW6QR9BftWm3PCSJWInO5DUakJSkcf9YQ==', N'92793496-06fe-4dc8-9410-bf231ce3c198', NULL, 0, 0, NULL, 1, 0, N'guest@carrenting.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f6f8e4fc-ce4f-42c3-97c1-434f95ca9f2e', N'CanManageCars')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'42fd403a-647b-43b8-9070-707aaea07006', N'f6f8e4fc-ce4f-42c3-97c1-434f95ca9f2e')

");
        }
        
        public override void Down()
        {
        }
    }
}
