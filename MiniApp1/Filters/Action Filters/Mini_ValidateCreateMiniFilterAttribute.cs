using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MiniApp1.Models;
using MiniApp1.Models.Repositories;

namespace MiniApp1.Filters
{
    public class Mini_ValidateCreateMiniFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var mini = context.ActionArguments["mini"] as Mini;
            
            if (mini == null)
            {
                context.ModelState.AddModelError("Mini", "Mini object is null.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingMini =
                    MiniRepo.GetMiniByProperties(mini.Name, mini.Category, mini.Size);
                if (existingMini != null) 
                { 
                    context.ModelState.AddModelError("Mini", "Mini already exists.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                context.Result = new BadRequestObjectResult(problemDetails);
                }
            }
        }
    }
}
