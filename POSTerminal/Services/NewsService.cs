using POSTerminal.Data;
using POSTerminal.Models;

namespace POSTerminal.Services;

public interface INewsService
{
    List<NewsItem> GetNews();
}

public class NewsService : INewsService
{
    private readonly ApplicationDbContext _context;

    public NewsService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<NewsItem> GetNews()
    {
        return _context.NewsItems.ToList();
    }

}