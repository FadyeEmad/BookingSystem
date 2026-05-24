namespace BookingSystem.Core.Entities;

public class ServiceHotspot
{
    public int Id { get; set; }
    public int ServiceDetailId { get; set; }
    public string Label { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;

    public ServiceDetail ServiceDetail { get; set; } = null!;
}

public class ServiceChecklistItem
{
    public int Id { get; set; }
    public int ServiceDetailId { get; set; }
    public string Text { get; set; } = string.Empty;
    public int OrderIndex { get; set; }

    public ServiceDetail ServiceDetail { get; set; } = null!;
}
