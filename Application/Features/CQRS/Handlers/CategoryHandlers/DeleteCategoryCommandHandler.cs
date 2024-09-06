namespace Application.Features.CQRS.Handlers.CategoryHandlers;

public class DeleteCategoryCommandHandler
{
    private readonly IRepository<Category> _repository;

    public DeleteCategoryCommandHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteCategoryCommand command)
    {
        var value =
            await _repository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"Category with ID '{command.Id}' was not found.");

        await _repository.DeleteAsync(value);
    }
}
