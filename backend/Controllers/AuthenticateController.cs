using API.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers.V01
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;  //För authUser
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost] //Return Token
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    //add id to claim
                    new Claim(ClaimTypes.Anonymous, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    authUserId = user.Id,
                });
            }
            return Unauthorized();
        }

        [HttpPost] //Ok(new Response { Status = "Success", Message = "User created successfully!" });
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponseDto { Status = "Error", Message = "User already exists!" });

            IdentityUser user = new()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponseDto { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new AuthResponseDto { Status = "Success", Message = "User created successfully!" });
        }

        [HttpGet]
        [Route("isAuthenticated")]
        public async Task<IActionResult> IsAuthenticated()
        {
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);

            return Ok(new
            {
                id = user.Id,
                username = User.Identity?.Name
            });
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(21),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

    }
}

