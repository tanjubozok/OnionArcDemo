namespace Application.Features.CQRS.Handlers.ContactHandlers;

public class CreateContactCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateContactCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateContactCommand command)
    {
        await _unitOfWork.ContactRepository.CreateAsync(new Contact
        {
            Email = command.Email,
            Message = command.Message,
            Name = command.Name,
            SendDate = command.SendDate,
            Subject = command.Subject
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
