using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSTerminal.Data;
using POSTerminal.Models;
using POSTerminal.Services;

namespace POSTerminal.Controllers;

[Authorize]
public class JobsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<JobsController> _logger;
    
    private readonly IImageService _imageService;
    
    public JobsController(ApplicationDbContext context, ILogger<JobsController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    // TODO: Проверка на NULL
    [HttpPost]
    public IActionResult Create(JobsItem model, IFormFile image)
    {
        _context.JobsItems.Add(model);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(int id, JobsItem model, IFormFile image)
    {
        ImageModel? imageModel = null;
        var jobs = await _context.JobsItems.FindAsync(id);

        if (image != null)
        {
            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(image.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)image.Length);
            }

            imageModel = new ImageModel 
            {
                Image = imageData,
                Name = image.FileName
            };

            _context.ImageItems.Add(imageModel);
            await _context.SaveChangesAsync();
        
            // jobs.ImageId = imageModel.Id;
            // jobs.Image = imageModel;
            jobs.PicSrc = null;
        }
        else if (!string.IsNullOrEmpty(model.PicSrc))
        {
            var result = await _imageService.DownloadAndSaveImage(model.PicSrc);
    
            if (result)
            {
                imageModel = await _context.ImageItems.FirstOrDefaultAsync(i => i.Name == Path.GetFileName(model.PicSrc));
                
                // jobs.ImageId = imageModel.Id;
                // jobs.Image = imageModel;
                jobs.PicSrc = model.PicSrc;
            }
        }

        jobs.Vacancy = model.Vacancy;
        jobs.Responsibilities = model.Responsibilities;
        jobs.Requirements = model.Requirements;

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
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
    
    
    
    // public IActionResult Update(JobsItem model)
    // {
    //     var jobsFromDb = _context.JobsItems.Find(model.Id);
    //     jobsFromDb.Vacancy = model.Vacancy;
    //     jobsFromDb.Requirements = model.Requirements;
    //     jobsFromDb.Responsibilities = model.Responsibilities;
    //     jobsFromDb.PicSrc = model.PicSrc;
    //     
    //     _context.JobsItems.Update(jobsFromDb);
    //     _context.SaveChanges();
    //     
    //     return RedirectToAction("Index");
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}