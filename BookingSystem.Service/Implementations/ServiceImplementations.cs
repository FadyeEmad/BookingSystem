using BookingSystem.Core.DTOs;
using BookingSystem.Core.Entities;
using BookingSystem.Core.Interfaces;

namespace BookingSystem.Service.Implementations;

public class ServiceService : IServiceService
{
    private readonly IServiceRepository _repo;
    public ServiceService(IServiceRepository repo) => _repo = repo;

    public async Task<IEnumerable<ServiceListDto>> GetAllAsync()
    {
        var services = await _repo.GetAllAsync();
        return services.Select(s => new ServiceListDto
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            Price = s.Price
        });
    }

    public async Task<ServiceDetailDto?> GetByIdAsync(int id)
    {
        var service = await _repo.GetByIdWithDetailsAsync(id);
        if (service == null) return null;

        return new ServiceDetailDto
        {
            Id = service.Id,
            Name = service.Name,
            Description = service.Description,
            Price = service.Price,
            AboutText = service.ServiceDetail?.AboutText ?? string.Empty,
            Standard = service.ServiceDetail?.Standard ?? string.Empty,
            Hotspots = service.ServiceDetail?.Hotspots.Select(h => new HotspotDto
            {
                Label = h.Label,
                Severity = h.Severity
            }).ToList() ?? new(),
            Checklist = service.ServiceDetail?.ChecklistItems
                .Select(c => c.Text).ToList() ?? new()
        };
    }
}

public class LookupService : ILookupService
{
    private readonly ILookupRepository _repo;
    public LookupService(ILookupRepository repo) => _repo = repo;

    public async Task<IEnumerable<LookupDto>> GetAreasAsync()
    {
        var areas = await _repo.GetAreasAsync();
        return areas.Select(a => new LookupDto { Id = a.Id, Name = a.Name });
    }

    public async Task<IEnumerable<LookupDto>> GetTimeSlotsAsync()
    {
        var slots = await _repo.GetTimeSlotsAsync();
        return slots.Select(s => new LookupDto { Id = s.Id, Name = s.Label });
    }
}
