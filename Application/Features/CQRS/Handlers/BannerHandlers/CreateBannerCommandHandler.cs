namespace Application.Features.CQRS.Handlers.BannerHandlers;

public class CreateBannerCommandHandler
{
    private readonly IBannerRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBannerCommandHandler(IBannerRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateBannerCommand command)
    {
        await _repository.CreateAsync(new Banner
        {
            Description = command.Description,
            Title = command.Title,
            VideoDescription = command.VideoDescription,
            VideoUrl = command.VideoUrl
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
