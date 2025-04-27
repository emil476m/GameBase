using Api.DTO;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Api.Controllers;

[ApiController]
public class AIController : ControllerBase
{
    private readonly AIService _aiService;
    public AIController(AIService aiService)
    {
        _aiService = aiService;
    }
    
    [HttpPost]
    [Route("/api/AIDescription")]
    public async Task<IActionResult> AI([FromBody] QueryDto query)
    {
        var response = await _aiService.getRespons(query.Query);
        if (response != null)
        {
            return Ok(response);
        }
        else
        {
            return BadRequest();
        }
    }
}