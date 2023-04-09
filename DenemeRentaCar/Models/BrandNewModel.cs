﻿using System.ComponentModel.DataAnnotations;

namespace DenemeRentaCar.Models
{
    public class BrandNewModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
    }
}
