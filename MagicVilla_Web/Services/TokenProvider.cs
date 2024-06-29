using MagicVilla_Utility.StaticDetails;
using MagicVilla_Web.Dto.LoginDto;
using MagicVilla_Web.Services.IServices;
using NuGet.Common;

namespace MagicVilla_Web.Services
{
    public class TokenProvider: ITokenProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public TokenProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void SetToken(TokenDto tokenDto)
        {
            var cookieOptions = new CookieOptions { Expires = DateTime.UtcNow.AddDays(60) };
            _contextAccessor.HttpContext!.Response.Cookies.Append(Sd.AccessToken, tokenDto.AccessToken, 
                cookieOptions);
            _contextAccessor.HttpContext!.Response.Cookies.Append(Sd.RefreshToken, tokenDto.RefreshToken,
                cookieOptions);
        }

        public TokenDto? GetToken()
        {
            try
            {
                var hasAccessToken = _contextAccessor.HttpContext!.Request.Cookies.TryGetValue(Sd.AccessToken, 
                        out var accessToken);
                var hasRefreshToken = _contextAccessor.HttpContext!.Request.Cookies.TryGetValue(Sd.RefreshToken,
                        out var refreshToken);

                var tokenDto = new TokenDto
                {
                    AccessToken = accessToken!,
                    RefreshToken = refreshToken!
                };
                return hasAccessToken ? tokenDto : default!;
            }
            catch (Exception e)
            {
                return default!;
            }
        }

        public void ClearToken()
        {
            _contextAccessor.HttpContext!.Response.Cookies.Delete(Sd.AccessToken);
            _contextAccessor.HttpContext!.Response.Cookies.Delete(Sd.RefreshToken);
        }
    }
}
