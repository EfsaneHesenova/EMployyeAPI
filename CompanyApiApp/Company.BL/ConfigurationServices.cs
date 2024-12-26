using Company.BL.ExternalServices.Abstractions;
using Company.BL.ExternalServices.Implementations;
using Company.BL.Services.Abstractions;
using Company.BL.Services.Implementations;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BL
{
    public static class ConfigurationServices
    {
        public static void AddBussinesServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddHttpContextAccessor();
            services.AddSingleton<IUrlHelperFactory, UrlHelperFactory>();
        }
    }
}
