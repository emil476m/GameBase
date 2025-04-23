

using api.dtos;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace api.controllers;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IService<float> _service;

    public ReviewController(IService<float> service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("{gameId}")]
    public async Task<IActionResult> GetScore([FromRoute] Guid gameId)
    {
        if (gameId.Equals(Guid.Empty)) return BadRequest();

        var score = await _service.GetScore(gameId);

        return score != null ? Ok(score) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddToScore([FromBody] ScoreAdditionDto dto)
    {
        if (dto.game_id == Guid.Empty || dto.score < 0 || dto.score > 10) return BadRequest();

        var newScore = await _service.AddScore(dto.game_id, dto.score);

        return newScore > 0 ? Ok(newScore) : NoContent();
    }
}