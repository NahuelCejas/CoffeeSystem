using System;
using System.Collections.Generic;
using CoffeeSystem.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoffeeSystem.DAL.DBContext;

public partial class DbcoffeeSystemContext : DbContext
{
    public DbcoffeeSystemContext()
    {
    }

    public DbcoffeeSystemContext(DbContextOptions<DbcoffeeSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Configuracion> Configuracions { get; set; }

    public virtual DbSet<DetalleOrdenDeCompra> DetalleOrdenDeCompras { get; set; }

    public virtual DbSet<NumeroCorrelativo> NumeroCorrelativos { get; set; }

    public virtual DbSet<OrdenDeCompra> OrdenDeCompras { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Configuracion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Configuracion");

            entity.Property(e => e.Propiedad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("propiedad");
            entity.Property(e => e.Recurso)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("recurso");
            entity.Property(e => e.Valor)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("valor");
        });

        modelBuilder.Entity<DetalleOrdenDeCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalleOrdenDeCompra).HasName("PK__DetalleO__4FA26974E4A47F4C");

            entity.ToTable("DetalleOrdenDeCompra");

            entity.Property(e => e.IdDetalleOrdenDeCompra).HasColumnName("idDetalleOrdenDeCompra");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.DescripcionProducto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcionProducto");
            entity.Property(e => e.IdOrdenDeCompra).HasColumnName("idOrdenDeCompra");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.MarcaProducto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("marcaProducto");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdOrdenDeCompraNavigation).WithMany(p => p.DetalleOrdenDeCompras)
                .HasForeignKey(d => d.IdOrdenDeCompra)
                .HasConstraintName("FK__DetalleOr__idOrd__33D4B598");
        });

        modelBuilder.Entity<NumeroCorrelativo>(entity =>
        {
            entity.HasKey(e => e.IdNumeroCorrelativo).HasName("PK__NumeroCo__25FB547E3CAE2127");

            entity.ToTable("NumeroCorrelativo");

            entity.Property(e => e.IdNumeroCorrelativo).HasColumnName("idNumeroCorrelativo");
            entity.Property(e => e.CantidadDigitos).HasColumnName("cantidadDigitos");
            //entity.Property(e => e.FechaActualizacion)
            //    .HasColumnType("datetime")
            //    .HasColumnName("fechaActualizacion");
            entity.Property(e => e.Gestion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("gestion");
            entity.Property(e => e.UltimoNumero).HasColumnName("ultimoNumero");
        });

        modelBuilder.Entity<OrdenDeCompra>(entity =>
        {
            entity.HasKey(e => e.IdOrdenDeCompra).HasName("PK__OrdenDeC__5874C40629E7FC0C");

            entity.ToTable("OrdenDeCompra");

            entity.Property(e => e.IdOrdenDeCompra).HasColumnName("idOrdenDeCompra");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.NombreProveedor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombreProveedor");
            entity.Property(e => e.NumeroOrdenDeCompra)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("numeroOrdenDeCompra");
            entity.Property(e => e.RazonSocialProveedor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("razonSocialProveedor");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SubTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ImpuestoTotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.OrdenDeCompras)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__OrdenDeCo__idPro__300424B4");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__07F4A13299071078");

            entity.ToTable("Producto");

            entity.HasIndex(e => e.CodProducto, "UQ__Producto__59E87D7D380051FA").IsUnique();

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.CodProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codProducto");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaVencimiento)
                .HasColumnName("fechaVencimiento")
                .HasColumnType("dateOnly");
                //.HasColumnType("datetime")
                //.HasDefaultValueSql("(getdate())"); 
            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            
            entity.Property(e => e.NombreImagen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreImagen");
            entity.Property(e => e.PrecioCompra)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precioCompra");
            
            entity.Property(e => e.Stock).HasColumnName("stock");
           
            entity.Property(e => e.UrlImagen)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("urlImagen");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__Producto__idProv__2B3F6F97");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__A3FA8E6BB59F245F");

            entity.ToTable("Proveedor");

            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            //entity.Property(e => e.Apellido)
            //    .HasMaxLength(50)
            //    .IsUnicode(false)
            //    .HasColumnName("apellido");
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("codigoPostal");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Cuit)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cuit");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Localidad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("localidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");            
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("razonSocial");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono");            
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
