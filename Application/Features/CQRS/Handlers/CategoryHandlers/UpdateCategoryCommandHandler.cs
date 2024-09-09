namespace Application.Features.CQRS.Handlers.CategoryHandlers;

public class UpdateCategoryCommandHandler
{
    private readonly ICategoryRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(ICategoryRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCategoryCommand command)
    {
        var result =
           await _repository.GetByIdAsync(command.Id)
           ?? throw new KeyNotFoundException($"Car with ID '{command.Id}' was not found.");

        result.Name = command.Name;

        _repository.Update(result);
        await _unitOfWork.SaveChangesAsync();
    }
}
