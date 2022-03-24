using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;
using WebApi.Services;

namespace WebApi.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;
        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }
        public async Task Invoke(HttpContext context)
        {
            var watch=Stopwatch.StartNew();
            try
            {
                string message="[Request] HTTP "+context.Request.Method + " - "+context.Request.Path;
                System.Console.WriteLine(message);
                
                await _next(context); //Sonraki middleware çağırılması için
                watch.Stop(); //start ve stop methodları ile request-response arasında geçen zamanı ölçtük.

                message="[Response] HTTP " + context.Request.Method + " - " + context.Request.Path + " responded "+ context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + " ms";
                _loggerService.Write(message);

            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context,ex,watch);
            }
        }
        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            string message = "[Error]   HTTP " + context.Request.Method + " - " + context.Response.StatusCode + " Error message " + ex.Message + " in " + watch.Elapsed.TotalMilliseconds + " ms.";
            _loggerService.Write(message);

            var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None); //Json işlemlerini yapmak için newsoft json u nuget üzerinden projemize dahil ettik.

            return context.Response.WriteAsync(result);

        }
        //Extension method yazalım(program.cs de use.middleware şeklinde çağırabilmek için)

    }

    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}