using BookingSystem.Core.Entities;
using BookingSystem.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Repository.Data;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        await SeedAreasAsync(context);
        await SeedTimeSlotsAsync(context);
        await SeedServicesAsync(context);
    }

    // ── Service Areas ─────────────────────────────────────────────────────────
    private static async Task SeedAreasAsync(AppDbContext context)
    {
        if (await context.ServiceAreas.AnyAsync()) return;

        context.ServiceAreas.AddRange(
            new ServiceArea { Name = "Perth Metro" },
            new ServiceArea { Name = "Joondalup" },
            new ServiceArea { Name = "Fremantle" },
            new ServiceArea { Name = "Rockingham" },
            new ServiceArea { Name = "Mandurah" },
            new ServiceArea { Name = "Armadale" },
            new ServiceArea { Name = "Midland" },
            new ServiceArea { Name = "Canning Vale" },
            new ServiceArea { Name = "Scarborough" },
            new ServiceArea { Name = "Other WA" }
        );

        await context.SaveChangesAsync();
    }

    // ── Time Slots ────────────────────────────────────────────────────────────
    private static async Task SeedTimeSlotsAsync(AppDbContext context)
    {
        if (await context.TimeSlots.AnyAsync()) return;

        context.TimeSlots.AddRange(
            new TimeSlot { Label = "9:00 AM - 11:00 AM" },
            new TimeSlot { Label = "11:00 AM - 1:00 PM" },
            new TimeSlot { Label = "1:00 PM - 3:00 PM" },
            new TimeSlot { Label = "3:00 PM - 5:00 PM" }
        );

        await context.SaveChangesAsync();
    }

    // ── Services ──────────────────────────────────────────────────────────────
    private static async Task SeedServicesAsync(AppDbContext context)
    {
        if (await context.Services.AnyAsync()) return;

        var services = new List<Service>
        {
            // ── 1. Pre-Purchase Inspection ────────────────────────────────────
            new Service
            {
                Name = "Pre-Purchase Inspection",
                Description = "Comprehensive structural & defect assessment before you commit to a property purchase.",
                Price = 450.00m,
                ServiceDetail = new ServiceDetail
                {
                    AboutText = "Comprehensive structural & defect assessment before you commit to a property purchase. Our certified ex-builder inspectors utilize advanced drone cameras, FLIR moisture mapping, and non-invasive technologies to ensure absolute structural standard compliance.",
                    Standard = "AS 4349.1-2007 (Pre-purchase Building Inspections)",
                    Hotspots = new List<ServiceHotspot>
                    {
                        new() { Label = "Fremantle (Shifting sand erosion)", Severity = "Red" },
                        new() { Label = "Joondalup (Moderate)", Severity = "Yellow" }
                    },
                    ChecklistItems = new List<ServiceChecklistItem>
                    {
                        new() { Text = "Subfloor visual audit & structural timber dampness check", OrderIndex = 1 },
                        new() { Text = "Internal load-bearing plasterboard cracking evaluation (AS 2870)", OrderIndex = 2 },
                        new() { Text = "External double-brick weep holes & expansion joint integrity", OrderIndex = 3 },
                        new() { Text = "Roof structure sagging & ceiling frame deflection audit", OrderIndex = 4 },
                        new() { Text = "Wet area tiling seal breaches & moisture mapping with FLIR", OrderIndex = 5 }
                    }
                }
            },

            // ── 2. Pest & Termite Inspection ──────────────────────────────────
            new Service
            {
                Name = "Pest & Termite Inspection",
                Description = "Advanced thermal imaging to detect termite activity and timber pest damage throughout the property.",
                Price = 395.00m,
                ServiceDetail = new ServiceDetail
                {
                    AboutText = "Advanced thermal imaging to detect termite activity and timber pest damage throughout the property. Our certified ex-builder inspectors utilize advanced drone cameras, FLIR moisture mapping, and non-invasive technologies to ensure absolute structural standard compliance.",
                    Standard = "AS 3660.2-2017 (Termite management in existing buildings)",
                    Hotspots = new List<ServiceHotspot>
                    {
                        new() { Label = "Mandurah & Joondalup (High humidity / Mature native trees)", Severity = "Red" }
                    },
                    ChecklistItems = new List<ServiceChecklistItem>
                    {
                        new() { Text = "Active FLIR E8-XT thermal imaging sweep of internal wall linings", OrderIndex = 1 },
                        new() { Text = "High-frequency moisture detection behind potential wet areas", OrderIndex = 2 },
                        new() { Text = "Acoustic sound checking of load-bearing timber doorframes & skirting boards", OrderIndex = 3 },
                        new() { Text = "Exterior gardens, fences, & timber sleeper retaining walls audit", OrderIndex = 4 },
                        new() { Text = "Roof cavity structural timber pest screening", OrderIndex = 5 }
                    }
                }
            },

            // ── 3. Construction Stage Inspection ──────────────────────────────
            new Service
            {
                Name = "Construction Stage Inspection",
                Description = "Quality assurance checks at slab, frame, lock-up, and pre-handover stages of your build.",
                Price = 450.00m,
                ServiceDetail = new ServiceDetail
                {
                    AboutText = "Quality assurance checks at slab, frame, lock-up, and pre-handover stages of your build. Our certified ex-builder inspectors utilize advanced drone cameras, FLIR moisture mapping, and non-invasive technologies to ensure absolute structural standard compliance.",
                    Standard = "AS 2870-2011 (Residential Slabs and Footings)",
                    Hotspots = new List<ServiceHotspot>
                    {
                        new() { Label = "Canning Vale (Rapid construction soil compaction checks)", Severity = "Yellow" }
                    },
                    ChecklistItems = new List<ServiceChecklistItem>
                    {
                        new() { Text = "Slab reinforcement steel placement & concrete thickness check", OrderIndex = 1 },
                        new() { Text = "Brickwork structural cavity cleaning & wall-tie count verification", OrderIndex = 2 },
                        new() { Text = "Roof truss tie-down bracket & wind-bracing connection inspection", OrderIndex = 3 },
                        new() { Text = "Internal structural framing plumbness, leveling & expansion joints", OrderIndex = 4 },
                        new() { Text = "Pre-plaster services rough-in & acoustic lining check", OrderIndex = 5 }
                    }
                }
            },

            // ── 4. Handover Inspection ────────────────────────────────────────
            new Service
            {
                Name = "Handover Inspection",
                Description = "Detailed snagging and defect identification before taking possession of your new home.",
                Price = 495.00m,
                ServiceDetail = new ServiceDetail
                {
                    AboutText = "Detailed snagging and defect identification before taking possession of your new home. Our certified ex-builder inspectors utilize advanced drone cameras, FLIR moisture mapping, and non-invasive technologies to ensure absolute structural standard compliance.",
                    Standard = "AS 4349.0-2007 (Inspection of buildings - General requirements)",
                    Hotspots = new List<ServiceHotspot>
                    {
                        new() { Label = "Scarborough Metro (New high-density townhouse waterproofing issues)", Severity = "Red" }
                    },
                    ChecklistItems = new List<ServiceChecklistItem>
                    {
                        new() { Text = "Cabinetry, doors, & sliding window alignment & glide testing", OrderIndex = 1 },
                        new() { Text = "Narrated video walkthrough of practical completion snagging issues", OrderIndex = 2 },
                        new() { Text = "Paint finish, dry plaster surface and tile layout snag list compilation", OrderIndex = 3 },
                        new() { Text = "Roof tile flashing, downpipes, & perimeter concrete path checks", OrderIndex = 4 },
                        new() { Text = "Electrical fixtures operation & plumbing flow drainage check", OrderIndex = 5 }
                    }
                }
            },

            // ── 5. Roof Inspection ────────────────────────────────────────────
            new Service
            {
                Name = "Roof Inspection",
                Description = "Drone-assisted visual and thermal roof assessments for damage, leaks, and insulation issues.",
                Price = 350.00m,
                ServiceDetail = new ServiceDetail
                {
                    AboutText = "Drone-assisted visual and thermal roof assessments for damage, leaks, and insulation issues. Our certified ex-builder inspectors utilize advanced drone cameras, FLIR moisture mapping, and non-invasive technologies to ensure absolute structural standard compliance.",
                    Standard = "AS 3500.3 (Stormwater drainage & roof plumbing compliance)",
                    Hotspots = new List<ServiceHotspot>
                    {
                        new() { Label = "Scarborough & Fremantle (Severe coastal salt corrosion & winds)", Severity = "Red" }
                    },
                    ChecklistItems = new List<ServiceChecklistItem>
                    {
                        new() { Text = "Fenced drone aerial 4K photography mapping of tile surface fractures", OrderIndex = 1 },
                        new() { Text = "Ridge capping mortar bedding & point-up cracking audit", OrderIndex = 2 },
                        new() { Text = "Valley gutters, flashings & structural downpipe drainage capacity check", OrderIndex = 3 },
                        new() { Text = "Internal roof space insulation consistency & leakage check", OrderIndex = 4 },
                        new() { Text = "Eaves, soffit lining, & roof ventilation efficiency review", OrderIndex = 5 }
                    }
                }
            },

            // ── 6. Waterproofing Inspection ───────────────────────────────────
            new Service
            {
                Name = "Waterproofing Inspection",
                Description = "Moisture testing and waterproofing compliance checks for wet areas and balconies.",
                Price = 380.00m,
                ServiceDetail = new ServiceDetail
                {
                    AboutText = "Moisture testing and waterproofing compliance checks for wet areas and balconies. Our certified ex-builder inspectors utilize advanced drone cameras, FLIR moisture mapping, and non-invasive technologies to ensure absolute structural standard compliance.",
                    Standard = "AS 3740-2021 (Waterproofing of domestic wet areas)",
                    Hotspots = new List<ServiceHotspot>
                    {
                        new() { Label = "Scarborough (High-density apartment balconies water egress risk)", Severity = "Red" }
                    },
                    ChecklistItems = new List<ServiceChecklistItem>
                    {
                        new() { Text = "Wet area shower screen hob waterproofing bandage inspection", OrderIndex = 1 },
                        new() { Text = "Floor wastes screed fall and puddle testing (AS 3740)", OrderIndex = 2 },
                        new() { Text = "High-frequency moisture depth scanning in laundry, bath & WC", OrderIndex = 3 },
                        new() { Text = "Balcony membrane integrity, overflow drains and sealing check", OrderIndex = 4 },
                        new() { Text = "Silicone grout bead expansion joint consistency check", OrderIndex = 5 }
                    }
                }
            }
        };

        context.Services.AddRange(services);
        await context.SaveChangesAsync();
    }
}
