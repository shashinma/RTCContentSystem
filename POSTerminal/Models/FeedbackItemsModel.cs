namespace POSTerminal.Models;

public class FeedbackItem
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string Message { get; set; }
    public string? Mail { get; set; }
    public string? Author { get; set; }
    public DateTime PublishDate { get; set; }
}