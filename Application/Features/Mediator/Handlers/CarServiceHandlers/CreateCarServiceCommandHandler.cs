namespace Application.Features.Mediator.Handlers.CarServiceHandlers;

public class CreateCarServiceCommandHandler : IRequestHandler<CreateCarServiceCommand, IResponse<CreateCarServiceDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCarServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<CreateCarServiceDto>> Handle(CreateCarServiceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var data = await _unitOfWork.CarServiceRepository.CreateAsync(new CarService
            {
                Description = request.Description,
                IconUrl = request.IconUrl,
                Title = request.Title
            });

            CreateCarServiceDto dto = new()
            {
                Description = request.Description,
                IconUrl = request.IconUrl,
                Title = request.Title
            };

            var result = await _unitOfWork.SaveChangesAsync();
            if (result > 0)
                return new Response<CreateCarServiceDto>(ResponseType.Success, dto, Message.Success);
            return new Response<CreateCarServiceDto>(ResponseType.SaveError, Message.SaveError);
        }
        catch (Exception ex)
        {
            return new Response<CreateCarServiceDto>(ResponseType.TryCatch, ex.Message);
        }
    }
}
