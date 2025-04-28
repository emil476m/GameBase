using infrastructur.Models.Dto;
using infrastructur.Models.Internal;

namespace infrastructur.Models.Mapper;

internal class ReviewMapper
{
    public ReviewEntity ToEntity(Review dto)
    {
        return new ReviewEntity
        {
            game_id = dto.GameId.ToString(),
            game_score = dto.GameScore,
            game_score_total = dto.TotalGameScore,
            total_reviews = dto.TotalReviews,
        };
    }

    public Review FromEntity(ReviewEntity entity)
    {
        return new Review
        {
            GameId = new Guid(entity.game_id),
            GameScore = entity.game_score,
            TotalGameScore = entity.game_score_total,
            TotalReviews = entity.total_reviews,
        };
    }
}