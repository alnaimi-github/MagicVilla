namespace MagicVilla_VillaAPI.Dto.RegisterDto
{
    public class RegistrationRequestDto
    {
        public string Name { get; set; }= string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
