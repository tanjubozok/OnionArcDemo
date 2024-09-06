namespace Application.Features.Mediator.Handlers.FooterAddressHandlers;

public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
{
    private readonly IRepository<FooterAddress> _repository;

    public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
    {
        _repository = repository;
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
