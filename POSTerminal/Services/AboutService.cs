using POSTerminal.Data;
using POSTerminal.Models;

namespace POSTerminal.Services;

public interface IAboutService
{
    List<AboutItem> getAbout();
    string getItem(int id);
}

public class AboutService : IAboutService
{
    private readonly ApplicationDbContext _context;

    public AboutService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<AboutItem> getAbout()
    {
        return _context.AboutItems.ToList();
    }
    
    public string getItem(int id)
    {
        var news = _context.AboutItems.Find(id);
        return news.Content;
    }
}