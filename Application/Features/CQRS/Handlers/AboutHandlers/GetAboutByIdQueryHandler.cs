using Application.Abstract;
using Application.Features.CQRS.Queries.AboutQueries;
using Application.Features.CQRS.Results.AboutResults;
using OnionArc.Domain.Entities;

namespace Application.Features.CQRS.Handlers.AboutHandlers;

public class GetAboutByIdQueryHandler
{
    private readonly IRepository<About> _repository;

    public GetAboutByIdQueryHandler(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
    {
        var result = await _repository.GetByIdAsync(query.Id);
        if (result == null)
            throw new KeyNotFoundException($"About with ID '{query.Id}' was not found.");

        return new GetAboutByIdQueryResult
        {
            Description = result.Description,
            Id = result.Id,
            ImageUrl = result.ImageUrl,
            Title = result.Title
        };
    }
}