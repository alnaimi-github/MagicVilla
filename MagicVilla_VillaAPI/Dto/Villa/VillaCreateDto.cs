using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Dto.Villa
{
    public class VillaCreateDto
    {
        [Required] [MaxLength(30)] public string Name { get; set; } = string.Empty;
        [Required] public string Details { get; set; } = string.Empty;
        [Required] public int Sqft { get; set; }
        [Required] public int Occupancy { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }
        [Required] public string Amenity { get; set; } = string.Empty;
        [Required] public double Rate { get; set; }
    }
}
