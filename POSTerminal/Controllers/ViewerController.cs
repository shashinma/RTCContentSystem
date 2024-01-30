using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using POSTerminal.Data;
using POSTerminal.Models;
using Westwind.AspNetCore.Markdown.Utilities;

namespace POSTerminal.Controllers;

[Authorize]
public class ViewerController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ViewerController> _logger;

    public ViewerController(ILogger<ViewerController> logger)
    {
        _logger = logger;
    }

    [Authorize]
    public IActionResult Index([FromRoute(Name = "searchString")] string? searchString)
    {
        ViewBag.searchString = searchString;
        ViewBag.referer = Request.Headers["Referer"].ToString().Split('/').Last();

        string[] subs = searchString.Split('_');
        
        ViewBag.searchString = subs[0];
        ViewBag.searchStringDocumentId = null;
        
        if (subs.Length >= 2)
        {
            ViewBag.searchStringDocumentId = int.Parse(subs[1]);
        }
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}