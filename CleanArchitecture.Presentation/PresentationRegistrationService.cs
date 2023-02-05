﻿using CleanArchitecture.Presentation.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Presentation
{
    public static class PresentationRegistrationService
    {
        public static void AddPresentationService(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<ApiExceptionFilterAttribute>();
            }).AddApplicationPart(AssemblyReference.Assembly);
        }
    }
}
