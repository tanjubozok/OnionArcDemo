namespace Application.DTOs.CarServiceDtos;

public class GetByIdCarServiceDto : IRequest<IResponse<GetCarServiceByIdQueryResult>>
{
    public int Id { get; set; }
}
