using Dapper;
using infrastructur.Interfaces;
using Npgsql;

namespace infrastruvtur.Implementation;

public class SeartchRepositoryString: ISearchRepository<string>
{
    
    private NpgsqlDataSource _dataSource;
    public SeartchRepositoryString(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }
    
    public async Task<IEnumerable<string>> QuerySearch(string searchQuery)
    {
        var sql = $@"
                SELECT DISTINCT game_name FROM Game WHERE game_name ILIKE @query;
                ";

        using var conn = _dataSource.OpenConnection();
        
        var list = await conn.QueryAsync<string>(sql, new {
            query = @$"%{searchQuery.Trim()}%"
        });

        return list;
    }
}