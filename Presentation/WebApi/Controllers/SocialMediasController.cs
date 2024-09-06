namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SocialMediasController : ControllerBase
{
    private readonly IMediator _mediator;

    public SocialMediasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _mediator.Send(new GetSocialMediaQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var value = await _mediator.Send(new GetSocialMediaByIdQuery(id));
            return Ok(value);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSocialMediaCommand command)
    {
        await _mediator.Send(command);
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateSocialMediaCommand command)
    {
        try
        {
            await _mediator.Send(command);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _mediator.Send(new DeleteSocialMediaCommand(id));
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}