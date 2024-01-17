using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POSTerminal.Data;
using POSTerminal.Models;

namespace POSTerminal.Services;

public interface IImageService
{
    Task<bool> DownloadAndSaveImage(string imageUrl);
}

public class ImageService : IImageService
{
    private readonly ApplicationDbContext _context;
    private readonly HttpClient _httpClient;

    public ImageService(ApplicationDbContext context)
    {
        _context = context;
        _httpClient = new HttpClient();
    }

    public async Task<bool> DownloadAndSaveImage(string imageUrl)
    {
        byte[] imageBytes;

        try
        {
            imageBytes = await _httpClient.GetByteArrayAsync(imageUrl);
        }
        catch (Exception ex)
        {
            // Log the exception here
            return false;
        }

        var imageModel = new ImageModel
        {
            Image = imageBytes,
            Name = Path.GetFileName(imageUrl)
        };

        _context.ImageItems.Add(imageModel);
        await _context.SaveChangesAsync();
        
        return true;
    }
}