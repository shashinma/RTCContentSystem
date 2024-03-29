using Microsoft.EntityFrameworkCore;
using POSTerminal.Data;
using POSTerminal.Models;

namespace POSTerminal.Services;

public interface IViewerSevice
{
    List<InstructionItem> GetInstructions();
}

public class ViewerSevice : IViewerSevice
{
    private readonly ApplicationDbContext _context;

    public ViewerSevice(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<InstructionItem> GetInstructions()
    {
        return _context.InstructionItems
            .Include(n => n.Image)
            .Include(n => n.Document)
            .ToList();
    }
}