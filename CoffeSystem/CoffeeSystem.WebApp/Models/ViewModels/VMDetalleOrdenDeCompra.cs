namespace CoffeeSystem.WebApp.Models.ViewModels
{
    public class VMDetalleOrdenDeCompra
    {
        public int IdDetalleOrdenDeCompra { get; set; }

        public int? IdOrdenDeCompra { get; set; }

        public int? IdProducto { get; set; }

        public string? MarcaProducto { get; set; }

        public string? DescripcionProducto { get; set; }

        public int? Cantidad { get; set; }

        public string? Precio { get; set; }

        public string? Total { get; set; }


    }
}
