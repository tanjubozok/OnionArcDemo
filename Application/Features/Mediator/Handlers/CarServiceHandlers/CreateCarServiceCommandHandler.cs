namespace Application.Features.Mediator.Handlers.CarServiceHandlers;

public class CreateCarServiceCommandHandler : IRequestHandler<CreateCarServiceCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCarServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateCarServiceCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CarServiceRepository.CreateAsync(new CarService
        {
            Description = request.Description,
            IconUrl = request.IconUrl,
            Title = request.Title
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
