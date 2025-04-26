using infrastructure.Models;

namespace service.Interfaces;

public interface IService
{
    Task<GameModel> CreateGame(GameCreateModelDto gamedto);
}