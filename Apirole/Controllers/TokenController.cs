using Apiauth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Apiauth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ApplicationDbContext _con;
        private readonly IConfiguration _configuration;

        public TokenController(ApplicationDbContext con, IConfiguration configuration)
        {
            _con = con;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User userData)
        {
            if (userData != null && !string.IsNullOrEmpty(userData.Email) && !string.IsNullOrEmpty(userData.Password))
            {
                var user = await _con.Users.FirstOrDefaultAsync(u => u.Email == userData.Email && u.Password == userData.Password);

                if (user != null)
                {
                    var token = GenerateToken(user);
                    return Ok(new { token });
                }
                return BadRequest("Invalid credentials");
            }

            return BadRequest("Invalid request data");
        }

        private string GenerateToken(User user)
        {
            // Ensure role matches exactly what [Authorize(Roles="User,Admin")] expects
            string role = user.Role.ToLower() switch
            {
                "admin" => "Admin",
                "user" => "User",
                _ => user.Role
            };

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Username!),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
