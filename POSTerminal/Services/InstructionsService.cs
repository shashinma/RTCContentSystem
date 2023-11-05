using POSTerminal.Data;
using POSTerminal.Models;

namespace POSTerminal.Services;

public interface IInstructionsService
{
    List<InstructionItem> GetInstructions();
}

public class InstructionsService : IInstructionsService
{
    private readonly ApplicationDbContext _context;

    public InstructionsService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<InstructionItem> GetInstructions()
    {
        return _context.InstructionItems.ToList();
    }
}