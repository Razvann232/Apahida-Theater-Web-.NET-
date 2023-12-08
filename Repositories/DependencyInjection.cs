using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApahidaTheatherWeb.BusinessLogic;
using ApahidaTheatherWeb.Data;
using Microsoft.Extensions.DependencyInjection;
using ApahidaTheatherWeb.Controllers;

namespace ApahidaTheatherWeb.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, String c)
        {
            services.AddSwaggerGen();
            services.AddTransient<TicketRepository>();
            services.AddTransient<TicketService>();
            services.AddTransient<UserRepository>();
            services.AddTransient<UserService>();
            services.AddTransient<PlayRepository>();
            services.AddTransient<PlayService>();
            services.AddTransient<UnitOfWork>();

            services.AddDbContext<ApahidaTheatherWebContext>(opt => opt.UseSqlServer(c));
            return services;
        }
    }
}
