use dbydrSoft
GO

----- CLIENTE

CREATE PROCEDURE sp_Insert_Cliente
	 @ruc varchar(11),	 
	 @razsoc varchar(100), 
	 @direc varchar(250),
	 @pago varchar(40),
	 @credito int,
	 @estado int,		 
	 @ID int output
AS
	set nocount on
	begin try
		set @ID = 1	
		insert into Cliente values(@ruc,@razsoc,@direc,'telf','cel','cor',@pago,@credito,0,@estado)
		return @ID
	end try
	begin catch
		set @ID = 0
		return -1
	end catch
GO



--- PROVEEDOR

CREATE PROCEDURE sp_Insert_Proveedor
     @ruc varchar(11),
	 @razsocial varchar(100),
	 @direccion varchar(200),
	 @ID int output
AS
	set nocount on
	begin try				
		insert into Proveedor values(@ruc,@razsocial,@direccion,1)
		set @ID = 1
		return @ID
	end try
	begin catch
		return -1
	end catch
