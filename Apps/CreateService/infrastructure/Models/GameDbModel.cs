using System.ComponentModel.DataAnnotations;

namespace infrastructure.Models;

public class GameDbModel
{
    [MaxLength(36)]
    public string Id { get; set; }
    
    [MaxLength(250)]
    public string Name { get; set; }
    
    [MaxLength(2400)]
    public string Description { get; set; }
    
    [MaxLength(2048)]
    public string ImgUrl { get; set; }
    
    [MaxLength(6)]
    public string PublishedYear { get; set; }
}