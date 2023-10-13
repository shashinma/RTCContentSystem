using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using POSTerminalWebApp.Models;

namespace POSTerminalWebApp.Controllers;

public class InstructionsController : Controller
{
    private readonly ILogger<InstructionsController> _logger;

    public InstructionsController(ILogger<InstructionsController> logger)
    {
        _logger = logger;
    }

    public IActionResult Instructions()
    {
        return View();
    }
    
    public IActionResult Viewer()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}