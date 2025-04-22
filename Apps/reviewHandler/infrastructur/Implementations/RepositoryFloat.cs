using Dapper;
using infrastructur.Interfaces;
using Npgsql;

namespace infrastructur.Implementations;

public class RepositoryFloat : IRepository<float>
{    private NpgsqlDataSource _dataSource;

    public RepositoryFloat(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public async Task<float> GetScore(Guid gameId)
    {
        var sqlQuery = $@"SELECT game_score FROM GameScore where game_id = @id";

        using var conn = _dataSource.OpenConnection();
        
        var id = await conn.QuerySingleAsync<float>(sqlQuery, new {
            id = $@"{gameId}"
        });

        return id;
    }

    public async Task<bool> AddScore(Guid gameId, int addition)
    {
        var sqlQuery = $@"UPDATE GameScore
                            SET
                            game_score_total = game_score_total + @plusscore,
                            total_reviews = total_reviews + 1,
                            game_score = CAST(game_score_total + @plusscore AS DECIMAL) / (total_reviews + 1)
                            WHERE game_id = @id;";
        
        using var conn = _dataSource.OpenConnection();
        
        var rowsAffected = await conn.ExecuteAsync(sqlQuery, new {
            plusscore = addition,
            id = $@"{gameId}"
        });

        return rowsAffected > 0;
    }
}