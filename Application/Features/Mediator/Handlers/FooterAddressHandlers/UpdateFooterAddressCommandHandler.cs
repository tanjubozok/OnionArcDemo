namespace Application.Features.Mediator.Handlers.FooterAddressHandlers;

public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
{
    private readonly IFooterAddressRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFooterAddressCommandHandler(IFooterAddressRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
    {
        var value =
           await _repository.GetByIdAsync(request.Id)
           ?? throw new KeyNotFoundException($"FooterAddress with ID '{request.Id}' was not found.");

        value.Description = request.Description;
        value.Address = request.Address;
        value.Phone = request.Phone;
        value.Email = request.Email;

        _repository.Update(value);
        await _unitOfWork.SaveChangesAsync();
    }
}
