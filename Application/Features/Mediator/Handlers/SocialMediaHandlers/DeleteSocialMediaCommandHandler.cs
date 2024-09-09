namespace Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand>
{
    private readonly ISocialMediaRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSocialMediaCommandHandler(ISocialMediaRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var value =
            await _repository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"SocialMedia with ID '{request.Id}' was not found.");

        _repository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
