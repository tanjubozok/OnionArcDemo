namespace Application.Features.CQRS.Handlers.ContactHandlers;

public class UpdateContactCommandHandler
{
    private readonly IContactRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateContactCommandHandler(IContactRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
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

        _repository.Update(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
