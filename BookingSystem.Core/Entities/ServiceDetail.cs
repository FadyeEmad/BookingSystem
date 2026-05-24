namespace BookingSystem.Core.Entities;

public class ServiceDetail
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public string AboutText { get; set; } = string.Empty;
    public string Standard { get; set; } = string.Empty;

    public Service Service { get; set; } = null!;
    public ICollection<ServiceHotspot> Hotspots { get; set; } = new List<ServiceHotspot>();
    public ICollection<ServiceChecklistItem> ChecklistItems { get; set; } = new List<ServiceChecklistItem>();
}
