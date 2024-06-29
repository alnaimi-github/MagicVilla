using MagicVilla_Web.Dto.LoginDto;
using MagicVilla_Web.Dto.RegisterDto;

namespace MagicVilla_Web.Services.IServices
{
    public interface IAuthService
    {
        Task<T>LoginAsync<T>(LoginRequestDto  loginRequestDto);
        Task<T>RegisterAsync<T>(RegistrationRequestDto  registrationRequestDto);
        Task<T>LogoutAsync<T>(TokenDto tokenDto);

    }
}
