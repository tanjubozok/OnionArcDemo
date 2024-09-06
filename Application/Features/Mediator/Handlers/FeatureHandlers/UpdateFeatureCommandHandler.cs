namespace Application.Features.Mediator.Handlers.FeatureHandlers;

public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
{
    private readonly IRepository<Feature> _repository;

    public UpdateFeatureCommandHandler(IRepository<Feature> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
    {
        var value =
           await _repository.GetByIdAsync(request.Id)
           ?? throw new KeyNotFoundException($"Feature with ID '{request.Id}' was not found.");

        value.Name = request.Name;

        await _repository.UpdateAsync(value);
    }
}
