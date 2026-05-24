using BookingSystem.Core.Entities;

namespace BookingSystem.Core.Interfaces;

public interface ILookupRepository
{
    Task<IEnumerable<ServiceArea>> GetAreasAsync();
    Task<IEnumerable<TimeSlot>> GetTimeSlotsAsync();
}
