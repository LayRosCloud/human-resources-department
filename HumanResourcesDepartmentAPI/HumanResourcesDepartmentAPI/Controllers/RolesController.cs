using HumanResourcesDepartmentAPI.Models;
using HumanResourcesDepartmentAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourcesDepartmentAPI.Controllers
{
    [ApiController]
    [Route("roles")]
    public class RolesController : ControllerBase, IController<RoleEntity, int>
    {
        private readonly IService<RoleEntity, int> _service;

        public RolesController()
        {
            _service = new RoleService();
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
        public async Task<IActionResult> Create([FromBody] RoleEntity role)
        {
            var list = await _service.Create(role);
            return Ok(list);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RoleEntity role)
        {
            var list = await _service.Update(role);
            return Ok(list);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var list = await _service.Delete(id);
            return Ok(list);
        }
    }
}
