-- SP para listar articulos...
Create procedure storedListar  as 
SELECT A.Codigo, A.Nombre Telefono, A.Descripcion,A.Precio,A.ImagenUrl,
A.IdMarca, A.IdCategoria, A.Id, M.Descripcion Modelo , C.Descripcion Tipo 
FROM ARTICULOS A, MARCAS M , CATEGORIAS C 
WHERE A.IdMarca = M.id AND A.IdCategoria = C.Id


Go

-- Logica para Logon

Create table Usuarios
(
	IdUsuario int identity(1000,1) primary key,
	Usuario varchar(50) unique not null,
	Contraseņa varbinary(500) not null,
	IdRol int foreign key references Roles(IdRol) not null
)

Create table Roles
(
	IdRol int identity(1000,1) primary key,
	Rol varchar(50) unique not null 
)


Go

Create procedure SP_AgregarUsuario
@Usuario varchar(50),
@Contraseņa varchar(50),
@IdRol int,
@Patron varchar(50)
As 
Begin

	if exists(select * from Usuarios where Usuario = @Usuario)
	begin
	raiserror('El usuario ya existe',16,1)
	return
	end

Insert into Usuarios(Usuario,Contraseņa, IdRol) values (@Usuario,ENCRYPTBYPASSPHRASE(@Patron,@Contraseņa),@IdRol)

End


Go 

Create procedure SP_ValidarUsuario
@Usuario varchar(50),
@Contraseņa varchar(50),
@Patron varchar(50)
As 
Begin

select * from Usuarios 
Where Usuario = @Usuario and CONVERT(Varchar(50),DECRYPTBYPASSPHRASE(@Patron,Contraseņa))=@Contraseņa 

End




-- Datos.
Go
SP_AgregarUsuario 'Encargado', '1234A', 1001, 'Programacion3'
Go
SP_AgregarUsuario 'Administrador', '1234A', 1000 , 'Programacion3'

-- Validaciones SP
exec SP_ValidarUsuario 'Encargado', '1234A', 'Programacion3'
exec SP_ValidarUsuario 'Administrador', '1234A', 1000, 'Programacion3'
