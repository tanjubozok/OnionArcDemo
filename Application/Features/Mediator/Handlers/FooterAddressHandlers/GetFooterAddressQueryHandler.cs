namespace Application.Features.Mediator.Handlers.FooterAddressHandlers;

public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetFooterAddressQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
    {
        var values = await _unitOfWork.FooterAddressRepository.GetAllAsync();
        return values.Select(x => new GetFooterAddressQueryResult
        {
            Address = x.Address,
            Description = x.Description,
            Email = x.Email,
            Id = x.Id,
            Phone = x.Phone
        }).ToList();
    }
}
