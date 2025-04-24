namespace infrastructur.Interfaces;

public interface ISearchRepository<T, TF> where T : class where TF : class
{
    Task<IEnumerable<T>> QuerySearch(string query);
    Task<IEnumerable<TF>> getGames();
    Task<TF> getGame(Guid gameId);
}