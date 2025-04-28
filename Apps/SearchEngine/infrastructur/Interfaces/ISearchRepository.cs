namespace infrastructur.Interfaces;

public interface ISearchRepository<T, TF> where T : class where TF : class
{
    Task<IEnumerable<T>> QuerySearch(string query);
    Task<IEnumerable<TF>> getGames();
    Task<IEnumerable<TF>> getGamesPage(int offset);
    Task<TF> getGame(Guid gameId);
}