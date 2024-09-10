namespace Application.Features.Mediator.Handlers.FooterAddressHandlers;

public class DeleteFooterAddressCommandHandler : IRequestHandler<DeleteFooterAddressCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFooterAddressCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteFooterAddressCommand request, CancellationToken cancellationToken)
    {
        var value =
            await _unitOfWork.FooterAddressRepository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"FooterAddress with ID '{request.Id}' was not found.");

        _unitOfWork.FooterAddressRepository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}