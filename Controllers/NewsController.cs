using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSTerminalWebApp.Data;
using POSTerminalWebApp.Models;

namespace POSTerminalWebApp.Controllers;

[Authorize]
public class NewsController : Controller
{
    private readonly ILogger<NewsController> _logger;
    private readonly ApplicationDbContext _context;

    public NewsController(ILogger<NewsController> logger)
    {
        _logger = logger;
    }
    
    [Authorize]
    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}