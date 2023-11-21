using POSTerminal.Data;
using POSTerminal.Models;

namespace POSTerminal.Services;

public interface IMuseumService
{
    List<MuseumItem> getMuseumItems();
    string getItem(int id);
}

public class MuseumService : IMuseumService
{
    private readonly ApplicationDbContext _context;

    public MuseumService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<MuseumItem> getMuseumItems()
    {
        return _context.MuseumItems.ToList();
    }
    
    public string getItem(int id)
    {
        var news = _context.AboutItems.Find(id);
        return news.Content;
    }
}