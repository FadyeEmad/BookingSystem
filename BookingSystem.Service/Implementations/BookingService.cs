using BookingSystem.Core.DTOs;
using BookingSystem.Core.Entities;
using BookingSystem.Core.Interfaces;

namespace BookingSystem.Service.Implementations;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _repo;
    private readonly IServiceRepository _serviceRepo;

    public BookingService(IBookingRepository repo, IServiceRepository serviceRepo)
    {
        _repo = repo;
        _serviceRepo = serviceRepo;
    }

    public async Task<BookingResultDto> CreateAsync(CreateBookingDto dto)
    {
        // جيب السعر من الـ service
        var service = await _serviceRepo.GetByIdWithDetailsAsync(dto.ServiceId)
            ?? throw new Exception("Service not found");

        // احفظ الـ signature
        var signatureUrl = await SaveSignatureAsync(dto.SignatureBase64);

        var booking = new Booking
        {
            ServiceId = dto.ServiceId,
            ServiceAreaId = dto.ServiceAreaId,
            TimeSlotId = dto.TimeSlotId,
            PreferredDate = dto.PreferredDate,
            FullName = dto.FullName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            PropertyAddress = dto.PropertyAddress,
            SignatureImageUrl = signatureUrl,
            Status = "Pending",
            TotalAmount = service.Price,
            CreatedAt = DateTime.UtcNow
        };

        await _repo.CreateAsync(booking);

        return new BookingResultDto
        {
            BookingId = booking.Id,
            TotalAmount = booking.TotalAmount,
            Status = booking.Status
        };
    }

    public async Task<bool> ConfirmPaymentAsync(int bookingId, ConfirmPaymentDto dto)
    {
        var booking = await _repo.GetByIdAsync(bookingId);
        if (booking == null) return false;

        booking.Status = "Confirmed";
        booking.Payment = new Payment
        {
            BookingId = bookingId,
            GatewayName = dto.GatewayName,
            GatewayTransactionId = dto.GatewayTransactionId,
            Amount = dto.Amount,
            Status = "Paid",
            CreatedAt = DateTime.UtcNow
        };

        await _repo.UpdateAsync(booking);
        return true;
    }

    public Task<byte[]> GeneratePdfAsync(int bookingId)
    {
        // TODO: Phase 7 — QuestPDF
        throw new NotImplementedException();
    }

    private async Task<string> SaveSignatureAsync(string base64)
    {
        if (string.IsNullOrEmpty(base64)) return string.Empty;

        var bytes = Convert.FromBase64String(base64.Split(',').Last());
        var fileName = $"{Guid.NewGuid()}.png";
        var folderPath = Path.Combine("wwwroot", "signatures");
        Directory.CreateDirectory(folderPath);
        var filePath = Path.Combine(folderPath, fileName);
        await File.WriteAllBytesAsync(filePath, bytes);

        return $"/signatures/{fileName}";
    }
}
