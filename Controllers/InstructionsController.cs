using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSTerminalWebApp.Models;

namespace POSTerminalWebApp.Controllers;

[Authorize]
public class InstructionsController : Controller
{
    private readonly ILogger<InstructionsController> _logger;

    public InstructionsController(ILogger<InstructionsController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    // public IActionResult Viewer(string searchString = "Phishing")
    public IActionResult Viewer([FromRoute(Name = "searchString")] string? searchString)
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