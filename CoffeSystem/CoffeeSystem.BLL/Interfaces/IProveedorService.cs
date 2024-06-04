using CoffeeSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSystem.BLL.Interfaces
{
    public interface IProveedorService
    {
        Task<List<Proveedor>> Lista();
        Task<Proveedor> Registrar(Proveedor entidad);
        Task<Proveedor> Editar(Proveedor entidad);
        Task<bool> Eliminar(int IdProveedor);
        Task<Proveedor> Consultar(int IdProveedor);
        Task<bool> Guardar(Proveedor entidad);
    }
}
