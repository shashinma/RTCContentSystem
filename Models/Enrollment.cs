namespace POSTerminalWebApp.Models;

public class Enrollment
{
    public int EnrollmentId { get; set; } 
    public int DepartmentID { get; set; } // Подразделение
    public int UserId { get; set; } // GUID
    
    public virtual Department Department { get; set; }
    public virtual User User { get; set; }
}