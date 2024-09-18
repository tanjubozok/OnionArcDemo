namespace Application.Features.Mediator.Handlers.CarServiceHandlers;

public class CreateCarServiceCommandHandler : IRequestHandler<CreateCarServiceCommand, IResponse<CreateCarServiceDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICarServiceRepository _repository;

    public CreateCarServiceCommandHandler(IUnitOfWork unitOfWork, ICarServiceRepository repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }    

    public async Task<IResponse<CreateCarServiceDto>> Handle(CreateCarServiceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var data = await _repository.CreateAsync(new CarService
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