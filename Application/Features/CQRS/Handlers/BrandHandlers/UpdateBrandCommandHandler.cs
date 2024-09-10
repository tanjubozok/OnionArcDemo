namespace Application.Features.CQRS.Handlers.BrandHandlers;

public class UpdateBrandCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBrandCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateBrandCommand command)
    {
        var value =
            await _unitOfWork.BrandRepository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"Brand with ID '{command.Id}' was not found.");

        value.Name = command.Name;

        _unitOfWork.BrandRepository.Update(value);
    }
}
