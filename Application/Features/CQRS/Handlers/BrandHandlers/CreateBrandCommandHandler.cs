namespace Application.Features.CQRS.Handlers.BrandHandlers;

public class CreateBrandCommandHandler
{
    private readonly IBrandRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBrandCommandHandler(IBrandRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateBrandCommand command)
    {
        await _repository.CreateAsync(new Brand
        {
            Name = command.Name,
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
