using infrastructur.Interfaces;
using Service.Interfaces;

namespace service.Implementations;

public class ServiceFloat : IService<float>
{
    private readonly IRepository<float> _repository;

    public ServiceFloat(IRepository<float> repository)
    {
        _repository = repository;
    }

    public async Task<float> GetScore(Guid gameId)
    {
        return await _repository.GetScore(gameId);
    }

    public async Task<float> AddScore(Guid gameId, int addition)
    {
        var succes =  await _repository.AddScore(gameId, addition);
        if (succes == false) throw new Exception("Could not update review");

        return await _repository.GetScore(gameId);
    }
}