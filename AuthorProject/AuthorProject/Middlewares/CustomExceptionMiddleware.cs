using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace AuthorProject.Middlewares
{
    public class CustomExceptionMiddleware
    {

        private readonly RequestDelegate _next;
        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }



        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
           
            try
            {
                string message = "[Request] HTTP " + context.Request.Method + " " + context.Request.Path;
                Console.WriteLine(message);


                await _next(context);
                watch.Stop();

                message = "[Response] HTTP " + context.Response.StatusCode + " " + context.Request.Path + "Responded" + context.Response.StatusCode + "in" + watch.Elapsed.TotalMilliseconds + "ms";
                Console.WriteLine(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context, watch,ex);

            }
           
        }

        private  Task HandleException(HttpContext context, Stopwatch watch, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;


            string message = "[Error]     HTTP " + context.Request.Method + " - " + context.Response.StatusCode + "Error Message" + ex.Message + "in" + watch.Elapsed.TotalMilliseconds + "ms";
            Console.WriteLine(message);

           

            //Burada hata mesajını Json formatında döndürüyoruz.Bunun için Newtonsoft.Json kütüphanesini kullanıyoruz.
            var result = JsonConvert.SerializeObject(new
            

               { message = ex.Message},
                Formatting.None);

            return  context.Response.WriteAsync(result);


        }
    }


    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomeExceptionMiddleware(this IApplicationBuilder builder)
        {

            return builder.UseMiddleware<CustomExceptionMiddleware>();

        }

    }
}
