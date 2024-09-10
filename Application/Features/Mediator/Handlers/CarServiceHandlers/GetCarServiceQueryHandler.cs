namespace Application.Features.Mediator.Handlers.CarServiceHandlers;

public class GetCarServiceQueryHandler : IRequestHandler<GetCarServiceQuery, List<GetCarServiceQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCarServiceQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetCarServiceQueryResult>> Handle(GetCarServiceQuery request, CancellationToken cancellationToken)
    {
        var values = await _unitOfWork.CarServiceRepository.GetAllAsync();
        return values.Select(x => new GetCarServiceQueryResult
        {
            Title = x.Title,
            Description = x.Description,
            IconUrl = x.IconUrl,
            Id = x.Id,
        }).ToList();
    }
}
