using CoffeeSystem.Entity;

namespace CoffeeSystem.WebApp.Models.ViewModels
{
    public class VMOrdenDeCompra
    {
        public int IdOrdenDeCompra { get; set; }

        public string? NumeroOrdenDeCompra { get; set; }

        public int? IdProveedor { get; set; }

        public string? RazonSocialProveedor { get; set; }

        public string? NombreProveedor { get; set; }

        public decimal? Total { get; set; }

        public string? FechaRegistro { get; set; }

        public virtual ICollection<VMDetalleOrdenDeCompra> DetalleOrdenDeCompras { get; set; }

        public string? SubTotal { get; set; }       

        public string? ImpuestoTotal { get; set; }


    }
}
