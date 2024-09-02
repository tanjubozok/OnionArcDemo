using Application.Abstract;
using Application.Features.CQRS.Results.BannerResults;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BannerHandlers;

public class GetBannerQueryHandler
{
    private readonly IRepository<Banner> _repository;

    public GetBannerQueryHandler(IRepository<Banner> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetBannerQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();

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
