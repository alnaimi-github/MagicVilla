using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Web.Dto.VillaNumber
{
    public class VillaNumberUpdateDto
    {
        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; } = string.Empty;
        [Required]
        public int VillaId { get; set; }
    }
}
