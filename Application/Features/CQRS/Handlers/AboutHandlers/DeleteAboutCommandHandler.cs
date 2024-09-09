namespace Application.Features.CQRS.Handlers.AboutHandlers;

public class DeleteAboutCommandHandler
{
    private readonly IAboutRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAboutCommandHandler(IAboutRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteAboutCommand command)
    {
        var value =
            await _repository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"About with ID '{command.Id}' was not found.");

        _repository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
