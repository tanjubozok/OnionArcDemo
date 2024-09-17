namespace Application.Features.Mediator.Handlers.CarServiceHandlers;

public class UpdateCarServiceCommandHandler : IRequestHandler<UpdateCarServiceCommand, IResponse<UpdateCarServiceDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCarServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    async Task<IResponse<UpdateCarServiceDto>> IRequestHandler<UpdateCarServiceCommand, IResponse<UpdateCarServiceDto>>.Handle(UpdateCarServiceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var data = await _unitOfWork.CarServiceRepository.GetByIdAsync(request.Id);
            if (data == null)
                return new Response<UpdateCarServiceDto>(ResponseType.NotFound, string.Format(Message.IdNotFound, request.Id, "Araba servisi"));

            data.Description = request.Description;
            data.Title = request.Title;
            data.IconUrl = request.IconUrl;

            _unitOfWork.CarServiceRepository.Update(data);

            var result = await _unitOfWork.SaveChangesAsync();
            if (result > 0)
            {
                UpdateCarServiceDto dto = new()
                {
                    Id = data.Id,
                    Description = data.Description,
                    IconUrl = data.IconUrl,
                    Title = data.Title
                };
                return new Response<UpdateCarServiceDto>(ResponseType.Success, dto, Message.Success);
            }
            return new Response<UpdateCarServiceDto>(ResponseType.SaveError, Message.SaveError);
        }
        catch (Exception ex)
        {
            return new Response<UpdateCarServiceDto>(ResponseType.TryCatch, ex.Message);
        }
    }
}