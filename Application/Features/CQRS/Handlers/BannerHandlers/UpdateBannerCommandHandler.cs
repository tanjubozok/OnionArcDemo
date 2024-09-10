namespace Application.Features.CQRS.Handlers.BannerHandlers;

public class UpdateBannerCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBannerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateBannerCommand command)
    {
        var value =
            await _unitOfWork.BannerRepository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"Banner with ID '{command.Id}' was not found.");

        value.Title = command.Title;
        value.Description = command.Description;
        value.VideoDescription = command.VideoDescription;
        value.VideoUrl = command.VideoUrl;

        _unitOfWork.BannerRepository.Update(value);
        await _unitOfWork.SaveChangesAsync();
    }
}