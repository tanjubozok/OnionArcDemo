namespace Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
{
    private readonly IRepository<SocialMedia> _repository;

    public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetSocialMediaQueryResult
        {
            Icon = x.Icon,
            Id = x.Id,
            Name = x.Name,
            Url = x.Url
        }).ToList();
    }
}
