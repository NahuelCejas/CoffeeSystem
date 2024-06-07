
create database DBCoffeeSystem

go

use DBCoffeeSystem


go


create table Proveedor(
idProveedor int primary key identity(1,1),
razonSocial VARCHAR(50) NOT NULL,
nombre varchar(50),
email varchar(50),
telefono varchar(50),
cuit VARCHAR(20) NOT NULL,
direccion varchar(50),
localidad varchar(50),
codigoPostal VARCHAR(20),
)

go

create table Producto(
idProducto int primary key identity(1,1),
codProducto varchar(50) UNIQUE NOT NULL,
marca varchar(50),
descripcion varchar(150),
idProveedor int references Proveedor(idProveedor),
precioCompra DECIMAL(10,2),
stock int,
fechaVencimiento date,
urlImagen varchar(500),
nombreImagen varchar(100),
)

go

create table NumeroCorrelativo(
idNumeroCorrelativo int primary key identity(1,1),
ultimoNumero int,
cantidadDigitos int,
gestion varchar(100),
fechaActualizacion datetime
)

go

create table OrdenDeCompra(
idOrdenDeCompra int primary key identity(1,1),
numeroOrdenDeCompra varchar(6),
idProveedor int references Proveedor(idProveedor),
razonSocialProveedor varchar(50),
nombreProveedor varchar(20),
SubTotal decimal(10,2),
ImpuestoTotal decimal(10,2),
Total decimal(10,2),
fechaRegistro datetime default getdate()
)

go

create table DetalleOrdenDeCompra(
idDetalleOrdenDeCompra int primary key identity(1,1),
idOrdenDeCompra int references OrdenDeCompra(idOrdenDeCompra),
idProducto int,
marcaProducto varchar(100),
descripcionProducto varchar(100),
cantidad int,
precio decimal(10,2),
total decimal(10,2)
)


go

create table Configuracion(
recurso varchar(50),
propiedad varchar(50),
valor varchar(60)
)

