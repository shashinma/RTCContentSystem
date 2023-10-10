namespace POSTerminalWebApp.Models;

public class Department
{
    public int DepartmentID {get; set;}
    public string Title {get; set;}
    
    public virtual ICollection<Enrollment> Enrollment { get; set; }
}