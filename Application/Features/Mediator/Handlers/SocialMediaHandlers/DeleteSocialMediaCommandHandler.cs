namespace Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSocialMediaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var value =
            await _unitOfWork.SocialMediaRepository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"SocialMedia with ID '{request.Id}' was not found.");

        _unitOfWork.SocialMediaRepository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
