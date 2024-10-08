﻿global using Application;
global using Application.ComplexTypes;
global using Application.Features.CQRS.Commands.AboutCommands;
global using Application.Features.CQRS.Commands.BannerCommands;
global using Application.Features.CQRS.Commands.BrandCommands;
global using Application.Features.CQRS.Commands.CarCommands;
global using Application.Features.CQRS.Commands.CategoryCommands;
global using Application.Features.CQRS.Commands.ContactCommands;
global using Application.Features.CQRS.Handlers.AboutHandlers;
global using Application.Features.CQRS.Handlers.BannerHandlers;
global using Application.Features.CQRS.Handlers.BrandHandlers;
global using Application.Features.CQRS.Handlers.CarHandlers;
global using Application.Features.CQRS.Handlers.CategoryHandlers;
global using Application.Features.CQRS.Handlers.ContactHandlers;
global using Application.Features.CQRS.Queries.AboutQueries;
global using Application.Features.CQRS.Queries.BannerQueries;
global using Application.Features.CQRS.Queries.BrandQueries;
global using Application.Features.CQRS.Queries.CarQueries;
global using Application.Features.CQRS.Queries.CategoryQueries;
global using Application.Features.CQRS.Queries.ContactQueries;
global using Application.Features.Mediator.Commands.CarServiceCommands;
global using Application.Features.Mediator.Commands.FeatureCommands;
global using Application.Features.Mediator.Commands.FooterAddressCommands;
global using Application.Features.Mediator.Commands.LocationCommands;
global using Application.Features.Mediator.Commands.SocialMediaCommands;
global using Application.Features.Mediator.Commands.TestimonialCommands;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using Persistence.DependencyResolvers;
