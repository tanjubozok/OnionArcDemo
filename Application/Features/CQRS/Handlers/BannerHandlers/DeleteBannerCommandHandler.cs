namespace Application.Features.CQRS.Handlers.BannerHandlers;

public class DeleteBannerCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBannerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteBannerCommand command)
    {
        var value =
            await _unitOfWork.BannerRepository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"Banner with ID '{command.Id}' was not found.");

        _unitOfWork.BannerRepository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
