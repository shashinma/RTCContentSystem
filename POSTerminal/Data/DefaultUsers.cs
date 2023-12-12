using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace POSTerminal.Data;

public static class DefaultUsers
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        using var context = new IdentityContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<IdentityContext>>());

        // Seed the users.
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
    
        if (!context.Users.Any())
        {
            IdentityUser adminUser = new IdentityUser 
            { 
                UserName = configuration["ADMIN_USERNAME"], 
                Email = configuration["ADMIN_USERNAME"] 
            };
            
            IdentityUser terminalUser = new IdentityUser
            {
                UserName = configuration["TERMINAL_USERNAME"],
                Email = configuration["TERMINAL_USERNAME"]
            };

            await userManager.CreateAsync(adminUser, configuration["ADMIN_PASSWORD"]);
            await userManager.CreateAsync(terminalUser, configuration["TERMINAL_PASSWORD"]);
        }
    }
}