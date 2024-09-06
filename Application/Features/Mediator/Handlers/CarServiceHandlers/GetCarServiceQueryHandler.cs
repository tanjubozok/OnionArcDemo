namespace Application.Features.Mediator.Handlers.CarServiceHandlers;

public class GetCarServiceQueryHandler : IRequestHandler<GetCarServiceQuery, List<GetCarServiceQueryResult>>
{
    private readonly IRepository<CarService> _repository;

    public GetCarServiceQueryHandler(IRepository<CarService> repository)
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
