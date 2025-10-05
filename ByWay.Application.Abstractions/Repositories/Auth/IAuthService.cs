
namespace ByWay.Application.Services.Auth
{
    public interface IAuthService
    {
        Task<UserDto> RegisterAsync(RegisterDto registerDto);
        Task<UserDto> LoginAsync(LoginDto loginDto);
        Task<UserDto> GetCurrentUserAsync(ClaimsPrincipal claimsPrincipal);
        Task<bool> UserExistsAsync(string email);

    }
}
