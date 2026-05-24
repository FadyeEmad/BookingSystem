using BookingSystem.Core.Entities;
using BookingSystem.Core.Interfaces;
using BookingSystem.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Repository.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly AppDbContext _context;
    public ServiceRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Service>> GetAllAsync() =>
        await _context.Services.ToListAsync();

    public async Task<Service?> GetByIdWithDetailsAsync(int id) =>
        await _context.Services
            .Include(s => s.ServiceDetail)
                .ThenInclude(d => d!.Hotspots)
            .Include(s => s.ServiceDetail)
                .ThenInclude(d => d!.ChecklistItems.OrderBy(c => c.OrderIndex))
            .FirstOrDefaultAsync(s => s.Id == id);
}

public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext _context;
    public BookingRepository(AppDbContext context) => _context = context;

    public async Task<Booking?> GetByIdAsync(int id) =>
        await _context.Bookings
            .Include(b => b.Service)
            .Include(b => b.ServiceArea)
            .Include(b => b.TimeSlot)
            .Include(b => b.Payment)
            .FirstOrDefaultAsync(b => b.Id == id);

    public async Task<Booking> CreateAsync(Booking booking)
    {
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
        return booking;
    }

    public async Task UpdateAsync(Booking booking)
    {
        _context.Bookings.Update(booking);
        await _context.SaveChangesAsync();
    }
}

public class LookupRepository : ILookupRepository
{
    private readonly AppDbContext _context;
    public LookupRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<ServiceArea>> GetAreasAsync() =>
        await _context.ServiceAreas.ToListAsync();

    public async Task<IEnumerable<TimeSlot>> GetTimeSlotsAsync() =>
        await _context.TimeSlots.ToListAsync();
}
