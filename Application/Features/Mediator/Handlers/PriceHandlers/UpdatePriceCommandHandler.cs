namespace Application.Features.Mediator.Handlers.PriceHandlers;

public class UpdatePriceCommandHandler : IRequestHandler<UpdatePriceCommand>
{
    private readonly IPriceRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePriceCommandHandler(IPriceRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdatePriceCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id)
                   ?? throw new KeyNotFoundException($"Location with ID '{request.Id}' was not found.");

        value.Name = request.Name;

         _repository.Update(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
