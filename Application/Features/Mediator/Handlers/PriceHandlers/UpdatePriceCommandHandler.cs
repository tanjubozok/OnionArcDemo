namespace Application.Features.Mediator.Handlers.PriceHandlers;

public class UpdatePriceCommandHandler : IRequestHandler<UpdatePriceCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePriceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdatePriceCommand request, CancellationToken cancellationToken)
    {
        var value = await _unitOfWork.PriceRepository.GetByIdAsync(request.Id)
                   ?? throw new KeyNotFoundException($"Location with ID '{request.Id}' was not found.");

        value.Name = request.Name;

        _unitOfWork.PriceRepository.Update(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
