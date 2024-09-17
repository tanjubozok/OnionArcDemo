namespace Application.DTOs.AboutDtos;

public class GetByIdAboutDto : IRequest<IResponse<GetCarServiceByIdQueryResult>>
{
    public int Id { get; set; }
}
