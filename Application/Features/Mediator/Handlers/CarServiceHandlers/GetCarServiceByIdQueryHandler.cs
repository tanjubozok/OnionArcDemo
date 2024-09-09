namespace Application.Features.Mediator.Handlers.CarServiceHandlers;

public class GetCarServiceByIdQueryHandler : IRequestHandler<GetCarServiceByIdQuery, GetCarServiceByIdQueryResult>
{
    private readonly ICarServiceRepository _repository;

    public GetCarServiceByIdQueryHandler(ICarServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetCarServiceByIdQueryResult> Handle(GetCarServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return value == null
            ? throw new KeyNotFoundException($"Location with ID '{request.Id}' was not found.")
            : new GetCarServiceByIdQueryResult
            {
                Id = value.Id,
                Description = value.Description,
                IconUrl = value.IconUrl,
                Title = value.Title,
            };
    }
}
