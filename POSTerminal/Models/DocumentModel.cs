namespace POSTerminal.Models;

public class DocumentModel
{
    public int Id { get; set; }
    public byte[]? Document { get; set; }
    public string Name { get; set; }
}