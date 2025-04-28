namespace infrastruvtur.Models.Internals;

internal class GameEntity
{
    internal string game_id { get; set; }
    internal string game_name { get; set; }
    internal string game_description { get; set; }
    internal string? game_img_url { get; set; }
    internal string game_published_year { get; set; }
    internal float game_score { get; set; }
}