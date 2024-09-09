namespace Application.Features.Mediator.Handlers.PriceHandlers;

public class CreatePriceCommandHandler : IRequestHandler<CreatePriceCommand>
{
    private readonly IPriceRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePriceCommandHandler(IPriceRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreatePriceCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Price
        {
            Name = request.Name,
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
