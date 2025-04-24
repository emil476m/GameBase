using infrastruvtur.Models.externals;
using infrastruvtur.Models.Internals;

namespace infrastruvtur.Models.Mappers;

internal class SearchMapper
{
    internal SearchDto FromEntity(SearchEntity entity)
    {
        return new SearchDto
        {
            GameId = Guid.Parse(entity.game_id),
            GameName = entity.game_name,
        };
    }

    internal SearchEntity ToEntity(SearchDto dto)
    {
        return new SearchEntity
        {
            game_id = dto.GameId.ToString(),
            game_name = dto.GameName,
        };
    }
}