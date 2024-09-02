﻿using Application.Abstract;
using Application.Features.CQRS.Commands.BrandCommands;
using OnionArc.Domain.Entities;

namespace Application.Features.CQRS.Handlers.BrandHandlers;

public class CreateBrandCommandHandler
{
    private readonly IRepository<Brand> _repository;

    public CreateBrandCommandHandler(IRepository<Brand> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateBrandCommand command)
    {
        await _repository.CreateAsync(new Brand
        {
            Name = command.Name,
        });
    }
}
