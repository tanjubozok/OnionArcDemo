namespace Application.Features.Mediator.Handlers.CarServiceHandlers;

public class GetCarServiceByIdQueryHandler : IRequestHandler<GetCarServiceByIdQueryResult, GetByIdCarServiceDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICarServiceRepository _repository;

    public GetCarServiceByIdQueryHandler(IUnitOfWork unitOfWork, ICarServiceRepository repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task<IResponse<GetByIdCarServiceDto>> Handle(GetCarServiceByIdQueryResult request, CancellationToken cancellationToken)
    {
        try
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                return new Response<GetByIdCarServiceDto>(ResponseType.NotFound, "Car service not found.");
        }
        catch (Exception)
        {

            throw;
        }
    }

    Task<GetByIdCarServiceDto> IRequestHandler<GetCarServiceByIdQueryResult, GetByIdCarServiceDto>.Handle(GetCarServiceByIdQueryResult request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    //public async Task<IResponse<GetCarServiceByIdQueryResult>> Handle1(GetCarServiceByIdQuery request, CancellationToken cancellationToken)
    //{
    //    try
    //    {
    //        var value = await _repository.GetByIdAsync(request.Id);

    //        if (value == null)
    //            return new Response<GetCarServiceByIdQueryResult>(ResponseType.NotFound, "Car service not found.");

    //        var result = new GetCarServiceByIdQueryResult
    //        {
    //            Id = value.Id,
    //            Description = value.Description,
    //            IconUrl = value.IconUrl,
    //            Title = value.Title
    //        };

    //        return new Response<GetCarServiceByIdQueryResult>(ResponseType.Success, result, "Car service retrieved successfully.");
    //    }
    //    catch (Exception ex)
    //    {
    //        return new Response<GetCarServiceByIdQueryResult>(ResponseType.TryCatch, ex.Message);
    //    }
    //}
}