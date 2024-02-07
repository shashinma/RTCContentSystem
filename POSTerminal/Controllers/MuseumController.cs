using System.Diagnostics;
using Markdig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSTerminal.Data;
using POSTerminal.Models;

namespace POSTerminal.Controllers;

[Authorize]
public class MuseumController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AboutController> _logger;
    
    public MuseumController(ApplicationDbContext context, ILogger<AboutController> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public IActionResult Index()
    {
        var museumItem = _context.MuseumItems.FirstOrDefault(item => item.Id == 1); // получаем запись с id = 1
        ViewBag.Content = museumItem.Content;
        
        return View();
    }
    
    [HttpPost]
    public IActionResult SaveContent(IFormCollection content)
    {
        var museumItem = _context.MuseumItems.FirstOrDefault(item => item.Id == 1); // попытка найти запись с id = 1
        if (museumItem != null) // если запись найдена
        {
            museumItem.Content = content["content"];
        } 
        else // Если запись не найдена...
        {
            museumItem = new MuseumItem() // создаем новую запись 
            {
                Id = 1, // установка Id в 1
                Content = content["content"]
            };
            _context.MuseumItems.Add(museumItem); // добавляем запись в контекст DbContext
        }

        _context.SaveChanges(); // сохраняем изменения
        return RedirectToAction("Index", "Museum");
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}