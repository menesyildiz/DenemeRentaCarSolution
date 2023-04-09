using System.ComponentModel.DataAnnotations;

namespace DenemeRentaCar.Models
{
    public class FuelEditModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
