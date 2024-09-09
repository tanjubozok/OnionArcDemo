namespace Application.Features.Mediator.Handlers.FeatureHandlers;

public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
{
    private readonly IFeatureRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFeatureCommandHandler(IFeatureRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
    {
        var value =
           await _repository.GetByIdAsync(request.Id)
           ?? throw new KeyNotFoundException($"Feature with ID '{request.Id}' was not found.");

        value.Name = request.Name;

        _repository.Update(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
