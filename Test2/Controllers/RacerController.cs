using Microsoft.AspNetCore.Mvc;
using Test2.Dtos;
using Test2.Services;

namespace Test2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RacerController : ControllerBase
{
    private readonly IRacerService _racerService;
    
    public RacerController(IRacerService racerService)
    {
        _racerService = racerService;
    }

    [HttpGet("{id}/participations")]
    [ProducesResponseType(typeof(RacerParticipationDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RacerParticipationDto>> GetParticipations(int id)
    {
        var participations = await _racerService.GetParticipationsAsync(id);
        if (participations == null)
        {
            return NotFound();
        }
        return Ok(participations);
    }

    [HttpPost("track-races/participants")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddParticipations(AddParticipationsRequest request)
    {
        try
        {
            await _racerService.AddParticipationsAsync(request);
            return Created(string.Empty, null);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
} 