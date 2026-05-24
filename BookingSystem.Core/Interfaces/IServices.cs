using BookingSystem.Core.DTOs;

namespace BookingSystem.Core.Interfaces;

public interface IServiceService
{
    Task<IEnumerable<ServiceListDto>> GetAllAsync();
    Task<ServiceDetailDto?> GetByIdAsync(int id);
}

public interface IBookingService
{
    Task<BookingResultDto> CreateAsync(CreateBookingDto dto);
    Task<bool> ConfirmPaymentAsync(int bookingId, ConfirmPaymentDto dto);
    Task<byte[]> GeneratePdfAsync(int bookingId);
}

public interface ILookupService
{
    Task<IEnumerable<LookupDto>> GetAreasAsync();
    Task<IEnumerable<LookupDto>> GetTimeSlotsAsync();
}
