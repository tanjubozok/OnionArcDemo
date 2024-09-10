namespace Application.Features.CQRS.Handlers.BrandHandlers;

public class GetBrandByIdQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetBrandByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
    {
        var value = await _unitOfWork.BrandRepository.GetByIdAsync(query.Id);

        return value == null
            ? throw new KeyNotFoundException($"Brand with ID '{query.Id}' was not found.")
            : new GetBrandByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name
            };
    }
}
