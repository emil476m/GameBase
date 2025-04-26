using infrastructure.Interfaces;
using infrastructure.Models;
using service.Interfaces;

namespace service.Implementations;

public class CreateService : IService
{
    private readonly IRepository _repository;

    public CreateService(IRepository repository)
    {
        _repository = repository;
    }
    
    public Task<GameModel> CreateGame(GameModel game)
    {
        game.Id = CreateGuid().Result;
        return _repository.CreateGame(game);
    }

    private async Task<Guid> CreateGuid()
    {
        int limiter = 0;
        while (limiter < 5)
        {
            limiter++;
            var guid = Guid.NewGuid();
            if (!await _repository.CheckIfGuidExists(guid))
            {
                return guid;
            }
        }
        
        throw new Exception("Error Occurred try again latter");
    }
}