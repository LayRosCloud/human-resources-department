using HumanResourcesDepartmentAPI.Models;
using HumanResourcesDepartmentAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourcesDepartmentAPI.Controllers;

[ApiController]
[Route("citiesStreets")]
public class CityStreetController: ControllerBase, IController<CityStreetEntity, int>
{
    private readonly IService<CityStreetEntity, int> _service;

    public CityStreetController()
    {
        _service = new CityStreetService();
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
    public async Task<IActionResult> Create([FromBody] CityStreetEntity item)
    {
        var list = await _service.Create(item);
        return Ok(list);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CityStreetEntity item)
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