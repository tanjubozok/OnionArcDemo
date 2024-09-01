using Application.Abstract;
using Application.Features.CQRS.Commands.AboutCommands;
using OnionArc.Domain.Entities;

namespace Application.Features.CQRS.Handlers.AboutHandlers;

public class DeleteAboutCommandHandler
{
    private readonly IRepository<About> _repository;

    public DeleteAboutCommandHandler(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteAboutCommand command)
    {
        var value =
            await _repository.GetByIdAsync(command.Id)
            ?? throw new KeyNotFoundException($"About with ID '{command.Id}' was not found.");

        await _repository.DeleteAsync(value);
    }
}
