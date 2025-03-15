using Microsoft.AspNetCore.Mvc;
using Mission10_Spencer.Models;

namespace Mission10_Spencer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BowlerController : ControllerBase
{
    private readonly IBowlingRepository _repository; // ✅ Use IBowlingRepository

    public BowlerController(IBowlingRepository repository) // ✅ Accept IBowlingRepository
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    [HttpGet(Name = "GetBowlers")]
    public IActionResult Get()
    {
        var bowlersWithTeams = _repository.GetBowlersWithTeam();
        return Ok(bowlersWithTeams);
    }
}
