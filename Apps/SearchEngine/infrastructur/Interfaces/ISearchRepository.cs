namespace infrastructur.Interfaces;

public interface ISearchRepository<T, TF> where T : class where TF : class
{
    Task<IEnumerable<T>> QuerySearch(string query);
}