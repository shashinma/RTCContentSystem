using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSTerminal.Data;
using POSTerminal.Models;
using POSTerminal.Services;

namespace POSTerminal.Controllers;

[Authorize]
public class InstructionsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<InstructionsController> _logger;
    
    private readonly IImageService _imageService;
    
    public InstructionsController(ApplicationDbContext context, ILogger<InstructionsController> logger, IImageService imageService)
    {
        _context = context;
        _logger = logger;
        _imageService = imageService;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(InstructionItem model, IFormFile image, IFormFile document)
    {
        ImageModel? imageModel = null;
        DocumentModel? documentModel = null;

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
        else if (!string.IsNullOrEmpty(model.ImageUrl))
        {
            // If image file was not provided, but URL for image (PicSrc) is present, use the ImageService to download and save the image
            var result = await _imageService.DownloadAndSaveImage(model.ImageUrl);

            if (result)
            {
                // If image is downloaded and saved successfuly, retrieve the ImageModel that we just saved
                imageModel = await _context.ImageItems.FirstOrDefaultAsync(i => i.Name == Path.GetFileName(model.ImageUrl));
            }
        }
        
        if (document != null)
        {
            byte[] documentData = null;

            // считываем переданный файл в массив байт
            using (var binaryReader = new BinaryReader(document.OpenReadStream()))
            {
                documentData = binaryReader.ReadBytes((int)document.Length);
            }

            documentModel = new DocumentModel() 
            {
                Document = documentData,
                Name = document.FileName
            };

            _context.DocumentItems.Add(documentModel);
            await _context.SaveChangesAsync();
        }
        
        var instruction = new InstructionItem()
        {
            Title = model.Title,
            ImageUrl = model.ImageUrl,
        };
    
        if (imageModel != null)
        {
            instruction.ImageId = imageModel.Id;
            instruction.Image = imageModel;
        }

        if (documentModel != null)
        {
            instruction.DocumentId = documentModel.Id;
            instruction.Document = documentModel;
            instruction.LinkToPage = Path.GetFileNameWithoutExtension(documentModel.Name);
        }

        _context.InstructionItems.Add(instruction);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(int id, InstructionItem model, IFormFile image, IFormFile document)
    {
        ImageModel? imageModel = null;
        DocumentModel? documentModel = null;
        var instructions = await _context.InstructionItems.FindAsync(id);

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

            instructions.ImageId = imageModel.Id;
            instructions.Image = imageModel;
            instructions.ImageUrl = null;
        }
        else if (!string.IsNullOrEmpty(model.ImageUrl))
        {
            var result = await _imageService.DownloadAndSaveImage(model.ImageUrl);

            if (result)
            {
                imageModel = await _context.ImageItems.FirstOrDefaultAsync(i => i.Name == Path.GetFileName(model.ImageUrl));
                
                instructions.ImageId = imageModel.Id;
                instructions.Image = imageModel;
                instructions.ImageUrl = model.ImageUrl;
            }
        }
        
        if (document != null)
        {
            byte[] documentData = null;

            // считываем переданный файл в массив байт
            using (var binaryReader = new BinaryReader(document.OpenReadStream()))
            {
                documentData = binaryReader.ReadBytes((int)document.Length);
            }

            documentModel = new DocumentModel() 
            {
                Document = documentData,
                Name = document.FileName
            };

            _context.DocumentItems.Add(documentModel);
            await _context.SaveChangesAsync();

            instructions.DocumentId = documentModel.Id;
            instructions.Document = documentModel;
        }

        instructions.Title = model.Title;

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
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
        var instruction = _context.InstructionItems.Find(id);
        return Json(instruction);
    }

    // public IActionResult GetInstructions(int id)
    // {
    //     var news = _context.InstructionItems.Find(id);
    //     return Json(news);
    // }
    
    // [HttpPost]
    // public IActionResult Update(InstructionItem model)
    // {
    //     var InstructionFromDb = _context.InstructionItems.Find(model.Id);
    //     InstructionFromDb.Title = model.Title;
    //     InstructionFromDb.ImageUrl = model.ImageUrl;
    //     
    //     _context.InstructionItems.Update(InstructionFromDb);
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