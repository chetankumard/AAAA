using AspNetExtendingIdentityRoles.Models;
using System.Data.Entity.Migrations;

namespace AspNetExtendingIdentityRoles.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }


        protected override void Seed(ApplicationDbContext context)
        {
            this.AddUserAndRoles();
            this.AddMenu();
        }

        bool AddMenu()
        {
            bool success = false;

            return success;
        }


        bool AddUserAndRoles()
        {
            bool success = false;

            var idManager = new IdentityManager();
            success = idManager.CreateRole("Admin", "Global Access");
            if (!success == true) return success;

            success = idManager.CreateRole("CanEdit", "Edit existing records");
            if (!success == true) return success;

            success = idManager.CreateRole("User", "Restricted to business domain activity");
            if (!success) return success;


            var newUser = new ApplicationUser()
            {
                UserName = "jatten",
                FirstName = "John",
                LastName = "Atten",
                Email = "jatten@typecastexception.com"
            };

            // Be careful here - you  will need to use a password which will 
            // be valid under the password rules for the application, 
            // or the process will abort:
            success = idManager.CreateUser(newUser, "Password1");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "Admin");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "CanEdit");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "User");
            if (!success) return success;

            return success;
        }
    }
}
