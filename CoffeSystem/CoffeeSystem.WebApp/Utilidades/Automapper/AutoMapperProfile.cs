using CoffeeSystem.WebApp.Models.ViewModels;
using CoffeeSystem.Entity;
using System.Globalization;
using AutoMapper;


namespace CoffeeSystem.WebApp.Utilidades.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Proveedor
            CreateMap<Proveedor, VMProveedor>()
                //.ForMember(dest => dest.IdProveedor, opt => opt.MapFrom(src => src.IdProveedor))
                //.ForMember(dest => dest.RazonSocial, opt => opt.MapFrom(src => src.RazonSocial))
                //.ForMember(dest => dest.Cuit, opt => opt.MapFrom(src => src.Cuit))
                //.ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.Direccion))
                //.ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.Telefono))
                //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();
            #endregion Proveedor

            #region Producto
            CreateMap<Producto, VMProducto>()
                .ForMember(dest => dest.Proveedor, opt => opt.MapFrom(src => src.IdProveedorNavigation.RazonSocial))
                .ForMember(dest => dest.PrecioCompra, opt => opt.MapFrom(src => Convert.ToString(src.PrecioCompra.Value, new CultureInfo("es-AR"))));
                //.ForMember(dest => dest.FechaVencimiento, opt => opt.MapFrom(src => src.FechaVencimiento.Value.ToString("dd/MM/yyyy")));

            CreateMap<VMProducto, Producto>()
                .ForMember(dest => dest.IdProveedorNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.PrecioCompra, opt => opt.MapFrom(src => Convert.ToDecimal(src.PrecioCompra, new CultureInfo("es-AR"))));
            //.ForMember(dest => dest.FechaVencimiento, opt => opt.MapFrom(src => DateOnly.Parse(src.FechaVencimiento, new CultureInfo("es-AR"))));
            //.ForMember(dest => dest.FechaVencimiento, opt => opt.MapFrom(src => DateTime.Parse(src.FechaVencimiento, new CultureInfo("es-AR"))));
            //.ForMember(dest => dest.FechaVencimiento, opt => opt.MapFrom(src => DateTime.ParseExact(src.FechaVencimiento, "yyyy/MM/dd", CultureInfo.InvariantCulture)));
            //.ForMember(dest => dest.FechaVencimiento, opt => opt.MapFrom(src => DateHelper.ConvertToDateOnly(src.FechaVencimiento)));
            #endregion Producto

            #region OrdenDeCompra
            CreateMap<OrdenDeCompra, VMOrdenDeCompra>()
                .ForMember(dest => dest.RazonSocialProveedor, opt => opt.MapFrom(src => src.IdProveedorNavigation.RazonSocial))
                .ForMember(dest => dest.NombreProveedor, opt => opt.MapFrom(src => src.IdProveedorNavigation.Nombre))
                .ForMember(dest => dest.SubTotal, opt => opt.MapFrom(src => Convert.ToString(src.SubTotal.Value, new CultureInfo("es-AR"))))
                .ForMember(dest => dest.ImpuestoTotal, opt => opt.MapFrom(src => Convert.ToString(src.ImpuestoTotal.Value, new CultureInfo("es-AR"))))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => Convert.ToString(src.Total.Value, new CultureInfo("es-AR"))))
                .ForMember(dest => dest.FechaRegistro, opt => opt.MapFrom(src => src.FechaRegistro.Value.ToString("dd/MM/yyyy")));

            CreateMap<VMOrdenDeCompra, OrdenDeCompra>()
                .ForMember(dest => dest.SubTotal, opt => opt.MapFrom(src => Convert.ToDecimal(src.SubTotal, new CultureInfo("es-AR"))))
                .ForMember(dest => dest.ImpuestoTotal, opt => opt.MapFrom(src => Convert.ToDecimal(src.ImpuestoTotal, new CultureInfo("es-AR"))))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => Convert.ToDecimal(src.Total, new CultureInfo("es-AR"))));

            #endregion OrdenDeCompra

            #region DetalleOrdenDeCompra
            CreateMap<DetalleOrdenDeCompra, VMDetalleOrdenDeCompra>()
                .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => Convert.ToString(src.Precio.Value, new CultureInfo("es-AR"))))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => Convert.ToString(src.Total.Value, new CultureInfo("es-AR"))));

            CreateMap<VMDetalleOrdenDeCompra, DetalleOrdenDeCompra>()
                .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => Convert.ToDecimal(src.Precio, new CultureInfo("es-AR"))))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => Convert.ToDecimal(src.Total, new CultureInfo("es-AR"))));

            #endregion DetalleOrdenDeCompra
        }
    }
    
}
