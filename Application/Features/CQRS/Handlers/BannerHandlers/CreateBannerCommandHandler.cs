namespace Application.Features.CQRS.Handlers.BannerHandlers;

public class CreateBannerCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateBannerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateBannerCommand command)
    {
        await _unitOfWork.BannerRepository.CreateAsync(new Banner
        {
            Description = command.Description,
            Title = command.Title,
            VideoDescription = command.VideoDescription,
            VideoUrl = command.VideoUrl
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
