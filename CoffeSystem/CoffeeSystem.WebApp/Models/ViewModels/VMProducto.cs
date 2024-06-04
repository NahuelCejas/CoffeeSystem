namespace CoffeeSystem.WebApp.Models.ViewModels
{
    public class VMProducto
    {
        public int IdProducto { get; set; }

        public string CodProducto { get; set; } = null!;        

        public string? Marca { get; set; }

        public string? Descripcion { get; set; }

        public int? IdProveedor { get; set; }

        //public decimal? PrecioCompra { get; set; }
        public string? PrecioCompra { get; set; }

        public int? Stock { get; set; }        

        public DateOnly? FechaVencimiento { get; set; }

        public string? UrlImagen { get; set; }

        public string? Proveedor { get; set; }



    }
}
