using StudyBuddy.API;
using StudyBuddy.Application;
using StudyBuddy.Core;
using StudyBuddy.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(option =>
{
   option.AddPolicy("AllowFrontend", policy =>
   {
      policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
   });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiDI();
builder.Services.AddApplicationDI();
builder.Services.AddCoreDI();
builder.Services.AddInfrastructureDI(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

// Use CORS policy
app.UseCors("AllowFrontend");

app.UseExceptionHandler(_ => { });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
