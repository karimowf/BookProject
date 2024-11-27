using Microsoft.Extensions.DependencyInjection;
using Repository.Abstract;
using Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Extensions
{
    public static class RepositoryConfigure
    {
        public static IServiceCollection AddRepositoryConfigures(this IServiceCollection services)
        {
            services.AddScoped<IScoreRepository, ScoreRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            
            return services;
        }
    }
}
