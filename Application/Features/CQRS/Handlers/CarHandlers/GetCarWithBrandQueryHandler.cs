namespace Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarWithBrandQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCarWithBrandQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetCarWithBrandQueryResult>> Handle()
    {
        var values = await _unitOfWork.CarRepository.GetCarWithBrandListAsync();
        return values.Select(x => new GetCarWithBrandQueryResult
        {
            Id = x.Id,
            BigImageUrl = x.BigImageUrl,
            BrandId = x.BrandId,
            BrandName = x.Brand!.Name,
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
