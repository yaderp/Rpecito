USE dbydrSoft
GO

CREATE PROCEDURE sp_Insert_Gasto
     @idtipo int,
	 @iddoc int,
	 @idprov varchar(11),
	 @serie varchar(6),
	 @numero varchar(10),
	 @fecha date,
	 @inafecta decimal(10,2),
	 @total decimal(10,2),
	 @img varbinary(max),
	 @ID int output
AS
	set nocount on
	begin try
		set @ID = (select top(1) ID from Gasto order by ID desc)
		if @ID is not null
		begin
			set @ID = @ID + 1
		end
		else
		begin
			set @ID = 1
		end		
		insert into Gasto values(@ID,@idtipo,@iddoc,@idprov,@serie,@numero,@fecha,@inafecta,@total,@img,1,GETDATE())
		return @ID
	end try
	begin catch
		return -1
	end catch
	GO

/*

	CREATE PROCEDURE sp_Insert_Pago
     @opera int,
	 @monto decimal(10,2),
	 @saldo decimal(10,2),
	 @fecha date,
	 @banco int,
	 @ID int output
AS
	set nocount on
	begin try
		set @ID = (select top(1) ID from Pago order by ID desc)
		if @ID is not null
		begin
			set @ID = @ID + 1
		end
		else
		begin
			set @ID = 1
		end		
		insert into Pago values(@ID,@opera,@monto,@saldo,@fecha,@banco,GETDATE())
		return @ID
	end try
	begin catch
		return -1
	end catch
	GO
--ALTER TABLE CuentaPagar ADD Fecha_Reg date ;
	

CREATE PROCEDURE sp_Insert_CuentaPPago
     @idcuenta int,
	 @idpago int,
	 @interes decimal(10,2),
	 @monto decimal(10,2),
	 @ID int output
AS
	set nocount on
	begin try	
		insert into CuentaP_Pago values(@idcuenta,@idpago,@interes,@monto, GETDATE())
		set @ID = 1
		return @ID
	end try
	begin catch
		return -1
	end catch
GO

CREATE PROCEDURE sp_Insert_CuentaPagar
     @idgasto int,
	 @saldo decimal(10,2),
	 @descrip varchar(250),
	 @ID int output
AS
	set nocount on
	begin try
		set @ID = (select top(1) ID from CuentaPagar order by ID desc)
		if @ID is not null
		begin
			set @ID = @ID + 1
		end
		else
		begin
			set @ID = 1
		end		
		insert into CuentaPagar values(@ID,@idgasto,@saldo,@descrip,1,GETDATE())
		return @ID
	end try
	begin catch
		return -1
	end catch
GO


CREATE PROCEDURE sp_Insert_GastoDetalle
     @idgasto int,
	 @idalma int,
	 @cantidad decimal(10,2),
	 @inafecta decimal(10,2),
	 @total decimal(10,2),
	 @ID int output
AS
	set nocount on
	begin try
		set @ID = (select top(1) ID from Gasto_Detalle order by ID desc)
		if @ID is not null
		begin
			set @ID = @ID + 1
		end
		else
		begin
			set @ID = 1
		end		
		insert into Gasto_Detalle values(@ID,@idgasto,@idalma,@cantidad,@inafecta,@total)
		return @ID
	end try
	begin catch
		return -1
	end catch
GO

*/