namespace POSTerminalWebApp.Models;

public class MenuItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public List<SubMenuItem> SubMenuItems { get; set; }
}

public class SubMenuItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public int MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; }
}