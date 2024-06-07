using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CoffeeSystem.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using CoffeeSystem.DAL.Interfaces;
using CoffeeSystem.DAL.Implementacion;
using CoffeeSystem.BLL.Implementacion;
using CoffeeSystem.BLL.Interfaces;
using CoffeeSystem.BLL.Implementacion;



namespace CoffeeSystem.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencia(this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddDbContext<DbcoffeeSystemContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CadenaSQL"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ICompraRepository, CompraRepository>();

            services.AddScoped<IFireBaseService, FireBaseService>();

            services.AddScoped<IProveedorService, ProveedorService>();

            services.AddScoped<IProductoService, ProductoService>();
        }
    }
}
