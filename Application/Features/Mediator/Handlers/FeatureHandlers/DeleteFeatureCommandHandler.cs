namespace Application.Features.Mediator.Handlers.FeatureHandlers;

public class DeleteFeatureCommandHandler : IRequestHandler<DeleteFeatureCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFeatureCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteFeatureCommand request, CancellationToken cancellationToken)
    {
        var value =
            await _unitOfWork.FeatureRepository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"Feature with ID '{request.Id}' was not found.");

        _unitOfWork.FeatureRepository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
