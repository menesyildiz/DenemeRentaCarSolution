using DenemeRentaCar.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DenemeRentaCar.Models
{
    public class RentModel
    {
        public DateTime? DeliveryDate { get; set; }

        public Car Car { get; set; }
        public Brand Brand { get; set; }
        public Colour Colour { get; set; }
        public Fuel Fuel { get; set; }
        public Gearbox Gearbox { get; set; }

        public int CustomerId { get; set; }
        public SelectList? Customers { get; set; }
    }
}
