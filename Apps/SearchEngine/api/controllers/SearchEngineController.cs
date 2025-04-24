using infrastruvtur.Models.externals;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace api.controllers;

[ApiController]
[Route("[controller]")]
public class SearchEngineController : ControllerBase
{
    private readonly IService<SearchDto, GameDto> _service;

    public SearchEngineController(IService<SearchDto, GameDto> service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> Search([FromQuery] string query)
    {
        if (query.Trim() == "") BadRequest();

        IEnumerable<SearchDto> result = await _service.QuerySearch(query);

        return result.Any() ? Ok(result) : NotFound();
    }
    
    [HttpGet]
    [Route("Game/{GameId}")]
    public async Task<IActionResult> Search([FromRoute] Guid GameId)
    {
        if (GameId == null ||Guid.Empty.Equals(GameId)) BadRequest();

        GameDto result = await _service.getGame(GameId);

        return result != null ? Ok(result) : NotFound();
    }
    
    [HttpGet]
    [Route("Games")]
    public async Task<IActionResult> GetGame()
    {
        IEnumerable<GameDto> result = await _service.getGames();

        return result.Any() ? Ok(result) : NotFound();
    }
}