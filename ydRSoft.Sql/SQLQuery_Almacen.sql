use dbydrSoft
GO

CREATE PROCEDURE sp_Insert_Almacen
     @idtipo int,@nombre varchar(75),@detalle varchar(200),@imagen varbinary(max),@ID int output
AS
	set nocount on
	begin try
		set @ID = (select top(1) ID from Almacen order by ID desc)
		if @ID is not null
		begin
			set @ID = @ID + 1
		end
		else
		begin
			set @ID = 1
		end
		insert into Almacen values(@ID,@idtipo,@nombre,0,0,'KILOGRAMOS',@detalle,@imagen,1)
		return @ID
	end try
	begin catch
		set @ID = 0
		return -1
	end catch
GO


