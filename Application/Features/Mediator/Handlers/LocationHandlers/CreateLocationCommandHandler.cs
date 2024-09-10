namespace Application.Features.Mediator.Handlers.LocationHandlers;

public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateLocationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.LocationRepository.CreateAsync(new Location
        {
            Name = request.Name,
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
