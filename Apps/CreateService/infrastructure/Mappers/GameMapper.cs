using infrastructure.Models;

namespace infrastructure.Mappers;

public static class GameMapper
{
    public static GameDbModel ToDbModel(this GameModel model)
    {
        return new GameDbModel
        {
            Id = model.Id.ToString(),
            Name = model.Name,
            Description = model.Description,
            ImgUrl = model.ImgUrl,
            PublishedYear = model.PublishedYear
        };
    }

    public static GameModel ToModel(this GameDbModel model)
    {
        return new GameModel
        {
            Id = Guid.Parse(model.Id),
            Name = model.Name,
            Description = model.Description,
            ImgUrl = model.ImgUrl,
            PublishedYear = model.PublishedYear
        };
    }
}