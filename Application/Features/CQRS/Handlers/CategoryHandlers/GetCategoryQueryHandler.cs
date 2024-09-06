namespace Application.Features.CQRS.Handlers.CategoryHandlers;

public class GetCategoryQueryHandler
{
    private readonly IRepository<Category> _repository;

    public GetCategoryQueryHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetCategoryQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();

        return values.Select(x => new GetCategoryQueryResult
        {
            Name = x.Name,
            Id = x.Id
        }).ToList();
    }
}
