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

    // [HttpGet]
    // [Route("GetEventsByUserId/{userId}")]
    // public async Task<ActionResult<List<Event>>> GetEventsByUserId(Guid userId)
    // {
    //     var events = await _context.Events.Where(x => x.UserInterest.UserId == userId).ToListAsync();
    //     return Ok(events);
    // }

    [HttpGet]
    [Route("GetEventsByUserId/{userId}")]
    public async Task<ActionResult<List<Event>>> GetEventsByUserId(Guid userId)
    {
        var user = await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
        var userEvents = await _context.UserEvents.Where(ue => ue.UserId == userId).ToListAsync();
        List<Event> events = new List<Event>();

        foreach (var userEvent in userEvents)
        {
            Event e = await _context.Events.Where(e => e.Id == userEvent.EventId).FirstOrDefaultAsync();
            events.Add(e);
        }

        return Ok(events);
    }

}