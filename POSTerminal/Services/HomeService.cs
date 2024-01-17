using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using POSTerminal.Data;
using POSTerminal.Models;

namespace POSTerminal.Services;

public interface IHomeService
{
    IEnumerable<NewsItem> GetNews();
}

public class HomeService : IHomeService
{
    private readonly ApplicationDbContext _context;

    public HomeService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<NewsItem> GetNews()
    {
        return _context.NewsItems.Include(n => n.Image).ToList();
    }
}