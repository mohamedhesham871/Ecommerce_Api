using Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Shared;

namespace Ecommerce_Api.MiddelWare
{
    public class GlobalErrorHandlingMiddleware
    {
        //CLR will Handel the Object Creation
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;

        // Request Delegate is An Abstraction for the next middleware in the pipeline
        // Also it's Like address of Next Middlerware 
        public GlobalErrorHandlingMiddleware(RequestDelegate request, ILogger<GlobalErrorHandlingMiddleware> logger) { 
            _next = request;
            _logger = logger;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Call the next middleware in the pipeline
                // This is where the request is passed to the next middleware
                await _next.Invoke(context);
                //End Point not Found 
                await EndPointNotFound(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                //Handle the exception
                //1- set status code for Response
                //2- set content type for Response
                //3- set response body
                //4- return the respons

                #region Basic
                ////1- set status code for Response
                //context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                ////2- set content type for Response
                //context.Response.ContentType = "application/json";
                ////3- set response body
                //var response = new ErrorDetails()
                //{
                //SatusCode = context.Response.StatusCode,
                //Message = ex.Message,
                //};
                ////4- return the response
                // await context.Response.WriteAsJsonAsync(response); 
                #endregion
                context.Response.ContentType = "application/json";

                var Response =new ErrorDetails()
                {
                    Message = ex.Message,
                };
                var satusCode = ex switch
                {
                    //Handle Not Found Exception
                    NotFoundException => StatusCodes.Status404NotFound, 
                    BadRequestException => StatusCodes.Status400BadRequest,
                    _ => StatusCodes.Status500InternalServerError,
                };
               Response.SatusCode = satusCode;
                await context.Response.WriteAsJsonAsync(Response);

                //Handel Not Found Exception



            }

        }

        private static async Task EndPointNotFound(HttpContext context)
        {
            if (context.Response.StatusCode == 404)
            {
                context.Response.ContentType = "application/json";
                var response = new ErrorDetails()
                {
                    SatusCode = StatusCodes.Status404NotFound,
                    Message = $"thid {context.Request.Path} Not Found", //,mead this End point is not found
                };
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
//Handle Validation Exception
//ArgumentException => StatusCodes.Status400BadRequest,
////Handle Unauthorized Exception
//UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
//Handle Forbidden Exception