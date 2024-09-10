namespace Application.Features.CQRS.Handlers.CategoryHandlers;

public class GetCategoryQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoryQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetCategoryQueryResult>> Handle()
    {
        var values = await _unitOfWork.CategoryRepository.GetAllAsync();

        return values.Select(x => new GetCategoryQueryResult
        {
            Name = x.Name,
            Id = x.Id
        }).ToList();
    }
}
