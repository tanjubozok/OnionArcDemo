namespace Application.Features.Mediator.Handlers.FooterAddressHandlers;

public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand>
{
    private readonly IFooterAddressRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFooterAddressCommandHandler(IFooterAddressRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new FooterAddress
        {
            Phone = request.Phone,
            Address = request.Address,
            Description = request.Description,
            Email = request.Email
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
