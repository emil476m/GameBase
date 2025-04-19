namespace Service.Interfaces;

public interface IService<T, TF> where T : class where TF : class
{
    Task<IEnumerable<T>> QuerySearch(string query);
}