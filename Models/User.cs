using Microsoft.AspNetCore.Identity;

namespace POSTerminalWebApp.Models;

public class User : IdentityUser
{
    public int ID { get; set; } // GUID
    public string LastName { get; set; } // Фамилия
    public string FirstName { get; set; } // Имя
    public string MiddleName { get; set; } // Отчество
    public DateTime Created { get; set; } // Дата создания аккаунта
    public DateTime LastActivity { get; set; } // Время последней активности
}