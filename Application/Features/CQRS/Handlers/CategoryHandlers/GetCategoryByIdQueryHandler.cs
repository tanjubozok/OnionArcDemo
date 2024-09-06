namespace Application.Features.CQRS.Handlers.CategoryHandlers;

public class GetCategoryByIdQueryHandler
{
    private readonly IRepository<Category> _repository;

    public GetCategoryByIdQueryHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
    {
        var value = await _repository.GetByIdAsync(query.Id);

        return value == null
            ? throw new KeyNotFoundException($"Category with ID '{query.Id}' was not found.")
            : new GetCategoryByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name
            };
    }
}
