namespace Application.Features.CQRS.Handlers.BrandHandlers;

public class GetBrandQueryHandler
{
    private readonly IBrandRepository _repository;

    public GetBrandQueryHandler(IBrandRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetBrandQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();

        return values.Select(x => new GetBrandQueryResult
        {
            Id = x.Id,
            Name = x.Name
        }).ToList();
    }
}