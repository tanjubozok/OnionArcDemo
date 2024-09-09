﻿namespace Application.Features.Mediator.Handlers.FooterAddressHandlers;

public class DeleteFooterAddressCommandHandler : IRequestHandler<DeleteFooterAddressCommand>
{
    private readonly IFooterAddressRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFooterAddressCommandHandler(IFooterAddressRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteFooterAddressCommand request, CancellationToken cancellationToken)
    {
        var value =
            await _repository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"FooterAddress with ID '{request.Id}' was not found.");

        _repository.Delete(value);
        await _unitOfWork.SaveChangesAsync();
    }
}