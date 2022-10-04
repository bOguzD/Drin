using Drin.Business.Exceptions;
using Drin.Core.Responses;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace Drin.API.Middlewares
{
    public static class CustomExceptionHandler
    {
        public static void CustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                //Run sonlandırıcı bir middlewaredir.
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        _ => 500
                    };

                    context.Response.StatusCode = statusCode;

                    var response = ServiceResponse.Failure(statusCode, exceptionFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                });
            });
        }
    }
}
