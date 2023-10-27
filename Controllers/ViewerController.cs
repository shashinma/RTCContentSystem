using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSTerminalWebApp.Data;
using POSTerminalWebApp.Models;

namespace POSTerminalWebApp.Controllers;

[Authorize]
public class ViewerController : Controller
{
    private readonly ILogger<ViewerController> _logger;
    private readonly ApplicationDbContext _context;

    public ViewerController(ILogger<ViewerController> logger)
    {
        _logger = logger;
    }
    
    [Authorize]
    public IActionResult Index([FromRoute(Name = "searchString")] string? searchString)
    {
        if (searchString == null) return RedirectToAction("Index");
        
        var layoutModel = new MenuItem();
        var pageModel = new ViewerItem()
        {
            name = searchString
        };
    
        var viewerModel = new ViewerModel()
        {
            Layout = layoutModel,
            Page = pageModel
        };
    
        return View(viewerModel);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}