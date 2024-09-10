namespace Application.Features.CQRS.Handlers.AboutHandlers;

public class GetAboutQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAboutQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetAboutQueryResult>> Handle()
    {
        var values = await _unitOfWork.AboutRepository.GetAllAsync();

        return values.Select(x => new GetAboutQueryResult
        {
            Description = x.Description,
            Id = x.Id,
            ImageUrl = x.ImageUrl,
            Title = x.Title
        }).ToList();
    }
}