namespace Application.Features.Mediator.Handlers.FooterAddressHandlers;

public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFooterAddressCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
    {
        var value =
           await _unitOfWork.FooterAddressRepository.GetByIdAsync(request.Id)
           ?? throw new KeyNotFoundException($"FooterAddress with ID '{request.Id}' was not found.");

        value.Description = request.Description;
        value.Address = request.Address;
        value.Phone = request.Phone;
        value.Email = request.Email;

        _unitOfWork.FooterAddressRepository.Update(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
