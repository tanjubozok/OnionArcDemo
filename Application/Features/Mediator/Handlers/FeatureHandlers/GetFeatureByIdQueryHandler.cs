namespace Application.Features.Mediator.Handlers.FeatureHandlers;

public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetFeatureByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _unitOfWork.FeatureRepository.GetByIdAsync(request.Id);
        return value == null
            ? throw new KeyNotFoundException($"Feature with ID '{request.Id}' was not found.")
            : new GetFeatureByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name
            };
    }
}
