namespace Application.Features.CQRS.Handlers.ContactHandlers;

public class DeleteContactCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteContactCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteContactCommand command)
    {
        var value =
            await _unitOfWork.ContactRepository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"Contact with ID '{command.Id}' was not found.");

        _unitOfWork.ContactRepository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
