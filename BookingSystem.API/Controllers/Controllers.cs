using BookingSystem.Core.DTOs;
using BookingSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers;

[ApiController]
[Route("api/services")]
public class ServicesController : ControllerBase
{
    private readonly IServiceService _service;
    private readonly ILookupService _lookup;

    public ServicesController(IServiceService service, ILookupService lookup)
    {
        _service = service;
        _lookup = lookup;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _service.GetAllAsync();
        return Ok(ApiResponse<IEnumerable<ServiceListDto>>.Ok(data));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _service.GetByIdAsync(id);
        if (data == null)
            return NotFound(ApiResponse<ServiceDetailDto>.Fail("Service not found"));

        return Ok(ApiResponse<ServiceDetailDto>.Ok(data));
    }

    [HttpGet("areas")]
    public async Task<IActionResult> GetAreas()
    {
        var data = await _lookup.GetAreasAsync();
        return Ok(ApiResponse<IEnumerable<LookupDto>>.Ok(data));
    }

    [HttpGet("timeslots")]
    public async Task<IActionResult> GetTimeSlots()
    {
        var data = await _lookup.GetTimeSlotsAsync();
        return Ok(ApiResponse<IEnumerable<LookupDto>>.Ok(data));
    }
}

[ApiController]
[Route("api/bookings")]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _service;

    public BookingsController(IBookingService service) => _service = service;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookingDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return Ok(ApiResponse<BookingResultDto>.Ok(result, "Booking created successfully"));
    }

    [HttpPost("{id}/pay")]
    public async Task<IActionResult> ConfirmPayment(int id, [FromBody] ConfirmPaymentDto dto)
    {
        var success = await _service.ConfirmPaymentAsync(id, dto);
        if (!success)
            return NotFound(ApiResponse<bool>.Fail("Booking not found"));

        return Ok(ApiResponse<bool>.Ok(true, "Payment confirmed"));
    }

    [HttpGet("{id}/pdf")]
    public async Task<IActionResult> GetPdf(int id)
    {
        var pdf = await _service.GeneratePdfAsync(id);
        return File(pdf, "application/pdf", $"booking-{id}.pdf");
    }
}
