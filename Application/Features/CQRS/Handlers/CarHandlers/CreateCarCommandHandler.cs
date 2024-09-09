namespace Application.Features.CQRS.Handlers.CarHandlers;

public class CreateCarCommandHandler
{
    private readonly ICarRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCarCommandHandler(ICarRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
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

        await _unitOfWork.SaveChangesAsync();
    }
}