using BookingSystem.Core.Entities;

namespace BookingSystem.Core.Interfaces;

public interface IBookingRepository
{
    Task<Booking?> GetByIdAsync(int id);
    Task<Booking> CreateAsync(Booking booking);
    Task UpdateAsync(Booking booking);
}
