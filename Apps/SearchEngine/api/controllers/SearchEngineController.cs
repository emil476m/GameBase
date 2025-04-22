using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace api.controllers;

[ApiController]
[Route("[controller]")]
public class SearchEngineController : ControllerBase
{
    private readonly IService<string> _service;

    public SearchEngineController(IService<string> service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> Search([FromQuery] string query)
    {
        if (query.Trim() == "") BadRequest();

        IEnumerable<string> result = await _service.QuerySearch(query);

        return result.Any() ? Ok(result) : NotFound();
    }
}