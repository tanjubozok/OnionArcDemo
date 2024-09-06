namespace Application.Features.Mediator.Handlers.FeatureHandlers;

public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
{
    private readonly IRepository<Feature> _repository;

    public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
    {
        _repository = repository;
    }

    public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return value == null
            ? throw new KeyNotFoundException($"Feature with ID '{request.Id}' was not found.")
            : new GetFeatureByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name
            };
    }
}
