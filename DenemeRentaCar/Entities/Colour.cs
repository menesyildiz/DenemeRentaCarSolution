using System.ComponentModel.DataAnnotations;

namespace DenemeRentaCar.Entities
{
    public class Colour
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
