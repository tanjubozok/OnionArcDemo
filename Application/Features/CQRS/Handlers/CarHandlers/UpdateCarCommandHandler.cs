namespace Application.Features.CQRS.Handlers.CarHandlers;

public class UpdateCarCommandHandler
{
    private readonly ICarRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCarCommandHandler(ICarRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCarCommand command)
    {
        var value =
            await _repository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"Car with ID '{command.Id}' was not found.");

        value.KM = command.KM;
        value.Fuel = command.Fuel;
        value.Transmission = command.Transmission;
        value.Luggage = command.Luggage;
        value.Seat = command.Seat;
        value.BigImageUrl = command.BigImageUrl;
        value.BrandId = command.BrandId;
        value.Model = command.Model;
        value.CoverImageUrl = command.CoverImageUrl;

        _repository.Update(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
