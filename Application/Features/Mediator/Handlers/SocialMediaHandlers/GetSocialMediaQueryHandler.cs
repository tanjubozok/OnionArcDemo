namespace Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
{
    private readonly ISocialMediaRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public GetSocialMediaQueryHandler(ISocialMediaRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
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
