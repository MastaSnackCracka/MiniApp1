using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MiniApp1.Models;

namespace MiniApp1.Filters
{
    public class Mini_ValidateUpdateMiniFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;
            var mini = context.ActionArguments["mini"] as Mini;

            if (id.HasValue && mini != null && id != mini.MiniId)
            {
                context.ModelState.AddModelError("MiniId", "MiniId is not the same as id.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}
