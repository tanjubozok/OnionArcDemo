namespace Application.Features.CQRS.Handlers.BrandHandlers;

public class DeleteBrandCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBrandCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteBrandCommand command)
    {
        var value =
            await _unitOfWork.BrandRepository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"Brand with ID '{command.Id}' was not found.");

        _unitOfWork.BrandRepository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}