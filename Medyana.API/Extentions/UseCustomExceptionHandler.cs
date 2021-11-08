using Medyana.API.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Medyana.API.Extentions
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(cfg =>
            {
                cfg.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var ex = error.Error;
                        ErrorModel errorModel = new ErrorModel();
                        errorModel.Status = 500;
                        errorModel.Errors.Add(ex.Message);
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorModel));
                    }
                });
            });
        }
    }
}