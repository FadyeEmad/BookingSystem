using BookingSystem.Core.Entities;

namespace BookingSystem.Core.Interfaces;

public interface IServiceRepository
{
    Task<IEnumerable<Service>> GetAllAsync();
    Task<Service?> GetByIdWithDetailsAsync(int id);
}
