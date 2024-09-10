namespace Application.Features.Mediator.Handlers.LocationHandlers;

public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteLocationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var value =
            await _unitOfWork.LocationRepository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"Location with ID '{request.Id}' was not found.");

        _unitOfWork.LocationRepository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
