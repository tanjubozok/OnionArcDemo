namespace Application.Features.Mediator.Handlers.CarServiceHandlers;

public class DeleteCarServiceCommandHandler : IRequestHandler<DeleteCarServiceCommand, IResponse<DeleteCarServiceDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCarServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<DeleteCarServiceDto>> Handle(DeleteCarServiceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var value = await _unitOfWork.CarServiceRepository.GetByIdAsync(request.Id);
            if (value == null)
                return new Response<DeleteCarServiceDto>(ResponseType.NotFound, string.Format(Message.IdNotFound, request.Id, "Araba Servisi"));

            _unitOfWork.CarServiceRepository.Delete(value);

            var result = await _unitOfWork.SaveChangesAsync();
            if (result > 0)
                return new Response<DeleteCarServiceDto>(ResponseType.Success, Message.Deleted);
            return new Response<DeleteCarServiceDto>(ResponseType.SaveError, Message.SaveError);
        }
        catch (Exception ex)
        {
            return new Response<DeleteCarServiceDto>(ResponseType.TryCatch, ex.Message);
        }
    }
}
