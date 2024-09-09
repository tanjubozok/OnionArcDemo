namespace Application.Features.Mediator.Handlers.FeatureHandlers;

public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
{
    private readonly IFeatureRepository _repository;

    public GetFeatureQueryHandler(IFeatureRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetFeatureQueryResult
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();
    }
}
