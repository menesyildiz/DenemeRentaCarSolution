using System.ComponentModel.DataAnnotations;

namespace DenemeRentaCar.Entities
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Plate { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Passengers { get; set; }
        [Required]
        [StringLength(20)]
        public string HasDriver { get; set; }
        [Required]
        [StringLength(20)]
        public string Category { get; set; }
        [Required]
        [StringLength(20)]
        public string Year { get; set; }
        [Required]
        [StringLength(20)]
        public string Price { get; set; }
        public bool Rented { get; set; }

        public DateTime? RentDate { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public Gearbox Gearbox { get; set; }
        public int GearboxId { get; set; }
        public Fuel Fuel { get; set; }
        public int FuelId { get; set; }
        public Colour Colour { get; set; }
        public int ColourId { get; set; }

        //public Customer? Customer { get; set; }
        //public int CustomerId { get; set; }

    }
}
