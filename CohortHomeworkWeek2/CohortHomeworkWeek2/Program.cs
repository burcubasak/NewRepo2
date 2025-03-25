using CohortHomeworkWeek2.Extensions;
using CohortHomeworkWeek2.Middleware;
using CohortHomeworkWeek2.Repositories;
using CohortHomeworkWeek2.Services;
using CohortHomeworkWeek2.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Burada Program.cs dosyasýna servisleri Kaydettik.
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

//Burada AddRepositories metotunu çaðýrdýk.
builder.Services.AddRepositories();

//Burada FakeAuthService sýnýfýný IAuthService arayüzüne baðladýk.
builder.Services.AddSingleton<IAuthService, FakeAuthService>();


builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();



var app = builder.Build();

// **Önce Exception Middleware eklenmeli ki hata yönetimi en üstte olsun.**
app.UseMiddleware<ExceptionMiddleware>();

// **Sonra Logging Middleware eklenebilir.**
app.UseMiddleware<LoggingMiddleware>();

// Swagger Middleware (Development ortamýnda kullanýlacaksa)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS yönlendirmesi
app.UseHttpsRedirection();

// Yetkilendirme (Authorization) middleware’i burada olmalý
app.UseAuthorization();

// Controller'larý API'ye baðlama
app.MapControllers();

app.Run();
