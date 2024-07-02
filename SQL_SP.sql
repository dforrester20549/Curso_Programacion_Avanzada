USE [Practica2]
GO

-- Procedimiento almacenado para registrar un vendedor
CREATE PROCEDURE RegistrarVendedor
	@Cedula		varchar(50),
    @Nombre		varchar(100),
    @Correo		varchar(100)
AS
BEGIN

	IF NOT EXISTS(SELECT 1 FROM Vendedores WHERE Cedula = @Cedula)
	BEGIN

		INSERT INTO Vendedores(Cedula,Nombre,Correo,Estado)
		VALUES (@Cedula,@Nombre,@Correo,1)

	END

END
GO

-- Procedimiento almacenado para registrar un vehiculo
CREATE PROCEDURE RegistrarVehiculo
	@Marca			varchar(100),
    @Modelo			varchar(100),
    @Color			varchar(100),
    @Precio			decimal(18, 2),
	@IdVendedor		bigint
AS
BEGIN
	DECLARE @MarcaRepetida int;

	SET @MarcaRepetida = (SELECT COUNT(*) FROM Vehiculos WHERE Marca = @Marca);

	IF (@MarcaRepetida < 2)
	BEGIN

		INSERT INTO [dbo].[Vehiculos](Marca,Modelo,Color,Precio,IdVendedor)
		VALUES (@Marca,@Modelo,@Color,@Precio,@IdVendedor)

	END

END
GO

-- Procedimiento para consultar todos los vehiculos
CREATE PROCEDURE ConsultarVehiculos
	
AS
BEGIN

	SELECT	Vn.Cedula, Vn.Nombre, Vh.Marca, Vh.Modelo, Vh.Precio
	FROM	Vendedores Vn
	INNER JOIN Vehiculos Vh 
	ON Vn.IdVendedor = Vh.IdVendedor;

END
GO