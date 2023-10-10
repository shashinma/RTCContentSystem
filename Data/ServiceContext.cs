using POSTerminalWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace POSTerminalWebApp.Data;

public class ServiceContext : DbContext
{
    public ServiceContext() : base()
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Department> Departments { get; set; }
} 