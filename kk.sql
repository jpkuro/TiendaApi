
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_guardarcabezera
	@nombre_cl varchar(100),
	@cedula varchar(10),
	@num_factura varchar(10),
	@base_imp varchar(50),
	@contacto varchar(10),
	@correo varchar(100),
	@preciotot varchar(50),
	@detalles datos_detalles readonly
AS
BEGIN
	declare @id_cabezera int
	insert into cabezera(nombre_cl, cedula, num_factura, base_imp, contacto, correo, precio_tot)values(@nombre_cl, @cedula, @num_factura, @base_imp, @contacto, @correo, @preciotot)

	set @id_cabezera = @@IDENTITY
	insert into detalle (cantidad, iva, precio_unit, producto, id_cabezera)
	select cantidad,iva,precio_unit,producto,@id_cabezera from @detalles


END
GO
