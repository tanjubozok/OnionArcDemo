namespace Application.Features.Mediator.Handlers.LocationHandlers;

public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetLocationByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _unitOfWork.LocationRepository.GetByIdAsync(request.Id);
        return value == null
            ? throw new KeyNotFoundException($"Location with ID '{request.Id}' was not found.")
            : new GetLocationByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name
            };
    }
}
