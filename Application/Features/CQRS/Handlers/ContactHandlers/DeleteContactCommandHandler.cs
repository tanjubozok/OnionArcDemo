namespace Application.Features.CQRS.Handlers.ContactHandlers;

public class DeleteContactCommandHandler
{
    private readonly IContactRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteContactCommandHandler(IContactRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteContactCommand command)
    {
        var value =
            await _repository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"Contact with ID '{command.Id}' was not found.");

        _repository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
