using AutoMapper;
using BookService.Services.Abstract;
using BookService.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using System.Threading.Tasks;

namespace BookService.Service.Configures
{
    public static class ServiceConfigures
    {
        public static void AddServiceConfigures(this IServiceCollection services)
        {
            // servisleri DI'e elave etmeni burda edirem
            services.AddScoped<IBookService, BookService.Services.Concrete.BookService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IScoreService, ScoreService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();

            //Automapper konfiqurasiyasini burda edirem
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
