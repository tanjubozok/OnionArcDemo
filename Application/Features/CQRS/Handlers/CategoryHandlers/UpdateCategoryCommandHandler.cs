namespace Application.Features.CQRS.Handlers.CategoryHandlers;

public class UpdateCategoryCommandHandler
{
    private readonly IRepository<Category> _repository;

    public UpdateCategoryCommandHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCategoryCommand command)
    {
        var result =
           await _repository.GetByIdAsync(command.Id)
           ?? throw new KeyNotFoundException($"Car with ID '{command.Id}' was not found.");

        result.Name = command.Name;

        await _repository.UpdateAsync(result);
    }
}
