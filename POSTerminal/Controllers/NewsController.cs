using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using POSTerminal.Data;
using POSTerminal.Models;
using POSTerminal.Services;

namespace POSTerminal.Controllers;

[Authorize]
public class NewsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<NewsController> _logger;
    
    private readonly IImageService _imageService;
    
    public NewsController(ApplicationDbContext context, ILogger<NewsController> logger, IImageService imageService)
    {
        _context = context;
        _logger = logger;
        _imageService = imageService;
    }

    [Authorize]
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult GetNews(int id)
    {
        var news = _context.NewsItems.Find(id);
        return Json(news);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateNews(NewsItem model, IFormFile image)
    {
        ImageModel imageModel = null;

        if (image != null)
        {
            byte[] imageData = null;

            // считываем переданный файл в массив байт
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
        }
        else if (!string.IsNullOrEmpty(model.PicSrc))
        {
            // If image file was not provided, but URL for image (PicSrc) is present, use the ImageService to download and save the image
            var result = await _imageService.DownloadAndSaveImage(model.PicSrc);

            if (result)
            {
                // If image is downloaded and saved successfuly, retrieve the ImageModel that we just saved
                imageModel = await _context.ImageItems.FirstOrDefaultAsync(i => i.Name == Path.GetFileName(model.PicSrc));
            }
        }

        var news = new NewsItem()
        {
            PublishDate = DateTime.Now,
            Title = model.Title,
            PicSrc = model.PicSrc,
            Content = model.Content
        };
    
        if (imageModel != null)
        {
            news.ImageId = imageModel.Id;
            news.Image = imageModel;
        }

        _context.NewsItems.Add(news);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
    
    [HttpPost]
    public async Task<IActionResult> EditNews(int id, NewsItem model, IFormFile image)
    {
        ImageModel imageModel = null;
        var news = await _context.NewsItems.FindAsync(id);

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
        
            news.ImageId = imageModel.Id;
            news.Image = imageModel;
            news.PicSrc = null;
        }
        else if (!string.IsNullOrEmpty(model.PicSrc))
        {
            var result = await _imageService.DownloadAndSaveImage(model.PicSrc);
    
            if (result)
            {
                imageModel = await _context.ImageItems.FirstOrDefaultAsync(i => i.Name == Path.GetFileName(model.PicSrc));
                news.ImageId = imageModel.Id;
                news.Image = imageModel;
    
                news.PicSrc = model.PicSrc;
            }
        }

        news.Title = model.Title;
        news.Content = model.Content;

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }    
    // TODO: Добавить вывод актуальных значений в базу данных
    // [HttpPost]
    // public async Task<IActionResult> EditNews(int id, NewsItem model, IFormFile image)
    // {
    //     var news = await _context.NewsItems.FindAsync(id);
    //     
    //     ImageModel imageModel = null;
    //     if (image != null)
    //     {
    //         byte[] imageData = null;
    //         using (var binaryReader = new BinaryReader(image.OpenReadStream()))
    //         {
    //             imageData = binaryReader.ReadBytes((int)image.Length);
    //         }
    //
    //         // Create new image model to replace the old one
    //         imageModel = new ImageModel 
    //         {
    //             Image = imageData,
    //             Name = image.FileName
    //         };
    //
    //         _context.ImageItems.Add(imageModel);
    //         await _context.SaveChangesAsync();
    //     }
    //     else if (!string.IsNullOrEmpty(model.PicSrc))
    //     {
    //         // Use ImageService to download and save image
    //         var result = await _imageService.DownloadAndSaveImage(model.PicSrc);
    //
    //         if (result)
    //         {
    //             imageModel = await _context.ImageItems.FirstOrDefaultAsync(i => i.Name == Path.GetFileName(model.PicSrc));
    //         }
    //     }
    //
    //     // Update fields
    //     news.Title = model.Title;
    //     news.Content = model.Content;
    //     if (!model.PicSrc.IsNullOrEmpty())
    //     {
    //         news.PicSrc = model.PicSrc;
    //     }
    //
    //     if (imageModel != null)
    //     {
    //         news.ImageId = imageModel.Id;
    //         news.Image = imageModel;
    //     }
    //
    //     await _context.SaveChangesAsync();
    //
    //     return RedirectToAction(nameof(Index));
    // }

    public JsonResult Delete(int id)
    {
        bool result = false;
        var news = _context.NewsItems.Find(id);

        if (news != null)
        {
            result = true;
            _context.NewsItems.Remove(news);
            _context.SaveChanges();
        }
        
        return Json(result);
    }
    
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}