namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
    private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
    private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
    private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
    private readonly DeleteCategoryCommandHandler _deleteCategoryCommandHandler;

    public CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, CreateCategoryCommandHandler createCategoryCommandHandler, DeleteCategoryCommandHandler deleteCategoryCommandHandler)
    {
        _getCategoryQueryHandler = getCategoryQueryHandler;
        _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
        _updateCategoryCommandHandler = updateCategoryCommandHandler;
        _createCategoryCommandHandler = createCategoryCommandHandler;
        _deleteCategoryCommandHandler = deleteCategoryCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _getCategoryQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(value);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryCommand command)
    {
        await _createCategoryCommandHandler.Handle(command);
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCategoryCommand command)
    {
        try
        {
            await _updateCategoryCommandHandler.Handle(command);
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
            await _deleteCategoryCommandHandler.Handle(new DeleteCategoryCommand(id));
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
