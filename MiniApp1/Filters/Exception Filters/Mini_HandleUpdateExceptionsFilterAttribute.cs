using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MiniApp1.Models.Repositories;

namespace MiniApp1.Filters.Exception_Filters
{
    public class Mini_HandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strMiniId = context.RouteData.Values["id"] as string;
            if (int.TryParse(strMiniId, out int miniId))
            {
                if (!MiniRepo.MiniExists(miniId))
                {
                    context.ModelState.AddModelError("MiniId", "Mini doesn't exist anymore.");
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
