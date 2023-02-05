using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using CleanArchitecture.Application.Behaviors;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Application.Contracts.Services;

namespace CleanArchitecture.Application
{
    public static class ApplicationRegistrationService
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            var t = Assembly.GetExecutingAssembly();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddScoped<ITaskService, TaskService>();
        }
    }
}
