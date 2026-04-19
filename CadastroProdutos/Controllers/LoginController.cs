using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration configuration;
        public LoginController(IConfiguration configuration)
        {
            this.configuration = configuration;

        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            string role;
            // validar os usuários

            if (login.Usuario == "admin" && login.Senha == "1234")
            {
                role = "admin";

            }
            else if (login.Usuario == "cliente" && login.Senha == "1234")
            {
                role = "cliente";

            }
            else
            {
                return Unauthorized();
            }

            // criar o token jwt
            var jwtConfig = configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtConfig["Key"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptior = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("usuario", login.Usuario),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = jwtConfig["Issuer"],
                Audience = jwtConfig["Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptior);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Tokem = tokenString });

        }
    }
}
