namespace Application.Features.Mediator.Handlers.PriceHandlers;

public class GetPriceQueryHandler : IRequestHandler<GetPriceQuery, List<GetPriceQueryResult>>
{
    private readonly IRepository<Price> _repository;

    public GetPriceQueryHandler(IRepository<Price> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetPriceQueryResult>> Handle(GetPriceQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetPriceQueryResult
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();
    }
}
