namespace Application.Features.Mediator.Handlers.CarServiceHandlers;

public class UpdateCarServiceCommandHandler : IRequestHandler<UpdateCarServiceCommand>
{
    private readonly ICarServiceRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCarServiceCommandHandler(ICarServiceRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCarServiceCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"CarService with ID '{request.Id}' was not found.");

        value.Description = request.Description;
        value.Title = request.Title;
        value.IconUrl = request.IconUrl;

        _repository.Update(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
