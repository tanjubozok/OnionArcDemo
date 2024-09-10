namespace Application.Features.CQRS.Handlers.ContactHandlers;

public class UpdateContactCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateContactCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateContactCommand command)
    {
        var value =
           await _unitOfWork.ContactRepository.GetByIdAsync(command.Id)
           ?? throw new KeyNotFoundException($"Contact with ID '{command.Id}' was not found.");

        value.SendDate = command.SendDate;
        value.Subject = command.Subject;
        value.Email = command.Email;
        value.Name = command.Name;
        value.Message = command.Message;

        _unitOfWork.ContactRepository.Update(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
