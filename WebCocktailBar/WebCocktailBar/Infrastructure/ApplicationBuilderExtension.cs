using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebCocktailBar.Data;
using WebCocktailBar.Domain;

namespace WebCocktailBar.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var services = serviceScope.ServiceProvider;

            await RoleSeeder(services);
            await SeedAdministrator(services);

            var dataCategory = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedCategories(dataCategory);

            var dataTaste = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedTastes(dataTaste);
            return app;
        }
        private static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Administrator", "Client" };

            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);

                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }    
            }
        }
        private static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            if (await userManager.FindByNameAsync("admin") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "admin";
                user.LastName = "admin";
                user.PhoneNumber = "0888888888";
                user.UserName = "admin";
                user.Email = "admin@admin.com";

                var result = await userManager.CreateAsync(user, "admin123");
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }
        private  static void SeedCategories(ApplicationDbContext dataCategory)
        {
            if (dataCategory.Categories.Any())
            {
                return;
            }
            dataCategory.Categories.AddRange(new[]
            {
                new Category {CategoryName ="Non-Alchoholic"},
                new Category {CategoryName ="Vodka"},
                new Category {CategoryName ="Whiskey"},
                new Category {CategoryName ="Gin"},
                new Category {CategoryName ="White Rum"},
                new Category {CategoryName ="Dark Rum"},
                new Category {CategoryName ="Liqueurs"},
                new Category {CategoryName ="vermouths"},
                new Category{CategoryName ="Wines"},
                new Category{CategoryName ="Aniseed"}
                
            });
            dataCategory.SaveChanges();
        }
        private static void SeedTastes(ApplicationDbContext dataTaste)
        {
            if (dataTaste.Tastes.Any())
            {
                return ;
            }
            dataTaste.Tastes.AddRange(new[]
            {
                new Taste{TasteName ="Sweet"},
                new Taste{TasteName ="Sour"},
                new Taste{TasteName="Sweet & Sour"},
                new Taste{TasteName ="Salty"},
                new Taste{TasteName ="Bitter"},
            });
            dataTaste.SaveChanges();
        }

    }
}
