using DATA.Data.Entity;
using DATA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DATA.Extensions
{
    public static class DbInject
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookDbContext>(op =>
            {
                op.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            services.AddIdentity<User, Role>(options =>
            {

            }).AddEntityFrameworkStores<BookDbContext>().AddDefaultTokenProviders();
        }
    }
}
