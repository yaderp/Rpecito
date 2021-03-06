USE dbydrSoft
GO

CREATE PROCEDURE sp_Insert_Producto
     @idarea int,
	 @Nombres varchar(75),
	 @detalle varchar(200),
	 @img varbinary(max),
	 @ID int output
AS
	set nocount on
	begin try
		set @ID = (select top(1) ID from Producto order by ID desc)
		if @ID is not null
		begin
			set @ID = @ID + 1
		end
		else
		begin
			set @ID = 1
		end		
		insert into Producto values(@ID,@idarea,@Nombres,0,0,0,'KILOGRAMOS',0,'',@img,1)
		return @ID
	end try
	begin catch
		return -1
	end catch
GO

CREATE PROCEDURE sp_Insert_Receta
     @idprod int,@idAlma int,@cantidad decimal(10,2),@ID int output
AS
	set nocount on
	begin try
		set @ID = (select top(1) ID from Receta order by ID desc)
		if @ID is not null
		begin
			set @ID = @ID + 1
		end
		else
		begin
			set @ID = 1
		end
		insert into Receta values(@ID,@idprod,@idAlma,@cantidad,1)
		return @ID
	end try
	begin catch
		set @ID = 0
		return -1
	end catch
GO
