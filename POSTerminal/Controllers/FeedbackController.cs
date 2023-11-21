using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSTerminal.Data;
using POSTerminal.Models;

namespace POSTerminal.Controllers;

[Authorize]
public class FeedbackController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<FeedbackController> _logger;
    
    public FeedbackController(ApplicationDbContext context, ILogger<FeedbackController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [Authorize]
    public ActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(FeedbackItem model)
    {
        model.PublishDate = DateTime.Now;
        
        _context.FeedbackItems.Add(model);
        _context.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
    
    // // GET: NewsControllerAlt/Details/5
    // public ActionResult Details(int id)
    // {
    //     return View();
    // }
    //
    
    // public ActionResult Create()
    // {
    //     return View();
    // }
    
    // [HttpPost]
    // public IActionResult Create(NewsItem model)
    // {
    //         try
    //         {
    //             var newsItem = new NewsItem
    //             {
    //                 Title = model.Title,
    //                 Content = model.Content,
    //                 PicSrc = model.PicSrc,
    //                 PublishDate = DateTime.Now
    //             };
    //             
    //             _context.NewsItems.Add(newsItem);
    //             _context.SaveChanges();
    //         }
    //         catch (Exception ex)
    //         {
    //             Console.WriteLine(ex.Message);
    //         }
    //
    //         return RedirectToAction("Index");
    //     }
    
    // // POST: NewsControllerAlt/Edit/5
    // [HttpPost]
    // public IActionResult Edit(int id, IFormCollection collection)
    // {
    //     var news = _context.NewsItems.Find(id);
    //     return Json(news);
    // }
    
    
    // GET: NewsControllerAlt/Delete/5
    // public ActionResult Delete(int id)
    // {
    //     return View();
    // }
    
    // POST: NewsControllerAlt/Delete/id
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public ActionResult Delete(int id, IFormCollection collection)
    // {
    //     NewsItem news = _context.NewsItems.Find(id);
    //     if (news != null)
    //     {
    //         _context.NewsItems.Remove(news);
    //         _context.SaveChanges();
    //     }
    //
    //     return RedirectToAction("Index");
    // }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}