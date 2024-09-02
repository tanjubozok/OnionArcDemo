using Application.Abstract;
using Application.Features.CQRS.Commands.BannerCommands;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BannerHandlers;

public class UpdateBannerCommandHandler
{
    private readonly IRepository<Banner> _repository;

    public UpdateBannerCommandHandler(IRepository<Banner> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateBannerCommand command)
    {
        var value =
            await _repository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"Banner with ID '{command.Id}' was not found.");

        value.Title = command.Title;
        value.Description = command.Description;
        value.VideoDescription = command.VideoDescription;
        value.VideoUrl = command.VideoUrl;

        await _repository.UpdateAsync(value);
    }
}