using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]

public class LevelController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public LevelController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("GetAllLevels")]
    public async Task<ActionResult<List<Level>>> GetAllLevels()
    {
        var levels = await _context.Levels.ToListAsync();
        return Ok(levels);
    }
    }