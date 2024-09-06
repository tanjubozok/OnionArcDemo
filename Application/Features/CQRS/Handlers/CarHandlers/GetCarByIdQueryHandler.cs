namespace Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarByIdQueryHandler
{
    private readonly IRepository<Car> _repository;

    public GetCarByIdQueryHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
    {
        var value = await _repository.GetByIdAsync(query.Id);

        return value == null
            ? throw new KeyNotFoundException($"Car with ID '{query.Id}' was not found.")
            : new GetCarByIdQueryResult
            {
                Id = value.Id,
                BigImageUrl = value.BigImageUrl,
                BrandId = value.BrandId,
                CoverImageUrl = value.CoverImageUrl,
                Fuel = value.Fuel,
                KM = value.KM,
                Luggage = value.Luggage,
                Model = value.Model,
                Seat = value.Seat,
                Transmission = value.Transmission
            };
    }
}
