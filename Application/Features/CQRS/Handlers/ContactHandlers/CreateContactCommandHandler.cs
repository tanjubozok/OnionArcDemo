namespace Application.Features.CQRS.Handlers.ContactHandlers;

public class CreateContactCommandHandler
{
    private readonly IContactRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateContactCommandHandler(IContactRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateContactCommand command)
    {
        await _repository.CreateAsync(new Contact
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
