using System;
using System.Collections.Generic;

namespace CoffeeSystem.Entity;

public partial class DetalleOrdenDeCompra
{
    public int IdDetalleOrdenDeCompra { get; set; }

    public int? IdOrdenDeCompra { get; set; }

    public int? IdProducto { get; set; }

    public string? MarcaProducto { get; set; }

    public string? DescripcionProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public decimal? Total { get; set; }

    public virtual OrdenDeCompra? IdOrdenDeCompraNavigation { get; set; }
}
