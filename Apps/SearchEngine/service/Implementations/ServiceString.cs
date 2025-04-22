using infrastructur.Interfaces;
using Service.Interfaces;

namespace service.Implementations;

public class ServiceString : IService<string>
{
    private readonly ISearchRepository<string> _searchRepository;

    /**
     * Basse Interface for strings
     */
    public ServiceString(ISearchRepository<string> searchRepository)
    {
        _searchRepository = searchRepository;
    }
    
    public async Task<IEnumerable<string>> QuerySearch(string query)
    {
        return await _searchRepository.QuerySearch(query);
    }
}