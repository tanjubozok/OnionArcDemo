using Application.DTOs.AboutDtos;

namespace Application.Features.Mediator.Handlers.CarServiceHandlers;

public class GetCarServiceByIdQueryHandler : IRequestHandler<GetCarServiceByIdQuery, IResponse<GetByIdCarServiceDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCarServiceByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<GetCarServiceByIdQueryResult>> Handle(GetCarServiceByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var value = await _unitOfWork.CarServiceRepository.GetByIdAsync(request.Id);

            if (value == null)
                return new Response<GetCarServiceByIdQueryResult>(ResponseType.NotFound, "Car service not found.");

            var result = new GetCarServiceByIdQueryResult
            {
                Id = value.Id,
                Description = value.Description,
                IconUrl = value.IconUrl,
                Title = value.Title
            };

            return new Response<GetCarServiceByIdQueryResult>(ResponseType.Success, result, "Car service retrieved successfully.");
        }
        catch (Exception ex)
        {
            return new Response<GetCarServiceByIdQueryResult>(ResponseType.TryCatch, ex.Message);
        }
    }
}

