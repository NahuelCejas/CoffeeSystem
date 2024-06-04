using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeSystem.Entity;


namespace CoffeeSystem.DAL.Interfaces
{
    public interface ICompraRepository : IGenericRepository<OrdenDeCompra>
    {
        Task<OrdenDeCompra> Registrar(OrdenDeCompra entidad);
        //Task<List<OrdenDeCompra>> Reporte(DateTime fechaInicio, DateTime fechaFin);
    }
}
