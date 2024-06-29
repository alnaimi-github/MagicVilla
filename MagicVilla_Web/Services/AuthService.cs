using MagicVilla_Utility.StaticDetails;
using MagicVilla_Web.Dto.LoginDto;
using MagicVilla_Web.Dto.RegisterDto;
using MagicVilla_Web.Dto.RequestDto;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
    public class AuthService: IAuthService
    {
          private readonly IBaseService _baseService;
        private readonly string _villaUrl;
        private const string Url = $"/api/{Sd.CurrentApiVersion}/UserAuth/";

        public AuthService(IBaseService baseService, IConfiguration config)
        {
            _baseService = baseService;
            _villaUrl = config.GetValue<string>("ServiceUrls:VillaApi")!;
        }
        public async Task<T> LoginAsync<T>(LoginRequestDto loginRequestDto)
        {
            return await _baseService.SendAsync<T>(new ApiRequest
            {
                ApiType = Sd.ApiType.Post,
                Data = loginRequestDto,
                ApiUrl = _villaUrl + Url + "login"
            }, false);
        }

        public async Task<T> RegisterAsync<T>(RegistrationRequestDto registrationRequestDto)
        {
            return await _baseService.SendAsync<T>(new ApiRequest
            {
                ApiType = Sd.ApiType.Post,
                Data = registrationRequestDto,
                ApiUrl = _villaUrl + Url + "register"
            }, false);
        }

        public async Task<T> LogoutAsync<T>(TokenDto tokenDto)
        {
            return await _baseService.SendAsync<T>(new ApiRequest
            {
                ApiType = Sd.ApiType.Post,
                Data = tokenDto,
                ApiUrl = _villaUrl + Url + "RevokeRefreshToken"
            });
        }
    }
}
