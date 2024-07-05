USE [CasoEstudio]
GO
/****** Object:  StoredProcedure [dbo].[ConsultarVehiculos]    Script Date: 04/07/2024 20:17:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento para consultar todos los vehiculos
CREATE PROCEDURE [dbo].[Consultar]
	
AS
BEGIN

	SELECT	E.Fecha, E.Monto, TE.DescripcionTipoEjercicio, E.Nombre
	FROM	Ejercicios E
	INNER JOIN TiposEjercicio TE 
	ON E.TipoEjercicio = TE.TipoEjercicio

END

USE [CasoEstudio]
GO
/****** Object:  StoredProcedure [dbo].[RegistrarVehiculo]    Script Date: 04/07/2024 20:07:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento almacenado para registrar un vehiculo
CREATE PROCEDURE [dbo].[RegistrarEjercicio]
	@Nombre			   nvarchar(100),
    @Monto		       decimal(18, 2),
	@TipoEjercicio	   bigint

AS
BEGIN
	DECLARE @TipoEjercicioRepetida bigint;

	SET @TipoEjercicioRepetida = (SELECT COUNT(*) FROM Ejercicios WHERE TipoEjercicio = @TipoEjercicio);

	IF (@TipoEjercicioRepetida < 2)
	BEGIN

		INSERT INTO [dbo].[Ejercicios](Nombre,Fecha,Monto,TipoEjercicio)
		VALUES (@Nombre,GETDATE(),@Monto,@TipoEjercicio)

	END

END