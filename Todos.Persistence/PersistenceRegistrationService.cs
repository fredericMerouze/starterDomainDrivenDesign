using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Application.Contracts;

namespace Todos.Persistence
{
    public static class PersistenceRegistrationService
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        }
    }
}
