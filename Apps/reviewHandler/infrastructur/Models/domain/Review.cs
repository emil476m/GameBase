namespace infrastructur.Models.Dto;

public class Review
{
    public Guid GameId { get; set; }
    public float GameScore { get; set; }
    public int TotalGameScore { get; set; }
    public int TotalReviews { get; set; }
}