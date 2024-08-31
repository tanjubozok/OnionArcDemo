using Application.Features.CQRS.Commands.AboutCommands;
using Application.Features.CQRS.Handlers.AboutHandlers;
using Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AboutsController : ControllerBase
{
    private readonly CreateAboutCommandHandler _createAboutCommandHandler;
    private readonly DeleteAboutCommandHandler _deleteAboutCommandHandler;
    private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
    private readonly GetAboutQueryHandler _getAboutQueryHandler;
    private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;

    public AboutsController(CreateAboutCommandHandler createAboutCommandHandler, DeleteAboutCommandHandler deleteAboutCommandHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, GetAboutQueryHandler getAboutQueryHandler, UpdateAboutCommandHandler updateAboutCommandHandler)
    {
        _createAboutCommandHandler = createAboutCommandHandler;
        _deleteAboutCommandHandler = deleteAboutCommandHandler;
        _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
        _getAboutQueryHandler = getAboutQueryHandler;
        _updateAboutCommandHandler = updateAboutCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _getAboutQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var value = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(value);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAboutCommand command)
    {
        await _createAboutCommandHandler.Handle(command);
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateAboutCommand command)
    {
        try
        {
            await _updateAboutCommandHandler.Handle(command);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Remove(int id)
    {
        try
        {
            await _deleteAboutCommandHandler.Handle(new DeleteAboutCommand(id));
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}