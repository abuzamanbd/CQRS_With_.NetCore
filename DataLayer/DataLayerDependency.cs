using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DataLayer.Interface;
using DataLayer.Repositories;
using DataLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayer
{
    public static class DataLayerDependency
    {
        public static void AllDependency(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddTransient<IProductRepository, ProductRepository>();
        }

        //dotnet ef migrations add InitialCreate --project "DataLayer" --startup-project "API"
        //dotnet ef database update --project "DataLayer" --startup-project "API"
    }
}
