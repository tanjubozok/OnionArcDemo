namespace Application.Features.Mediator.Handlers.PriceHandlers;

public class GetPriceByIdQueryHandler : IRequestHandler<GetPriceByIdQuery, GetPriceByIdQueryResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPriceByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetPriceByIdQueryResult> Handle(GetPriceByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _unitOfWork.PriceRepository.GetByIdAsync(request.Id);
        return value == null
            ? throw new KeyNotFoundException($"Location with ID '{request.Id}' was not found.")
            : new GetPriceByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name,
            };
    }
}
