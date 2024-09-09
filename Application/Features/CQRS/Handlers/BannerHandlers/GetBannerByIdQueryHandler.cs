namespace Application.Features.CQRS.Handlers.BannerHandlers;

public class GetBannerByIdQueryHandler
{
    private readonly IBannerRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public GetBannerByIdQueryHandler(IBannerRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
    {
        var value = await _repository.GetByIdAsync(query.Id);

        return value == null
            ? throw new KeyNotFoundException($"About with ID '{query.Id}' was not found.")
            : new GetBannerByIdQueryResult
            {
                Description = value.Description,
                Id = value.Id,
                Title = value.Title,
                VideoDescription = value.VideoDescription,
                VideoUrl = value.VideoUrl
            };
    }
}
