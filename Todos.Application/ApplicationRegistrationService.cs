using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Todos.Application.Contracts;
using Todos.Application.Services;

namespace Todos.Application
{
    public static class ApplicationRegistrationService
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ITaskService, TaskService>();
        }
    }
}
