namespace Application.Features.Mediator.Handlers.FooterAddressHandlers;

public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateFooterAddressCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.FooterAddressRepository.CreateAsync(new FooterAddress
        {
            Phone = request.Phone,
            Address = request.Address,
            Description = request.Description,
            Email = request.Email
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
