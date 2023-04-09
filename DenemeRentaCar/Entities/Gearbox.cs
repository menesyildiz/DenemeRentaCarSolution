using System.ComponentModel.DataAnnotations;

namespace DenemeRentaCar.Entities
{
    public class Gearbox
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Type { get; set; }
    }
}
