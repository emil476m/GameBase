using infrastruvtur.Models.externals;
using infrastruvtur.Models.Internals;

namespace infrastruvtur.Models.Mappers;

public class GameMapper
{
    internal GameDto FromEntity(GameEntity entity)
    {
        return new GameDto()
        {
            GameId = Guid.Parse(entity.game_id),
            GameName = entity.game_name,
            GameDescription = entity.game_description,
            GameImgUrl = entity.game_img_url,
            GamePublishedYear = entity.game_published_year,
            game_score = entity.game_score
        };
    }

    internal GameEntity ToEntity(GameDto dto)
    {
        return new GameEntity()
        {
            game_id = dto.GameId.ToString(),
            game_name = dto.GameName,
            game_description = dto.GameDescription,
            game_img_url = dto.GameImgUrl,
            game_published_year = dto.GamePublishedYear,
            game_score = dto.game_score
        };
    }
}