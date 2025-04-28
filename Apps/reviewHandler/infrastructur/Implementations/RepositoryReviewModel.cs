using Dapper;
using infrastructur.Interfaces;
using infrastructur.Models.Dto;
using infrastructur.Models.Internal;
using infrastructur.Models.Mapper;
using Npgsql;

namespace infrastructur.Implementations;

public class RepositoryReviewModel : IRepository<Review>
{    
    private NpgsqlDataSource _dataSource;
    private ReviewMapper _mapper;
    public RepositoryReviewModel(NpgsqlDataSource dataSource)
    {
        _mapper = new ReviewMapper();
        _dataSource = dataSource;
    }

    public async Task<Review> GetScore(Guid gameId)
    {
        var sqlQuery = $@"SELECT game_id, game_score, game_score_total, total_reviews  FROM GameScore where game_id = @id";

        using var conn = _dataSource.OpenConnection();
        
        ReviewEntity score = await conn.QuerySingleAsync<ReviewEntity>(sqlQuery, new {
            id = gameId.ToString()
        });

        return _mapper.FromEntity(score);
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
            id = gameId.ToString()
        });

        return rowsAffected > 0;
    }
}