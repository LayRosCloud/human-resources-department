using HumanResourcesDepartmentAPI.Scripts.Exceptions;
using HumanResourcesDepartmentAPI.Scripts.Records;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HumanResourcesDepartmentAPI.Scripts.Filters
{
    public class ExceptionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception is NotFoundException notFoundException)
            {
                context.Result = new ObjectResult(new ExceptionObject(404, notFoundException.Message))
                {
                    StatusCode = 404
                };
            }
            else if (context.Exception is Exception exception)
            {
                context.Result = new ObjectResult(new ExceptionObject(500, exception.Message))
                {
                    StatusCode = 500
                };
            }

            context.ExceptionHandled = true;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
