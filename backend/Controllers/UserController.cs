using DAL.Entities;
using DAL.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("CreateUserWithAuthId/{authId:Guid}")]
    public async Task<ActionResult<User>> CreateUserWithAuthId([FromBody]UserRequestDto dto)
    {
        var user = new User()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            ProfilePictureURL = dto.ProfilePictureURL,
            BirthDate = dto.BirthDate,
            Gender = dto.Gender,
            About = dto.About,
            AuthUserId = dto.PassAuthUserId,
        };
        await _context.SaveChangesAsync();
        return Ok(user);
    }

    [HttpGet]
    [Route("GetUserByAuthId/{authId:Guid}")]
    public async Task<ActionResult<User>> GetUserByAuthId(Guid authId)
    {        
        var user = await _context.Users.FirstOrDefaultAsync(u => u.AuthUserId.ToString() == authId.ToString());

        return Ok(user);
    }

    [HttpGet]
    [Route("GetAllUsers")]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        var users = await _context.Users.ToListAsync();
        return Ok(users);
    }

    [HttpPut]
    [Route("UpdateUser")]
    public async Task<ActionResult> CompleteUserProfile(UserRequestDto dto)
    {
        var getUser = await _context.Users.Where(u => u.AuthUserId == dto.PassAuthUserId).FirstOrDefaultAsync();
        //update user with data from dto
        var updateUser = new User()
        {
            Id = getUser.Id,
            Name = dto.Name,
            ProfilePictureURL = dto.ProfilePictureURL,
            BirthDate = dto.BirthDate,
            Gender = dto.Gender,
            About = dto.About,
            AuthUserId = getUser.AuthUserId,
        };
        try {
            _context.Users.Update(updateUser);

        }
        catch (Exception e) {
            Console.WriteLine(e);
        }
        return Ok();
    }
}