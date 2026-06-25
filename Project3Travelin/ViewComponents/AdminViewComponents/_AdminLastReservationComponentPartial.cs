using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Dtos.ReservationDtos;
using Project3Travelin.Services.ReservationServices;

public class _AdminLastReservationComponentPartial : ViewComponent
{
    private readonly IReservationService _reservationService;
    private readonly IMapper _mapper;

    public _AdminLastReservationComponentPartial(IReservationService reservationService, IMapper mapper)
    {
        _reservationService = reservationService;
        _mapper = mapper;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _reservationService.GetAllReservationsAsync();
        var dto = _mapper.Map<List<ResultReservationDto>>(values);
        return View(dto);
    }
}