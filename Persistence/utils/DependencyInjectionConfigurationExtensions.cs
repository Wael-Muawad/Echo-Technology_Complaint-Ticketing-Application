using Domain.Common;
using Domain.Entities;
using Domain.IRepositories;
using Domain.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.AppContexts.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.utils
{
    public static class DependencyInjectionConfigurationExtensions
    {

        public static void RegisterInfraStructure(this IServiceCollection services, IConfiguration configuration)
        {
            //var dataConnectionString = configuration.GetConnectionString("DataConnection") ??
            //    throw new InvalidOperationException("Connection string 'DataConnection' not found.");

            //var securityConnectionString = configuration.GetConnectionString("SecurityConnection") ??
            //    throw new InvalidOperationException("Connection string 'SecurityConnection' not found.");
            //services.AddDbContextFactory<IdentityContext>();

            services.AddAuthorization();
            services.AddDbContextFactory<AppDBContext>();

            services.AddIdentityApiEndpoints<AppUser>()
                .AddRoles<AppRole>()
                .AddEntityFrameworkStores<AppDBContext>();

            //Register Repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IComplaintRepo, ComplaintRepo>();
            services.AddScoped<IDemandRepo, DemandRepo>();
        }
    }
}
