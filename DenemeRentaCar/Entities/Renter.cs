namespace DenemeRentaCar.Entities
{
    public class Renter
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public string? Paid { get; set; }
        public DateTime? RentDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }

    }
}
