namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeaturesController : ControllerBase
{
    private readonly IMediator _mediator;

    public FeaturesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _mediator.Send(new GetFeatureQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var value = await _mediator.Send(new GetFeatureByIdQuery(id));
            return Ok(value);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFeatureCommand command)
    {
        await _mediator.Send(command);
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateFeatureCommand command)
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
            await _mediator.Send(new DeleteFeatureCommand(id));
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
