using Microsoft.AspNetCore.Identity;

namespace POSTerminalWebApp.Models;

public class User : IdentityUser
{
    public int Year { get; set;}
}