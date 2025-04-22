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
            $@"INSERT INTO Game (game_id, game_name, game_description, game_img_url) 
            VALUES(@GameId, @GameName, @GameDesc, @ImgUrl)
            RETURNING game_id as {nameof(GameDbModel.Id)},
            game_name as {nameof(GameDbModel.Name)},
            game_description as {nameof(GameDbModel.Description)},
            game_img_url as {nameof(GameDbModel.ImgUrl)}
            ;";

        using var conn = _dataSource.OpenConnection();
        try
        {
            var result = await conn.QueryFirstAsync<GameDbModel>(sql, new {
                GameId = dbGame.Id,
                GameName = dbGame.Name, 
                GameDesc = dbGame.Description, 
                ImgUrl = dbGame.ImgUrl
            });
                
            return result.ToModel();
        }
        catch (Exception e)
        {
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