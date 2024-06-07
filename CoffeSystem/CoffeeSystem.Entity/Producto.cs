using System;
using System.Collections.Generic;

namespace CoffeeSystem.Entity;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string CodProducto { get; set; } = null!;    

    public string? Marca { get; set; }

    public string? Descripcion { get; set; }

    public int? IdProveedor { get; set; }

    public decimal? PrecioCompra { get; set; }    

    public int? Stock { get; set; }    

    public DateOnly? FechaVencimiento { get; set; }

    //public string? FechaVencimiento { get; set; }

    public string? UrlImagen { get; set; }

    public string? NombreImagen { get; set; }

    public virtual Proveedor? IdProveedorNavigation { get; set; }
}
