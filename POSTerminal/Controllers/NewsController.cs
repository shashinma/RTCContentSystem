using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSTerminal.Data;
using POSTerminal.Models;

namespace POSTerminal.Controllers;

[Authorize]
public class NewsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<NewsController> _logger;
    
    public NewsController(ApplicationDbContext context, ILogger<NewsController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [Authorize]
    public ActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    // // GET: NewsControllerAlt/Details/5
    // public ActionResult Details(int id)
    // {
    //     return View();
    // }
    //
    
    public ActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(NewsItem model)
    {
            try
            {
                var newsItem = new NewsItem
                {
                    Title = model.Title,
                    Content = model.Content,
                    PicSrc = model.PicSrc,
                    PublishDate = DateTime.Now
                };
                _context.NewsItems.Add(newsItem);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Index");
        }
    
    //
    // // GET: NewsControllerAlt/Edit/5
    // public ActionResult Edit(int id)
    // {
    //     return View();
    // }
    //
    // // POST: NewsControllerAlt/Edit/5
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public ActionResult Edit(int id, IFormCollection collection)
    // {
    //     try
    //     {
    //         // TODO: Add update logic here
    //
    //         return RedirectToAction(nameof(Index));
    //     }
    //     catch
    //     {
    //         return View();
    //     }
    // }
    //
    // // GET: NewsControllerAlt/Delete/5
    // public ActionResult Delete(int id)
    // {
    //     return View();
    // }
    //
    // // POST: NewsControllerAlt/Delete/5
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public ActionResult Delete(int id, IFormCollection collection)
    // {
    //     try
    //     {
    //         // TODO: Add delete logic here
    //
    //         return RedirectToAction(nameof(Index));
    //     }
    //     catch
    //     {
    //         return View();
    //     }
    // }
}