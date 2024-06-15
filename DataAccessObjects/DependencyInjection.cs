using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Implement;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FunewsManagementDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            //Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<INewsArticleRepository, NewArticleRepository>();
            services.AddScoped<INewsTagRepository, NewsTagRepository>();
            services.AddScoped<ISystemAccountRepository, SystemAccountRepository>();
            services.AddScoped<ITagRepository, TagRepository>();

            //Services
            services.AddScoped<CategoryDAO>();
            services.AddScoped<NewsArticleDao>();
            services.AddScoped<NewsTagDAO>();
            services.AddScoped<SystemAccountDAO>();
            services.AddScoped<TagDAO>();

            return services;
        }
    }
}
