namespace Application.Features.Mediator.Handlers.FeatureHandlers;

public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFeatureCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
    {
        var value =
           await _unitOfWork.FeatureRepository.GetByIdAsync(request.Id)
           ?? throw new KeyNotFoundException($"Feature with ID '{request.Id}' was not found.");

        value.Name = request.Name;

        _unitOfWork.FeatureRepository.Update(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
