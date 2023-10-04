using AutoMapper;
using InventoryManagement.Data;
using InventoryManagement.Dtos.AuthDto;
using InventoryManagement.Models;
using InventoryManagement.Services.AuthServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public AuthController(IAuthService authService, IMapper mapper)
        {

            _authService = authService;
            _mapper = mapper;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationDto dto)
        {
            var userfromdb = _authService.GetUser(dto);
            
            if (userfromdb != null) {
                return BadRequest("Email already exists");
            }
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.PasswordHash);

            if (dto.RoleId == 0)
            {
                dto.RoleId = 2;
            }

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = passwordHash,
                RoleId = dto.RoleId
           
            };

            var retVal = _authService.Register(user);
            var newUser = _mapper.Map<UserDetailDto>(retVal);
            return Ok(newUser);
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto dto)
        {
            var user = _authService.GetUser(dto);

            if (user == null)
                return BadRequest("Invalid username or password.");

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return BadRequest("Invalid username or password.");

            string token = _authService.GenerateToken(user);

            return Ok(token);
        }


    }
}
