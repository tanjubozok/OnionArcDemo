namespace Application.Features.Mediator.Handlers.CarServiceHandlers;

public class CreateCarServiceCommandHandler : IRequestHandler<CreateCarServiceCommand>
{
    private readonly ICarServiceRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCarServiceCommandHandler(ICarServiceRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateCarServiceCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new CarService
        {
            Description = request.Description,
            IconUrl = request.IconUrl,
            Title = request.Title
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
