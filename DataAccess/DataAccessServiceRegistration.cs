﻿using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessService(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            services.AddScoped<IUserRepository, EfUserRepository>();
            services.AddDbContext<BaseDbContext>();

            return services;
        }
    }
}
