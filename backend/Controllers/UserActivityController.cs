using DAL.Dtos;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserActivityController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ApplicationDbContext _context;

    public UserActivityController(ILogger<WeatherForecastController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserActivityCardDto>>> GetAllUserActivityCardsAsync(Guid userId)
    {
        var myUserActivities = await _context.UserActivities.Where(ua => ua.UserId == userId).ToListAsync();
        var matchingUserActivities = new List<UserActivity>();
        var userActivityCardDtos = new List<UserActivityCardDto>();

        foreach (var userAcitivty in myUserActivities)
        {
            matchingUserActivities.AddRange(await _context.UserActivities.Where(x => x.ActivityId == userAcitivty.ActivityId && userId != x.UserId).ToListAsync());
        }

        foreach (var match in matchingUserActivities)
        {
            var user = await _context.Users.Where(x => x.Id == match.UserId).FirstOrDefaultAsync();
            var activity = await _context.Activities.Where(x => x.Id == match.ActivityId).FirstOrDefaultAsync();
            var level = await _context.Levels.Where(x => x.Id == match.LevelId).FirstOrDefaultAsync();
            

            userActivityCardDtos.Add(
                new UserActivityCardDto{
                    Username = user.Name,
                    ActivityName = activity.Name,
                    ProfilePictureURL = user.ProfilePictureURL,
                    Gender = user.Gender,
                    Level = level.Name,
                    Age = user.Age
                }
            );
        }



       return Ok(userActivityCardDtos);
    }

    [HttpGet]
    public async Task<ActionResult<List<UserActivityCardDto>>> GetUserActivityCardDtosByActivity(Guid userId, Guid activityId)
    {
        var matchingUserActivities = new List<UserActivity>();
        var userActivityCardDtos = new List<UserActivityCardDto>();

        matchingUserActivities.AddRange(await _context.UserActivities.Where(x=> x.ActivityId == activityId && x.UserId == userId).ToListAsync());

        foreach (var match in matchingUserActivities)
        {
            var user = await _context.Users.Where(x => x.Id == match.UserId).FirstOrDefaultAsync();
            var activity = await _context.Activities.Where(x => x.Id == match.ActivityId).FirstOrDefaultAsync();
            var level = await _context.Levels.Where(x => x.Id == match.LevelId).FirstOrDefaultAsync();
            

            userActivityCardDtos.Add(
                new UserActivityCardDto{
                    Username = user.Name,
                    ActivityName = activity.Name,
                    ProfilePictureURL = user.ProfilePictureURL,
                    Gender = user.Gender,
                    Level = level.Name,
                    Age = user.Age
                }
            );
        }

        return Ok(userActivityCardDtos);
    }
}