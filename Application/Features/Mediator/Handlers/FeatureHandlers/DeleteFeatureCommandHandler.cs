namespace Application.Features.Mediator.Handlers.FeatureHandlers;

public class DeleteFeatureCommandHandler : IRequestHandler<DeleteFeatureCommand>
{
    private readonly IRepository<Feature> _repository;

    public DeleteFeatureCommandHandler(IRepository<Feature> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteFeatureCommand request, CancellationToken cancellationToken)
    {
        var value =
            await _repository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"Feature with ID '{request.Id}' was not found.");

        await _repository.DeleteAsync(value);
    }
}
