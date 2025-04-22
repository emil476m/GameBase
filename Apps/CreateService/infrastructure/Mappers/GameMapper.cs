using infrastructure.Models;

namespace infrastructure.Mappers;

public static class GameMapper
{
    public static GameDbModel ToDbModel(this GameModel model)
    {
        return new GameDbModel
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            ImgUrl = model.ImgUrl
        };
    }

    public static GameModel ToModel(this GameDbModel model)
    {
        return new GameModel
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            ImgUrl = model.ImgUrl
        };
    }
}