namespace Application.Features.CQRS.Handlers.ContactHandlers;

public class DeleteContactCommandHandler
{
    private readonly IRepository<Contact> _repository;

    public DeleteContactCommandHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteContactCommand command)
    {
        var value =
            await _repository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"Contact with ID '{command.Id}' was not found.");

        await _repository.DeleteAsync(value);
    }
}
