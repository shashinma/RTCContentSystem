namespace POSTerminal.Models;

public class InstructionItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? ImageUrl { get; set; }
    public int? ImageId { get; set; }
    public ImageModel? Image { get; set; }
    public int? DocumentId { get; set; }
    public DocumentModel? Document { get; set; }
    public string? LinkToPage { get; set; }
}