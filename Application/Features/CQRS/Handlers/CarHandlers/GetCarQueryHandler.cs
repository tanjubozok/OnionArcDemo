namespace Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarQueryHandler
{
    private readonly ICarRepository _repository;

    public GetCarQueryHandler(ICarRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetCarQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();

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
