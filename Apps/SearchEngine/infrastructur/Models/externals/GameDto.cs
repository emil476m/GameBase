namespace infrastruvtur.Models.externals;

public class GameDto
{
    public Guid GameId { get; set; }
    public string GameName { get; set; }
    public string GameDescription { get; set; }
    public string? GameImgUrl { get; set; }
    public string GamePublishedYear { get; set; }
}