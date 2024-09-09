namespace Application.Features.CQRS.Handlers.AboutHandlers;

public class GetAboutByIdQueryHandler
{
    private readonly IAboutRepository _repository;

    public GetAboutByIdQueryHandler(IAboutRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
    {
        var result = await _repository.GetByIdAsync(query.Id);

        return result == null
            ? throw new KeyNotFoundException($"About with ID '{query.Id}' was not found.")
            : new GetAboutByIdQueryResult
            {
                Description = result.Description,
                Id = result.Id,
                ImageUrl = result.ImageUrl,
                Title = result.Title
            };
    }
}