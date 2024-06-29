using System.ComponentModel.DataAnnotations;
using MagicVilla_Web.Dto.Villa;

namespace MagicVilla_Web.Dto.VillaNumber
{
    public class VillaNumberDto
    {
        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; } = string.Empty;
        [Required]
        public int VillaId { get; set; }
        public VillaDto? Villa { get; set; }
    }
}
