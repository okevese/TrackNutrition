using System;
using System.Threading.Tasks;
using TrackNutrition.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TrackNutrition
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var roleManager = services
                .GetRequiredService<roleManager<IdentityRole>>();
            await EnsureRolesAsync(roleManager);

            var userManager = services
                .GetRequiredService<userManager<ApplicationUser>>();
            await EnsureTestAdminAsync(userManager);
        }

        private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var alreadyExists = await roleManager
                .RoleExistsAsync(Constants.AdministratorRole);
            if (alreadyExists) return;

            await roleManager.CreateAsync(new IdentityRole(Constants.AdministratorRole));
        }

        private static async Task EnsureTestAdminAsync(UserManager<ApplicationUser> userManager)
        {
            var testAdmin = await userManager.Users
                .Where(x => x.UserName == "admin@tracknutrio.local")
                .SingleOrDefaultAsync();
            
            if (testAdmin != null) return;

            testAdmin = new ApplicationUser
            {
                UserName = "admin@tracknutrio.local",
                EnvironmentVariableTarget = "admin@tracknutrio.local"
            };
            await userManager.CreateAsync(testAdmin, "Badbad123!");
            await userManager.AddToRoleAsync(testAdmin, Constants.AdministratorRole);
        }
    }
}