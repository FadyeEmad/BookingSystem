using BookingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Repository.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Service> Services => Set<Service>();
    public DbSet<ServiceDetail> ServiceDetails => Set<ServiceDetail>();
    public DbSet<ServiceHotspot> ServiceHotspots => Set<ServiceHotspot>();
    public DbSet<ServiceChecklistItem> ServiceChecklistItems => Set<ServiceChecklistItem>();
    public DbSet<ServiceArea> ServiceAreas => Set<ServiceArea>();
    public DbSet<TimeSlot> TimeSlots => Set<TimeSlot>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<Payment> Payments => Set<Payment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Service>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Price).HasColumnType("decimal(10,2)");
        });

        modelBuilder.Entity<ServiceDetail>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasOne(x => x.Service)
             .WithOne(s => s.ServiceDetail)
             .HasForeignKey<ServiceDetail>(x => x.ServiceId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ServiceHotspot>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasOne(x => x.ServiceDetail)
             .WithMany(sd => sd.Hotspots)
             .HasForeignKey(x => x.ServiceDetailId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ServiceChecklistItem>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasOne(x => x.ServiceDetail)
             .WithMany(sd => sd.ChecklistItems)
             .HasForeignKey(x => x.ServiceDetailId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Booking>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.TotalAmount).HasColumnType("decimal(10,2)");
            e.HasOne(x => x.Service).WithMany(s => s.Bookings)
             .HasForeignKey(x => x.ServiceId).OnDelete(DeleteBehavior.Restrict);
            e.HasOne(x => x.ServiceArea).WithMany(sa => sa.Bookings)
             .HasForeignKey(x => x.ServiceAreaId).OnDelete(DeleteBehavior.Restrict);
            e.HasOne(x => x.TimeSlot).WithMany(ts => ts.Bookings)
             .HasForeignKey(x => x.TimeSlotId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Payment>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Amount).HasColumnType("decimal(10,2)");
            e.HasOne(x => x.Booking).WithOne(b => b.Payment)
             .HasForeignKey<Payment>(x => x.BookingId)
             .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
