using System;
using System.Collections.Generic;

namespace CoffeeSystem.Entity;

public partial class Proveedor
{    
    public int IdProveedor { get; set; }

    public string? RazonSocial { get; set; }

    public string? Nombre { get; set; }    

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? Cuit { get; set; }    

    public string? Direccion { get; set; }

    public string? Localidad { get; set; }

    public string? CodigoPostal { get; set; }

    public virtual ICollection<OrdenDeCompra> OrdenDeCompras { get; set; } = new List<OrdenDeCompra>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
