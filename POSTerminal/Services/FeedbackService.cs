using POSTerminal.Data;
using POSTerminal.Models;

namespace POSTerminal.Services;

public interface IFeedbackService
{
    IEnumerable<FeedbackItem> GetFeedbackItems();
}

public class FeedbackService : IFeedbackService
{
    private readonly ApplicationDbContext _context;

    public FeedbackService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<FeedbackItem> GetFeedbackItems()
    {
        return _context.FeedbackItems.ToList();
    }

}