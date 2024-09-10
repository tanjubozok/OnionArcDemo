namespace Application.Features.CQRS.Handlers.CategoryHandlers;

public class UpdateCategoryCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCategoryCommand command)
    {
        var result =
           await _unitOfWork.CategoryRepository.GetByIdAsync(command.Id)
           ?? throw new KeyNotFoundException($"Car with ID '{command.Id}' was not found.");

        result.Name = command.Name;

        _unitOfWork.CategoryRepository.Update(result);
        await _unitOfWork.SaveChangesAsync();
    }
}
