using Application.Abstract;
using Application.Features.CQRS.Commands.CarCommands;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers;

public class UpdateCarCommandHandler
{
    private readonly IRepository<Car> _repository;

    public UpdateCarCommandHandler(IRepository<Car> repository)
    {
        _repository = repository;
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

        await _repository.UpdateAsync(value);
    }
}
