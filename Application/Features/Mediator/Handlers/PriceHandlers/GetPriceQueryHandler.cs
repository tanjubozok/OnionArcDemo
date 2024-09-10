namespace Application.Features.Mediator.Handlers.PriceHandlers;

public class GetPriceQueryHandler : IRequestHandler<GetPriceQuery, List<GetPriceQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPriceQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetPriceQueryResult>> Handle(GetPriceQuery request, CancellationToken cancellationToken)
    {
        var values = await _unitOfWork.PriceRepository.GetAllAsync();
        return values.Select(x => new GetPriceQueryResult
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();
    }
}
