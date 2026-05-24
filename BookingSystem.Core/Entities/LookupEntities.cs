namespace BookingSystem.Core.Entities;

public class ServiceArea
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}

public class TimeSlot
{
    public int Id { get; set; }
    public string Label { get; set; } = string.Empty;

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
