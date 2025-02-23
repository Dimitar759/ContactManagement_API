using DataAccess;
using DataAccess.Implementation;
using DataAccess.Interface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Implementation;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(x =>
                x.UseSqlServer(connectionString)); 
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ICountryService, CountryService>();
            // Add other services here
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped<IRepository<Company>, CompanyRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IRepository<Country>, CountryRepository >();
            // Add other repositories here
        }
    }
}
