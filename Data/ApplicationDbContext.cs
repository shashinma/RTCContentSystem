using Microsoft.EntityFrameworkCore;
using POSTerminalWebApp.Models;

namespace POSTerminalWebApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<SubMenuItem> SubMenuItems { get; set; }
    public DbSet<NewsItem> NewsItems { get; set; }
    public DbSet<JobsItem> JobsItems { get; set; }
    public DbSet<AboutItem> AboutItems { get; set; }
    public DbSet<ShortcutItems> ShortcutItems { get; set; }
    public DbSet<InstructionItem> InstructionItems { get; set; }
}