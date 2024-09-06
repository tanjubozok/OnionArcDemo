namespace Application.Features.Mediator.Handlers.LocationHandlers;

public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
{
    private readonly IRepository<Location> _repository;

    public UpdateLocationCommandHandler(IRepository<Location> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id)
           ?? throw new KeyNotFoundException($"Location with ID '{request.Id}' was not found.");

        value.Name = request.Name;

        await _repository.UpdateAsync(value);
    }
}
