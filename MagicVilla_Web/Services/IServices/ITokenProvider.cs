using MagicVilla_Web.Dto.LoginDto;

namespace MagicVilla_Web.Services.IServices
{
    public interface ITokenProvider
    {
        void SetToken(TokenDto tokenDto);
        TokenDto? GetToken();
        void ClearToken();
    }
}
