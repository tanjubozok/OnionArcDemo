namespace Application.Features.CQRS.Handlers.AboutHandlers;

public class UpdateAboutCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAboutCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateAboutCommand command)
    {
        var values =
            await _unitOfWork.AboutRepository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"About with ID '{command.Id}' was not found.");

        values.Description = command.Description;
        values.Title = command.Title;
        values.ImageUrl = command.ImageUrl;

        _unitOfWork.AboutRepository.Update(values);
        await _unitOfWork.SaveChangesAsync();
    }
}
