namespace Application.Features.Mediator.Handlers.CarServiceHandlers;

public class DeleteCarServiceCommandHandler : IRequestHandler<DeleteCarServiceCommand>
{
    private readonly IRepository<CarService> _repository;

    public DeleteCarServiceCommandHandler(IRepository<CarService> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteCarServiceCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"CarService with ID '{request.Id}' was not found.");

        await _repository.DeleteAsync(value);
    }
}
