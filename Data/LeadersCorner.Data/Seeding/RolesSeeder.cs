namespace LeadersCorner.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using LeadersCorner.Common;
    using LeadersCorner.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    internal class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(LeadersCornerDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
          await SeedRoleAsync(roleManager, GlobalConstants.AdministratorRoleName);

            if (!dbContext.UserRoles.Any())
            {
                const string adminEmail = "admin@lc.com";
                const string adminPassword = "admin55";

                var user = new ApplicationUser
                {
                    Email = adminEmail,
                    UserName = adminEmail,
                    UserFirstName = "Admin",
                };
                await userManager.CreateAsync(user, adminPassword);
                await userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
            }
        }

        private static async Task SeedRoleAsync(RoleManager<ApplicationRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var result = await roleManager.CreateAsync(new ApplicationRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
