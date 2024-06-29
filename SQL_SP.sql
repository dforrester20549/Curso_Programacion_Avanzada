USE [Practica2]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RegistrarVendedor]
	
	@Cedula varchar(50),
	@Nombre varchar(100),
	@Correo varchar(100)
AS
BEGIN
	
	DECLARE @Estado BIT = 1

	IF NOT EXISTS(SELECT 1 FROM dbo.Vendedores WHERE Correo = @Correo OR Cedula = @Cedula)
	BEGIN

	INSERT INTO dbo.Vendedores(Cedula,Nombre,Correo,Estado)
	VALUES (@Cedula,@Nombre,@Correo,@Estado)

	END

END
GO

USE [Practica2]
GO
/****** Object:  StoredProcedure [dbo].[RegistrarVendedor]    Script Date: 29/06/2024 11:41:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RegistrarVehiculo]
	
	@Marca   varchar(50),
	@Modelo  varchar(100),
	@Color   varchar(100),
	@Precio  decimal(18,2),
	@Vendedor Bigint

AS
BEGIN
	
	-- Declarar la variable para contar el número de vehículos con la misma marca
    DECLARE @MarcaCount INT;

    -- Contar el número de vehículos con la misma marca
    SELECT @MarcaCount = COUNT(*)
    FROM dbo.Vehiculos
    WHERE Marca = @Marca;

    -- Si la marca no se ha registrado más de dos veces, insertar el nuevo vehículo
    IF @MarcaCount < 2
    BEGIN
        INSERT INTO dbo.Vehiculos (Marca, Modelo, Color, Precio, IdVendedor)
        VALUES (@Marca, @Modelo, @Color, @Precio, @Vendedor);
    END

END
GO