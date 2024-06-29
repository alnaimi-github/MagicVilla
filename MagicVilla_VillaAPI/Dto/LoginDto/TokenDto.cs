using MagicVilla_VillaAPI.Models;

namespace MagicVilla_VillaAPI.Dto.LoginDto
{
    public class TokenDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
