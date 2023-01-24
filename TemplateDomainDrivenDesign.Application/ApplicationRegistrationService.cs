using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Behaviors;
using CleanArchitecture.Application.Contracts;
using CleanArchitecture.Application.Services;

namespace CleanArchitecture.Application
{
    public static class ApplicationRegistrationService
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ITaskRepository, TaskService>();
        }
    }
}
