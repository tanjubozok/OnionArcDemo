namespace Application.Features.Mediator.Handlers.CarServiceHandlers;

public class GetCarServiceByIdQueryHandler : IRequestHandler<GetCarServiceByIdQuery, GetCarServiceByIdQueryResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCarServiceByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetCarServiceByIdQueryResult> Handle(GetCarServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _unitOfWork.CarServiceRepository.GetByIdAsync(request.Id);
        return value == null
            ? throw new KeyNotFoundException($"Location with ID '{request.Id}' was not found.")
            : new GetCarServiceByIdQueryResult
            {
                Id = value.Id,
                Description = value.Description,
                IconUrl = value.IconUrl,
                Title = value.Title,
            };
    }
}
