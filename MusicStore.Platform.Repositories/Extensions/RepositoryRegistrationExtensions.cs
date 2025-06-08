
using Microsoft.Extensions.DependencyInjection;
using MusicStore.Platform.Repositories.EntityFramework;
using MusicStore.Platform.Repositories.Dapper;
using MusicStore.Platform.Repositories.Interfaces.EntityFramework;
using MusicStore.Platform.Repositories.Interfaces.Dapper;


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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();


        }

    }
}
