using Microsoft.EntityFrameworkCore;
using POSTerminal.Data;
using POSTerminal.Models;

namespace POSTerminal.Services;

public interface IJobsService
{
    List<JobsItem> getJobs();
}

public class JobsService : IJobsService
{
    private readonly ApplicationDbContext _context;

    public JobsService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<JobsItem> getJobs()
    {
        return _context.JobsItems.Include(n => n.Image).ToList();
    }
}