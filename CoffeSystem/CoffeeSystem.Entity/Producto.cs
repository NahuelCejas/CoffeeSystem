using System;
using System.Collections.Generic;

namespace CoffeeSystem.Entity;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string CodProducto { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Marca { get; set; }

    public string? Descripcion { get; set; }

    public int? IdProveedor { get; set; }

    public decimal? PrecioCompra { get; set; }

    public decimal? PrecioVenta { get; set; }

    public int? Stock { get; set; }

    public int? StockMinimo { get; set; }

    public int? StockMaximo { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    public string? UrlImagen { get; set; }

    public string? NombreImagen { get; set; }

    public virtual Proveedor? IdProveedorNavigation { get; set; }
}
