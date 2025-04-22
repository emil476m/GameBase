namespace Service.Interfaces;

public interface IService<T> where T : class
{
    Task<IEnumerable<T>> QuerySearch(string query);
}