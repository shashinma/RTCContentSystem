using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSTerminal.Data;
using POSTerminal.Models;

namespace POSTerminal.Controllers;

[Authorize]
public class JobsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<JobsController> _logger;
    
    public JobsController(ApplicationDbContext context, ILogger<JobsController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(JobsItem model)
    {
        _context.JobsItems.Add(model);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    
    public JsonResult Delete(int id)
    {
        bool result = false;
        var jobs = _context.JobsItems.Find(id);

        if (jobs != null)
        {
            result = true;
            _context.JobsItems.Remove(jobs);
            _context.SaveChanges();
        }
        
        return Json(result);
    }
    
    public IActionResult GetJobs(int id)
    {
        var jobs = _context.JobsItems.Find(id);
        return Json(jobs);
    }
    
    [HttpPost]
    public IActionResult Update(JobsItem model)
    {
        var jobsFromDb = _context.JobsItems.Find(model.Id);
        jobsFromDb.Vacancy = model.Vacancy;
        jobsFromDb.Requirements = model.Requirements;
        jobsFromDb.Responsibilities = model.Responsibilities;
        jobsFromDb.PicSrc = model.PicSrc;
        
        _context.JobsItems.Update(jobsFromDb);
        _context.SaveChanges();
        
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}