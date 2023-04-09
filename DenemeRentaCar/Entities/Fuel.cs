using System.ComponentModel.DataAnnotations;

namespace DenemeRentaCar.Entities
{
    public class Fuel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

    }
}
