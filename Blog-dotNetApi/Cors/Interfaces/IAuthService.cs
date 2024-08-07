using Blog_dotNetApi.Cors.Dtos;
using Blog_dotNetApi.Cors.Entities;

namespace Blog_dotNetApi.Cors.Interfaces
{
    public interface IAuthService
    {
        Task<AuthServiceResponseDto> SeedRolesAsync();
        Task<AuthServiceResponseDto> RegisterAsync(RegisterDto registerDto);
        Task<AuthServiceResponseDto> LoginAsync(LoginDto loginDto);
        Task<ApplicationUser> UserDataAsync(DataDto DataDto);
        string ExtractFirstName(string firstName);
        Task<AuthServiceResponseDto> MakeAdminAsync(UpdatePermissionDto updatePermissionDto);
        Task<AuthServiceResponseDto> MakeOwnerAsync(UpdatePermissionDto updatePermissionDto);
    }
}
