namespace Application.Features.Mediator.Handlers.LocationHandlers;

public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
{
    private readonly ILocationRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateLocationCommandHandler(ILocationRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Location
        {
            Name = request.Name,
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
