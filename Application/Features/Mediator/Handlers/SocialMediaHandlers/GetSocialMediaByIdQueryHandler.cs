namespace Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSocialMediaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
    {
        var value =
           await _unitOfWork.SocialMediaRepository.GetByIdAsync(request.Id)
           ?? throw new KeyNotFoundException($"SocialMedia with ID '{request.Id}' was not found.");

        return new GetSocialMediaByIdQueryResult
        {
            Icon = value.Icon,
            Id = value.Id,
            Name = value.Name,
            Url = value.Url
        };
    }
}
