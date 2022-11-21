use master
go

go
use CATALOGO_DB
go
USE [CATALOGO_DB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MARCAS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_MARCAS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [CATALOGO_DB]
GO

/****** Object:  Table [dbo].[CATEGORIAS]    Script Date: 08/09/2019 10:32:14 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CATEGORIAS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_CATEGORIAS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [CATALOGO_DB]
GO

/****** Object:  Table [dbo].[ARTICULOS]    Script Date: 08/09/2019 10:32:24 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ARTICULOS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](150) NULL,
	[IdMarca] [int] NULL,
	[IdCategoria] [int] NULL,
	[ImagenUrl] [varchar](1000) NULL,
	[Precio] [money] NULL,
 CONSTRAINT [PK_ARTICULOS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

insert into MARCAS values ('Samsung'), ('Apple'), ('Sony'), ('Huawei'), ('Motorola')
insert into CATEGORIAS values ('Celulares'),('Televisores'), ('Media'), ('Audio')
insert into ARTICULOS values ('S01', 'Galaxy S10', 'Una canoa cara', 1, 1, 'https://images.samsung.com/is/image/samsung/co-galaxy-s10-sm-g970-sm-g970fzyjcoo-frontcanaryyellow-thumb-149016542', 69.999),
('M03', 'Moto G Play 7ma Gen', 'Ya siete de estos?', 1, 5, 'https://www.motorola.cl/arquivos/moto-g7-play-img-product.png?v=636862863804700000', 15699),
('S99', 'Play 4', 'Ya no se cuantas versiones hay', 3, 3, 'https://www.euronics.cz/image/product/800x800/532620.jpg', 35000),
('S56', 'Bravia 55', 'Alta tele', 3, 2, 'https://intercompras.com/product_thumb_keepratio_2.php?img=images/product/SONY_KDL-55W950A.jpg&w=650&h=450', 49500),
('A23', 'Apple TV', 'lindo loro', 2, 3, 'https://cnnespanol2.files.wordpress.com/2015/12/gadgets-mc3a1s-populares-apple-tv-2015-18.jpg?quality=100&strip=info&w=460&h=260&crop=1', 7850)

select * from ARTICULOS

-- Crear tabla de Provedores

USE [CATALOGO_DB]
GO

Create table PROVEEDORES
(
	Id int primary key identity(1000,1) not null,
	RazonSocial varchar(50) not null,
	Cuit varchar(50) not null,
	Telefono varchar(50),
	Email varchar(50),
	Estado bit not null default 1
	
)

-- insertar provedor

insert into PROVEEDORES(RazonSocial,Cuit,Telefono,Email) values ('Tienda De Cafe','30-12345678-9','123456789','tiendacafe@gmailcom')

-- modificar SP storedListar (para que solo muestre los articulos activos)

ALTER procedure [dbo].[storedListar] as 
SELECT A.Codigo, A.Nombre Telefono, A.Descripcion,A.Precio,A.ImagenUrl,
A.IdMarca, A.IdCategoria, A.Id, M.Descripcion Modelo , C.Descripcion Tipo 
FROM ARTICULOS A, MARCAS M , CATEGORIAS C 
WHERE A.IdMarca = M.id AND A.IdCategoria = C.Id AND A.Estado = 1

-- Crear tabla de clientes

USE [CATALOGO_DB]
Go 

Create table CLIENTES
(
	Id int primary key identity(1000,1) not null,
	Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	Dni varchar(50) unique not null,
	Telefono varchar(50),
	Email varchar(50),
	Estado bit not null default 1
	
)

-- insertar Cliente

insert into CLIENTES (Nombre,Apellido,Dni,Telefono,Email) values ('Juan','Perez','12345678','123456789','juanperez@gmailcom')
insert into CLIENTES (Nombre,Apellido,Dni,Telefono,Email) values ('Medina','Perez','2341','2134','medina@gmailcom')

-- agregar columna Stock en tabla Articulos

ALTER TABLE Articulos
ADD Stock int

-- completar la columna Stock de los articulos existentes con un valor numerico

--Preguntar a stef porque proveedores y no articulos... porque me genero error en Proveedores.
update PROVEEDORES set Stock=100 where id<100

-- Modificar SP para que muestre el Stock de cada articulo

ALTER procedure [dbo].[storedListar] as 
SELECT A.Codigo, A.Nombre Telefono, A.Descripcion,A.Precio,A.ImagenUrl,
A.IdMarca, A.IdCategoria, A.Id, M.Descripcion Modelo , C.Descripcion, A.Stock Tipo 
FROM ARTICULOS A, MARCAS M , CATEGORIAS C 
WHERE A.IdMarca = M.id AND A.IdCategoria = C.Id AND A.Estado = 1

--agregar columna Proveedor a tabla Articulos

ALTER TABLE Articulos
ADD Proveedor int

-- settear columnar Proveedor como FK 

ALTER TABLE Articulos 
ADD CONSTRAINT fk_proveeder FOREIGN KEY (Proveedor) REFERENCES PROVEEDORES(id);

-- completar la columna Proveedor de los articulos existentes con un valor numerico

update ARTICULOS set Proveedor=1000 where id<100

-- agregar proveedor generico 

insert into PROVEEDORES
( RazonSocial, Cuit, Telefono, Email)
values( 'Sin proveedor', 0000000, 000000,' ')


-- crear tabla para relacionar todos los articulos con todos los proveedores

CREATE TABLE ARTICULOSxPROVEEDORES(
	idArticulo int not null,
	idProveedor int not null,
	primary key (idArticulo, idProveedor)
)

-- agregar las claves foraneas para ambos casos

ALTER TABLE ARTICULOSxPROVEEDORES
ADD CONSTRAINT fk_articulo
FOREIGN KEY(idArticulo)REFERENCES
ARTICULOS(id)

ALTER TABLE ARTICULOSxPROVEEDORES
ADD CONSTRAINT fk_proveedor
FOREIGN KEY(idProveedor)REFERENCES
PROVEEDORES(id)

--  cargar tabla ARTICULOSxPROVEEDORES

 INSERT INTO ARTICULOSxPROVEEDORES values (1,1000)
 INSERT INTO ARTICULOSxPROVEEDORES values (2,1000)

-- crear tabla para los Registros contables

Create table REGISTROS
(
	Id int primary key identity(1000,1) not null,
	Tipo int not null,
	Destinatario int not null,
	idArticulo int not null,
	Cantidad int not null,
	Monto money not null,
	Estado bit not null default 1
)
--Tipo: compra 1, venta 0
-- Destinaratio: IdProveedor o IdCliente 

-- cargar tabla REGISTROS

INSERT INTO REGISTROS(Tipo, Destinatario, idArticulo, Cantidad, Monto) values (1,1000, 1, 10, 99.0 )
INSERT INTO REGISTROS(Tipo, Destinatario, idArticulo, Cantidad, Monto) values (0,1000, 1, 10, 1199.0 )

select * from REGISTROS
select * from ARTICULOS
select * from PROVEEDORES
select * from CLIENTES

