using AbstractionServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentaion.AttributeFolder
{
    public class CashAttribute(int TimeDuration_inSecond) : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //1-Get the CashServices 
            var CashServices = context.HttpContext.RequestServices.GetRequiredService<IServicesManager>().CashServices;
            //2-Generate Key
            var key = GenerateKey(context.HttpContext.Request);
            var result =await CashServices.GetCashAsync(key);
            //3-Check if the key is exist in the cash
            if (!string.IsNullOrEmpty(result))
            {
                var response = new ContentResult()
                {
                    ContentType = "application/json",
                    StatusCode = StatusCodes.Status200OK,
                    Content = result
                };
                return;// terminate the request and return the cached response [data is already in the cash]
            }
            // 4-Execute the Endpoint
            var ExecuteEndPoint = await next.Invoke();
            //5-Check if the Endpoint is success
            if (ExecuteEndPoint.Result is OkObjectResult okObject)
            {
               await  CashServices.SetCashAsync(key, okObject.Value!, TimeSpan.FromSeconds(TimeDuration_inSecond));
            }


        }


        private string GenerateKey(HttpRequest request)
        {
            var Fullpath=new StringBuilder();
            //1-Get the Controller Name
            Fullpath.Append(request.Path);
            foreach (var item in request.Query.OrderBy(q=>q.Key))
            {
               Fullpath.Append($"|{item.Key}-{item.Value}");
            }
            return Fullpath.ToString();
        }
    }
}
