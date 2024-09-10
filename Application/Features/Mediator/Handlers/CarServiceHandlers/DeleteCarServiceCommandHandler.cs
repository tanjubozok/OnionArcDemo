namespace Application.Features.Mediator.Handlers.CarServiceHandlers;

public class DeleteCarServiceCommandHandler : IRequestHandler<DeleteCarServiceCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCarServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCarServiceCommand request, CancellationToken cancellationToken)
    {
        var value = await _unitOfWork.CarServiceRepository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"CarService with ID '{request.Id}' was not found.");

        _unitOfWork.CarServiceRepository.Delete(value);

        await _unitOfWork.SaveChangesAsync();
    }
}
