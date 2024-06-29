using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Web.Dto.Villa
{
    public class VillaDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
        public string? ImageLocalPath { get; set; } = string.Empty;
        public string Amenity { get; set; } = string.Empty;
        [Required]
        public double Rate { get; set; }
    }
}
