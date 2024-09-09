namespace Application.Features.Mediator.Handlers.FooterAddressHandlers;

public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
{
    private readonly IFooterAddressRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public GetFooterAddressQueryHandler(IFooterAddressRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
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
