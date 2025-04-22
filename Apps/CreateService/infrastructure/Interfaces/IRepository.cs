using infrastructure.Models;

namespace infrastructure.Interfaces;

public interface IRepository
{
    Task<GameModel> CreateGame(GameModel game);
    
    Task<bool> CheckIfGuidExists(Guid guid);
}