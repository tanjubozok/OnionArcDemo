namespace Application.Features.Mediator.Handlers.FooterAddressHandlers;

public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetFooterAddressByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _unitOfWork.FooterAddressRepository.GetByIdAsync(request.Id);
        return value == null
            ? throw new KeyNotFoundException($"FooterAddress with ID '{request.Id}' was not found.")
            : new GetFooterAddressByIdQueryResult
            {
                Address = value.Address,
                Description = value.Description,
                Email = value.Email,
                Id = value.Id,
                Phone = value.Phone
            };
    }
}
