using Microsoft.EntityFrameworkCore;
using POSTerminal.Data;
using POSTerminal.Models;

namespace POSTerminal.Services;

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