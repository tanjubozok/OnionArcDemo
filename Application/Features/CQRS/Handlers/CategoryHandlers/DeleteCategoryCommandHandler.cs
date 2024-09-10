namespace Application.Features.CQRS.Handlers.CategoryHandlers;

public class DeleteCategoryCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCategoryCommand command)
    {
        var value =
            await _unitOfWork.CategoryRepository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"Category with ID '{command.Id}' was not found.");

        _unitOfWork.CategoryRepository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
