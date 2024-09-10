namespace Application.Features.CQRS.Handlers.CategoryHandlers;

public class CreateCategoryCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateCategoryCommand command)
    {
        await _unitOfWork.CategoryRepository.CreateAsync(new Category
        {
            Name = command.Name
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
