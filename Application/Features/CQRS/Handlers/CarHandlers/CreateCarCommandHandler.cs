namespace Application.Features.CQRS.Handlers.CarHandlers;

public class CreateCarCommandHandler
{
    private readonly IRepository<Car> _repository;

    public CreateCarCommandHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateCarCommand command)
    {
        await _repository.CreateAsync(new Car
        {
            BigImageUrl = command.BigImageUrl,
            BrandId = command.BrandId,
            CoverImageUrl = command.CoverImageUrl,
            Fuel = command.Fuel,
            KM = command.KM,
            Luggage = command.Luggage,
            Model = command.Model,
            Seat = command.Seat,
            Transmission = command.Transmission
        });
    }
}