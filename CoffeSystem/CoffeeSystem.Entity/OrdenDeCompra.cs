using System;
using System.Collections.Generic;

namespace CoffeeSystem.Entity;

public partial class OrdenDeCompra
{
    public int IdOrdenDeCompra { get; set; }

    public string? NumeroOrdenDeCompra { get; set; }

    public int? IdProveedor { get; set; }

    public string? RazonSocialProveedor { get; set; }

    public string? NombreProveedor { get; set; }

    public decimal? Total { get; set; }

    public decimal? SubTotal { get; set; }

    public decimal? ImpuestoTotal { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<DetalleOrdenDeCompra> DetalleOrdenDeCompras { get; set; } = new List<DetalleOrdenDeCompra>();

    public virtual Proveedor? IdProveedorNavigation { get; set; }
}
