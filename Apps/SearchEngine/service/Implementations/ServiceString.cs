using infrastructur.Interfaces;
using Service.Interfaces;

namespace service.Implementations;

public class ServiceString : IService<string,string>
{
    private readonly ISearchRepository<string, string> _searchRepository;

    /**
     * Basse Interface for strings
     */
    public ServiceString(ISearchRepository<string, string> searchRepository)
    {
        _searchRepository = searchRepository;
    }
    
    public async Task<IEnumerable<string>> QuerySearch(string query)
    {
        return await _searchRepository.QuerySearch(query);
    }

    public Task<IEnumerable<string>> getGames()
    {
        throw new NotImplementedException();
    }

    public Task<string> getGame(Guid gameId)
    {
        throw new NotImplementedException();
    }
}