namespace Application.Features.CQRS.Handlers.AboutHandlers;

public class DeleteAboutCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAboutCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteAboutCommand command)
    {
        var value =
            await _unitOfWork.AboutRepository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"About with ID '{command.Id}' was not found.");

        _unitOfWork.AboutRepository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
