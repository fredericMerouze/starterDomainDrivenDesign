using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TemplateDomainDrivenDesign.Application.Behaviors;
using TemplateDomainDrivenDesign.Application.Contracts;
using TemplateDomainDrivenDesign.Application.Services;

namespace TemplateDomainDrivenDesign.Application
{
    public static class ApplicationRegistrationService
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ITaskService, TaskService>();
        }
    }
}
