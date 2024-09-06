namespace Application.Features.Mediator.Handlers.CarServiceHandlers;

public class UpdateCarServiceCommandHandler : IRequestHandler<UpdateCarServiceCommand>
{
    private readonly IRepository<CarService> _repository;

    public UpdateCarServiceCommandHandler(IRepository<CarService> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCarServiceCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"CarService with ID '{request.Id}' was not found.");

        value.Description = request.Description;
        value.Title = request.Title;
        value.IconUrl = request.IconUrl;

        await _repository.UpdateAsync(value);
    }
}
