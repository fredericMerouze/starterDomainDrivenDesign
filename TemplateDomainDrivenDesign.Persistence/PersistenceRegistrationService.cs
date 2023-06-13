using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Application.Contracts;
using CleanArchitecture.Persistence.Repositories;
using CleanArchitecture.Domain.Contracts.Repositories;

namespace CleanArchitecture.Persistence
{
    public static class PersistenceRegistrationService
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>()!);
            services.AddScoped<ITaskRepository, TaskRepository>();

            return services;
        }
    }
}
