using Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class ExceptionMiddleware
    {   
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch(Exception exception)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                string errorMessage;
                if(exception is BusinessException)
                {
                    ProblemDetails problemDetails = new ProblemDetails();
                    problemDetails.Title = "Business Rule Violation";
                    problemDetails.Detail = exception.Message;
                    problemDetails.Type = "Business Exception";

                    await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
                }
                else
                {
                    errorMessage = "Bilinmeyen Hata";
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                }
                

            }
        }
    }
}
