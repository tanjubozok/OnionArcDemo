namespace Application.Features.CQRS.Handlers.BannerHandlers;

public class DeleteBannerCommandHandler
{
    private readonly IBannerRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBannerCommandHandler(IBannerRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteBannerCommand command)
    {
        var value =
            await _repository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"Banner with ID '{command.Id}' was not found.");

        _repository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
