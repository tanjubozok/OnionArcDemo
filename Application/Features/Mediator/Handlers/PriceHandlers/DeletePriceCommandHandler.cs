namespace Application.Features.Mediator.Handlers.PriceHandlers;

public class DeletePriceCommandHandler : IRequestHandler<DeletePriceCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePriceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeletePriceCommand request, CancellationToken cancellationToken)
    {
        var value =
            await _unitOfWork.PriceRepository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"Price with ID '{request.Id}' was not found.");

        _unitOfWork.PriceRepository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
