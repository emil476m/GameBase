namespace infrastructur.Interfaces;

public interface IRepository<T>
{
    Task<T> GetScore(Guid gameId);
    Task<bool> AddScore(Guid gameId, int addition);

}