using Dapper;
using infrastructure.Interfaces;
using infrastructure.Mappers;
using infrastructure.Models;
using Npgsql;

namespace infrastructure.Implementations;

public class Repository : IRepository
{
    
    private readonly NpgsqlDataSource _dataSource;

    public Repository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }
    
    public async Task<GameModel> CreateGame(GameModel game)
    {
        var dbGame = game.ToDbModel();
        var sql =
            $@"INSERT INTO Game (game_id, game_name, game_description, game_img_url, game_published_year) 
            VALUES(@GameId, @GameName, @GameDesc, @ImgUrl, @PublishedYear)
            RETURNING game_id as {nameof(GameDbModel.Id)},
            game_name as {nameof(GameDbModel.Name)},
            game_description as {nameof(GameDbModel.Description)},
            game_img_url as {nameof(GameDbModel.ImgUrl)},
            game_published_year as {nameof(GameDbModel.PublishedYear)}
            ;";

        var sqlReiew = $@"INSERT INTO GameScore (game_score, game_id, game_score_total, total_reviews) values
                        (0,@gameId, 0, 0);";

        using var conn = _dataSource.OpenConnection();
        using var transaction = conn.BeginTransaction();

        try
        {
            var result = await conn.QueryFirstAsync<GameDbModel>(sql, new {
                GameId = dbGame.Id,
                GameName = dbGame.Name, 
                GameDesc = dbGame.Description, 
                ImgUrl = dbGame.ImgUrl,
                PublishedYear = dbGame.PublishedYear
            });
            
            await conn.ExecuteAsync(sqlReiew, new {gameId=result.Id});
            
            await transaction.CommitAsync();
            
            return result.ToModel();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw new Exception("Could not create game");
        }
            
        
    }

    public async Task<bool> CheckIfGuidExists(Guid guid)
    {
        var sql = $@"SELECT game_id FROM Game WHERE game_id = @NewGuid;";

        using var conn = _dataSource.OpenConnection();
        try
        {
            var result = await conn.QueryFirstOrDefaultAsync<Guid>(sql, new { NewGuid = guid.ToString() });
            return result != default;
        }
        catch (Exception e)
        {
            throw new Exception("Could not check guid");
        }
    }
}