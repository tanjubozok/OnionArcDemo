namespace Application.Features.CQRS.Handlers.CarHandlers;

public class DeleteCarCommandHandler
{
    private readonly IRepository<Car> _repository;

    public DeleteCarCommandHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteCarCommand command)
    {
        var value =
            await _repository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"Car with ID '{command.Id}' was not found.");

        await _repository.DeleteAsync(value);
    }
}
