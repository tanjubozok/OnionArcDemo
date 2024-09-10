namespace Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSocialMediaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var value =
           await _unitOfWork.SocialMediaRepository.GetByIdAsync(request.Id)
           ?? throw new KeyNotFoundException($"SocialMedia with ID '{request.Id}' was not found.");

        value.Url = request.Url;
        value.Name = request.Name;
        value.Icon = request.Icon;

        _unitOfWork.SocialMediaRepository.Update(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
