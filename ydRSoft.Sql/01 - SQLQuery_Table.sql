/*
CREATE DATABASE dbydrSoft
COLLATE Latin1_General_100_CS_AS
GO
CREATE SCHEMA ydrsoft
GO

*/



use dbydrSoft
GO


CREATE TABLE Conexion(
	ID int  primary key  not null
	,	RUC varchar(11) unique NOT NULL 
	,	Nombre varchar(30) NOT NULL
	,	Correo varchar(30)
	,	Direccion varchar(75)
	,	Facebook varchar(40)
	,	Pagweb varchar(40)
	,	OtroUrl varchar(40)
	,	Img	varbinary(max)
	,	Fecha_Reg date not null
)
GO

CREATE TABLE Cargo(
	ID int NOT NULL PRIMARY KEY
	,	Nombre varchar(20) NOT NULL
)
GO

CREATE TABLE Empleado(
	DNI varchar(8) primary key  not null
	,	ID_Cargo int NOT NULL
	,	Nombres varchar(30) NOT NULL
	,	Apellidos varchar(30) NOT NULL
	,	Correo varchar(30) NOT NULL
	,	Clave VARBINARY(max)
	,	Direccion varchar(100)
	,	Fecha_Nac date	
	,	Sexo tinyint not null
	,	Img	varbinary(max)
	,	Estado int NOT NULL
	,	Fecha_Reg date NOT NULL
	,	Fecha_Fin date
)
GO

ALTER TABLE Empleado  WITH CHECK ADD  CONSTRAINT FK_Empleado_Cargo FOREIGN KEY(ID_Cargo)
REFERENCES Cargo (ID)
GO

CREATE TABLE Area(
	ID int NOT NULL primary key
	,	Nombre varchar(75)
)

CREATE TABLE Producto(
	ID int NOT NULL primary key
	,	ID_Area int not null
	,	Nombre varchar(100) NOT NULL
	,	Stock decimal(10,2) not null
	,	Cantidad decimal(10,2) not null
	,	Cantidad_Min decimal(10,2) not null
	,	Unidad varchar(30)
	,	Precio Decimal(7,2) not null
	,	Detalle varchar(200)	
	,	Img varbinary(max)
	,	Estado int not null
)
GO


ALTER TABLE Producto  WITH CHECK ADD  CONSTRAINT FK_Producto_Area FOREIGN KEY(ID_Area)
REFERENCES Area (ID)
GO

CREATE TABLE Sede(
	ID int NOT NULL primary key
	,	Nombre varchar(75)
	,	Direccion varchar(200)
	,	Telefono varchar(20)
	,	Celular varchar(20)
	,	Correo varchar(75)
	,	Empleado varchar(8)
	,	Estado int not null
)
GO

CREATE TABLE Cotizacion(
	ID int primary key NOT NULL
	,	ID_Sede int not null
	,	RUC varchar(11) not null
	,	RazSocial varchar(100)
	,	Total decimal(7,2) not null
	,	ID_Empleado varchar(8)
	,	ID_Aprobado varchar(8)
	,	Estado int not null
	,	Fecha_Reg datetime not null
)
GO

CREATE TABLE Cotiza_Detalle(
	ID int primary key NOT NULL
	,	ID_Producto int not null
	,	ID_Cotiza int not null	
	,	Cantidad decimal(10,2) not null
	,	Precio Decimal(7,2) not null
	,	Detalle varchar(200)
	,	Total Decimal(10,2) not null
	,	Estado int not null
)
GO

ALTER TABLE Cotiza_Detalle  
WITH CHECK ADD  CONSTRAINT FK_CotDetalle_Prod FOREIGN KEY(ID_Producto)
REFERENCES Producto (ID)
GO

ALTER TABLE Cotiza_Detalle  
WITH CHECK ADD  CONSTRAINT FK_CotDetalle_Cotiza FOREIGN KEY(ID_Cotiza)
REFERENCES Cotizacion (ID)
GO


CREATE TABLE Cliente_Pago(
	ID int primary key NOT NULL
	,	Nombre varchar(40)
)
GO

CREATE TABLE Cliente_Estado(
	ID int primary key NOT NULL
	,	Nombre varchar(40)
)
GO

CREATE TABLE Cliente_Credito(
	ID int primary key NOT NULL
	,	Nombre varchar(40)
)
GO

CREATE TABLE Cliente(
	RUC varchar(11) primary key not null
	,	RazSocial varchar(100) not null
	,	Direccion varchar(200)
	,	Telefono varchar(20)
	,	Celular varchar(20)
	,	Correo varchar(100)
	,	Pago varchar(40)
	,	Credito int not null
	,	Sede int not null
	,	ID_Estado int not null
)
GO

ALTER TABLE Cliente  
WITH CHECK ADD  CONSTRAINT FK_Cliente_Estado FOREIGN KEY(ID_Estado)
REFERENCES Cliente_Estado (ID)
GO

CREATE TABLE Cliente_Sede(
	ID int primary key not null
	,	ID_Cliente varchar(11) not null
	,	Direccion varchar(200)
)
GO

ALTER TABLE Cliente_Sede  
WITH CHECK ADD  CONSTRAINT FK_Sede_Cliente FOREIGN KEY(ID_Cliente)
REFERENCES Cliente (RUC)
GO

CREATE TABLE Venta_Orden(
	ID int primary key NOT NULL
	,	ID_Sede int not null
	,	ID_Cotiza int not null
	,	ID_Cliente varchar(11) not null
	,	ID_Empleado varchar(8)
	,	Serie varchar(6)
	,	Numero varchar(10)
	,	Estado int not null
	,	Fecha_Reg datetime not null
)
GO

ALTER TABLE Venta_Orden  
WITH CHECK ADD  CONSTRAINT FK_V_Orden_Sede FOREIGN KEY(ID_Sede)
REFERENCES Sede (ID)
GO

ALTER TABLE Venta_Orden  
WITH CHECK ADD  CONSTRAINT FK_V_Orden_Cotiza FOREIGN KEY(ID_Cotiza)
REFERENCES Cotizacion (ID)
GO

ALTER TABLE Venta_Orden  
WITH CHECK ADD  CONSTRAINT FK_V_Orden_Cliente FOREIGN KEY(ID_Cliente)
REFERENCES Cliente (RUC)
GO


CREATE TABLE Venta_Guia(
	ID int primary key NOT NULL
	,	ID_Empleado varchar(8)
	,	Serie varchar(6)
	,	Numero varchar(10)
	,	Licencia varchar(10)
	,	Placa varchar(10)
	,	Modelo varchar(20)
	,	Fecha date
	,	Direccion varchar(200)
	,	Img varbinary(max)	
	,	Estado int not null
	,	Fecha_Reg datetime not null
)
GO


CREATE TABLE Documento(
	ID int NOT NULL primary key
	,	Nombre varchar(75)
)
GO


CREATE TABLE Venta(
	ID int primary key NOT NULL
	,	ID_Empleado varchar(8)
	,	ID_Doc int not null
	,	Serie varchar(6)
	,	Numero varchar(10)
	,	Fecha date
	,	Direccion varchar(200)
	,	Img varbinary(max)
	,	Estado int not null
	,	Fecha_Reg datetime not null
)

ALTER TABLE Venta  
WITH CHECK ADD  CONSTRAINT FK_Venta_Doc FOREIGN KEY(ID_Doc)
REFERENCES Documento (ID)
GO

CREATE TABLE Moneda(
	ID int primary key not null
	,	Nombre varchar(10)
	,	Cambio decimal(7,4) not null
	,	Detalle varchar(40)
)
GO

CREATE TABLE Venta_Cuerpo( 
	ID int primary key NOT NULL
	,	ID_Moneda int not null
	,	Cambio decimal(7,4) not null
	,	Inafecta Decimal(10,2) not null
	,	Descuento Decimal(10,2) not null
	,	Base Decimal(10,2) not null
	,	IGV Decimal(7,2) not null
	,	Total Decimal(10,2) not null
)
GO

ALTER TABLE Venta_Cuerpo  
WITH CHECK ADD  CONSTRAINT FK_V_Cuerpo_Moneda FOREIGN KEY(ID_Moneda)
REFERENCES Moneda (ID)
GO

CREATE TABLE Venta_Detalle(
	ID int primary key NOT NULL
	,	ID_Empleado varchar(8)
	,	ID_Cuerpo int not null
	,	ID_Producto int not null
	,	Detalle varchar(200)
	,	Cantidad decimal(10,2) not null
	,	Precio Decimal(7,2) not null	
	,	Descuento Decimal(10,2) not null
	,	Base Decimal(10,2) not null
	,	Igv Decimal(10,2) not null
	,	Total Decimal(10,2) not null
	,	Estado int not null
)
GO

ALTER TABLE Venta_Detalle  
WITH CHECK ADD  CONSTRAINT FK_V_Detalle_Cuerpo FOREIGN KEY(ID_Cuerpo)
REFERENCES Venta_Cuerpo (ID)
GO

ALTER TABLE Venta_Detalle  
WITH CHECK ADD  CONSTRAINT FK_V_Detalle_Prod FOREIGN KEY(ID_Producto)
REFERENCES Producto (ID)
GO

CREATE TABLE Serie_Numero(
	ID int primary key NOT NULL
	,	Serie varchar(6) not null
	,	Numero int not null
	,	Estado int not null
)
GO


CREATE TABLE Alma_Tipo(
	ID int NOT NULL primary key
	,	Nombre varchar(75)
)

CREATE TABLE Almacen(
	ID int NOT NULL primary key
	,	ID_Tipo int not null
	,	Nombre varchar(100) NOT NULL
	,	Stock decimal(10,2) not null
	,	Cantidad_Orden decimal(10,2) not null
	,	Unidad varchar(30)
	,	Detalle varchar(200)	
	,	Img varbinary(max)
	,	Estado int not null
)
GO

ALTER TABLE Almacen  WITH CHECK ADD  CONSTRAINT FK_Almacen_Tipo FOREIGN KEY(ID_Tipo)
REFERENCES Alma_Tipo (ID)
GO


CREATE TABLE Receta(
	ID int primary key NOT NULL
	,	ID_Producto int not null
	,	ID_Almacen int not null	
	,	Cantidad Decimal(10,2) not null
	,	Estado int not null
)


ALTER TABLE Receta  
WITH CHECK ADD  CONSTRAINT FK_Receta_Producto FOREIGN KEY(ID_Producto)
REFERENCES Producto (ID)
GO

ALTER TABLE Receta  
WITH CHECK ADD  CONSTRAINT FK_Receta_Almacen FOREIGN KEY(ID_Almacen)
REFERENCES Almacen (ID)
GO


create table Proveedor(
	RUC varchar(11) primary key not null
	,	RazSocial varchar(100)
	,	Direccion varchar(200)
	,	Estado int not null
)

-- compras, caja chica u otros
create table Gasto_Tipo(
	ID int primary key not null
	,	Nombre varchar(100)
)

create table Gasto(
ID int primary key not null
,   ID_Tipo int not null
,	ID_doc int not null
,	ID_Prov varchar(11)
,	Serie varchar(6)
,	Numero varchar(10)
,	Fecha date not null
,	Detalle varchar(250)
,	Inafecta decimal(10,2) not null
,	Total decimal(10,2) not null
,	Img	varbinary(max)
,	ID_Empl varchar(8) not null
,	Estado int not null
,	Fecha_reg datetime
)

ALTER TABLE Gasto
WITH CHECK ADD  CONSTRAINT FK_Gasto_Doc FOREIGN KEY(ID_Prov)
REFERENCES Proveedor (RUC)
GO

ALTER TABLE Gasto
WITH CHECK ADD  CONSTRAINT FK_Gasto_Prov FOREIGN KEY(ID_Tipo)
REFERENCES Documento (ID)
GO

ALTER TABLE Gasto
WITH CHECK ADD  CONSTRAINT FK_Gasto_Tipo FOREIGN KEY(ID_doc)
REFERENCES Gasto_Tipo (ID)
GO


create table Pago(
	ID int primary key not null
	,	ID_Gasto int not null
	,	ID_Compra int not null
	,	Total decimal(10,2) not null
	,	Saldo decimal(10,2) not null
	,	Interes decimal(10,2) not null
	,	Estado int not null
	,	Fecha_reg date
)

ALTER TABLE Pagos
WITH CHECK ADD  CONSTRAINT FK_Pagos_Gasto FOREIGN KEY(ID_Gasto)
REFERENCES Gasto (ID)
GO

ALTER TABLE Pagos
WITH CHECK ADD  CONSTRAINT FK_Pagos_Compra FOREIGN KEY(ID_Compra)
REFERENCES Compra (ID)
GO

/*
-- compras, caja chica, otros


create table Banco(
	ID int primary key not null
,	Nombre varchar(5)
,	Descripcion varchar(50)
)

create table Pago(
	ID int primary key not null
,	NrOpera int not null
,	Monto decimal(10,2) not null
,	Saldo decimal(10,2) not null
,	Fecha date
,	ID_Banco int not null
,	Fecha_reg date
)

ALTER TABLE Pago  
WITH CHECK ADD  CONSTRAINT FK_Pago_Banco FOREIGN KEY(ID_Banco)
REFERENCES Banco (ID)
GO

create table CuentaP_Pago(
	ID_Cuenta int not null
	,	ID_Pago int not null
	,	Interes decimal(10,2) not null
	,	Monto decimal(10,2) not null
	,	Fecha_reg date

	CONSTRAINT PK_CuentaP_Pago PRIMARY KEY (ID_Cuenta, ID_Pago)
)

ALTER TABLE CuentaP_Pago  
WITH CHECK ADD  CONSTRAINT FK_CuentaP_Cuenta FOREIGN KEY(ID_Cuenta)
REFERENCES CuentaPagar (ID)
GO

ALTER TABLE CuentaP_Pago  
WITH CHECK ADD  CONSTRAINT FK_CuentaP_Pago FOREIGN KEY(ID_Pago)
REFERENCES Pago (ID)
GO
*/
CREATE TABLE Compra_Solicitud(
	ID int primary key NOT NULL
	,	Sede int not null
	,	ID_Empleado varchar(8) not null
	,	ID_Aprobado varchar(8)
	,	ID_Alma int not null
	,	Cantidad decimal(10,2) not null
	,	Observacion varchar(250)
	,	Fecha_Reg date not null
	,	Estado int not null
)
GO

ALTER TABLE Compra_Solicitud  
WITH CHECK ADD  CONSTRAINT FK_C_Sol_Alma FOREIGN KEY(ID_Alma)
REFERENCES Almacen(ID)
GO


CREATE TABLE Compra_Orden(
	ID int primary key NOT NULL
	,	Sede int not null
	,	ID_Prov varchar(11) not null
	,	ID_Empleado varchar(8) not null
	,	Total decimal(10,2) not null
	,	Fecha_Reg date not null
	,	Estado int not null
)
GO

ALTER TABLE Compra_Orden  
WITH CHECK ADD  CONSTRAINT FK_C_Orden_Prove FOREIGN KEY(ID_Prov)
REFERENCES Proveedor(RUC)
GO


CREATE TABLE Compra_Cuerpo(
	ID int primary key NOT NULL
	,	ID_Moneda int not null
	,	TipoCambio decimal(5,2) not null
	,	Inafecta decimal(10,2) not null
	,	Igv decimal(10,2) not null
	,	Total decimal(10,2) not null
	,	Estado int not null
)
GO

ALTER TABLE Compra_Cuerpo  
WITH CHECK ADD  CONSTRAINT FK_C_Cuerpo_Moneda FOREIGN KEY(ID_Moneda)
REFERENCES Moneda(ID)
GO

CREATE TABLE Compra_Detalle(
	ID int primary key NOT NULL
	,	ID_Cuerpo int not null
	,	ID_Alma int not null	
	,	Cantidad decimal(10,2) not null
	,	Cant_Real decimal(10,2) not null
	,	Precio decimal(10,2) not null
	,	Total decimal(10,2) not null
	,	Observ varchar(250)
	,	Estado int not null
)
GO

ALTER TABLE Compra_Detalle  
WITH CHECK ADD  CONSTRAINT FK_C_Detalle_Cuerpo FOREIGN KEY(ID_Cuerpo)
REFERENCES Compra_Cuerpo(ID)
GO

ALTER TABLE Compra_Detalle  
WITH CHECK ADD  CONSTRAINT FK_C_Detalle_Alma FOREIGN KEY(ID_Alma)
REFERENCES Almacen(ID)
GO


CREATE TABLE Compra_Guia(
	ID int primary key NOT NULL
	,	Sede int not null
	,	ID_Prov varchar(11) not null
	,	Serie varchar(6)
	,	Numero varchar(10)
	,	Fecha date not null
	,	ID_Empleado varchar(8) not null
	,	ID_AProbado varchar(8)
	,	Img varbinary(max) not null
	,	Fecha_Reg date not null
	,	Estado int not null
)
GO

ALTER TABLE Compra_Guia  
WITH CHECK ADD  CONSTRAINT FK_C_Guia_Prov FOREIGN KEY(ID_Prov)
REFERENCES Proveedor(RUC)
GO



CREATE TABLE Compra(
	ID int primary key NOT NULL
	,	Sede int not null
	,	ID_Guia int not null
	,	ID_Doc int not null
	,	Serie varchar(6)
	,	Numero varchar(10)
	,	Fecha date not null	
	,	ID_Empleado varchar(8) not null
	,	Inafecta decimal(10,2) not null
	,	Total decimal(10,2) not null
	,	Img varbinary(max) not null
	,	Fecha_Reg date not null
	,	Estado int not null
)
GO


ALTER TABLE Compra  
WITH CHECK ADD  CONSTRAINT FK_Compra_Guia FOREIGN KEY(ID_Guia)
REFERENCES Compra_Guia(ID)
GO


ALTER TABLE Compra  
WITH CHECK ADD  CONSTRAINT FK_Compra_Doc FOREIGN KEY(ID_Doc)
REFERENCES Documento(ID)
GO