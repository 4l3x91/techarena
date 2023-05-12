using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]

public class LocationController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public LocationController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("GetAllLocations")]
    public async Task<ActionResult<List<Location>>> GetAllLevels()
    {
        var locations = await _context.Locations.ToListAsync();
        return Ok(locations);
    }
    }