using InspectionApp.BLL.DTOs;
using InspectionApp.BLL.Helpers;
using InspectionApp.BLL.Interfaces;
using InspectionApp.BLL.Services;
using InspectionApp.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace InspectionApp.BLL.Extenstions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IHelperService<InspectionDto>, InspectionService>();
            services.AddScoped<IHelperService<InspectionTypeDto>, InspectionTypeService>();
            services.AddScoped<IHelperService<StatusDto>, StatusService>();

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            return services;
        }
    }
}
