using System.Diagnostics;
using Markdig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSTerminal.Data;
using POSTerminal.Models;

namespace POSTerminal.Controllers;

[Authorize]
public class AboutController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AboutController> _logger;
    
    public AboutController(ApplicationDbContext context, ILogger<AboutController> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public IActionResult Index()
    {
        var aboutItem = _context.AboutItems.FirstOrDefault(item => item.Id == 1); // получаем запись с id = 1
        ViewBag.Content = aboutItem.Content;
        
        return View();
    }
    
    [HttpPost]
    public IActionResult SaveContent(IFormCollection content)
    {
        var aboutItem = _context.AboutItems.FirstOrDefault(item => item.Id == 1); // попытка найти запись с id = 1
        if (aboutItem != null) // если запись найдена
        {
            aboutItem.Content = content["content"];
        } 
        else // Если запись не найдена...
        {
            aboutItem = new AboutItem // создаем новую запись 
            {
                Id = 1, // установка Id в 1
                Content = content["content"]
            };
            _context.AboutItems.Add(aboutItem); // добавляем запись в контекст DbContext
        }

        _context.SaveChanges(); // сохраняем изменения
        return RedirectToAction("Index", "About");
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}