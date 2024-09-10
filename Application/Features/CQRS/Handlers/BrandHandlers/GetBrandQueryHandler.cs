namespace Application.Features.CQRS.Handlers.BrandHandlers;

public class GetBrandQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetBrandQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetBrandQueryResult>> Handle()
    {
        var values = await _unitOfWork.BrandRepository.GetAllAsync();

        return values.Select(x => new GetBrandQueryResult
        {
            Id = x.Id,
            Name = x.Name
        }).ToList();
    }
}