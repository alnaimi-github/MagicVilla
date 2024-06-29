using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI
{
    public class JwtOptions
    {
        public static string SectionName = "ApiSettings";

        [Required]
        public string SecretKey { get; set; } = string.Empty;
        [Required]
        public string Issuer { get; set; } = string.Empty;
        [Required]
        public string Audience { get; set; } = string.Empty;
        //[Required]
        //public DateTime ExpireAt { get; set; } 
    }
}
