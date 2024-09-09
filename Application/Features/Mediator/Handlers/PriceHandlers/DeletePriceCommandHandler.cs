namespace Application.Features.Mediator.Handlers.PriceHandlers;

public class DeletePriceCommandHandler : IRequestHandler<DeletePriceCommand>
{
    private readonly IPriceRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePriceCommandHandler(IPriceRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeletePriceCommand request, CancellationToken cancellationToken)
    {
        var value =
            await _repository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"Price with ID '{request.Id}' was not found.");

        _repository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
