namespace Application.Features.Mediator.Handlers.CarServiceHandlers;

public class CreateCarServiceCommandHandler : IRequestHandler<CreateCarServiceCommand>
{
    private readonly IRepository<CarService> _repository;

    public CreateCarServiceCommandHandler(IRepository<CarService> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateCarServiceCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new CarService
        {
            Description = request.Description,
            IconUrl = request.IconUrl,
            Title = request.Title
        });
    }
}
