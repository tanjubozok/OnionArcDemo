namespace Application.Features.CQRS.Handlers.AboutHandlers;

public class GetAboutByIdQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAboutByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
    {
        var result = await _unitOfWork.AboutRepository.GetByIdAsync(query.Id);

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