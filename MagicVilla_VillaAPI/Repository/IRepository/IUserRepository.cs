using MagicVilla_VillaAPI.Dto.LoginDto;
using MagicVilla_VillaAPI.Dto.RegisterDto;
using MagicVilla_VillaAPI.Models;

namespace MagicVilla_VillaAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<TokenDto> Login(LoginRequestDto loginRequestDto);
        Task<UserDto>Register(RegistrationRequestDto registerRequestDto);
        Task<TokenDto> RefreshAccessToken(TokenDto tokenDto);
        Task RevokeRefreshToken(TokenDto tokenDto);
    }
}
