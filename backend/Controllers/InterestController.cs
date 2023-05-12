using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class InterestController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public InterestController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    [Route("GetMyInterests")]
    public async Task<ActionResult<List<Interest>>> GetMyInterests(Guid userId)
    {
        var myInterests = new List<Interest>();
        var myUserInterests = await _context.UserInterests.Where(x => x.UserId == userId).ToListAsync();
        foreach (var item in myUserInterests)
        {
            myInterests.Add(await _context.Interests.Where(x => x.Id == item.InterestId).FirstOrDefaultAsync());
        }

        return Ok(myInterests);
    }

    [HttpGet]
    [Route("GetAllInterests")]
    public async Task<ActionResult<List<Interest>>> GetAllInterests()
    {
        return await _context.Interests.ToListAsync();
    }

    [HttpPost]
    [Route("AddInterestToUser/{userId:Guid}")]
    public async Task<ActionResult> AddInterestToUser(Guid userId, Guid interestId, [FromBody] UserInterest UserInterest)
    {
        var user = await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
        var interest = await _context.Interests.Where(i => i.Id == interestId).FirstOrDefaultAsync();
        var newUserInterest = new UserInterest
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            InterestId = interestId,
            LevelId = UserInterest.LevelId,
            Note = UserInterest.Note,
            LocationId = UserInterest.LocationId
        };
        await _context.UserInterests.AddAsync(newUserInterest);
        await _context.SaveChangesAsync();
        return Ok();
    }
}