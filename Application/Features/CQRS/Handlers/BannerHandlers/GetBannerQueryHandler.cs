namespace Application.Features.CQRS.Handlers.BannerHandlers;

public class GetBannerQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetBannerQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetBannerQueryResult>> Handle()
    {
        var values = await _unitOfWork.BannerRepository.GetAllAsync();

        return values.Select(x => new GetBannerQueryResult
        {
            Description = x.Description,
            Id = x.Id,
            Title = x.Title,
            VideoDescription = x.VideoDescription,
            VideoUrl = x.VideoUrl
        }).ToList();
    }
}
