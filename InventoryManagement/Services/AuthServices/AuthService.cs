using InventoryManagement.Data;
using InventoryManagement.Dtos.AuthDto;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventoryManagement.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly ApiDbContext _context;
        private readonly IConfiguration _config;
        public AuthService(IConfiguration config, ApiDbContext context)
        {
            _context = context;
            _config = config;

        }
        public string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.FullName),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.role.Name),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Secret").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(7), signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public  User? GetUser(UserLoginDto userLoginDto)
        {
            User? userfromdb = _context.Users.Include(p => p.role).FirstOrDefault(x => x.Email == userLoginDto.email);
            return userfromdb;
        }

        public string? GetUser(UserRegistrationDto userRegistrationDto)
        {
            var userfromdb = _context.Users.FirstOrDefault(x => x.Email == userRegistrationDto.Email);
            if (userfromdb != null)
            { 
            return userfromdb.Email;
            }
            return null;
            
        }

        public async Task<User> Register(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
