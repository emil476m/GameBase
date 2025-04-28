using infrastructur.Interfaces;
using infrastruvtur.Models.externals;
using Service.Interfaces;

namespace service.Implementations;

public class ServiceSearchDto:IService<SearchDto, GameDto>
{
    private readonly ISearchRepository<SearchDto, GameDto> _searchRepository;

    /**
     * Basse Interface for strings
     */
    public ServiceSearchDto(ISearchRepository<SearchDto, GameDto> searchRepository)
    {
        _searchRepository = searchRepository;
    }
    
    public async Task<IEnumerable<SearchDto>> QuerySearch(string query)
    {
        return await _searchRepository.QuerySearch(query);
    }

    public async Task<IEnumerable<GameDto>> getGames(int page)
    {
        if (page <= 0)
        {
            return await _searchRepository.getGames();
        }

        int offset = (page * 10)-10;
        return await _searchRepository.getGamesPage(offset);
    }

    public async Task<GameDto> getGame(Guid gameId)
    {
        return await _searchRepository.getGame(gameId);
    }
}