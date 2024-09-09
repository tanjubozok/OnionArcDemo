namespace Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
{
    private readonly ISocialMediaRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSocialMediaCommandHandler(ISocialMediaRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new SocialMedia
        {
            Icon = request.Icon,
            Name = request.Name,
            Url = request.Url
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
