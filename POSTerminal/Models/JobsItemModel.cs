﻿namespace POSTerminal.Models;

public class JobsItem
{
    public int Id { get; set; }
    
    public string Vacancy { get; set; }
    
    public string Requirements { get; set; }
    
    public string Responsibilities { get; set; }

    public string? PicSrc { get; set; }
    
    public int? ImageId { get; set; }
    
    public ImageModel? Image { get; set; }
}