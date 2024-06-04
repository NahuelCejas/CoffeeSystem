using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeSystem.DAL.Interfaces;
using CoffeeSystem.Entity;
using CoffeeSystem.DAL.DBContext;
using Microsoft.EntityFrameworkCore;

namespace CoffeeSystem.DAL.Implementacion
{
    public class CompraRepository : GenericRepository<OrdenDeCompra>, ICompraRepository
    {
        private readonly DbcoffeeSystemContext _dbContext;

        public CompraRepository(DbcoffeeSystemContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrdenDeCompra> Registrar(OrdenDeCompra entidad)
        {
            OrdenDeCompra ordenDeCompraGenerada = new OrdenDeCompra();

            //Se realiza una transaccion para que en caso de que ocurra un error al insertar datos a una tabla, se haga un rollback al inicio
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {          

                    NumeroCorrelativo correlativo = _dbContext.NumeroCorrelativos.Where(x => x.Gestion == "compra").First();

                    correlativo.UltimoNumero++;

                    _dbContext.NumeroCorrelativos.Update(correlativo);  
                    await _dbContext.SaveChangesAsync();
                    
                    string ceros = string.Concat(Enumerable.Repeat("0", correlativo.CantidadDigitos.Value));      //se concatena con  seis ceros
                    string numeroOrdenDeCompra = ceros + correlativo.UltimoNumero.ToString();                     //se concatena con el ultimo numero de la tabla
                    numeroOrdenDeCompra = numeroOrdenDeCompra.Substring(numeroOrdenDeCompra.Length - correlativo.CantidadDigitos.Value, correlativo.CantidadDigitos.Value); //se toma los ultimos 6 digitos

                    entidad.NumeroOrdenDeCompra = numeroOrdenDeCompra;

                    await _dbContext.OrdenDeCompras.AddAsync(entidad);
                    await _dbContext.SaveChangesAsync();

                    ordenDeCompraGenerada = entidad;

                    transaction.Commit();   
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }

                return ordenDeCompraGenerada;
            }            
            
        }
    }
    
}
