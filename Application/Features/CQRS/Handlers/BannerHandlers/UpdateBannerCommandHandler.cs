namespace Application.Features.CQRS.Handlers.BannerHandlers;

public class UpdateBannerCommandHandler
{
    private readonly IBannerRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBannerCommandHandler(IBannerRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateBannerCommand command)
    {
        var value =
            await _repository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"Banner with ID '{command.Id}' was not found.");

        value.Title = command.Title;
        value.Description = command.Description;
        value.VideoDescription = command.VideoDescription;
        value.VideoUrl = command.VideoUrl;

        _repository.Update(value);
        await _unitOfWork.SaveChangesAsync();
    }
}