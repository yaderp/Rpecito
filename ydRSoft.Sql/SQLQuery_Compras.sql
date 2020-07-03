use dbydrSoft
GO

CREATE PROCEDURE sp_Insert_CompraSol
     @idsede int,
	 @idempl varchar(8),
	 @idalma int,
	 @cantidad decimal(10,2),
	 @ID int output
AS
	set nocount on
	begin try
		set @ID = (select top(1) ID from Compra_Solicitud order by ID desc)
		if @ID is not null
		begin
			set @ID = @ID + 1
		end
		else
		begin
			set @ID = 1
		end		

		insert into Compra_Solicitud values(@ID,@idsede,@idempl,NULL,@idalma,@cantidad,NULL,GETDATE(),1)

		return @ID
	end try
	begin catch
		set @ID = 0
		return -1
	end catch
GO


CREATE PROCEDURE sp_Update_CompraSol
	 @idsol int,
	 @idalma int,
	 @cantidad decimal(10,2),
	 @ID int output
AS
	set nocount on
	begin try		
		update Compra_Solicitud
		set Estado = 2
		where ID = @idsol

		update Almacen
		set Cantidad_Orden = Cantidad_Orden +@cantidad
		where ID = @idalma

		set @ID = 1
		return @ID
	end try
	begin catch
		set @ID = 0
		return -1
	end catch
GO


CREATE PROCEDURE sp_Insert_CompraOrden
     @idsede int,
	 @idprov varchar(11),
	 @idempl varchar(8),
	 @idmoneda int,
	 @cambio decimal(10,2),
	 @ID int output
AS
	set nocount on
	begin try
		set @ID = (select top(1) ID from Compra_Orden order by ID desc)
		if @ID is not null
		begin
			set @ID = @ID + 1
		end
		else
		begin
			set @ID = 1
		end		

		insert into Compra_Orden values(@ID,@idsede,@idprov,@idempl,0,GETDATE(),1)
		insert into Compra_Cuerpo values(@ID,@idmoneda,@cambio,0,0,0,1)

		return @ID
	end try
	begin catch
		set @ID = 0
		return -1
	end catch
GO


CREATE PROCEDURE sp_Insert_CompraDetalle
     @idcuerpo int,
	 @idalma int,
	 @cantidad decimal(10,2),
	 @precio decimal(10,2),
	 @total decimal(10,2),
	 @ID int output
AS
	set nocount on
	begin try
		set @ID = (select top(1) ID from Compra_Detalle order by ID desc)
		if @ID is not null
		begin
			set @ID = @ID + 1
		end
		else
		begin
			set @ID = 1
		end		

		insert into Compra_Detalle values(@ID,@idcuerpo,@idalma,@cantidad,@cantidad,@precio,@total,NULL,1)

		return @ID
	end try
	begin catch
		set @ID = 0
		return -1
	end catch
GO

CREATE PROCEDURE sp_Insert_CompraGuia
	 @idcom int,
	 @idsede int,
	 @idprov varchar(11),
	 @serie varchar(6),
	 @numero varchar(10),
	 @fecha date,	 
	 @idempl varchar(8),
	 @img varbinary(max),
	 @ID int output
AS
	set nocount on
	begin try
		insert into Compra_Guia values(@idcom,@idsede,@idprov,@serie,@numero,@fecha,@idempl,null,@img,GETDATE(),1)
		set @ID = 1
		return @ID
	end try
	begin catch
		set @ID = 0
		return -1
	end catch
GO


CREATE PROCEDURE sp_Insert_Compra
	 @idguia int,
	 @idsede int,
	 @iddoc int,
	 @serie varchar(6),
	 @numero varchar(10),
	 @fecha date,
	 @idempl varchar(8),
	 @inafecta decimal(10,2),
	 @total decimal(10,2),	   
	 @img varbinary(max),
	 @ID int output
AS
	set nocount on
	begin try
		insert into Compra values(@idguia,@idsede,@idguia,@iddoc,@serie,@numero,@fecha,@idempl,@inafecta,@total,@img, GETDATE(),1)

		update Compra_Guia
		set Estado = 3
		where ID= @idguia

		set @ID = 1
		return @ID
	end try
	begin catch
		set @ID = 0
		return -1
	end catch
GO





