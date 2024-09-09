namespace Application.Features.Mediator.Handlers.CarServiceHandlers;

public class DeleteCarServiceCommandHandler : IRequestHandler<DeleteCarServiceCommand>
{
    private readonly ICarServiceRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCarServiceCommandHandler(ICarServiceRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCarServiceCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"CarService with ID '{request.Id}' was not found.");

        _repository.Delete(value);

        await _unitOfWork.SaveChangesAsync();
    }
}
