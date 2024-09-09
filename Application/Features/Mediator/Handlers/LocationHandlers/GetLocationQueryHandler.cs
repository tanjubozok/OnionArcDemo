namespace Application.Features.Mediator.Handlers.LocationHandlers;

public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
{
    private readonly ILocationRepository _repository;

    public GetLocationQueryHandler(ILocationRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetLocationQueryResult
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();
    }
}
