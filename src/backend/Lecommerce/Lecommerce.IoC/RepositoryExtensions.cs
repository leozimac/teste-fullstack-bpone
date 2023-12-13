using Lecommerce.Domain.Repository;
using Lecommerce.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Lecommerce.IoC
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
