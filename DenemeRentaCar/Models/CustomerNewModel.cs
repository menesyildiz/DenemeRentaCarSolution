using System.ComponentModel.DataAnnotations;

namespace DenemeRentaCar.Models
{
    public class CustomerNewModel
    {
        [Required]
        [StringLength(11)]
        public string TC { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Surname { get; set; }
    }
}
