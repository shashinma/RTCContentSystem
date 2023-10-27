using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSTerminalWebApp.Data;
using POSTerminalWebApp.Models;

namespace POSTerminalWebApp.Services;

public interface IAboutService
{
    List<AboutItem> getAbout();
}

public class AboutService : IAboutService
{
    private readonly ApplicationDbContext _context;

    public AboutService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<AboutItem> getAbout()
    {
        return _context.AboutItems.ToList();

    }
}