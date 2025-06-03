using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using MusicStore.Platform.Repositories;
using MusicStore.Platform.Repositories.Interfaces;
using MusicStore.Platform.Services;
using MusicStore.Platform.Services.Interfaces;

namespace MusicStore.Platform.Services.Extensions
{
    public static class RepositoryRegistrationExtensions
    {

        public static void RegisterPlatformRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerRepositoryDapper, CustomerRepositoryDapper>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderRepositoryDapper, OrderRepositoryDapper>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeRepositoryDapper, EmployeeRepositoryDapper>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductRepositoryDapper, ProductRepositoryDapper>();

        }

    }
}
