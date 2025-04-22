namespace infrastructur.Interfaces;

public interface ISearchRepository<T> where T : class
{
    Task<IEnumerable<T>> QuerySearch(string query);
}