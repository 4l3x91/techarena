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
    [Route("GetEventByInterestId/{interestId:Guid}")]
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
    [Route("GetEventsByUserId/{userId:Guid}")]
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
    [HttpPost]
    [Route("CreateNewEvent/{userId:Guid}")]
    public async Task<ActionResult> CreateNewEvent(Guid userId, [FromBody] Event Event)
    {
        var user = await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
        
        var newEvent = new Event
        {
            Id = Guid.NewGuid(),
            UserInterestId = Event.UserInterestId,
            Time = Event.Time,
            IsPublic = Event.IsPublic
        };
        await _context.Events.AddAsync(newEvent);
        await _context.SaveChangesAsync();
        return Ok();
    }

}