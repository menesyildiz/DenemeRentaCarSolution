using System.ComponentModel.DataAnnotations;

namespace DenemeRentaCar.Models
{
    public class GearboxEditModel
    {
        [Required]
        [StringLength(100)]
        public string Type { get; set; }
    }
}
