use dbydrSoft
GO

insert into Gasto_Tipo values(1,'Tipo 01')
insert into Gasto_Tipo values(2,'Tipo 02')
insert into Gasto_Tipo values(3,'Tipo 03')
GO

insert into Banco values(1,'BCP', 'BANCO DE CREDITO DEL PERU')
insert into Banco values(2,'BBVA', 'BANCO BILBAO VIZCAYA ARGENTARIA')


insert into Alma_Tipo values(1,'OTROS')
insert into Alma_Tipo values(2,'MATERIA PRIMA')
insert into Alma_Tipo values(3,'INSUMO')
insert into Alma_Tipo values(4,'PROD. INTERMEDIO')
GO


insert into Cargo values(1,'EMPLEADO')
insert into Cargo values(2,'VENTAS')
insert into Cargo values(3,'PRODUCCION')
insert into Cargo values(4,'LOGISTICA')
insert into Cargo values(5,'CONTABILIDAD')
insert into Cargo values(6,'FINANZAS')
insert into Cargo values(9,'ADMINISTRADOR')
GO


--insert into Empleado values(1,1,'43114343','YADER','PHOOL','yaderch@gmail.com',NULL,'ATE',GETDATE(),1,NULL,1,GETDATE(),NULL)

insert into Conexion values (1,'20434417521','Industrias Sondor SAC','@sondorperu.pe','direccion','facebook','web','otro',NULL,GETDATE())
GO

insert into Area values(1,'HIERBAS')
insert into Area values(2,'SECOS')
insert into Area values(3,'SNACKS NUTRISIMO')
insert into Area values(4,'SNACKS TORCAZA')
insert into Area values(5,'MENESTRAS')
insert into Area values(6,'PRE-COCIDOS')
GO


Insert into Sede Values(1,'CHOSICA','AV. LOTE 5 LURIGANCHO','Telefono','celular','correo','43114343',1)
GO

Insert into Cliente_Pago Values(1,'CONTADO')
Insert into Cliente_Pago Values(2,'CREDITO')
GO

insert into Cliente_Estado values(1,'NUEVO')
insert into Cliente_Estado values(2,'ACTIVO')
insert into Cliente_Estado values(3,'VIP')
insert into Cliente_Estado values(4,'MOROSO')
insert into Cliente_Estado values(5,'BLOQUEADO')
GO

insert into Cliente_Credito values(1,'DIAS')
insert into Cliente_Credito values(7,'SEMANAS')
insert into Cliente_Credito values(30,'MESES')
insert into Cliente_Credito values(360,'AÑOS')
GO

insert into Documento values(1,'FACTURA')
insert into Documento values(3,'BOLETA DE VENTA')
insert into Documento values(7,'NOTA DE CREDITO')
insert into Documento values(8,'NOTA DE DEBITO')
insert into Documento values(9,'GUIA DE REMISION')
insert into Documento values(100,'ORDEN VENTA')
insert into Documento values(101,'ORDEN COMPRA')
GO

insert into Serie_Numero values(1,'F001',100,1)
insert into Serie_Numero values(3,'000001',40,1)
insert into Serie_Numero values(7,'000001',30,1)
insert into Serie_Numero values(8,'000001',50,1)
insert into Serie_Numero values(9,'000001',40,1)
insert into Serie_Numero values(100,'OV001',10,1)
insert into Serie_Numero values(101,'OC001',50,1)
GO

insert into Moneda values (1,'SOLES',1,'')
insert into Moneda values (2,'DOLARES',3.4,'')
GO



----   PRODUCTOS  ------

INSERT Producto  VALUES (1, 3, 'MIXTURA DE NUECES CON FRUTA DESHIDRATADA', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (2, 5,'QUINUA TRICOLOR PRECOCIDO 500 G', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (3, 3,'CANCHA PICANTE', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (4, 3,'MANI CON PASAS', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (5, 3,'CANCHA CHULLPI', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (6, 3,'HABAS SALADA', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (7, 3,'MANI SALADO', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (8, 3,'CHIFLE CANCHA', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (9, 3,'MIX DE FRUTA DESHIDRATADA', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (10, 6,'ALVERJA X 500 GR', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (11, 4,'MIX DE NUECES, PASAS Y TARWI 30 G', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (12, 6,'PALLAR X 500 GR', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (13, 6,'CHOCHOCA 500 G', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (14, 6,'FRIJOL CASTILLA 500 G', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (15, 6,'LENTEJAS 500 G', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (16, 6,'FRIJOL NEGRO 500 G', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (17, 6,'LENTEJAS BEBE 500G', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (18, 6,'TRIGO MOTE X 500 GR', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (19, 6,'FRIJOL PANAMITO 500 G', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (20, 6,'QUINUA 500 G', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (21, 6,'FRIJOL CANARIO 500 G', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (22, 4,'KANCHA TOSTADA SABOR QUESO MANTECOSO 35 G', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (23, 6,'GARBANZO 500 G', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (24, 6,'ALVERJA 5 KG', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (25, 6,'ARROZ 5 KG', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (26, 6,'FRIJOL CANARIO 5 KG', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (27, 6,'FRIJOL PANAMITO 5 KG', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (28, 6,'FRIJOL CASTILLA 5 KG', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (29, 6,'FRIJOL NEGRO 5 KG', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (30, 6,'GARBANZO 5 KG', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (31, 6,'LENTEJAS 5 KG', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (32, 6,'LENTEJAS BEBE 5 KG', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (33, 6,'PALLAR 5 KG', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (34, 6,'PAPA SECA NEGRA 5 KG', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (35, 6,'POP CORN 5 KG', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (36, 6,'QUINUA 5 KG', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (37, 6,'TRIGO MOTE 5 KG', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (38, 1,'MANZANILLA', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (39, 1,'ANIS 40 KG', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (40, 1,'HIERBA LUISA 40 KG', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (41, 1,'DIGESTIVO 40 KG', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (42, 1,'RELAJANTE 40 KG', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (43, 1,'ANTIGRIPAL 40 KG', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (44, 4,'MIXTURA DE NUECES CON FRUTA DESHIDRATADA 20 G', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (45, 4,' MANZANA CON CANELA 15 G', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (46, 4,'MIXTURA DE FRUTA DESHIDRATADA 15 G', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
INSERT Producto  VALUES (47, 4,'KANCHA TOSTADA SABOR CECINA 35 G', 0, 0, 0,'KILOGRAMOS', 0,'', NULL, 1)
GO


INSERT Almacen VALUES (1, 3,'ACEITE PALMA', 0, 0,  'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (2, 3,'SABORIZANTE DE CECINA', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (3, 3,'SABORIZANTE DE QUESO MANTECOSO', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (4, 3,'SABORIZANTE PICANTE', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (5, 4,'MANGO DESHIDRATADO', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (6, 2,'CANELA', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (7, 2,'PIMPINELA', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (8, 4,'MANZANA DESHIDRATADA', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (9, 4,'PLATANO DESHIDRATADO', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (10, 4,'AGUAYMANTO DESHIDRATADO', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (11, 4,'PIÑA DESHIDRATADA', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (12, 4,'ARANDANO DESHIDRATADO', 0, 0, 'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (13, 4,'MANZANA CON CANELA DESHIDRATADA', 0,  0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (14, 2,'ALMENDRAS', 0, 0, 'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (15, 2,'TORONJIL', 0, 0, 'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (16, 2,'MANI TOSTADO', 0,  0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (17, 2,'VALERIANA', 0,  0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (18, 2,'PECANAS', 0,  0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (19, 2,'NUECES', 0,  0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (20, 2,'PASAS RUBIAS', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (21, 2,'PASAS MORENAS', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (22, 2,'TARWI TOSTADO', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (23, 2,'MAIZ TOSTADO',  0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (24, 2,'ALVERJA', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (25, 2,'CHOCHOCA', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (26, 2,'FRIJOL CASTILLA', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (27, 2,'MANZANILLA TALLO', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (28, 3,'POLEN', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (29, 3,'MANZANILLA TALLO', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (30, 2,'HIERBA LUISA SECA', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (31, 2,'ANIS', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (32, 2,'PALLAR', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (33, 2,'FRIJOL NEGRO', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (34, 2,'LENTEJAS BEBE', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (35, 2,'TRIGO MOTE', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (36, 2,'FRIJOL PANAMITO', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (37, 2,'QUINUA', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (38, 2,'FRIJOL CANARIO', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (39, 2,'GARBANZO', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (40, 2,'EUCALIPTO', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (41, 2,'MENTA', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (42, 2,'SCORZONERA', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (43, 2,'BORRAJA', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (44, 2,'MUÑA', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (45, 2,'BOLDO', 0, 0,'KILOGRAMOS','', NULL, 1)
INSERT Almacen VALUES (46, 2,'TOMILLO', 0, 0,'KILOGRAMOS','', NULL, 1)


INSERT Empleado VALUES ('40073546', 3,'FLOR','RAMOS','flor@sondorpe', 0xEBA02A626F79C5D6, NULL, NULL, 2, NULL, 1, '2020-05-22', NULL)
INSERT Empleado VALUES ('43114343', 9,'YADER PHOOL','COÑAS HOSPINO','yaderch@gmail.com', 0x35295507AA1C0D7A, NULL, NULL, 1, NULL, 1, N'2020-05-17', NULL)
INSERT Empleado VALUES ('47706785', 9,'ANGI ','VARGAS FLORES','angi.vargas@sondorperu.com', 0x03D8353F81D89832, NULL, NULL, 2, NULL, 1, '2020-05-18', NULL)
INSERT Empleado VALUES ('70094567', 2,'YOVANNA MAGALI','EULOGIO ALHUAY','yovaeulogio@gmail.com', 0xDC7C1817D5759648, NULL, NULL, 2, NULL, 1, '2020-05-17', NULL)
INSERT Empleado VALUES ('finanzas', 6,'MODULO','FINANZAS','finanzas', 0x35295507AA1C0D7A, NULL, NULL, 2, NULL, 1, '2020-05-25', NULL)
