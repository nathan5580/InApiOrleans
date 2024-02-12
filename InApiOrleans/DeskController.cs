using InApiOrleans.Grains;
using Microsoft.AspNetCore.Mvc;

namespace InApiOrleans;

[ApiController]
[Route("[controller]")]
public class DeskController : ControllerBase
{
    private readonly IGrainFactory _grainFactory;

    public DeskController(IGrainFactory grainFactory)
    {
        _grainFactory = grainFactory;
    }

    [HttpPost("desk/{deskId}/task")]
    public async Task<IActionResult> AddTaskToDesk(Guid deskId, [FromBody] Guid taskId)
    {
        var deskGrain = _grainFactory.GetGrain<IDeskGrain>(deskId);
        await deskGrain.AddTask(taskId);
        return Ok();
    }
}