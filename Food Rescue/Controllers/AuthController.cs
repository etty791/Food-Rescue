using FoodRescue.Core.Entities;
using FoodRescue.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Food_Rescue.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly IUserService _userService;

		public AuthController(IConfiguration configuration, IUserService userService)
		{
			_configuration = configuration;
			_userService = userService;
		}

		[HttpPost("login")]
		public async Task<ActionResult> Login([FromBody] User login)
		{
			// 1. אימות המשתמש מול בסיס הנתונים
			var user = await _userService.GetUserByCredentialsAsync(login.UserName, login.Password);

			if (user != null)
			{
				// 2. יצירת רשימת ה"טענות" (Claims) - מה אנחנו יודעים על המשתמש
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, user.UserName),
					new Claim(ClaimTypes.Role, user.Role.ToString()), // התפקיד (Business/Charity)
                    new Claim("UserId", user.Id.ToString())
				};

				// 3. יצירת מפתח הצפנה (חייב להיות זהה למה שנגדיר ב-Program.cs)
				var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
				var sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

				// 4. בניית הטוקן
				var token = new JwtSecurityToken(
					issuer: _configuration["JWT:Issuer"],
					audience: _configuration["JWT:Audience"],
					claims: claims,
					expires: DateTime.Now.AddHours(3),
					signingCredentials: sc
				);

				// 5. שליחת הטוקן המקודד חזרה לקליינט (Angular)
				return Ok(new JwtSecurityTokenHandler().WriteToken(token));
			}

			return Unauthorized("שם משתמש או סיסמה שגויים");
		}
	}
}

