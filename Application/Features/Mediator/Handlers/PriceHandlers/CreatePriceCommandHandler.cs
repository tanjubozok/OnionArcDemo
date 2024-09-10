namespace Application.Features.Mediator.Handlers.PriceHandlers;

public class CreatePriceCommandHandler : IRequestHandler<CreatePriceCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePriceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreatePriceCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.PriceRepository.CreateAsync(new Price
        {
            Name = request.Name,
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
