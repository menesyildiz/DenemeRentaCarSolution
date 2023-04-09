using System.ComponentModel.DataAnnotations;

namespace DenemeRentaCar.Entities
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
    }
}
