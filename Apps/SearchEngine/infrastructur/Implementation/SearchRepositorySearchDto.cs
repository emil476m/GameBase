using Dapper;
using infrastructur.Interfaces;
using infrastruvtur.Models.externals;
using infrastruvtur.Models.Internals;
using infrastruvtur.Models.Mappers;
using Npgsql;

namespace infrastruvtur.Implementation;

public class SearchRepositorySearchDto : ISearchRepository<SearchDto, GameDto>
{
    private NpgsqlDataSource _dataSource;
    private SearchMapper _searchMapper;
    private GameMapper _gameMapper;
    public SearchRepositorySearchDto(NpgsqlDataSource dataSource)
    {
        _searchMapper = new SearchMapper();
        _gameMapper = new GameMapper();
        _dataSource = dataSource;
    }
    
    public async Task<IEnumerable<SearchDto>> QuerySearch(string searchQuery)
    {
        var sql = $@"
                SELECT DISTINCT game_id, game_name FROM Game WHERE game_name ILIKE @query;
                ";

        using var conn = _dataSource.OpenConnection();
        
        var list = await conn.QueryAsync<SearchEntity>(sql, new {
            query = @$"%{searchQuery.Trim()}%"
        });

        return list.Select(entity => _searchMapper.FromEntity(entity));
    }

    public async Task<IEnumerable<GameDto>> getGames()
    {
        var sql = $@"
                SELECT game_id, game_name, game_description, game_img_url, game_published_year FROM Game;
                ";
        
        using var conn = _dataSource.OpenConnection();
        
        var list = await conn.QueryAsync<GameEntity>(sql);

        return list.Select(entity => _gameMapper.FromEntity(entity)); //Maps entity element in list to DocumentSimple
        
    }
    
    public async Task<IEnumerable<GameDto>> getGamesPage(int offset)
    {
        var sql = $@"
                SELECT game_id, game_name, game_description, game_img_url, game_published_year FROM Game LIMIT 10 OFFSET @offset;
                ";
        
        using var conn = _dataSource.OpenConnection();
        
        var list = await conn.QueryAsync<GameEntity>(sql, new {offset=offset});

        return list.Select(entity => _gameMapper.FromEntity(entity)); //Maps entity element in list to DocumentSimple
        
    }

    public async Task<GameDto> getGame(Guid gameId)
    {
        var sql = $@"
                SELECT game_id, game_name, game_description, game_img_url, game_published_year FROM Game WHERE game_id = @id;
                ";
        
        using var conn = _dataSource.OpenConnection();
        
        var game = conn.QuerySingle<GameEntity>(sql, new {
            id = gameId.ToString()
        });

        return _gameMapper.FromEntity(game);
    }  
}