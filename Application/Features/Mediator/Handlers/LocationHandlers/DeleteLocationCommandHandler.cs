namespace Application.Features.Mediator.Handlers.LocationHandlers;

public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand>
{
    private readonly ILocationRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteLocationCommandHandler(ILocationRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var value =
            await _repository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"Location with ID '{request.Id}' was not found.");

        _repository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
