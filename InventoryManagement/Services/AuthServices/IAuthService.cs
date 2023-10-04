using InventoryManagement.Dtos.AuthDto;
using InventoryManagement.Models;

namespace InventoryManagement.Services.AuthServices
{
    public interface IAuthService
    {
        Task<User> Register(User user);

        string GenerateToken(User user);

        User? GetUser(UserLoginDto userLoginDto);

        string? GetUser(UserRegistrationDto userRegistrationDto);


    }
}
