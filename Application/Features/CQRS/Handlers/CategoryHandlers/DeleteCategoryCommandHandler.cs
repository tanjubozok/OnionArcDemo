namespace Application.Features.CQRS.Handlers.CategoryHandlers;

public class DeleteCategoryCommandHandler
{
    private readonly ICategoryRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryCommandHandler(ICategoryRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCategoryCommand command)
    {
        var value =
            await _repository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"Category with ID '{command.Id}' was not found.");

        _repository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
