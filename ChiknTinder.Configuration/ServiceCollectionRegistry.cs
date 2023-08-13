using ChiknTinder.Contracts.Persistence;
using ChiknTinder.Contracts.Services;
using ChiknTinder.Persistence.NHibernate.Repositories;
using ChiknTinder.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ChiknTinder.Configuration
{
    public static class ServiceCollectionRegistry
    {
        public static void RegisterScopedServices(IServiceCollection services)
        {
            services.AddScoped<ICryptoService, CryptoService>();
            services.AddScoped<IUserService, UserService>();
        }

        public static void RegisterScopedRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}