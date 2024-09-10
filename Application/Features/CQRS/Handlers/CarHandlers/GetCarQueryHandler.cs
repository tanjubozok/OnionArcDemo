namespace Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCarQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetCarQueryResult>> Handle()
    {
        var values = await _unitOfWork.CarRepository.GetAllAsync();

        return values.Select(x => new GetCarQueryResult
        {
            Id = x.Id,
            BigImageUrl = x.BigImageUrl,
            BrandId = x.BrandId,
            CoverImageUrl = x.CoverImageUrl,
            Fuel = x.Fuel,
            KM = x.KM,
            Luggage = x.Luggage,
            Model = x.Model,
            Seat = x.Seat,
            Transmission = x.Transmission
        }).ToList();
    }
}
