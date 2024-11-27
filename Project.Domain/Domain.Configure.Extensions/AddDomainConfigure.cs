using Microsoft.Extensions.DependencyInjection;
using Project.Domain.UoW.Abstract;
using Project.Domain.UoW.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Domain.Configure.Extensions
{
    public static class AddDomainConfigure
    {
        public static IServiceCollection AddDomainConfigures(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
