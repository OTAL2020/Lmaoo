namespace Otal.lmaoo.Data.IntegrationTests.Seed
{
    using BCrypt.Net;
    using Otal.lmaoo.Core.Entities;
    using SqlKata;
    using SqlKata.Compilers;

    public class UserSeed : ISeed
    {
        public User DeveloperUser = new User
        {
            UserId = 1,
            Forename = "Developer User",
            Surname = "Integration",
            Username = "developer",
            Password = BCrypt.HashPassword("password"),
            Level = Core.Enums.UserRole.Developer,
            IsActive = true
        };

        public User ManagerUser = new User
        {
            UserId = 2,
            Forename = "Manager User",
            Surname = "Integration",
            Username = "manager",
            Password = BCrypt.HashPassword("password"),
            Level = Core.Enums.UserRole.Manager,
            IsActive = true
        };

        public User AdminUser = new User
        {
            UserId = 3,
            Forename = "Admin User",
            Surname = "Integration",
            Username = "admin",
            Password = BCrypt.HashPassword("password"),
            Level = Core.Enums.UserRole.Admin,
            IsActive = true
        };

        public User SuperAdminUser = new User
        {
            UserId = 4,
            Forename = "Super Admin User",
            Surname = "Integration",
            Username = "superadmin",
            Password = BCrypt.HashPassword("password"),
            Level = Core.Enums.UserRole.SuperAdmin,
            IsActive = true
        };

        public User DisabledUser = new User
        {
            UserId = 5,
            Forename = "Disabled User",
            Surname = "Integration",
            Username = "disabled",
            Password = BCrypt.HashPassword("password"),
            Level = Core.Enums.UserRole.Developer,
            IsActive = false
        };

        public string GetAllData()
        {
            var query = new Query("dbo.User")
                .AsInsert(new string[]
                {
                    "Forename", "Surname", "Username", "Password", "Level", "IsActive"
                },
                new[]
                {
                    new object[]
                    {
                        DeveloperUser.Forename,
                        DeveloperUser.Surname,
                        DeveloperUser.Username,
                        DeveloperUser.Password,
                        (int)DeveloperUser.Level,
                        DeveloperUser.IsActive ? 1 : 0
                    },
                    new object[]
                    {
                        ManagerUser.Forename,
                        ManagerUser.Surname,
                        ManagerUser.Username,
                        ManagerUser.Password,
                        (int)ManagerUser.Level,
                        ManagerUser.IsActive ? 1 : 0
                    },
                    new object[]
                    {
                        AdminUser.Forename,
                        AdminUser.Surname,
                        AdminUser.Username,
                        AdminUser.Password,
                        (int)AdminUser.Level,
                        AdminUser.IsActive ? 1 : 0
                    },
                    new object[]
                    {
                        SuperAdminUser.Forename,
                        SuperAdminUser.Surname,
                        SuperAdminUser.Username,
                        SuperAdminUser.Password,
                        (int)SuperAdminUser.Level,
                        SuperAdminUser.IsActive ? 1 : 0
                    },
                    new object[]
                    {
                        DisabledUser.Forename,
                        DisabledUser.Surname,
                        DisabledUser.Username,
                        DisabledUser.Password,
                        (int)DisabledUser.Level,
                        DisabledUser.IsActive ? 1 : 0
                    },
                });

            var compiler = new SqlServerCompiler();
            SqlResult result = compiler.Compile(query);

            return result.ToString();
        }
    }
}