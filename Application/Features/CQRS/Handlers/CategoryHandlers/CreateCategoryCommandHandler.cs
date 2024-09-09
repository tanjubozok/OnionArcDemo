namespace Application.Features.CQRS.Handlers.CategoryHandlers;

public class CreateCategoryCommandHandler
{
    private readonly ICategoryRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(ICategoryRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateCategoryCommand command)
    {
        await _repository.CreateAsync(new Category
        {
            Name = command.Name
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
