namespace Application.Features.CQRS.Handlers.CarHandlers;

public class DeleteCarCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCarCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCarCommand command)
    {
        var value =
            await _unitOfWork.CarRepository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"Car with ID '{command.Id}' was not found.");

        _unitOfWork.CarRepository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
