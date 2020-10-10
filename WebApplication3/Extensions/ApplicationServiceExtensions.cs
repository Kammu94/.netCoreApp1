using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Interfaces;
using WebApplication3.Services;

namespace WebApplication3.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationSerives(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<DataContext>(x => x.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
