namespace Application.Features.Mediator.Handlers.LocationHandlers;

public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand>
{
    private readonly IRepository<Location> _repository;

    public DeleteLocationCommandHandler(IRepository<Location> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var value =
            await _repository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"Location with ID '{request.Id}' was not found.");

        await _repository.DeleteAsync(value);
    }
}
