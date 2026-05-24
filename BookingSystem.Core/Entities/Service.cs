namespace BookingSystem.Core.Entities;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public ServiceDetail? ServiceDetail { get; set; }
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
