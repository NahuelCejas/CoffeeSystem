using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text;
using CoffeeSystem.DAL.Interfaces;
using CoffeeSystem.BLL.Interfaces;
using CoffeeSystem.Entity;


namespace CoffeeSystem.BLL.Implementacion
{
    public class ProveedorService : IProveedorService
    {
        private readonly IGenericRepository<Proveedor> _repositorio;
        private readonly IFireBaseService _fireBaseService;

        public ProveedorService(IGenericRepository<Proveedor> repositorio, IFireBaseService fireBaseService)
        {
            _repositorio = repositorio;
            _fireBaseService = fireBaseService;
        }

        public async Task<List<Proveedor>> Lista()
        {
            IQueryable<Proveedor> query = await _repositorio.Consultar();
            
            return query.ToList();
        }

        public async Task<Proveedor> Registrar(Proveedor entidad)
        {
            Proveedor proveedorExiste = await _repositorio.Obtener(p => p.Cuit == entidad.Cuit); 
            
            if (proveedorExiste != null)
            {
                throw new TaskCanceledException("El CUIT ya existe");
            }

            try
            {
                Proveedor proveedor = await _repositorio.Crear(entidad);

                if(proveedor.IdProveedor == 0)
                {
                    throw new TaskCanceledException("Error al registrar el proveedor");
                }

                IQueryable<Proveedor> query = await _repositorio.Consultar(p => p.IdProveedor == proveedor.IdProveedor);

                return proveedor;

            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<Proveedor> Editar(Proveedor entidad)
        {
            Proveedor proveedorExiste = await _repositorio.Obtener(p => p.Cuit == entidad.Cuit && p.IdProveedor != entidad.IdProveedor);

            if (proveedorExiste != null)
            {
                throw new TaskCanceledException("El CUIT ya existe");
            }

            try
            {
                IQueryable<Proveedor> queryProveedor = await _repositorio.Consultar(p => p.IdProveedor == entidad.IdProveedor);

                Proveedor proveedorEditar = queryProveedor.First();
                proveedorEditar.RazonSocial = entidad.RazonSocial;
                proveedorEditar.Nombre = entidad.Nombre;    
                //proveedorEditar.Apellido = entidad.Apellido;
                proveedorEditar.Email = entidad.Email;
                proveedorEditar.Telefono = entidad.Telefono;
                proveedorEditar.Cuit = entidad.Cuit;
                proveedorEditar.Direccion = entidad.Direccion;
                proveedorEditar.Localidad = entidad.Localidad;
                proveedorEditar.CodigoPostal = entidad.CodigoPostal;

                bool respuesta = await _repositorio.Editar(proveedorEditar);

                if (!respuesta)
                {
                    throw new TaskCanceledException("No se pudo modificar el proveedor");
                }

                return proveedorEditar;
            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> Eliminar(int IdProveedor)
        {
            try
            {
                Proveedor proveedorEncontrado = await _repositorio.Obtener(p => p.IdProveedor == IdProveedor);

                if (proveedorEncontrado == null)
                {
                    throw new TaskCanceledException("El proveedor no existe");
                }

                bool respuesta = await _repositorio.Eliminar(proveedorEncontrado);

                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<Proveedor> Consultar(int IDProveedor)
        {
            IQueryable<Proveedor> query = await _repositorio.Consultar(p => p.IdProveedor == IDProveedor);

            Proveedor resultado = query.FirstOrDefault();

            return resultado;
        }        

        public async Task<bool> Guardar(Proveedor entidad)
        {
            try
            {
                Proveedor proveedorEncontrado = await _repositorio.Obtener(p => p.IdProveedor == entidad.IdProveedor);

                if (proveedorEncontrado == null)
                {
                    throw new TaskCanceledException("El proveedor no existe");
                }

                proveedorEncontrado.RazonSocial = entidad.RazonSocial;
                proveedorEncontrado.Nombre = entidad.Nombre;    
                //proveedorEncontrado.Apellido = entidad.Apellido;
                proveedorEncontrado.Email = entidad.Email;
                proveedorEncontrado.Telefono = entidad.Telefono;
                proveedorEncontrado.Cuit = entidad.Cuit;
                proveedorEncontrado.Direccion = entidad.Direccion;
                proveedorEncontrado.Localidad = entidad.Localidad;
                proveedorEncontrado.CodigoPostal = entidad.CodigoPostal;

                bool respuesta = await _repositorio.Editar(proveedorEncontrado);

                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        
    }
}
