namespace Application.Features.CQRS.Handlers.CategoryHandlers;

public class GetCategoryByIdQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
    {
        var value = await _unitOfWork.CategoryRepository.GetByIdAsync(query.Id);

        return value == null
            ? throw new KeyNotFoundException($"Category with ID '{query.Id}' was not found.")
            : new GetCategoryByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name
            };
    }
}
