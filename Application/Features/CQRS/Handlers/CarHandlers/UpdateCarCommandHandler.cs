namespace Application.Features.CQRS.Handlers.CarHandlers;

public class UpdateCarCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCarCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCarCommand command)
    {
        var value =
            await _unitOfWork.CarRepository.GetByIdAsync(command.Id)
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

        _unitOfWork.CarRepository.Update(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
