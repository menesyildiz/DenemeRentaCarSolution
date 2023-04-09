using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DenemeRentaCar.Models
{
    public class CarNewModel
    {
        [Required]
        [StringLength(20)]
        public string Plate { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Passengers { get; set; }

        [Required]
        [StringLength(20)]
        public string Category { get; set; }

        [Required]
        [StringLength(20)]
        public string HasDriver { get; set; }

        [Required]
        [StringLength(20)]
        public string Year { get; set; }
        [Required]
        [StringLength(20)]
        public string Price { get; set; }

        public int BrandId { get; set; }
        public SelectList? Brands { get; set; }

        public int GearboxId { get; set; }
        public SelectList? Gearboxes { get; set; }

        public int FuelId { get; set; }
        public SelectList? Fuels { get; set; }

        public int ColourId { get; set; }
        public SelectList? Colours { get; set; }
    }
}
