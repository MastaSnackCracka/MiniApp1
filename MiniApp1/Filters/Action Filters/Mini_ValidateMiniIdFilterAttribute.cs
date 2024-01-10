using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MiniApp1.Models;
using MiniApp1.Models.Repositories;

namespace MiniApp1.Filters
{
    public class Mini_ValidateMiniIdFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var miniId = context.ActionArguments["id"] as int?;
            if (miniId.HasValue)
            {
                if (miniId.Value <= 0)
                {
                    context.ModelState.AddModelError("MiniId", "MiniID is invalid.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else if (!MiniRepo.MiniExists(miniId.Value))
                {
                    context.ModelState.AddModelError("MiniId", "Mini doesn't exist.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}
