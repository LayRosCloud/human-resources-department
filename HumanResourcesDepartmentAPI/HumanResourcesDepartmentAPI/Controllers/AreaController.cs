using HumanResourcesDepartmentAPI.Models;
using HumanResourcesDepartmentAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourcesDepartmentAPI.Controllers;

[ApiController]
[Route("areas")]
public class AreaController: ControllerBase, IController<AreaEntity, int>
{
    private readonly IService<AreaEntity, int> _service;

    public AreaController()
    {
        _service = new AreaService();
    }

    [HttpGet]
    public async Task<IActionResult> FindAll()
    {
        var list = await _service.FindAll();
        return Ok(list);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Find([FromRoute] int id)
    {
        var list = await _service.Find(id);
        return Ok(list);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AreaEntity item)
    {
        var list = await _service.Create(item);
        return Ok(list);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] AreaEntity item)
    {
        var list = await _service.Update(item);
        return Ok(list);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var list = await _service.Delete(id);
        return Ok(list);
    }
}