using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace POSTerminal.Data;

public class SampleData
{
    private static IConfiguration _configuration;

    public SampleData(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    // Creates default app's admin
    public static async Task CreateDefaultUser(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        
        var defaultAdminUsername = configuration.GetValue<string>("ADMIN_USERNAME");
        var defaultAdminPassword = configuration.GetValue<string>("ADMIN_PASSWORD");
        var defaultTerminalUsername = configuration.GetValue<string>("TERMINAL_USERNAME");
        var defaultTerminalPassword = configuration.GetValue<string>("TERMINAL_PASSWORD");

        var userCheck = await userManager.Users.AnyAsync();
        if (!userCheck)
        {
            var adminUser = new IdentityUser()
            {
                UserName = Environment.GetEnvironmentVariable("ADMIN_USERNAME") ?? defaultAdminUsername,
                Email = Environment.GetEnvironmentVariable("ADMIN_USERNAME") ?? defaultAdminUsername,
                EmailConfirmed = true
            };         
            
            await userManager.CreateAsync(adminUser, (Environment.GetEnvironmentVariable("ADMIN_PASSWORD") ?? defaultAdminPassword) ?? throw new InvalidOperationException());

            var terminalUser = new IdentityUser()
            {
                UserName = Environment.GetEnvironmentVariable("TERMINAL_USERNAME") ?? defaultTerminalUsername,
                Email = Environment.GetEnvironmentVariable("TERMINAL_USERNAME") ?? defaultTerminalUsername,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(terminalUser, (Environment.GetEnvironmentVariable("TERMINAL_PASSWORD") ?? defaultTerminalPassword) ?? throw new InvalidOperationException());
        }
    }
}