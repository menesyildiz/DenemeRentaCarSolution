using System.ComponentModel.DataAnnotations;

namespace DenemeRentaCar.Models
{
    public class FuelNewModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
