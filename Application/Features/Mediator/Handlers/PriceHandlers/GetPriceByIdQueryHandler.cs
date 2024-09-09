namespace Application.Features.Mediator.Handlers.PriceHandlers;

public class GetPriceByIdQueryHandler : IRequestHandler<GetPriceByIdQuery, GetPriceByIdQueryResult>
{
    private readonly IPriceRepository _repository;

    public GetPriceByIdQueryHandler(IPriceRepository repository)
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
