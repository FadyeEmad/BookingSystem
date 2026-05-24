namespace BookingSystem.Core.Entities;

public class Booking
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public int ServiceAreaId { get; set; }
    public int TimeSlotId { get; set; }
    public DateTime PreferredDate { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PropertyAddress { get; set; } = string.Empty;
    public string SignatureImageUrl { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending";
    public decimal TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Service Service { get; set; } = null!;
    public ServiceArea ServiceArea { get; set; } = null!;
    public TimeSlot TimeSlot { get; set; } = null!;
    public Payment? Payment { get; set; }
}

public class Payment
{
    public int Id { get; set; }
    public int BookingId { get; set; }
    public string GatewayName { get; set; } = string.Empty;
    public string GatewayTransactionId { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Status { get; set; } = "Pending";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Booking Booking { get; set; } = null!;
}
