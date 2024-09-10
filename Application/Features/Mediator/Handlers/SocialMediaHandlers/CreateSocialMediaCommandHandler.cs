namespace Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSocialMediaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.SocialMediaRepository.CreateAsync(new SocialMedia
        {
            Icon = request.Icon,
            Name = request.Name,
            Url = request.Url
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
