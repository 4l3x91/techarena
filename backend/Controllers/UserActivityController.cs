using DAL.Dtos;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserActivityController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UserActivityController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("GetAllUserInterest")]
    public async Task<ActionResult<List<UserInterestCardDto>>> GetAllUserInterestAsync(Guid userId)
    {
        var myUserInterests = await _context.UserInterests.Where(ua => ua.UserId == userId).ToListAsync();
        var matchingUserInterests = new List<UserInterest>();
        var userActivityCardDtos = new List<UserInterestCardDto>();

        foreach (var userInterest in myUserInterests)
        {
            matchingUserInterests.AddRange(await _context.UserInterests.Where(x => x.InterestId == userInterest.InterestId && userId != x.UserId).ToListAsync());
        }

        foreach (var match in matchingUserInterests)
        {
            var user = await _context.Users.Where(x => x.Id == match.UserId).FirstOrDefaultAsync();
            var interest = await _context.Interests.Where(x => x.Id == match.InterestId).FirstOrDefaultAsync();
            var level = await _context.Levels.Where(x => x.Id == match.LevelId).FirstOrDefaultAsync();
            var location = match.LocationId != null ? await _context.Locations.Where(x => x.Id == match.LocationId).FirstOrDefaultAsync() : null;


            userActivityCardDtos.Add(
                new UserInterestCardDto
                {
                    Username = user.Name,
                    InterestName = interest.Name,
                    ProfilePictureURL = user.ProfilePictureURL,
                    Gender = user.Gender,
                    Level = level.Name,
                    Age = user.Age,
                    About = user.About,
                    Location = location
                }
            );
        }

        return Ok(userActivityCardDtos);
    }

    [HttpGet]
    [Route("GetAllUserInterestByInterestId")]
    public async Task<ActionResult<List<UserInterestCardDto>>> GetUserInterestCardDtosByActivity( Guid interestId)
    {
        var matchingUserInterests = new List<UserInterest>();
        var userInterestsCardDtos = new List<UserInterestCardDto>();

        matchingUserInterests.AddRange(await _context.UserInterests.Where(x => x.InterestId == interestId).ToListAsync());

        foreach (var match in matchingUserInterests)
        {
            var user = await _context.Users.Where(x => x.Id == match.UserId).FirstOrDefaultAsync();
            var interest = await _context.Interests.Where(x => x.Id == match.InterestId).FirstOrDefaultAsync();
            var level = await _context.Levels.Where(x => x.Id == match.LevelId).FirstOrDefaultAsync();


            userInterestsCardDtos.Add(
            new UserInterestCardDto
            {
                Username = user.Name,
                InterestName = interest.Name,
                ProfilePictureURL = user.ProfilePictureURL,
                Gender = user.Gender,
                Level = level.Name,
                Age = user.Age
            }
        );
        }

        return Ok(userInterestsCardDtos);
    }
}