using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SocialMediaApp.Business.UserService;
using SocialMediaApp.Data.Dtoes;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialMediaApp.Controllers
{
    [ApiController]
    [Route("api/token/[controller]")]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        IConfiguration configuration;
        IUserService userService;

        public AuthenticationController(IConfiguration configuration, IUserService userService)
        {
            this.configuration = configuration;
            this.userService = userService;
        }
        [HttpPost(nameof(GetToken))]
        public IActionResult GetToken(UserDto model)
        {
            if (model == null) return Unauthorized();

            var user = userService.Get(model.Id);

            if (user == null) return Unauthorized();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                new Claim("UserId",user.Id.ToString()),
                new Claim("Name",user.Name),
                new Claim("LastName", user.LastName),

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"].ToString()));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //var tokens = new JwtSecurityTokenHandler().CreateToken(claims);

            var token = new JwtSecurityToken(
                configuration["JWT:Issuer"],
                configuration["JWT:Auidence"],
                claims,
                null,
                DateTime.UtcNow.AddMinutes(20),
                signIn);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
