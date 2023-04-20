using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MoviesCatalogueChallenge.Contexts;
using MoviesCatalogueChallenge.DTOs;
using MoviesCatalogueChallenge.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoviesCatalogueChallenge.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MoviesChContext context;
        private readonly IMapper mapper;
        private readonly IConfiguration _configuration;

        public UsersController(MoviesChContext context, IMapper mapper, IConfiguration configuration)
        {
            this.context = context;
            this.mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> Post(UserCreateDTO userPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(context.Users.Any(u => u.Email == userPost.Email))
            {
                return BadRequest("Email address is already registered");
            }

            var user = mapper.Map<User>(userPost);
            context.Add(user);
            await context.SaveChangesAsync();
            return Ok("Successefully Created!");
        }

        [HttpPost("authenticate")]
        public ActionResult Post(string Email, string Pass)
        {
            var user = context.Users.SingleOrDefault(u => u.Email == Email && u.Password == Pass);

            if (user == null)
            {
                return Unauthorized();
            }

            var role = context.Roles.SingleOrDefault(r => r.RoleId == user.RoleId);
            user.Role = role;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ChallengeMovies2023");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.Name.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }
    }
}
