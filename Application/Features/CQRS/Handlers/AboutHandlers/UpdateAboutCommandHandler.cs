namespace Application.Features.CQRS.Handlers.AboutHandlers;

public class UpdateAboutCommandHandler
{
    private readonly IAboutRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAboutCommandHandler(IAboutRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateAboutCommand command)
    {
        var values =
            await _repository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"About with ID '{command.Id}' was not found.");

        values.Description = command.Description;
        values.Title = command.Title;
        values.ImageUrl = command.ImageUrl;

        _repository.Update(values);
        await _unitOfWork.SaveChangesAsync();
    }
}
