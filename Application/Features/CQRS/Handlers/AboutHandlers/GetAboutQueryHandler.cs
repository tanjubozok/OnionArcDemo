namespace Application.Features.CQRS.Handlers.AboutHandlers;

public class GetAboutQueryHandler
{
    private readonly IAboutRepository _repository;

    public GetAboutQueryHandler(IAboutRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetAboutQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();

        return values.Select(x => new GetAboutQueryResult
        {
            Description = x.Description,
            Id = x.Id,
            ImageUrl = x.ImageUrl,
            Title = x.Title
        }).ToList();
    }
}