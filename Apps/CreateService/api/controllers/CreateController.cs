using infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using service.Interfaces;

namespace api.controllers;

[ApiController]
[Route("[controller]")]
public class CreateController : ControllerBase
{

    private readonly IService _service;
    
    public CreateController(IService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateGame([FromBody] GameModel game)
    {
        if (game == null) return BadRequest();
        
        GameModel result = await _service.CreateGame(game);

        return result != null ? Ok(result) : NotFound();
    }
}