using _55_API_JWT_Auhentication.Context;
using _55_API_JWT_Auhentication.Models;
using _55_API_JWT_Auhentication.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _55_API_JWT_Auhentication.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //User Kayıt
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UseForRegistrationDTO userDTO)
        {
            var result = _context.Users.SingleOrDefault(x => x.Email == userDTO.EMail);
            if (result is null)
            {
                AppUser user = new();
                user.Id = Guid.NewGuid().ToString();
                user.Email = userDTO.EMail;
                user.FirstName = userDTO.FirstName;
                user.LastName = userDTO.LastName;
                user.NormalizedEmail = userDTO.EMail.ToUpper();
                user.EmailConfirmed = true;
                user.PasswordHash = userDTO.Password;
                user.SecurityStamp = Guid.NewGuid().ToString();
                user.ConcurrencyStamp = Guid.NewGuid().ToString();
                user.PhoneNumber = userDTO.Phonenumber;
                user.PhoneNumberConfirmed = true;

                _context.Users.Add(user);
                _context.SaveChanges();

                return Ok();
            }
            else
                return BadRequest();
        }

        //User Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] AppUserLogin userLogin)
        {
            var login = _context.Users.SingleOrDefault(x => x.Email == userLogin.Email && x.PasswordHash == userLogin.Password);
            if (login is not null)
            {
                var authCalims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,userLogin.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };
                var token = GetToken(authCalims);
                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
            }
            else
            {
                return Unauthorized();
            }
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:securityKey"]));
            var signIn = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["JWTSettings:validIssuer"],
                _configuration["JWTSettings:validAudience"],
                authClaims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn
                );
            return token;
        }
    }
}
