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
    
    // public IActionResult Create(string contentString)
    // {
    //     ViewBag.Content = contentString;
    //     return RedirectToAction("Index", "Home");
    // }

    // [HttpPost]
    // public IActionResult Create(AboutItem model)
    // {
    //     // Обработка полученного значения Markdown
    //     string markdownContent = model.Content;
    //     string htmlContent = Markdown.ToHtml(markdownContent);
    //     
    //     // Сохранение в базу данных
    //     model.Content = htmlContent;
    //     
    //     _context.AboutItems.Add(model);
    //     _context.SaveChanges();
    //     return RedirectToAction("Index", "Home");
    // }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}