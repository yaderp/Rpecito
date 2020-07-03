
use dbydrSoft

SELECT CAST(table_name as varchar) as table_name FROM INFORMATION_SCHEMA.TABLES

-- Primero desabilitar la integridad referencial
 EXEC sp_MSforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'
 GO

EXEC sp_MSforeachtable @command1 = 'DROP TABLE ?'

-- Ahora volver a habilitar la integridad referencial
 EXEC sp_MSforeachtable 'ALTER TABLE ? CHECK CONSTRAINT ALL'
 GO



---  Eliminar procedimientos y triggers

DROP PROCEDURE sp_Insert_Almacen
GO


DROP PROCEDURE sp_Insert_Cliente
Go


DROP PROCEDURE sp_Insert_Proveedor
GO


DROP PROCEDURE sp_Insert_Producto
DROP PROCEDURE sp_Insert_Receta
GO


DROP PROCEDURE sp_Insert_Gasto
DROP PROCEDURE sp_Insert_Pago
DROP PROCEDURE sp_Insert_CuentaPPago
DROP PROCEDURE sp_Insert_CuentaPagar
DROP PROCEDURE sp_Insert_GastoDetalle
GO


DROP PROCEDURE sp_Insert_Empleado
GO


DROP PROCEDURE sp_Insert_Cotizacion
DROP PROCEDURE sp_Insert_CotizaDetalle
GO


----------  TRIGGERS

DROP TRIGGER tr_AddUpd_CotDetalle
GO