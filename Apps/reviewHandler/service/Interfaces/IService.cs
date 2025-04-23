namespace Service.Interfaces;

public interface IService<T>
{
    Task<T> GetScore(Guid gameId);
    Task<T> AddScore(Guid gameId, int addition);

}