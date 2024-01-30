namespace POSTerminal.Models;

public class ViewerItem
{
    public int Id { get; set; }

    public string? name { get; set; }
    
    public int? DocumentId { get; set; }
    
    public DocumentModel? Document { get; set; }
}