﻿using System;
using Microsoft.Extensions.DependencyInjection;
using HotChocolate.DataLoader;
using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection.Extensions;
using GreenDonut;

namespace HotChocolate
{
    public static class DataLoaderServiceCollectionExtensions
    {
        public static IServiceCollection AddDataLoader<T>(
            this IServiceCollection services)
            where T : class, IDataLoader
        {
            return services
                .AddDataLoaderRegistry()
                .AddTransient<T>();
        }

        public static IServiceCollection AddDataLoader<TService>(
            this IServiceCollection services,
            Func<IServiceProvider, TService> factory)
            where TService : class, IDataLoader
        {
            return services
                .AddDataLoaderRegistry()
                .AddTransient<TService>(factory);
        }

        public static IServiceCollection AddDataLoader<TService, TImplementation>(
            this IServiceCollection services)
            where TService : class, IDataLoader
            where TImplementation : class, TService
        {
            return services
                .AddDataLoaderRegistry()
                .AddTransient<TService, TImplementation>();
        }

        public static IServiceCollection AddDataLoaderRegistry(
            this IServiceCollection services)
        {
            services.TryAddScoped<IDataLoaderRegistry, DataLoaderRegistry>();
            services.TryAddScoped<IBatchOperation>(sp =>
            {
                var batchOperation = new DataLoaderBatchOperation();

                foreach (IDataLoaderRegistry registry in
                    sp.GetServices<IDataLoaderRegistry>())
                {
                    registry.Subscribe(batchOperation);
                }

                return batchOperation;
            });
            return services;
        }
    }
}
