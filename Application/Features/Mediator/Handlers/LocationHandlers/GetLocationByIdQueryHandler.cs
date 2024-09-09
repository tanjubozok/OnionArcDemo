namespace Application.Features.Mediator.Handlers.LocationHandlers;

public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
{
    private readonly ILocationRepository _repository;

    public GetLocationByIdQueryHandler(ILocationRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return value == null
            ? throw new KeyNotFoundException($"Location with ID '{request.Id}' was not found.")
            : new GetLocationByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name
            };
    }
}
