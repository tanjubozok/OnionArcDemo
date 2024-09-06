namespace Application.Features.CQRS.Handlers.ContactHandlers;

public class UpdateContactCommandHandler
{
    private readonly IRepository<Contact> _repository;

    public UpdateContactCommandHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateContactCommand command)
    {
        var value =
           await _repository.GetByIdAsync(command.Id)
           ?? throw new KeyNotFoundException($"Contact with ID '{command.Id}' was not found.");

        value.SendDate = command.SendDate;
        value.Subject = command.Subject;
        value.Email = command.Email;
        value.Name = command.Name;
        value.Message = command.Message;

        await _repository.UpdateAsync(value);
    }
}
