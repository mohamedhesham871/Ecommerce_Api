using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Ecommerce_Api.Factories
{
    public static  class ApiBehavior
    {
        public static IActionResult ConfigureApiBehavior(ActionContext context)
        {
          
                    var errors = context.ModelState.Where(modelStatue => modelStatue.Value.Errors.Any()).
                    Select(modelSatue => new validationError()
                    {
                        faild = modelSatue.Key,
                        errors = modelSatue.Value.Errors.Select(error => error.ErrorMessage)
                    });
                    var Response = new validationErrorModel
                    {
                        //i have Static data about {status code, message, }
                        validationErrors = errors
                    };
                    return new BadRequestObjectResult(Response);
                
        }
    }
}
