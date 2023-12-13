using Lecommerce.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lecommerce.IoC
{
    public static class DbExtensions
    {
        public static IServiceCollection AddPostgreSql(this IServiceCollection services, IConfiguration configuration, string dbHost = "", string dbName = "", string dbPassword = "")
        {
            string postgreConnection = "";
            if (string.IsNullOrEmpty(dbHost) || string.IsNullOrEmpty(dbName) || string.IsNullOrEmpty(dbPassword))
                postgreConnection = configuration.GetConnectionString("PostgreConnection")!;
            else
                postgreConnection = $"Server={dbHost}; Port=5432; Database={dbName}; User Id=postgres; Password={dbPassword};";

            services.AddDbContext<LecommerceContext>(o => o.UseNpgsql(postgreConnection));

            return services;
        }
    }
}
