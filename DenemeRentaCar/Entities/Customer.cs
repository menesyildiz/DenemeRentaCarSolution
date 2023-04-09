using System.ComponentModel.DataAnnotations;

namespace DenemeRentaCar.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
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
