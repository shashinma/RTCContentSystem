using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using POSTerminal.Data;
using POSTerminal.Models;

namespace POSTerminal.Services;

public interface INewsService
{
    IEnumerable<NewsItem> GetNews();
}

public class NewsService : INewsService
{
    private readonly ApplicationDbContext _context;

    public NewsService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<NewsItem> GetNews()
    {
        return _context.NewsItems.Include(n => n.Image).ToList();
    }
}