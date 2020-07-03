use dbydrSoft
GO

CREATE PROCEDURE sp_Insert_Cotizacion
     @idsede int,
	 @ruc varchar(11),	 
	 @razsoc varchar(100),
	 @idempl varchar(8),	 
	 @ID int output
AS
	set nocount on
	begin try
		set @ID = (select top(1) ID from Cotizacion order by ID desc)
		if @ID is not null
		begin
			set @ID = @ID + 1
		end
		else
		begin
			set @ID = 1
		end		

		insert into Cotizacion values(@ID,@idsede,@ruc,@razsoc,0,@idempl,NULL,0,GETDATE())

		return @ID
	end try
	begin catch
		set @ID = 0
		return -1
	end catch
GO

CREATE PROCEDURE sp_Insert_CotizaDetalle 
	 @idprod int, 
	 @idcot int,
	 @cantidad decimal(7,2),
	 @precio decimal(7,2),
	 @detalle varchar(200),
	 @total decimal(7,2),
	 @ID int output
AS
	set nocount on
	begin try
		set @ID = (select top(1) ID from Cotiza_Detalle order by ID desc)
		if @ID is not null
		begin
			set @ID = @ID + 1
		end
		else
		begin
			set @ID = 1
		end		

		insert into Cotiza_Detalle values(@ID,@idprod,@idcot,@cantidad,@precio,@detalle,@total,1)

		return @ID
	end try
	begin catch
		set @ID = 0
		return -1
	end catch
GO

/***************** X INGRESAR ****************/

/*
CREATE PROCEDURE sp_Insert_VentaOrden
     @idsede int,
	 @idcot int,	 
	 @idcli int,
	 @idempl varchar(8),
	 @ID int output
AS
	set nocount on
	begin try
		set @ID = (select top(1) ID from Venta_Orden order by ID desc)
		if @ID is not null
		begin
			set @ID = @ID + 1
		end
		else
		begin
			set @ID = 1
		end

		insert into Venta_Orden values(@ID,@idsede,@idcot,@idcli,@idempl,'','',0,GETDATE())

		return @ID
	end try
	begin catch
		set @ID = 0
		return -1
	end catch
GO

CREATE PROCEDURE sp_Insert_VentaGuia
     @idorden int,
	 @idempl varchar(8),
	 @licencia varchar(10),
	 @placa varchar(10),
	 @modelo varchar(20),
	 @fecha date,
	 @dire varchar(200),
	 @ID int output
AS
	set nocount on
	begin try

		set @ID = @idorden

		insert into Venta_Guia values(@ID,@idempl,'','',@licencia,@placa,@modelo,@fecha,@dire,NULL,0,GETDATE())
		return @ID
	end try
	begin catch
		set @ID = 0
		return -1
	end catch
GO

CREATE PROCEDURE sp_Insert_Venta
     @idguia int,
	 @idempl varchar(8),
	 @doc int,
	 @fecha date,
	 @dire varchar(200),
	 @ID int output
AS
	set nocount on
	begin try

		set @ID = @idguia

		insert into Venta values(@ID,@idempl,@doc,'','',@fecha,@dire,NULL,0,GETDATE())
		return @ID
	end try
	begin catch
		set @ID = 0
		return -1
	end catch
GO

CREATE PROCEDURE sp_Insert_VentaCuerpo
     @idguia int,
	 @idmoneda int,
	 @cambio decimal(7,2),
	 @inafecta decimal(7,2),
	 @descuento decimal(7,2),
	 @base decimal(7,2),
	 @igv decimal(7,2),
	 @total decimal(7,2),
	 @ID int output
AS
	set nocount on
	begin try

		set @ID = @idguia

		insert into Venta_Cuerpo values(@ID,@idmoneda,@cambio,@inafecta,@descuento,@base,@igv,@total)
		return @ID
	end try
	begin catch
		set @ID = 0
		return -1
	end catch
GO

CREATE PROCEDURE sp_Insert_VentaDetalle
	 @empl varchar(8),
	 @cuerpo int,
	 @prod int,
	 @detalle varchar(200),
	 @cantidad decimal(7,2),
	 @precio decimal(7,2),
	 @descuento decimal(7,2),
	 @base decimal(7,2),
	 @igv decimal(7,2),
	 @total decimal(7,2),
	 @ID int output
AS
	set nocount on
	begin try
		set @ID = (select top(1) ID from Venta_Detalle order by ID desc)
		if @ID is not null
		begin
			set @ID = @ID + 1
		end
		else
		begin
			set @ID = 1
		end

		insert into Venta_Detalle values(@ID,@empl,@cuerpo,@prod,@detalle,@cantidad,@precio,@descuento,@base,@igv,@total,1)

		return @ID
	end try
	begin catch
		set @ID = 0
		return -1
	end catch
GO

*/