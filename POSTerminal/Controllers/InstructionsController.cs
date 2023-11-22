using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSTerminal.Data;
using POSTerminal.Models;

namespace POSTerminal.Controllers;

[Authorize]
public class InstructionsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<InstructionsController> _logger;
    
    public InstructionsController(ApplicationDbContext context, ILogger<InstructionsController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(InstructionItem model)
    {
        _context.InstructionItems.Add(model);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    
    public JsonResult Delete(int id)
    {
        bool result = false;
        var instructions = _context.InstructionItems.Find(id);

        if (instructions != null)
        {
            result = true;
            _context.InstructionItems.Remove(instructions);
            _context.SaveChanges();
        }
        
        return Json(result);
    }
    
    public IActionResult GetInstructions(int id)
    {
        var news = _context.InstructionItems.Find(id);
        return Json(news);
    }
    
    [HttpPost]
    public IActionResult Update(InstructionItem model)
    {
        var InstructionFromDb = _context.InstructionItems.Find(model.Id);
        InstructionFromDb.Title = model.Title;
        InstructionFromDb.ImageUrl = model.ImageUrl;
        
        _context.InstructionItems.Update(InstructionFromDb);
        _context.SaveChanges();
        
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}