﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Web.Dto.Villa
{
    public class VillaUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Details { get; set; } = string.Empty;
        [Required]
        public int Sqft { get; set; }
        [Required]
        public int Occupancy { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
        public string? ImageLocalPath { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }
        [Required]
        public string Amenity { get; set; } = string.Empty;
        [Required]
        public double Rate { get; set; }
    }
}
