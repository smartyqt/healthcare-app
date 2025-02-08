using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAntiforgery _antiforgery;

        public AuthController(IConfiguration configuration, IAntiforgery antiforgery)
        {
            _configuration = configuration;
            _antiforgery = antiforgery;
        }

        // ✅ Generate CSRF Token (For Non-Login Requests)
        [HttpGet("csrf-token")]
        public IActionResult GetCsrfToken()
        {
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
            Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken!, new CookieOptions
            {
                HttpOnly = false,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });

            return Ok(new { token = tokens.RequestToken });
        }

        [IgnoreAntiforgeryToken]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            var users = new Dictionary<string, string>
            {
            { "admin", "Admin" },
            { "doctor", "HealthcareProfessional" }
            };

            if (users.TryGetValue(login.Username, out string role) && login.Password == "password")
            {
                var claims = new[]
                {
            new Claim(ClaimTypes.Name, login.Username),
            new Claim(ClaimTypes.Role, role) // ✅ Store the role in JWT token
        };

                var jwtKey = _configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key is missing!");

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), role });
            }

            return Unauthorized();
        }

    }

    public class LoginModel
    {
        public required string Username { get; set; }  
        public required string Password { get; set; }
    }
}
