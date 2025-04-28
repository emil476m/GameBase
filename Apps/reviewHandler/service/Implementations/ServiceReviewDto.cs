using infrastructur.Interfaces;
using infrastructur.Models.Dto;
using Service.Interfaces;

namespace service.Implementations;

public class ServiceReviewDto : IService<Review>
{
    private readonly IRepository<Review> _repository;

    public ServiceReviewDto(IRepository<Review> repository)
    {
        _repository = repository;
    }

    public async Task<Review> GetScore(Guid gameId)
    {
        return await _repository.GetScore(gameId);
    }

    public async Task<Review> AddScore(Guid gameId, int addition)
    {
        var succes =  await _repository.AddScore(gameId, addition);
        if (succes == false) throw new Exception("Could not update review");

        return await _repository.GetScore(gameId);
    }
}