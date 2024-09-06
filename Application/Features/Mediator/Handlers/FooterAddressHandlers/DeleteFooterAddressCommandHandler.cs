namespace Application.Features.Mediator.Handlers.FooterAddressHandlers;

public class DeleteFooterAddressCommandHandler : IRequestHandler<DeleteFooterAddressCommand>
{
    private readonly IRepository<FooterAddress> _repository;

    public DeleteFooterAddressCommandHandler(IRepository<FooterAddress> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteFooterAddressCommand request, CancellationToken cancellationToken)
    {
        var value =
            await _repository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"FooterAddress with ID '{request.Id}' was not found.");

        await _repository.DeleteAsync(value);
    }
}