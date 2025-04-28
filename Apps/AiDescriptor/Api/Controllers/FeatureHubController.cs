using Externalities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Api.Controllers;

[ApiController]
public class FeatureHubController : ControllerBase
{
    private readonly FeatureHubService _fhs;

    public FeatureHubController(FeatureHubService fhs)
    {
        _fhs = fhs;
    }

    [HttpGet]
    [Route("/api/Feature")]
    public async Task<IActionResult> GetFeatures()
    {
        var response = await _fhs.getFeatures();
        if (response == null)
        {
            return BadRequest();
        }
        return Ok(response);
    }
}