using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]

public class EventController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EventController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("GetEventByInterestId/{interestId}")]
    public async Task<ActionResult<List<Event>>> GetEventByInterestId(Guid interestId)
    {
        var events = await _context.Events.Where(x => x.UserInterestId == interestId).ToListAsync();
        return Ok(events);
    }

    [HttpGet]
    [Route("GetEventsByUserId/{userId}")]
    public async Task<ActionResult<List<Event>>> GetEventsByUserId(Guid userId)
    {
        var events = await _context.Events.Where(x => x.UserInterest.UserId == userId).ToListAsync();
        return Ok(events);
    }
}