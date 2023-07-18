using EmlakSiteAPI.Application.Repositories;
using EmlakSiteAPI.Application.Repositories.Adverts;
using EmlakSiteAPI.Application.Repositories.Messages;
using EmlakSiteAPI.Application.Repositories.Users;
using EmlakSiteAPI.Persistance.Contexts;
using EmlakSiteAPI.Persistance.Repositories.Adverts;
using EmlakSiteAPI.Persistance.Repositories.Messages;
using EmlakSiteAPI.Persistance.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakSiteAPI.Persistance
{
    public static class ServiceRegistiration
    {
        public static void AddServiceRegistiration(this IServiceCollection services)
        {
            services.AddDbContext<EmlakSiteDbContext>(options =>
                options.UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5728;Database=EmlakDb;"),
                    ServiceLifetime.Scoped);

            //services.AddDbContext<EmlakSiteDbContext>(options =>
            //    options.UseSqlServer("server=GGHQ-BT059;database=emlakSiteDb;integrated security=true"),
            //        ServiceLifetime.Scoped);

            services.AddScoped<IAdvertReadRepository, AdvertReadRepository>();
            services.AddScoped<IAdvertWriteRepository, AdvertWriteRepository>();

            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();

            services.AddScoped<IMessageReadRepository, MessageReadRepository>();
            services.AddScoped<IMessageWriteRepository, MessageWriteRepository>();

        }
    }
}
