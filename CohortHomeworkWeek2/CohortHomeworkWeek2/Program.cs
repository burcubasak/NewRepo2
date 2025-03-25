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

//Burada Program.cs dosyas�na servisleri Kaydettik.
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

//Burada AddRepositories metotunu �a��rd�k.
builder.Services.AddRepositories();

//Burada FakeAuthService s�n�f�n� IAuthService aray�z�ne ba�lad�k.
builder.Services.AddSingleton<IAuthService, FakeAuthService>();


builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();



var app = builder.Build();

// **�nce Exception Middleware eklenmeli ki hata y�netimi en �stte olsun.**
app.UseMiddleware<ExceptionMiddleware>();

// **Sonra Logging Middleware eklenebilir.**
app.UseMiddleware<LoggingMiddleware>();

// Swagger Middleware (Development ortam�nda kullan�lacaksa)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS y�nlendirmesi
app.UseHttpsRedirection();

// Yetkilendirme (Authorization) middleware�i burada olmal�
app.UseAuthorization();

// Controller'lar� API'ye ba�lama
app.MapControllers();

app.Run();
