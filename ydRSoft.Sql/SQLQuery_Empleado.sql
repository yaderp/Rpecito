use dbydrSoft
GO

CREATE PROCEDURE sp_Insert_Empleado
     @dni varchar(8),
	 @idcargo int,	 
	 @Nombres varchar(30), 
	 @apellidos varchar(30),
	 @correo varchar(30),
	 @clave varbinary(max),
	 @sexo int,
	 @ID int output
AS
	set nocount on
	begin try	
		insert into Empleado values(@dni,@idcargo,@Nombres,@apellidos,@correo,@clave,NULL,NULL,@sexo,NULL,1,GETDATE(),NULL)
		set @ID = 1
		return @ID
	end try
	begin catch
		set @ID = 0
		return -1
	end catch
GO