namespace Application.Features.Mediator.Handlers.FeatureHandlers;

public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetFeatureQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
    {
        var values = await _unitOfWork.FeatureRepository.GetAllAsync();
        return values.Select(x => new GetFeatureQueryResult
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();
    }
}
