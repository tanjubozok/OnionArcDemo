namespace Application.Features.Mediator.Handlers.FeatureHandlers;

public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
{
    private readonly IFeatureRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFeatureCommandHandler(IFeatureRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Feature
        {
            Name = request.Name
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
