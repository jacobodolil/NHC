using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHC.Claims.DataAccess.DataStoreContext;
using NHC.Claims.DataAccess.Repository;
using NHC.Claims.DataAccess.UnitofWork;
using NHC.Claims.Service;
using System;

namespace NHC.Claims.DependencyFactory
{
    public static class CoreDependencyExtensions
    {
        public static void AddRepository(this IServiceCollection services)
        {            
            services.AddTransient<IUnitofWork, UnitofWork>();
            services.AddTransient<IClaimRepository, ClaimRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IClaimService, ClaimService>();
        }
    }
}
