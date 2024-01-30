using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace PhoneEdit.Data;

public class SampleData
{
    private readonly DefaultUserOptions _options;

    public SampleData(IOptions<DefaultUserOptions> optionsAccessor)
    {
        _options = optionsAccessor.Value;
    }

    public static async Task CreateDefaultUser(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var optionsAccessor = serviceProvider.GetRequiredService<IOptions<DefaultUserOptions>>();
        var options = optionsAccessor.Value;

        var userCheck = await userManager.Users.AnyAsync();
        if (!userCheck)
        {
            var adminUser = new IdentityUser()
            {
                UserName = options.AdminUser.Username,
                Email = options.AdminUser.Username,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(adminUser, options.AdminUser.Password ?? throw new InvalidOperationException());

            var terminalUser = new IdentityUser()
            {
                UserName = options.TerminalUser.Username,
                Email = options.TerminalUser.Username,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(terminalUser, options.TerminalUser.Password ?? throw new InvalidOperationException());
        }
    }
}

public class DefaultUserOptions
{
    public User AdminUser { get; set; }
    public User TerminalUser { get; set; }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}