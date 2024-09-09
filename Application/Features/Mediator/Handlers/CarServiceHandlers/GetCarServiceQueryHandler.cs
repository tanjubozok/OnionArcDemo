namespace Application.Features.Mediator.Handlers.CarServiceHandlers;

public class GetCarServiceQueryHandler : IRequestHandler<GetCarServiceQuery, List<GetCarServiceQueryResult>>
{
    private readonly ICarServiceRepository _repository;

    public GetCarServiceQueryHandler(ICarServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetCarServiceQueryResult>> Handle(GetCarServiceQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetCarServiceQueryResult
        {
            Title = x.Title,
            Description = x.Description,
            IconUrl = x.IconUrl,
            Id = x.Id,
        }).ToList();
    }
}
