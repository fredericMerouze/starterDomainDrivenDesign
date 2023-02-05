using CleanArchitecture.Application;
using CleanArchitecture.Application.Behaviors;
using CleanArchitecture.Filters;
using CleanArchitecture.Persistence;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
var presentationAssembly = typeof(CleanArchitecture.Presentation.AssemblyReference).Assembly;
// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiExceptionFilterAttribute>();
}).AddApplicationPart(presentationAssembly);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddApplicationService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
