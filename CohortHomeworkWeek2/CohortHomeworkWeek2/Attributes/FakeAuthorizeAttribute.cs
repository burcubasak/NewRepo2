using CohortHomeworkWeek2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CohortHomeworkWeek2.Attributes
{
    // Bu attribute, kullanıcı adı ve şifre doğrulaması yapar.
    public class FakeAuthorizeAttribute : Attribute, IAsyncActionFilter
    {
        // Bu metot, kullanıcı adı ve şifre doğrulaması yapar.
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // IAuthService servisini almak için gerekli olan servis sağlayıcısını alır.
            var authService = context.HttpContext.RequestServices.GetRequiredService<IAuthService>();

            // Kullanıcı adı ve şifre doğrulaması yapar.
            if (!authService.Authenticate("admin", "1234")) // Sabit kullanıcı adı ve şifre
            {
                // Kullanıcı adı ve şifre doğrulanamazsa, 401 Unauthorized döner.
                context.Result = new UnauthorizedResult();
                return;
            }

            // Kullanıcı adı ve şifre doğrulanırsa, bir sonraki middleware'e geçer.
            await next();
        }
    }
}
