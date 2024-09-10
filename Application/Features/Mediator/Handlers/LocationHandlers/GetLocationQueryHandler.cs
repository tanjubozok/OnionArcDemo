namespace Application.Features.Mediator.Handlers.LocationHandlers;

public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetLocationQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
    {
        var values = await _unitOfWork.LocationRepository.GetAllAsync();
        return values.Select(x => new GetLocationQueryResult
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();
    }
}
