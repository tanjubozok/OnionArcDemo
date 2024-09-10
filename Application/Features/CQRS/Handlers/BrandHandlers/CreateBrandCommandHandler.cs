namespace Application.Features.CQRS.Handlers.BrandHandlers;

public class CreateBrandCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateBrandCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateBrandCommand command)
    {
        await _unitOfWork.BrandRepository.CreateAsync(new Brand
        {
            Name = command.Name,
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
