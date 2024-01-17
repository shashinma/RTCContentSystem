using System;

namespace POSTerminal.Models;

public class NewsItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string? PicSrc { get; set; }
    public string? Author { get; set; }
    public string? Tags { get; set; }
    public string? TimeToRead { get; set; }
    public int? ImageId { get; set; }
    public ImageModel? Image { get; set; }
    public DateTime PublishDate { get; set; }

}
