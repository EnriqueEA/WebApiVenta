create database VentaRepuestos
Go
-- Use venta_auto_parts
Use VentaRepuestos
-- Use master
Go

Create Table categoria(
categoriaId int identity(1, 1) primary key,
nombreCategoria varchar(50) unique not null,
categoriaPadre int null
)
Go
Create Table producto(
productoId int identity(1, 1) primary key,
categoriaId int not null,
marcaId int not null,
nombreProducto varchar(60) unique not null,
descripcion varchar(600) not null,
modelo varchar(45) not null,
stock int not null,
precio decimal(10, 2) not null
)
Go
Create Table imagen(
imagenId int identity(1, 1) primary key,
url varchar(200) unique not null,
productoId int not null
)
Go
Create Table marca(
marcaId int identity(1, 1) primary key,
paisId int not null,
descripcion varchar(45) not null
)
Go
Create Table rol(
rolId int identity(1, 1) primary key,
nombreRol varchar(100) not null
)
Go
Create Table usuario(
usuarioId int identity(1, 1) primary key,
nombreUsuario varchar(100) not null,
contrasena varchar(100) not null,
fechaCreacion datetime not null,
rolId int not null
)
Go -- agregarles permisos y crear un nuevo rol
Create Table usuarioRol(
usuarioRolId int identity(1, 1) primary key,
usuarioId int not null,
rolId int not null
)
GO
---------------------------------------------

Create Table cliente (
clienteId int identity(1, 1) primary key,
nombres varchar(45) not null,
apellidos varchar(100) not null,
direccion varchar(100) not null,
celular varchar(9) not null
)
Go
Create Table pedido (
pedidoId int identity(1, 1) primary key,
clienteId int not null,
lugarEntregaId int not null,
fechaRegistro datetime not null,
fechaEntrega datetime not null
)
/* se puede pagar al instante o el cliente puede decidir realizar el pago después */

Go
Create Table detallePedido (
detallePedidoId int identity(1, 1) primary key,
pedidoId int not null,
productoId int not null,
descuento decimal(10, 2) not null,
cantidad int not null,
subtotal decimal(10, 2) not null
)
Go
Create Table venta (
ventaId int identity(1, 1) primary key,
pedidoId int not null,
fechaVenta datetime not null,
total decimal(10, 2) not null
)
Go
Create Table historialPedido (
historialPedidoId int identity(1, 1) primary key,
pedidoId int not null,
estado varchar(10) not null,
fecha datetime not null
)
Go
Create Table pais (
paisId int identity(1, 1) primary key,
iso varchar(45) not null,
nombrePais varchar(45) not null
)
Go
Create Table lugarEntrega (
lugarEntregaId int identity(1, 1) primary key,
distritoId int not null,
precioEnvio decimal(10,2) not null
)
Go
Create Table departamento (
departamentoId int identity(1, 1) primary key,
nombre varchar(45) not null
)
Go
Create Table provincia (
provinciaId int identity(1, 1) primary key,
departamentoId int not null,
nombre varchar(45) not null
)
Go
Create Table distrito (
distritoId int identity(1, 1) primary key,
provinciaId int not null,
nombre varchar(45) not null
)

/*************** RELACIONES ****************/

Alter Table producto add constraint fk_producto_categoria 
foreign key (categoriaId) references categoria(categoriaId)

Alter Table producto add constraint fk_producto_marca 
foreign key (marcaId) references marca(marcaId)

Alter Table imagen add constraint fk_imagen_producto 
foreign key (productoId) references producto(productoId)

Alter Table categoria add constraint fk_categoria_categoriaPadre 
foreign key (categoriaPadre) references categoria(categoriaId)

Alter Table usuario add constraint fk_usuario_rol 
foreign key (rolId) references rol(rolId)

Alter Table usuarioRol add constraint fk_usuarioRol_rol 
foreign key (rolId) references rol(rolId)

Alter Table usuarioRol add constraint fk_usuarioRol_usuario 
foreign key (usuarioId) references usuario(usuarioId)

Alter Table pedido add constraint fk_pedido_cliente 
foreign key (clienteId) references cliente(clienteId)

Alter Table pedido add constraint fk_pedido_lugarEntrega 
foreign key (lugarEntregaId) references lugarEntrega(lugarEntregaId)

Alter Table detallePedido add constraint fk_detalleP_pedido 
foreign key (pedidoId) references pedido(pedidoId)

Alter Table detallePedido add constraint fk_detalleP_producto 
foreign key (productoId) references producto(productoId)

Alter Table venta add constraint fk_venta_pedido 
foreign key (pedidoId) references pedido(pedidoId)

Alter Table historialPedido add constraint fk_historialP_pedido 
foreign key (pedidoId) references pedido(pedidoId)

Alter Table marca add constraint fk_marca_pais 
foreign key (paisId) references pais(paisId)

Alter Table lugarEntrega add constraint fk_lugarEntrega_distrito 
foreign key (distritoId) references distrito(distritoId)

Alter Table distrito add constraint fk_distrito_provincia 
foreign key (provinciaId) references provincia(provinciaId)

Alter Table provincia add constraint fk_provincia_departamento 
foreign key (departamentoId) references departamento(departamentoId)


/* INSERT INTO categoria (nombreCategoria)
VALUES ('Faros'),
        ('Faros')
GO

select * from categoria
 */


/*
Requerimientos:

Seccion de marcas donde aparezca todas:
Sony
Hiunday
VMW

y al darle click me muestre todos los productos respecto a esa marca,
al igual con las categorías


Faltan:
    tabla ventas, solicitud de compra

para la venta:
    - El cliente tendrá que realizará el pedido 
    (puede adquirir varios productos mediante un carrito de compras),
    el cuál será mediante "pago contra entrega", 
    y el usuario admin (vendedor) recibirá el pedido que vendrá 
    con un estado inicial de pendiente (o en proceso de confirmación de la compra)
    hasta que el vendedor haga la confirmación, el cliente deberá proporcionar un
    lugar de entrega

    ...y asi podemos reolver el problema del stock
    
*/

