using System.ComponentModel.DataAnnotations;

namespace DenemeRentaCar.Models
{
    public class GearboxNewModel
    {
        [Required]
        [StringLength(25)]
        public string Type { get; set; }
    }
}
