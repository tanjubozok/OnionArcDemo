using Application.Abstract;
using Application.Features.CQRS.Queries.BrandQueries;
using Application.Features.CQRS.Results.BrandResults;
using OnionArc.Domain.Entities;

namespace Application.Features.CQRS.Handlers.BrandHandlers;

public class GetBrandByIdQueryHandler
{
    private readonly IRepository<Brand> _repository;

    public GetBrandByIdQueryHandler(IRepository<Brand> repository)
    {
        _repository = repository;
    }

    public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
    {
        var value = await _repository.GetByIdAsync(query.Id);

        return value == null
            ? throw new KeyNotFoundException($"Brand with ID '{query.Id}' was not found.")
            : new GetBrandByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name
            };
    }
}
