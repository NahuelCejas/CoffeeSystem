using CoffeeSystem.Entity;

namespace CoffeeSystem.WebApp.Models.ViewModels
{
    public class VMProveedor
    {
        public int? IdProveedor { get; set; }

        public string? RazonSocial { get; set; }

        public string? Nombre { get; set; }        

        public string? Email { get; set; }

        public string? Telefono { get; set; }

        public string? Cuit { get; set; } 

        public string? Direccion { get; set; }

        public string? Localidad { get; set; }

        public string? CodigoPostal { get; set; }
        
    }
}
