namespace Application.Features.Mediator.Handlers.FeatureHandlers;

public class DeleteFeatureCommandHandler : IRequestHandler<DeleteFeatureCommand>
{
    private readonly IFeatureRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFeatureCommandHandler(IFeatureRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteFeatureCommand request, CancellationToken cancellationToken)
    {
        var value =
            await _repository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"Feature with ID '{request.Id}' was not found.");

        _repository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
