using class_12.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

namespace class_12.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>> ();

            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));


            if(await userManager.FindByNameAsync("admin") == null)
            {
                var user = new ApplicationUser { UserName = "admin", Email = "admin@portfolio.com" };
                var result = await userManager.CreateAsync(user, "1234");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }    
            }
        }

    }
}
