
use dbydrSoft
GO

---  TRIGGERS COTIZACION

CREATE TRIGGER tr_AddUpd_CotDetalle ON Cotiza_Detalle
AFTER INSERT,UPDATE
AS
BEGIN
    SET NOCOUNT ON
	declare @idcotiza int
	declare @total decimal(10,2)
	declare @tot decimal(10,2)

	set @idcotiza = (select ID_Cotiza from inserted)
	set @total = (select Total from inserted)
	set @tot = 0

	if exists(select *from inserted) and exists(select *from deleted)
	begin		
		set @tot = (select Cantidad from deleted)
	end
	
	update Cotizacion
		set Total = Total - @tot + @total
		where ID = @idcotiza
	
END
GO

-- Aprobado = 3
CREATE TRIGGER tr_AddUpd_CompraGuia ON Compra_Guia
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON
	declare @id int

	set @id = (select ID from inserted)

	update Compra_Orden
	set Estado = 3
	where ID = @id	
	
END
GO




/*
CREATE TRIGGER tr_AddUpd_CompraSol ON Compra_Solicitud
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON
	declare @idalma int
	declare @cantidad decimal(10,2)
	declare @estado int

	set @idalma = (select ID_Alma from inserted)
	set @cantidad = (select Cantidad from inserted)

	if exists(select *from inserted) and exists(select *from deleted)
	begin		
		
		begin
			update Almacen
			set Cantidad_Orden = Cantidad_Orden + @cantidad
			where ID = @idalma
		end		
	end	
END

*/