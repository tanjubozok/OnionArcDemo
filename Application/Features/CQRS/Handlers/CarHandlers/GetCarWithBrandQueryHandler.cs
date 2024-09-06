namespace Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarWithBrandQueryHandler
{
    private readonly ICarRepository _carRepository;

    public GetCarWithBrandQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<List<GetCarWithBrandQueryResult>> Handle()
    {
        var values = await _carRepository.GetCarWithBrandListAsync();
        return values.Select(x => new GetCarWithBrandQueryResult
        {
            Id = x.Id,
            BigImageUrl = x.BigImageUrl,
            BrandId = x.BrandId,
            BrandName = x.Brand.Name,
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
