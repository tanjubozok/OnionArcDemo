namespace Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
{
    private readonly ISocialMediaRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public GetSocialMediaByIdQueryHandler(ISocialMediaRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetSocialMediaByIdQueryResult
        {
            Icon = value.Icon,
            Id = value.Id,
            Name = value.Name,
            Url = value.Url
        };
    }
}
