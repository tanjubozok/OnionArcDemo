using Application.Abstract;
using Application.Features.CQRS.Commands.BannerCommands;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BannerHandlers;

public class DeleteBannerCommandHandler
{
    private readonly IRepository<Banner> _repository;

    public DeleteBannerCommandHandler(IRepository<Banner> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteBannerCommand command)
    {
        var value =
            await _repository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"Banner with ID '{command.Id}' was not found.");

        await _repository.DeleteAsync(value);
    }
}
