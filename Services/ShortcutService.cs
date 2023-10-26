using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using POSTerminalWebApp.Data;
using POSTerminalWebApp.Models;

namespace POSTerminalWebApp.Services;

public interface IShortcutService
{
    List<ShortcutItems> GetShortcut();
}

public class ShortcutService : IShortcutService
{
    private readonly ApplicationDbContext _context;

    public ShortcutService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<ShortcutItems> GetShortcut()
    {
        return _context.ShortcutItems.ToList();
    }
}