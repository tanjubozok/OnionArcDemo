namespace Application.Features.Mediator.Handlers.PriceHandlers;

public class GetPriceByIdQueryHandler : IRequestHandler<GetPriceByIdQuery, GetPriceByIdQueryResult>
{
    private readonly IRepository<Price> _repository;

    public GetPriceByIdQueryHandler(IRepository<Price> repository)
    {
        _repository = repository;
    }

    public async Task<GetPriceByIdQueryResult> Handle(GetPriceByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return value == null
            ? throw new KeyNotFoundException($"Location with ID '{request.Id}' was not found.")
            : new GetPriceByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name,
            };
    }
}
