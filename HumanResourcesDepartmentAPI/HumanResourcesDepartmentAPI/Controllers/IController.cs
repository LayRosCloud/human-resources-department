using Microsoft.AspNetCore.Mvc;

namespace HumanResourcesDepartmentAPI.Controllers;

public interface IController<TSource, VKey>
{
    Task<IActionResult> FindAll();
    Task<IActionResult> Find(VKey id);
    Task<IActionResult> Create(TSource item);
    Task<IActionResult> Update(TSource item);
    Task<IActionResult> Delete(VKey id);
}