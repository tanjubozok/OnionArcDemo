namespace Application.Features.CQRS.Handlers.CarHandlers;

public class DeleteCarCommandHandler
{
    private readonly ICarRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCarCommandHandler(ICarRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCarCommand command)
    {
        var value =
            await _repository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"Car with ID '{command.Id}' was not found.");

        _repository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
