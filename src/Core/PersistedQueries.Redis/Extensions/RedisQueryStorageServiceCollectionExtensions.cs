using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using HotChocolate.Execution;
using HotChocolate.PersistedQueries.FileSystem;

namespace HotChocolate
{
    /// <summary>
    /// Provides utility methods to setup dependency injection.
    /// </summary>
    public static class RedisQueryStorageServiceCollectionExtensions
    {
        /// <summary>
        /// Adds a redis read and write query storage to the
        /// services collection.
        /// </summary>
        /// <param name="services">
        /// The service collection to which the services are added.
        /// </param>
        /// <param name="databaseFactory">
        /// A factory that resolves the redis database that
        /// shall be used for persistence.
        /// </param>
        public static IServiceCollection AddRedisQueryStorage(
            this IServiceCollection services,
            Func<IServiceProvider, IDatabase> databaseFactory)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (databaseFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseFactory));
            }

            services.AddReadOnlyRedisQueryStorage(databaseFactory);
            services.AddSingleton<IWriteStoredQueries>(sp =>
                sp.GetRequiredService<RedisQueryStorage>());
            return services;
        }

        /// <summary>
        /// Adds a redis read-only query storage to the services collection.
        /// </summary>
        /// <param name="services">
        /// The service collection to which the services are added.
        /// </param>
        /// <param name="databaseFactory">
        /// A factory that resolves the redis database that
        /// shall be used for persistence.
        /// </param>
        public static IServiceCollection AddReadOnlyRedisQueryStorage(
            this IServiceCollection services,
            Func<IServiceProvider, IDatabase> databaseFactory)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (databaseFactory is null)
            {
                throw new ArgumentNullException(nameof(databaseFactory));
            }

            RemoveService<IReadStoredQueries>(services);
            RemoveService<IWriteStoredQueries>(services);

            services.AddSingleton<RedisQueryStorage>(sp =>
                new RedisQueryStorage(databaseFactory(sp)));
            services.AddSingleton<IReadStoredQueries>(sp =>
                sp.GetRequiredService<RedisQueryStorage>());
            return services;
        }

        private static IServiceCollection RemoveService<TService>(
            this IServiceCollection services)
        {
            ServiceDescriptor serviceDescriptor = services
                .FirstOrDefault(t => t.ServiceType == typeof(TService));

            if (serviceDescriptor != null)
            {
                services.Remove(serviceDescriptor);
            }

            return services;
        }
    }
}
