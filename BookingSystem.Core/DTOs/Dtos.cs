namespace BookingSystem.Core.DTOs;

// ── API Response Wrapper ──────────────────────────────────────────────────────
public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }

    public static ApiResponse<T> Ok(T data, string message = "Success") =>
        new() { Success = true, Message = message, Data = data };

    public static ApiResponse<T> Fail(string message) =>
        new() { Success = false, Message = message };
}

// ── Lookup ────────────────────────────────────────────────────────────────────
public class LookupDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

// ── Services ──────────────────────────────────────────────────────────────────
public class ServiceListDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

public class ServiceDetailDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string AboutText { get; set; } = string.Empty;
    public string Standard { get; set; } = string.Empty;
    public List<HotspotDto> Hotspots { get; set; } = new();
    public List<string> Checklist { get; set; } = new();
}

public class HotspotDto
{
    public string Label { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
}

// ── Booking ───────────────────────────────────────────────────────────────────
public class CreateBookingDto
{
    public int ServiceId { get; set; }
    public int ServiceAreaId { get; set; }
    public int TimeSlotId { get; set; }
    public DateTime PreferredDate { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PropertyAddress { get; set; } = string.Empty;
    public string SignatureBase64 { get; set; } = string.Empty;
}

public class BookingResultDto
{
    public int BookingId { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = string.Empty;
}

public class ConfirmPaymentDto
{
    public string GatewayName { get; set; } = string.Empty;
    public string GatewayTransactionId { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
