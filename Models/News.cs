namespace POSTerminalWebApp.Models;

public class News
{
    public int ID { get; set; }
    public string Title {get; set; }
    public string Description {get; set; }
    public string Author {get; set; }
    public DateTime Created {get; set; }
    public DateTime Published {get; set; }
}