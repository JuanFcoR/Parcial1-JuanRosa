create database ProductosDb
go
use ProductosDb

create table Productos
(
	ProductoId int primary key,
	Descripcion varchar(25),
	Costo float,
	Existencia int,
	ValorInventario float
)