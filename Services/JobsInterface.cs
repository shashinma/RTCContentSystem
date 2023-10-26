using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSTerminalWebApp.Data;
using POSTerminalWebApp.Models;

namespace POSTerminalWebApp.Services;

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
        return _context.JobsItems.ToList();

    }
}