using AIScoutProject.AIScout.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ScoutController : ControllerBase
{
    private readonly IScoutService _scoutService;

    public ScoutController(IScoutService scoutService)
    {
        _scoutService = scoutService;
    }

    [HttpGet("analyze/{name}")]
    public async Task<IActionResult> Analyze(string name)
    {
        var result = await _scoutService.GetRecommendationsAsync(name);
        return Ok(result);
    }
}