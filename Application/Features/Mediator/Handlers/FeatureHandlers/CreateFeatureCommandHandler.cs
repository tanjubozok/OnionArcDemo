namespace Application.Features.Mediator.Handlers.FeatureHandlers;

public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateFeatureCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.FeatureRepository.CreateAsync(new Feature
        {
            Name = request.Name
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
