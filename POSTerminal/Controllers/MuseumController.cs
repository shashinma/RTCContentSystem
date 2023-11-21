using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSTerminal.Data;
using POSTerminal.Models;

namespace POSTerminal.Controllers;

[Authorize]
public class MuseumController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<MuseumController> _logger;

    public MuseumController(ApplicationDbContext context, ILogger<MuseumController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(MuseumItem model)
    {
        _context.MuseumItems.Add(model);
        _context.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
    
    [HttpPost]
    public IActionResult DeleteAllRecords(MuseumItem model)
    {
        // Получение DbSet, соответствующего таблице базы данных
        var records = _context.Set<ApplicationDbContext>();

        // Удаление всех записей
        records.RemoveRange(records);

        // Сохранение изменений в базе данных
        _context.SaveChanges();

        return Ok();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}