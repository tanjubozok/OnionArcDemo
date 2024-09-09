namespace Application.Features.Mediator.Handlers.FeatureHandlers;

public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
{
    private readonly IFeatureRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public GetFeatureByIdQueryHandler(IFeatureRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
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
