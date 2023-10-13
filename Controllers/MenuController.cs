using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSTerminalWebApp.Data;
using POSTerminalWebApp.Models;

namespace POSTerminalWebApp.Controllers;

public interface IMenuService
{
    List<MenuItem> GetMenu();
}

public class MenuService : IMenuService
{
    private readonly ApplicationDbContext _context;

    public MenuService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<MenuItem> GetMenu()
    {
        return _context.MenuItems
            .Include(m => m.SubMenuItems)
            .ToList();
    }
}