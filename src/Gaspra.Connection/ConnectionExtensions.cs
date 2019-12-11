using DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gaspra.Connection
{
    public static class ConnectionExtensions
    {
        public static IServiceCollection RegisterDataAccessServices(this IServiceCollection services)
        {
            services
                .AddTransient<IAccessOrders, AccessOrders>();

            return services;
        }
    }
}
