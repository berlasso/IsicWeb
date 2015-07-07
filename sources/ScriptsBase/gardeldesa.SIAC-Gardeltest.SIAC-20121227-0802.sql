/*
Run this script on:

        Gardeltest.SIAC    -  This database will be modified

to synchronize it with:

        gardeldesa.SIAC

You are recommended to back up your database before running this script

Script created by SQL Compare version 10.1.0 from Red Gate Software Ltd at 27/12/2012 08:02:31 a.m.

*/
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE id=OBJECT_ID('tempdb..#tmpErrors')) DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
GO
PRINT N'Dropping foreign keys from [dbo].[BusquedaTatuajes]'
GO
ALTER TABLE [dbo].[BusquedaTatuajes] DROP CONSTRAINT[FK_BusquedaTatuajes_Busqueda]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping foreign keys from [dbo].[Delitos]'
GO
ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT[FK_Delitos_NNClaseTipoDelito]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping foreign keys from [dbo].[SeniasParticulares]'
GO
ALTER TABLE [dbo].[SeniasParticulares] DROP CONSTRAINT[FK_SeniasParticulares_ClaseTipoPersona]
ALTER TABLE [dbo].[SeniasParticulares] DROP CONSTRAINT[FK_SeniasParticulares_ClaseUbicacionSeniaPart]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping foreign keys from [dbo].[TatuajesPersona]'
GO
ALTER TABLE [dbo].[TatuajesPersona] DROP CONSTRAINT[FK_TatuajesPersona_ClaseTipoPersona]
ALTER TABLE [dbo].[TatuajesPersona] DROP CONSTRAINT[FK_TatuajesPersona_ClaseUbicacionSeniaPart]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[BusquedaTatuajes]'
GO
ALTER TABLE [dbo].[BusquedaTatuajes] DROP CONSTRAINT [PK_BusquedaTatuajes]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[Delitos]'
GO
ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [DF__Delitos__idClase__4A43E4FB]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasDesaparecidasSelectCoincidencias]'
GO
ALTER PROCEDURE [dbo].[PersonasDesaparecidasSelectCoincidencias]
@Apellido char(50) = null, @Nombre char(50) = null, @usuario varchar(50) = null, @fechaDesde datetime = null, @fechaHasta datetime = null, @edadDesde int = null, @edadHasta int = null, @tallaDesde real = null, @tallaHasta real = null, @pesoDesde real = null, @pesoHasta real = null, @sexo int = null, @colorPiel varchar(50) = null, @colorCabello varchar(50) = null, @colorTenido varchar(50) = null, @longitudCabello varchar(50) = null, @aspectoCabello varchar(50) = null, @calvicie varchar(50) = null, @colorOjos varchar(50) = null, @faltanPiezasDentales varchar(50) = null, @seniaParticular varchar(50) = null, @ubicacionSeniaParticular varchar(50) = null,  @tatuaje varchar(50) = null,   @ubicacionTatuaje varchar(50) = null, @ADN char(80) = null, @cantidadCoincidencias int = null, @fechaUltimaModificacion datetime = null, @fechaAlta datetime = null
WITH EXEC AS CALLER
AS
BEGIN
      SET  NOCOUNT ON
      DECLARE @Err   INT
      
SELECT  *
        FROM (SELECT *,
                       CoincidenciaADN
                     + CoincidenciaAspectoCabello
                     + CoincidenciaAspectoCabello
                     + CoincidenciaCalvicie
                     + CoincidenciaCalvicie
                     + CoincidenciaColorCabello
                     + CoincidenciaColorOjos
                     + CoincidenciaColorPiel
                     + CoincidenciaColorTenido
                     + CoincidenciaEdad
                     + CoincidenciaFecha
                     + CoincidenciaLongCabello
                     + CoincidenciaNombreyApellido
                     + CoincidenciaPeso
                     + CoincidenciaSeniasParticulares
					 + CoincidenciaTatuajes
                     + CoincidenciaSexo
                     + CoincidenciaTalla
                        AS CantidadCoincidencias
                FROM (SELECT [Id],
                             [Ipp],
                             [UFI],
                             [idOrganismoInterviniente],
                             [idComisaria],
                             [idLugarDesaparicion],
                             [DNI],
                             [Apellido],
                             [Nombre],
                             [FechaDesaparicion],
                             [idSexo],
                             [FechaNacimiento],
                             [EdadMomentoDesaparicion],
                             [Talla],
                             [Peso],
                             [idColorPiel],
                             [idColorCabello],
                             [idColorTenido],
                             [idLongitudCabello],
                             [idAspectoCabello],
                             [idCalvicie],
                             [idColorOjos],
                             [idRostro],
                             [CantidadDiasNoAfeitado],
                             [FaltanPiezasDentales],
                             [idDentadura],
                             /*[idSeniaParticular],
                             [idUbicacionSeniaParticular],*/
                             [tieneADN],
                             [ADN],
                             [idGrupoSanguineo],
                             [Foto],
                             [FichasDactilares],
                             [Ropa],
                             [ArticulosPersonales],
                             [ExistenRadiografia],
                             [idBusqueda],
                             [FechaUltimaModificacion],
                             [UsuarioUltimaModificacion],
                             [Baja],
							 [FechaAlta],
							 [UsuarioAlta],
							 [esExtJurisdiccion],
                             
                               DATEDIFF (yy, [FechaNacimiento], GETDATE ())
                             - CASE
                                  WHEN (   (month ([FechaNacimiento]) >
                                               month (GETDATE ()))
                                        OR (    month ([FechaNacimiento]) =
                                                   month (GETDATE ())
                                            AND day ([FechaNacimiento]) >
                                                   day (GETDATE ())))
                                  THEN
                                     1
                                  ELSE
                                     0
                               END
                                AS EdadCalculadaConFechaNacimiento,
                               [EdadMomentoDesaparicion]
                             + (  DATEDIFF (yy,
                                            [FechaDesaparicion],
                                            GETDATE ())
                                - CASE
                                     WHEN (   (month ([FechaDesaparicion]) >
                                                  month (GETDATE ()))
                                           OR (    month (
                                                      [FechaDesaparicion]) =
                                                      month (GETDATE ())
                                               AND day ([FechaDesaparicion]) >
                                                      day (GETDATE ())))
                                     THEN
                                        1
                                     ELSE
                                        0
                                  END)
                                AS EdadCalculadaConFechaDesaparicion,
                             CASE
                                WHEN ([FechaNacimiento] IS NOT NULL)
                                THEN
                                   CASE
                                      WHEN (   (    @edadDesde IS NOT NULL
                                                AND @edadHasta IS NOT NULL
                                                AND   DATEDIFF (
                                                         yy,
                                                         [FechaNacimiento],
                                                         GETDATE ())
                                                    - CASE
                                                         WHEN (   (month (
                                                                      [FechaNacimiento]) >
                                                                      month (
                                                                         GETDATE ()))
                                                               OR (    month (
                                                                          [FechaNacimiento]) =
                                                                          month (
                                                                             GETDATE ())
                                                                   AND day (
                                                                          [FechaNacimiento]) >
                                                                          day (
                                                                             GETDATE ())))
                                                         THEN
                                                            1
                                                         ELSE
                                                            0
                                                      END >= @edadDesde
                                                AND   DATEDIFF (
                                                         yy,
                                                         [FechaNacimiento],
                                                         GETDATE ())
                                                    - CASE
                                                         WHEN (   (month (
                                                                      [FechaNacimiento]) >
                                                                      month (
                                                                         GETDATE ()))
                                                               OR (    month (
                                                                          [FechaNacimiento]) =
                                                                          month (
                                                                             GETDATE ())
                                                                   AND day (
                                                                          [FechaNacimiento]) >
                                                                          day (
                                                                             GETDATE ())))
                                                         THEN
                                                            1
                                                         ELSE
                                                            0
                                                      END <= @edadHasta)
                                            OR (    @edadDesde IS NULL
                                                AND   DATEDIFF (
                                                         yy,
                                                         [FechaNacimiento],
                                                         GETDATE ())
                                                    - CASE
                                                         WHEN (   (month (
                                                                      [FechaNacimiento]) >
                                                                      month (
                                                                         GETDATE ()))
                                                               OR (    month (
                                                                          [FechaNacimiento]) =
                                                                          month (
                                                                             GETDATE ())
                                                                   AND day (
                                                                          [FechaNacimiento]) >
                                                                          day (
                                                                             GETDATE ())))
                                                         THEN
                                                            1
                                                         ELSE
                                                            0
                                                      END <= @edadHasta)
                                            OR (    @edadHasta IS NULL
                                                AND   DATEDIFF (
                                                         yy,
                                                         [FechaNacimiento],
                                                         GETDATE ())
                                                    - CASE
                                                         WHEN (   (month (
                                                                      [FechaNacimiento]) >
                                                                      month (
                                                                         GETDATE ()))
                                                               OR (    month (
                                                                          [FechaNacimiento]) =
                                                                          month (
                                                                             GETDATE ())
                                                                   AND day (
                                                                          [FechaNacimiento]) >
                                                                          day (
                                                                             GETDATE ())))
                                                         THEN
                                                            1
                                                         ELSE
                                                            0
                                                      END >= @edadDesde))
                                      THEN
                                         1
                                      ELSE
                                         0
                                   END
                                ELSE
                                   (CASE
                                       WHEN     ([EdadMomentoDesaparicion]
                                                    IS NOT NULL)
                                            AND ([FechaDesaparicion]
                                                    IS NOT NULL)
                                       THEN
                                          CASE
                                             WHEN    (    @edadDesde
                                                             IS NOT NULL
                                                      AND @edadHasta
                                                             IS NOT NULL
                                                      AND   [EdadMomentoDesaparicion]
                                                          + (  DATEDIFF (
                                                                  yy,
                                                                  [FechaDesaparicion],
                                                                  GETDATE ())
                                                             - CASE
                                                                  WHEN ( (month ([FechaDesaparicion]) > month (GETDATE ())) OR (month ([FechaDesaparicion]) = month (GETDATE ()) AND day ([FechaDesaparicion]) > day (GETDATE ())))
                                                                  THEN
                                                                     1
                                                                  ELSE
                                                                     0
                                                               END) >=
                                                             @edadDesde
                                                      AND   [EdadMomentoDesaparicion]
                                                          + (  DATEDIFF (
                                                                  yy,
                                                                  [FechaDesaparicion],
                                                                  GETDATE ())
                                                             - CASE
                                                                  WHEN ( (month ([FechaDesaparicion]) > month (GETDATE ())) OR (month ([FechaDesaparicion]) = month (GETDATE ()) AND day ([FechaDesaparicion]) > day (GETDATE ())))
                                                                  THEN
                                                                     1
                                                                  ELSE
                                                                     0
                                                               END) <=
                                                             @edadHasta)
                                                  OR (    @edadDesde IS NULL
                                                      AND   [EdadMomentoDesaparicion]
                                                          + (  DATEDIFF (
                                                                  yy,
                                                                  [FechaDesaparicion],
                                                                  GETDATE ())
                                                             - CASE
                                                                  WHEN ( (month ([FechaDesaparicion]) > month (GETDATE ())) OR (month ([FechaDesaparicion]) = month (GETDATE ()) AND day ([FechaDesaparicion]) > day (GETDATE ())))
                                                                  THEN
                                                                     1
                                                                  ELSE
                                                                     0
                                                               END) <=
                                                             @edadHasta)
                                                  OR (    @edadHasta IS NULL
                                                      AND   [EdadMomentoDesaparicion]
                                                          + (  DATEDIFF (
                                                                  yy,
                                                                  [FechaDesaparicion],
                                                                  GETDATE ())
                                                             - CASE
                                                                  WHEN ( (month ([FechaDesaparicion]) > month (GETDATE ())) OR (month ([FechaDesaparicion]) = month (GETDATE ()) AND day ([FechaDesaparicion]) > day (GETDATE ())))
                                                                  THEN
                                                                     1
                                                                  ELSE
                                                                     0
                                                               END) >=
                                                             @edadDesde)
                                             THEN
                                                1
                                             ELSE
                                                0
                                          END
                                       ELSE
                                          0
                                    END)
                             END
                                AS CoincidenciaEdad,
                             CASE
                                WHEN (   ([Apellido] LIKE
                                             N'%' + @Apellido + '%')
                                      OR ([Nombre] LIKE N'%' + @Nombre + '%'))
                                THEN
                                   1
                                ELSE
                                   0
                             END
                                AS CoincidenciaNombreyApellido,
                             CASE
                                WHEN    (    @fechaDesde IS NOT NULL
                                         AND @fechaHasta IS NOT NULL
                                         AND [FechaDesaparicion] >=
                                                @fechaDesde
                                         AND [FechaDesaparicion] <=
                                                @fechaHasta)
                                     OR (    @fechaDesde IS NULL
                                         AND [FechaDesaparicion] <=
                                                @fechaHasta)
                                     OR (    @fechaHasta IS NULL
                                         AND [FechaDesaparicion] >=
                                                @fechaDesde)
                                THEN
                                   1
                                ELSE
                                   0
                             END
                                AS CoincidenciaFecha,
                             CASE
                                WHEN (   (    @tallaDesde IS NOT NULL
                                          AND @tallaHasta IS NOT NULL
                                          AND [Talla] >= @tallaDesde
                                          AND [Talla] <= @tallaHasta)
                                      OR (    @tallaHasta IS NULL
                                          AND [Talla] >= @tallaDesde)
                                      OR (    @tallaDesde IS NULL
                                          AND [Talla] <= @tallaHasta))
                                THEN
                                   1
                                ELSE
                                   0
                             END
                                AS CoincidenciaTalla,
                             CASE
                                WHEN (   (    @pesoDesde IS NOT NULL
                                          AND @pesoHasta IS NOT NULL
                                          AND [Peso] >= @pesoDesde
                                          AND [Peso] <= @pesoHasta)
                                      OR (    @pesoHasta IS NULL
                                          AND [Peso] >= @pesoDesde)
                                      OR (    @pesoDesde IS NULL
                                          AND [Peso] <= @pesoHasta))
                                THEN
                                   1
                                ELSE
                                   0
                             END
                                AS CoincidenciaPeso,
                             CASE
                                WHEN (    @sexo IS NOT NULL
                                      AND @sexo != ''
                                      AND ([idSexo] = @sexo))
                                THEN
                                   1
                                ELSE
                                   0
                             END
                                AS CoincidenciaSexo,
                             CASE
                                WHEN (    @colorPiel IS NOT NULL
                                      AND @colorPiel != ''
                                      AND ([idColorPiel] IN
                                              (SELECT ID
                                                 FROM fnSplitter (@colorPiel))))
                                THEN
                                   1
                                ELSE
                                   0
                             END
                                AS CoincidenciaColorPiel,
                             CASE
                                WHEN (    @colorCabello IS NOT NULL
                                      AND @colorCabello != ''
                                      AND ([idColorCabello] IN
                                              (SELECT ID
                                                 FROM fnSplitter (
                                                         @colorCabello))))
                                THEN
                                   1
                                ELSE
                                   0
                             END
                                AS CoincidenciaColorCabello,
                             CASE
                                WHEN (    @colorTenido IS NOT NULL
                                      AND @colorTenido != ''
                                      AND ([idColorTenido] IN
                                              (SELECT ID
                                                 FROM fnSplitter (
                                                         @colorTenido))))
                                THEN
                                   1
                                ELSE
                                   0
                             END
                                AS CoincidenciaColorTenido,
                             CASE
                                WHEN (    @longitudCabello IS NOT NULL
                                      AND @longitudCabello != ''
                                      AND ([idLongitudCabello] IN
                                              (SELECT ID
                                                 FROM fnSplitter (
                                                         @longitudCabello))))
                                THEN
                                   1
                                ELSE
                                   0
                             END
                                AS CoincidenciaLongCabello,
                             CASE
                                WHEN (    @aspectoCabello IS NOT NULL
                                      AND @aspectoCabello != ''
                                      AND ([idAspectoCabello] IN
                                              (SELECT ID
                                                 FROM fnSplitter (
                                                         @aspectoCabello))))
                                THEN
                                   1
                                ELSE
                                   0
                             END
                                AS CoincidenciaAspectoCabello,
                             CASE
                                WHEN (    @calvicie IS NOT NULL
                                      AND @calvicie != ''
                                      AND ([idCalvicie] IN
                                              (SELECT ID
                                                 FROM fnSplitter (@calvicie))))
                                THEN
                                   1
                                ELSE
                                   0
                             END
                                AS CoincidenciaCalvicie,
                             CASE
                                WHEN (    @colorOjos IS NOT NULL
                                      AND @colorOjos != ''
                                      AND ([idColorOjos] IN
                                              (SELECT ID
                                                 FROM fnSplitter (@colorOjos))))
                                THEN
                                   1
                                ELSE
                                   0
                             END
                                AS CoincidenciaColorOjos,
                           /*  CASE
                                WHEN (    @faltanPiezasDentales IS NOT NULL
                                      AND @faltanPiezasDentales != ''
                                      AND ([FaltanPiezasDentales] =
                                              @faltanPiezasDentales))
                                THEN
                                   1
                                ELSE
                                   0
                             END
                                AS CoincidenciaFaltanDientes,*/
                             CASE
                                WHEN     (   @seniaparticular IS NOT NULL
                                          OR @ubicacionseniaparticular
                                                IS NOT NULL)
                                     AND (SELECT count (*)
                                            FROM seniasparticulares s
                                           WHERE     s.idpersona = XFECHA.id
                                                 AND idtabladestino = 1
                                                 AND (    idseniaparticular IN
                                                             (SELECT ID
                                                                FROM fnSplitter (
                                                                        @seniaParticular))
                                                      AND idubicacionseniaparticular IN
                                                             (SELECT ID
                                                                FROM fnSplitter (
                                                                        @ubicacionSeniaParticular)))) >
                                            0
                                THEN
                                   1
                                ELSE
                                   0
                             END
                                AS CoincidenciaSeniasParticulares,
                             CASE
                                WHEN     (   @tatuaje IS NOT NULL
                                          OR @ubicacionTatuaje
                                                IS NOT NULL)
                                     AND (SELECT count (*)
                                            FROM tatuajesPersona t
                                           WHERE     t.idpersona = XFECHA.id
                                                 AND idtabladestino = 1
                                                 AND (    idTatuaje IN
                                                             (SELECT ID
                                                                FROM fnSplitter (
                                                                        @tatuaje))
                                                      AND idubicaciontatuaje IN
                                                             (SELECT ID
                                                                FROM fnSplitter (
                                                                        @ubicaciontatuaje)))) >
                                            0
                                THEN
                                   1
                                ELSE
                                   0
                             END
                                AS CoincidenciaTatuajes,
                             CASE
                                WHEN (    @ADN IS NOT NULL
                                      AND @ADN = ''
                                      AND ([ADN] = @ADN))
                                THEN
                                   1
                                ELSE
                                   0
                             END
                                AS CoincidenciaADN
                        FROM (SELECT *
                                FROM PersonasDesaparecidas
                               WHERE (  Baja= 'false' and   @fechaUltimaModificacion IS NULL
                                      OR @fechaUltimaModificacion = ''
                                      OR FechaUltimaModificacion IS NULL
                                      OR FechaUltimaModificacion >
                                            @fechaUltimaModificacion)) XFECHA) Q
               WHERE     (   @sexo IS NULL
                          OR @sexo = [idSexo]
                          OR [idSexo] = 1
                          OR @sexo=1 )
                     AND (   @usuario IS NULL
                          OR UsuarioAlta = @usuario)) XCANTCOINCIDENCIAS
       WHERE (   @cantidadCoincidencias IS NULL
              OR CantidadCoincidencias >= @cantidadCoincidencias)
      ORDER BY CantidadCoincidencias DESC
        SET @Err = @@Error

      RETURN @Err
   END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Rebuilding [dbo].[BusquedaTatuajes]'
GO
CREATE TABLE [dbo].[tmp_rg_xx_BusquedaTatuajes]
(
[id] [numeric] (18, 0) NOT NULL IDENTITY(1, 1),
[idBusqueda] [int] NULL,
[IdClaseTatuaje] [int] NULL,
[IdUbicacionTatuaje] [int] NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
SET IDENTITY_INSERT [dbo].[tmp_rg_xx_BusquedaTatuajes] ON
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
INSERT INTO [dbo].[tmp_rg_xx_BusquedaTatuajes]([id], [idBusqueda], [IdClaseTatuaje], [IdUbicacionTatuaje]) SELECT [id], [idBusqueda], [IdClaseTatuaje], [IdUbicacionTatuaje] FROM [dbo].[BusquedaTatuajes]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
SET IDENTITY_INSERT [dbo].[tmp_rg_xx_BusquedaTatuajes] OFF
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
DROP TABLE [dbo].[BusquedaTatuajes]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
EXEC sp_rename N'[dbo].[tmp_rg_xx_BusquedaTatuajes]', N'BusquedaTatuajes'
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_BusquedaTatuajes] on [dbo].[BusquedaTatuajes]'
GO
ALTER TABLE [dbo].[BusquedaTatuajes] ADD CONSTRAINT [PK_BusquedaTatuajes] PRIMARY KEY CLUSTERED  ([id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BusquedaTatuajesDeleteItemByIdBusqueda]'
GO

CREATE PROCEDURE [dbo].[BusquedaTatuajesDeleteItemByIdBusqueda]
(
	@idBusqueda int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [BusquedaTatuajes]
	WHERE
		[idBusqueda] = @idBusqueda
	SET @Err = @@Error

	RETURN @Err
END

GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[BusquedaTatuajesInsertUpdateSingleItem]'
GO

ALTER PROCEDURE [dbo].[BusquedaTatuajesInsertUpdateSingleItem]
(
	@id numeric(18,0),
	@idBusqueda int = NULL,
	@IdClaseTatuaje int = NULL,
	@IdUbicacionTatuaje int = NULL
)
AS
DECLARE @ReturnValue int
IF (@id IS NULL) -- New Item
BEGIN

	INSERT
	INTO [BusquedaTatuajes]
	(
			
		[idBusqueda],
		[IdClaseTatuaje],
		[IdUbicacionTatuaje]
	)
		VALUES
		(
			
		@idBusqueda,
		@IdClaseTatuaje,
		@IdUbicacionTatuaje
	)
	
	SELECT @ReturnValue = SCOPE_IDENTITY()

	END
	ELSE
	BEGIN

	UPDATE [BusquedaTatuajes]
	SET
		[idBusqueda] = @idBusqueda,
		[IdClaseTatuaje] = @IdClaseTatuaje,
		[IdUbicacionTatuaje] = @IdUbicacionTatuaje
	WHERE
		[id] = @id

SELECT @ReturnValue = @id

END
  IF (@@ERROR != 0)
  BEGIN
    RETURN -1
  END
  ELSE
  BEGIN
    RETURN @ReturnValue
  END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladas]'
GO
ALTER TABLE [dbo].[PersonasHalladas] ADD
[RestosOseos] [bit] NOT NULL CONSTRAINT [DF__PersonasH__resto__190C7C1A] DEFAULT ((0))
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Refreshing [dbo].[ViewPersonasHalladas]'
GO
EXEC sp_refreshview N'[dbo].[ViewPersonasHalladas]'
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[Delitos]'
GO
ALTER TABLE [dbo].[Delitos] ALTER COLUMN [idClaseDelito] [int] NOT NULL
ALTER TABLE [dbo].[Delitos] ALTER COLUMN [idUsuarioAlta] [varchar] (50) COLLATE Modern_Spanish_CI_AS NULL
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByIPP]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByIPP]
@IPP varchar(50)
WITH EXEC AS CALLER
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
    [FechaAlta],
    [UsuarioAlta],
		[Baja],
    [esExtJurisdiccion],
    [RestosOseos]
	FROM [PersonasHalladas]
	
	--WHERE 		([IPP] LIKE ('%'+@IPP+'%'))
  WHERE IPP=ltrim(rtrim(@IPP))
	ORDER BY [Ipp]
	
	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectSingleItemByIdCausa]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectSingleItemByIdCausa]
@IdCausa nchar(12)
WITH EXEC AS CALLER
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
    [FechaAlta],
    [UsuarioAlta],
		[Baja],
    [esExtJurisdiccion],
    [RestosOseos]
	FROM [PersonasHalladas]
	WHERE
		([Ipp] = @IdCausa)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByFechaUltimaModificacion]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByFechaUltimaModificacion]
@FechaUltimaModificacion datetime
WITH EXEC AS CALLER
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
		[Baja],
    [esExtJurisdiccion],
    [FechaAlta],
    [UsuarioAlta],
    [RestosOseos]
	FROM [PersonasHalladas]
	
	WHERE 		(FechaUltimaModificacion = @FechaUltimaModificacion)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectSingleItem]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectSingleItem]
@Id int
WITH EXEC AS CALLER
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
		[Baja],
    [esExtJurisdiccion],
    [FechaAlta],
    [UsuarioAlta],
    [RestosOseos]
	FROM [PersonasHalladas]
	WHERE
		([Id] = @Id)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectList]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectList]
WITH EXEC AS CALLER
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
		[Baja],
    [esExtJurisdiccion],
    [FechaAlta],
    [UsuarioAlta],
    [RestosOseos]
	FROM [PersonasHalladas]

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByidBusqueda]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByidBusqueda]
@idBusqueda numeric(18, 0)
WITH EXEC AS CALLER
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Ipp],
		[Id],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
    [FechaAlta],
    [UsuarioAlta],
		[Baja],
    [esExtJurisdiccion],
      [RestosOseos]
	FROM [PersonasHalladas]
	
	WHERE 		([idBusqueda] = @idBusqueda)
	ORDER BY [Ipp]
	
	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByidComisaria]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByidComisaria]
@idComisaria int
WITH EXEC AS CALLER
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
		[Baja],
    [FechaAlta],
    [UsuarioAlta],
    [RestosOseos]
	FROM [PersonasHalladas]
	
	WHERE 		([idComisaria] = @idComisaria)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByidDentadura]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByidDentadura]
@idDentadura int
WITH EXEC AS CALLER
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
		[Baja],
    [FechaAlta],
    [UsuarioAlta],
     [RestosOseos]
	FROM [PersonasHalladas]
	
	WHERE 		([idDentadura] = @idDentadura)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByidLugarHallazgo]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByidLugarHallazgo]
@idLugarHallazgo int
WITH EXEC AS CALLER
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
		[Baja],
    [FechaAlta],
    [UsuarioAlta],
    [RestosOseos]
	FROM [PersonasHalladas]
	
	WHERE 		([idLugarHallazgo] = @idLugarHallazgo)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByidAspectoCabello]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByidAspectoCabello]
@idAspectoCabello int
WITH EXEC AS CALLER
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
    [FechaAlta],
    [UsuarioAlta],
		[Baja],
    [RestosOseos]
	FROM [PersonasHalladas]
	
	WHERE 		([idAspectoCabello] = @idAspectoCabello)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByExistenRadiografia]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByExistenRadiografia]
@ExistenRadiografia int
WITH EXEC AS CALLER
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
		[Baja],
    [esExtJurisdiccion],
    [FechaAlta],
    [UsuarioAlta],
    [RestosOseos]
	FROM [PersonasHalladas]
	
	WHERE 		([ExistenRadiografia] = @ExistenRadiografia)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByFichasDactilares]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByFichasDactilares]
@FichasDactilares int
WITH EXEC AS CALLER
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
		[Baja],
    [FechaAlta],
    [UsuarioAlta],
    [RestosOseos]
	FROM [PersonasHalladas]
	
	WHERE 		([FichasDactilares] = @FichasDactilares)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByFaltanPiezasDentales]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByFaltanPiezasDentales]
@FaltanPiezasDentales int
WITH EXEC AS CALLER
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
		[Baja],
    [esExtJurisdiccion],
    [FechaAlta],
    [UsuarioAlta],
    [RestosOseos]
	FROM [PersonasHalladas]
	
	WHERE 		([FaltanPiezasDentales] = @FaltanPiezasDentales)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByidCalvicie]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByidCalvicie]
@idCalvicie int
WITH EXEC AS CALLER
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
		[Baja],
    [FechaAlta],
    [UsuarioAlta],
    [RestosOseos]
	FROM [PersonasHalladas]
	
	WHERE 		([idCalvicie] = @idCalvicie)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByidColorTenido]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByidColorTenido]
@idColorTenido int
WITH EXEC AS CALLER
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
    [FechaAlta],
    [UsuarioAlta],
		[Baja],
    [RestosOseos]
	FROM [PersonasHalladas]
	
	WHERE 		([idColorTenido] = @idColorTenido)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByidColorCabello]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByidColorCabello]
@idColorCabello int
WITH EXEC AS CALLER
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
    [FechaAlta],
    [UsuarioAlta],
		[Baja],
    [RestosOseos]
	FROM [PersonasHalladas]
	
	WHERE 		([idColorCabello] = @idColorCabello)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByidColorPiel]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByidColorPiel]
@idColorPiel int
WITH EXEC AS CALLER
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
    [FechaAlta],
    [UsuarioAlta],
		[Baja],
    [RestosOseos]
	FROM [PersonasHalladas]
	
	WHERE 		([idColorPiel] = @idColorPiel)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByidColorOjos]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByidColorOjos]
@idColorOjos int
WITH EXEC AS CALLER
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
		[Baja],
    [FechaAlta],
    [UsuarioAlta],
     [RestosOseos]
	FROM [PersonasHalladas]
	
	WHERE 		([idColorOjos] = @idColorOjos)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByidGrupoSanguineo]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByidGrupoSanguineo]
@idGrupoSanguineo int
WITH EXEC AS CALLER
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
		[Baja],
    [FechaAlta],
    [UsuarioAlta],
      [RestosOseos]
	FROM [PersonasHalladas]
	
	WHERE 		([idGrupoSanguineo] = @idGrupoSanguineo)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByidLongitudCabello]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByidLongitudCabello]
@idLongitudCabello int
WITH EXEC AS CALLER
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
    [FechaAlta],
    [UsuarioAlta],
		[Baja],
      [RestosOseos]
	FROM [PersonasHalladas]
	
	WHERE 		([idLongitudCabello] = @idLongitudCabello)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByidOrganismoInterviniente]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByidOrganismoInterviniente]
@idOrganismoInterviniente int
WITH EXEC AS CALLER
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
    [FechaAlta],
    [UsuarioAlta],
		[Baja],
      [RestosOseos]
	FROM [PersonasHalladas]
	
	WHERE 		([idOrganismoInterviniente] = @idOrganismoInterviniente)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByidRostro]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByidRostro]
@idRostro int
WITH EXEC AS CALLER
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
		[Baja],
    [FechaAlta],
    [UsuarioAlta],
      [RestosOseos]
	FROM [PersonasHalladas]
	
	WHERE 		([idRostro] = @idRostro)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByidSexo]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByidSexo]
@idSexo int
WITH EXEC AS CALLER
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
    [FechaAlta],
    [UsuarioAlta],
		[Baja],
      [RestosOseos]
	FROM [PersonasHalladas]
	
	WHERE 		([idSexo] = @idSexo)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasInsertUpdateSingleItem]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasInsertUpdateSingleItem]
@Id int, @Ipp nchar(12) = null, @UFI nchar(50) = null, @DNI nchar(8) = null, @Apellido nchar(50) = null, @Nombre nchar(50) = null, @idOrganismoInterviniente int = null, @idComisaria int = null, @idLugarHallazgo int = null, @FechaHallazgo smalldatetime = null, @idSexo int = null, @EdadAparente int = null, @EdadCientifica int = null, @Talla real = null, @Peso real = null, @idColorPiel int = null, @idColorCabello int = null, @idColorTenido int = null, @idLongitudCabello int = null, @idAspectoCabello int = null, @idCalvicie int = null, @idColorOjos int = null, @idRostro int = null, @CantidadDiasNoAfeitado int = null, @FaltanPiezasDentales int = null, @idDentadura int = null, @tieneADN int = null, @ADN nchar(80) = null, @idGrupoSanguineo int = null, @Foto int = null, @FichasDactilares int = null, @Ropa nchar(100) = null, @ArticulosPersonales nchar(100) = null, @ExistenRadiografia int = null, @Vive int = null, @idBusqueda numeric(18, 0) = null, @FechaUltimaModificacion datetime = null, @UsuarioUltimaModificacion nchar(50) = null, @Baja bit = null, @UsuarioAlta varchar(50) = null, @FechaAlta datetime = null, @esExtJurisdiccion bit = null, @restosOseos bit
WITH EXEC AS CALLER
AS
DECLARE @ReturnValue int
IF (@Id IS NULL) -- New Item
BEGIN

	INSERT
	INTO [PersonasHalladas]
	(
			[Ipp],
		[UFI],
		[DNI],
		[Apellido],
		[Nombre],
		[idOrganismoInterviniente],
		[idComisaria],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		[tieneADN],
		[ADN],
		[idGrupoSanguineo],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[idBusqueda],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
		[Baja],
    [UsuarioAlta],
    [FechaAlta],
    [esExtJurisdiccion],
    [RestosOseos]
	)
		VALUES
		(
			@Ipp,
		@UFI,
		@DNI,
		@Apellido,
		@Nombre,
		@idOrganismoInterviniente,
		@idComisaria,
		@idLugarHallazgo,
		@FechaHallazgo,
		@idSexo,
		@EdadAparente,
		@EdadCientifica,
		@Talla,
		@Peso,
		@idColorPiel,
		@idColorCabello,
		@idColorTenido,
		@idLongitudCabello,
		@idAspectoCabello,
		@idCalvicie,
		@idColorOjos,
		@idRostro,
		@CantidadDiasNoAfeitado,
		@FaltanPiezasDentales,
		@idDentadura,
		@tieneADN,
		@ADN,
		@idGrupoSanguineo,
		@Foto,
		@FichasDactilares,
		@Ropa,
		@ArticulosPersonales,
		@ExistenRadiografia,
		@Vive,
		@idBusqueda,
		@FechaUltimaModificacion,
		@UsuarioUltimaModificacion,
		@Baja,
    @UsuarioAlta,
    @FechaAlta,
    @esExtJurisdiccion,
    @restosOseos
	)
	
	SELECT @ReturnValue = SCOPE_IDENTITY()

	END
	ELSE
	BEGIN

	UPDATE [PersonasHalladas]
	SET
		[Ipp] = @Ipp,
		[UFI] = @UFI,
		[DNI] = @DNI,
		[Apellido] = @Apellido,
		[Nombre] = @Nombre,
		[idOrganismoInterviniente] = @idOrganismoInterviniente,
		[idComisaria] = @idComisaria,
		[idLugarHallazgo] = @idLugarHallazgo,
		[FechaHallazgo] = @FechaHallazgo,
		[idSexo] = @idSexo,
		[EdadAparente] = @EdadAparente,
		[EdadCientifica] = @EdadCientifica,
		[Talla] = @Talla,
		[Peso] = @Peso,
		[idColorPiel] = @idColorPiel,
		[idColorCabello] = @idColorCabello,
		[idColorTenido] = @idColorTenido,
		[idLongitudCabello] = @idLongitudCabello,
		[idAspectoCabello] = @idAspectoCabello,
		[idCalvicie] = @idCalvicie,
		[idColorOjos] = @idColorOjos,
		[idRostro] = @idRostro,
		[CantidadDiasNoAfeitado] = @CantidadDiasNoAfeitado,
		[FaltanPiezasDentales] = @FaltanPiezasDentales,
		[idDentadura] = @idDentadura,
		[tieneADN] = @tieneADN,
		[ADN] = @ADN,
		[idGrupoSanguineo] = @idGrupoSanguineo,
		[Foto] = @Foto,
		[FichasDactilares] = @FichasDactilares,
		[Ropa] = @Ropa,
		[ArticulosPersonales] = @ArticulosPersonales,
		[ExistenRadiografia] = @ExistenRadiografia,
		[Vive] = @Vive,
		[idBusqueda] = @idBusqueda,
		[FechaUltimaModificacion] = @FechaUltimaModificacion,
		[UsuarioUltimaModificacion] = @UsuarioUltimaModificacion,
		[Baja] = @Baja,
    [UsuarioAlta]=@UsuarioAlta,
    [FechaAlta]=@FechaAlta,
    [esExtJurisdiccion] = @esExtJurisdiccion,
    [RestosOseos] = @restosOseos
	WHERE
		[Id] = @Id

SELECT @ReturnValue = @Id

END
  IF (@@ERROR != 0)
  BEGIN
    RETURN -1
  END
  ELSE
  BEGIN
    RETURN @ReturnValue
  END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectCoincidencias]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectCoincidencias]
@Apellido char(50) = null, @Nombre char(50) = null, @usuario varchar(50) = null, @fechaDesde datetime = null, @fechaHasta datetime = null, @edadDesde int = null, @edadHasta int = null, @tallaDesde real = null, @tallaHasta real = null, @pesoDesde real = null, @pesoHasta real = null, @sexo int = null, @colorPiel varchar(50) = null, @colorCabello varchar(50) = null, @colorTenido varchar(50) = null, @longitudCabello varchar(50) = null, @aspectoCabello varchar(50) = null, @calvicie varchar(50) = null, @colorOjos varchar(50) = null, @faltanPiezasDentales varchar(50) = null, @seniaParticular varchar(50) = null, @ubicacionSeniaParticular varchar(50) = null, @tatuaje varchar(50) = null, @ubicacionTatuaje varchar(50) = null, @ADN char(80) = null, @cantidadCoincidencias int = null, @fechaUltimaModificacion datetime = null, @fechaAlta datetime = null, @usuarioAlta varchar(50) = null
WITH EXEC AS CALLER
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int
	SELECT * FROM(
	SELECT
		[id],
		[Ipp],
		[UFI],
		[idOrganismoInterviniente],
		[idComisaria],
        [Apellido],
        [Nombre],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[idGrupoSanguineo],
		[idBusqueda],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		/*[idSeniaParticular],
		[idUbicacionSeniaParticular],*/
		[ADN],
		[tieneADN],
		[DNI],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
    [FechaAlta],
    [UsuarioAlta],
		[Baja],
    [esExtJurisdiccion],
    [RestosOseos],
        CASE WHEN (([Apellido] LIKE N'%' + @Apellido + '%') OR ([Nombre] LIKE N'%' + @Nombre + '%')) THEN 1 ELSE 0 END AS CoincidenciaNombreyApellido,
		CASE WHEN ((@edadDesde IS NOT NULL AND @edadHasta IS NOT NULL AND [EdadAparente] >= @edadDesde AND [EdadAparente] <= @edadHasta ) OR (@edadHasta IS NULL AND [EdadAparente] >= @edadDesde) OR (@edadDesde IS NULL AND [EdadAparente] <= @edadHasta )) THEN 1 ELSE 0 END AS CoincidenciaEdadAparente,
 		CASE WHEN (@fechaDesde IS NOT NULL AND @fechaHasta is not null and ([FechaHallazgo] >= @fechaDesde) AND ([FechaHallazgo] <= @fechaHasta)) OR (@fechaDesde IS NULL and [FechaHallazgo] <= @fechaHasta) OR (@fechaHasta IS NULL and [FechaHallazgo] >= @fechaDesde) THEN 1 ELSE 0 END AS CoincidenciaFecha,
		CASE WHEN ((@tallaDesde IS NOT NULL AND @tallaHasta IS NOT NULL AND [Talla] >= @tallaDesde AND [Talla] <= @tallaHasta)OR (@tallaHasta IS NULL AND [Talla] >= @tallaDesde ) OR (@tallaDesde IS NULL and [Talla] <= @tallaHasta)) THEN 1 ELSE 0 END AS CoincidenciaTalla,
		CASE WHEN ((@pesoDesde IS NOT NULL AND @pesoHasta Is Not NUll AND [Peso] >= @pesoDesde AND [Peso] <= @pesoHasta) OR (@pesoHasta IS NULL AND [Peso] >= @pesoDesde) OR (@pesoDesde IS NULL AND [Peso] <= @pesoHasta )) THEN 1 ELSE 0 END AS CoincidenciaPeso,
		CASE WHEN (@sexo IS NOT NULL AND @sexo != '' AND ([idSexo] = @sexo)) THEN 1 ELSE 0 END AS CoincidenciaSexo,
		CASE WHEN (@colorPiel IS NOT NULL AND @colorPiel != '' AND ([idColorPiel] IN (SELECT ID FROM fnSplitter(@colorPiel)))) THEN 1 ELSE 0 END AS CoincidenciaColorPiel,
		CASE WHEN (@colorCabello IS NOT NULL AND @colorCabello != '' AND ([idColorCabello] IN (SELECT ID FROM fnSplitter(@colorCabello)))) THEN 1 ELSE 0 END AS CoincidenciaColorCabello,
		CASE WHEN (@colorTenido IS NOT NULL AND @colorTenido != '' AND ([idColorTenido] IN (SELECT ID FROM fnSplitter(@colorTenido)))) THEN 1 ELSE 0 END AS CoincidenciaColorTenido,
		CASE WHEN (@longitudCabello IS NOT NULL AND @longitudCabello != '' AND ([idLongitudCabello] IN (SELECT ID FROM fnSplitter(@longitudCabello)))) THEN 1 ELSE 0 END AS CoincidenciaLongCabello,
		CASE WHEN (@aspectoCabello IS NOT NULL AND @aspectoCabello != '' AND ([idAspectoCabello] IN (SELECT ID FROM fnSplitter(@aspectoCabello)))) THEN 1 ELSE 0 END AS CoincidenciaAspectoCabello,
		CASE WHEN (@calvicie IS NOT NULL AND @calvicie != '' AND ([idCalvicie] IN (SELECT ID FROM fnSplitter(@calvicie)))) THEN 1 ELSE 0 END AS CoincidenciaCalvicie,
		CASE WHEN (@colorOjos IS NOT NULL AND @colorOjos != '' AND ([idColorOjos] IN (SELECT ID FROM fnSplitter(@colorOjos))))  THEN 1 ELSE 0 END AS CoincidenciaColorOjos,
		CASE WHEN (@faltanPiezasDentales IS NOT NULL AND @faltanPiezasDentales != '' AND ([FaltanPiezasDentales] = @faltanPiezasDentales)) THEN 1 ELSE 0 END AS CoincidenciaFaltanDientes,
		CASE WHEN (@seniaparticular IS NOT NULL OR @ubicacionseniaparticular IS NOT NULL) AND (select count(*) from seniasparticulares s where s.idpersona=XFECHA.id and idtabladestino=2 and (idseniaparticular IN (SELECT ID FROM fnSplitter(@seniaParticular)) and idubicacionseniaparticular IN (SELECT ID FROM fnSplitter(@ubicacionseniaParticular))))>0 THEN 1 ELSE 0 END AS CoincidenciaSeniasParticulares,
		CASE WHEN (@tatuaje IS NOT NULL OR @ubicaciontatuaje IS NOT NULL) and (select count(*) from tatuajesPersona t where t.idpersona=XFECHA.id and idtabladestino=2 and (idtatuaje IN (SELECT ID FROM fnSplitter(@tatuaje)) and idubicaciontatuaje IN (SELECT ID FROM fnSplitter(@ubicaciontatuaje))))>0 THEN 1 ELSE 0 END AS CoincidenciaTatuajes,
		CASE WHEN (@ADN IS NOT  NULL AND @ADN='' AND ([ADN] = @ADN)) THEN 1 ELSE 0 END AS CoincidenciaADN,
    (    CASE WHEN ([Apellido] like N'%' + @Apellido + '%') OR ([Nombre] like N'%' + @Nombre + '%') THEN 1 ELSE 0 END
        +CASE WHEN ((@edadDesde IS NOT NULL AND @edadHasta IS NOT NULL AND [EdadAparente] >= @edadDesde AND [EdadAparente] <= @edadHasta ) OR (@edadHasta IS NULL AND [EdadAparente] >= @edadDesde) OR (@edadDesde IS NULL AND [EdadAparente] <= @edadHasta )) THEN 1 ELSE 0 END
		+CASE WHEN (@fechaDesde IS NOT NULL AND @fechaHasta is not null and ([FechaHallazgo] >= @fechaDesde) AND ([FechaHallazgo] <= @fechaHasta)) OR (@fechaDesde IS NULL and [FechaHallazgo] <= @fechaHasta) OR (@fechaHasta IS NULL and [FechaHallazgo] >= @fechaDesde)  THEN 1 ELSE 0 END 
		+ CASE WHEN ((@tallaDesde IS NOT NULL AND @tallaHasta IS NOT NULL AND [Talla] >= @tallaDesde AND [Talla] <= @tallaHasta)OR (@tallaHasta IS NULL AND [Talla] >= @tallaDesde ) OR (@tallaDesde IS NULL and [Talla] <= @tallaHasta)) THEN 1 ELSE 0 END 
		+ CASE WHEN ((@pesoDesde IS NOT NULL AND @pesoHasta Is Not NUll AND [Peso] >= @pesoDesde AND [Peso] <= @pesoHasta) OR (@pesoHasta IS NULL AND [Peso] >= @pesoDesde) OR (@pesoDesde IS NULL AND [Peso] <= @pesoHasta )) THEN 1 ELSE 0 END 
		+ CASE WHEN (@sexo IS NOT NULL AND @sexo != '' AND ([idSexo] = @sexo)) THEN 1 ELSE 0 END 
		+ CASE WHEN (@colorPiel IS NOT NULL AND @colorPiel != '' AND ([idColorPiel] IN (SELECT ID FROM fnSplitter(@colorPiel)))) THEN 1 ELSE 0 END 
		+ CASE WHEN (@colorCabello IS NOT NULL AND @colorCabello != '' AND ([idColorCabello] IN (SELECT ID FROM fnSplitter(@colorCabello)))) THEN 1 ELSE 0 END 
		+ CASE WHEN (@colorTenido IS NOT NULL AND @colorTenido != '' AND ([idColorTenido] IN (SELECT ID FROM fnSplitter(@colorTenido)))) THEN 1 ELSE 0 END 
		+ CASE WHEN (@longitudCabello IS NOT NULL AND @longitudCabello != '' AND ([idLongitudCabello] IN (SELECT ID FROM fnSplitter(@longitudCabello)))) THEN 1 ELSE 0 END 
		+ CASE WHEN (@aspectoCabello IS NOT NULL AND @aspectoCabello != '' AND ([idAspectoCabello] IN (SELECT ID FROM fnSplitter(@aspectoCabello)))) THEN 1 ELSE 0 END 
		+ CASE WHEN (@calvicie IS NOT NULL AND @calvicie != '' AND ([idCalvicie] IN (SELECT ID FROM fnSplitter(@calvicie)))) THEN 1 ELSE 0 END 
		+ CASE WHEN (@colorOjos IS NOT NULL AND @colorOjos != '' AND ([idColorOjos] IN (SELECT ID FROM fnSplitter(@colorOjos))))  THEN 1 ELSE 0 END 
		+ CASE WHEN (@faltanPiezasDentales IS NOT NULL AND @faltanPiezasDentales != '' AND ([FaltanPiezasDentales] = @faltanPiezasDentales))  THEN 1 ELSE 0 END 
        + CASE WHEN (@seniaparticular IS NOT NULL OR @ubicacionseniaparticular IS NOT NULL) and (select count(*) from seniasparticulares s where s.idpersona=XFECHA.id and idtabladestino=2 and (idseniaparticular IN (SELECT ID FROM fnSplitter(@seniaParticular)) and idubicacionseniaparticular IN (SELECT ID FROM fnSplitter(@ubicacionseniaParticular))))>0 THEN 1 ELSE 0 END
		+ CASE WHEN (@tatuaje IS NOT NULL OR @ubicaciontatuaje IS NOT NULL) and (select count(*) from tatuajesPersona t where t.idpersona=XFECHA.id and idtabladestino=2 and (idtatuaje IN (SELECT ID FROM fnSplitter(@tatuaje)) and idubicaciontatuaje IN (SELECT ID FROM fnSplitter(@ubicaciontatuaje))))>0 THEN 1 ELSE 0 END
		+ (CASE WHEN (@ADN IS NOT  NULL AND @ADN='' AND ([ADN] = @ADN)) THEN 1 ELSE 0 END)) AS CantidadCoincidencias
  
FROM (
		SELECT * FROM PersonasHalladas
			  WHERE ( Baja= 'False' and @fechaUltimaModificacion IS NULL OR @fechaUltimaModificacion='' OR FechaUltimaModificacion IS NULL OR FechaUltimaModificacion>@fechaUltimaModificacion)
			  )XFECHA
)Q
		where (@cantidadCoincidencias IS NULL OR CantidadCoincidencias >= @cantidadCoincidencias) 
             AND (@sexo IS NULL or @sexo =1 or @sexo = [idSexo] or [idSexo] = 1 )
                    AND (@usuario IS NULL OR UsuarioAlta=@usuario)
            -- AND (@fechaUltimaModificacion IS NULL OR @fechaUltimaModificacion='' OR FechaUltimaModificacion>@fechaUltimaModificacion)
        order by CantidadCoincidencias DESC
		
    

	SET @Err = @@Error

	RETURN @Err

END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByCriteriosBusqueda]'
GO
ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByCriteriosBusqueda]
@Apellido char(50) = null, @Nombre char(50) = null, @fechaDesde datetime = null, @fechaHasta datetime = null, @edadDesde int = null, @edadHasta int = null, @tallaDesde real = null, @tallaHasta real = null, @pesoDesde real = null, @pesoHasta real = null, @sexo int = null, @rostro varchar(50) = null, @colorPiel varchar(50) = null, @colorCabello varchar(50) = null, @colorTenido varchar(50) = null, @longitudCabello varchar(50) = null, @aspectoCabello varchar(50) = null, @calvicie varchar(50) = null, @colorOjos varchar(50) = null, @faltanPiezasDentales bit = null, @seniaParticular varchar(50) = null, @ubicacionSeniaParticular varchar(50) = null, @ADN char(80) = null, @cantidadCoincidencias int = null, @fechaUltimaModificacion varchar(50) = null, @usuarioUltimaModificacion varchar(50) = null, @fechaAlta datetime = null, @usuarioAlta varchar(50) = null
WITH EXEC AS CALLER
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int
	SELECT
		[id],
		[DNI],
		[tieneADN],
		[Ipp],
		[UFI],
		[idOrganismoInterviniente],
		[idComisaria],
		[idGrupoSanguineo],
		[idBusqueda],
        [Apellido],
        [Nombre],
		[idLugarHallazgo],
		[FechaHallazgo],
		[idSexo],
		[EdadAparente],
		[EdadCientifica],
		[Talla],
		[Peso],
		[idColorPiel],
		[idColorCabello],
		[idColorTenido],
		[idLongitudCabello],
		[idAspectoCabello],
		[idCalvicie],
		[idColorOjos],
		[idRostro],
		[CantidadDiasNoAfeitado],
		[FaltanPiezasDentales],
		[idDentadura],
		/*[idSeniaParticular],
		[idUbicacionSeniaParticular],*/
		[ADN],
		[Foto],
		[FichasDactilares],
		[Ropa],
		[ArticulosPersonales],
		[ExistenRadiografia],
		[Vive],
		[FechaUltimaModificacion],
		[UsuarioUltimaModificacion],
		[Baja],
    [esExtJurisdiccion],
    [FechaAlta],
    [UsuarioAlta],
    [RestosOseos]
  
	FROM [PersonasHalladas]H
	WHERE
		(
		 (@Apellido IS NULL OR @Apellido='' OR [Apellido] like N'%' + @Apellido + '%')
        AND (@Nombre IS NULL OR @Nombre='' OR [Nombre] like N'%' + @Nombre + '%')
		AND ((@fechaDesde IS NULL OR @fechaDesde='') AND (@fechaHasta IS NULL OR @fechaHasta='') OR ([EdadAparente] >= @edadDesde and [EdadAparente] <= @edadHasta) AND([FechaHallazgo] >= @fechaDesde and [FechaHallazgo] <= @fechaHasta))
		AND ((@tallaDesde IS NULL OR @tallaDesde='') AND (@tallaHasta IS NULL OR @tallaHasta='') OR ([Talla] >= @tallaDesde and [Talla] <= @tallaHasta))
		AND (((@pesoDesde IS NULL OR @pesoDesde='') AND (@pesoHasta IS NULL OR @pesoHasta='')) OR ([Peso] >= @pesoDesde and [Peso] <= @pesoHasta))
		AND (@Sexo IS NULL OR @sexo='' OR [idSexo] = @sexo)
		AND (@colorPiel IS NULL OR @colorPiel='' OR [idColorPiel] IN (SELECT ID FROM fnSplitter(@colorPiel)))
		AND (@colorCabello IS NULL OR @colorCabello='' OR [idColorCabello] IN (SELECT ID FROM fnSplitter(@colorCabello)))
		AND (@colorTenido IS NULL OR @colorTenido='' OR [idColorTenido] IN (SELECT ID FROM fnSplitter(@colorTenido)))
		AND (@longitudCabello IS NULL OR @longitudCabello='' OR [idLongitudCabello] IN (SELECT ID FROM fnSplitter(@longitudCabello))) 
		AND (@aspectoCabello IS NULL OR @aspectoCabello='' OR [idAspectoCabello] IN (SELECT ID FROM fnSplitter(@aspectoCabello)))
		AND (@calvicie IS NULL OR @calvicie='' OR [idCalvicie] IN (SELECT ID FROM fnSplitter(@calvicie))) 
		AND (@rostro IS NULL OR @rostro='' OR [idRostro] IN (SELECT ID FROM fnSplitter(@rostro))) 
		AND (@colorOjos IS NULL OR @colorOjos='' OR [idColorOjos] IN (SELECT ID FROM fnSplitter(@colorOjos))) 
		AND (@faltanPiezasDentales IS NULL OR @faltanPiezasDentales='' OR [FaltanPiezasDentales] = @faltanPiezasDentales) 
		AND ((@seniaparticular IS NULL AND @ubicacionseniaparticular IS NULL) OR (select count(*) from seniasparticulares s where s.idpersona=H.id and idtabladestino=2 and (idseniaparticular=@seniaParticular and idubicacionseniaparticular=@ubicacionSeniaParticular))>0)
		AND (@ADN IS NULL OR @ADN='' OR [tieneADN] = @ADN)
		--AND (@fechaUltimaModificacion is null or @fechaUltimaModificacion='' or FechaUltimaModificacion=CONVERT(datetime,@FechaUltimaModificacion,111))
		AND (@fechaUltimaModificacion is null or @fechaUltimaModificacion='' or convert(datetime,FechaUltimaModificacion,112)=@FechaUltimaModificacion)
		AND (@usuarioUltimaModificacion IS NULL OR @usuarioUltimaModificacion='' OR [UsuarioUltimaModificacion] = @usuarioUltimaModificacion)
    AND (@fechaAlta is null or @fechaAlta='' or convert(datetime,FechaAlta,112)=@FechaAlta)
		AND (@usuarioAlta IS NULL OR @usuarioAlta='' OR [UsuarioAlta] = @usuarioAlta)
		)
		
		

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding constraints to [dbo].[Delitos]'
GO
ALTER TABLE [dbo].[Delitos] ADD CONSTRAINT [DF__Delitos__idClase__31E24B85] DEFAULT ((1)) FOR [idClaseDelito]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[Autores]'
GO
ALTER TABLE [dbo].[Autores] WITH NOCHECK  ADD CONSTRAINT [FK_Autores_Delitos] FOREIGN KEY ([idDelito]) REFERENCES [dbo].[Delitos] ([id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[Delitos]'
GO
ALTER TABLE [dbo].[Delitos] WITH NOCHECK  ADD CONSTRAINT [FK_Delitos_NNClaseTipoDelito] FOREIGN KEY ([idClaseDelito]) REFERENCES [dbo].[NNClaseTipoDelito] ([id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[BusquedaTatuajes]'
GO
ALTER TABLE [dbo].[BusquedaTatuajes] ADD CONSTRAINT [FK_BusquedaTatuajes_Busqueda] FOREIGN KEY ([idBusqueda]) REFERENCES [dbo].[Busqueda] ([Id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[SeniasParticulares]'
GO
ALTER TABLE [dbo].[SeniasParticulares] ADD CONSTRAINT [FK_SeniasParticulares_ClaseTipoPersona] FOREIGN KEY ([idTablaDestino]) REFERENCES [dbo].[ClaseTipoPersona] ([id])
ALTER TABLE [dbo].[SeniasParticulares] ADD CONSTRAINT [FK_SeniasParticulares_ClaseUbicacionSeniaPart] FOREIGN KEY ([idUbicacionSeniaParticular]) REFERENCES [dbo].[ClaseUbicacionSeniaPart] ([id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[TatuajesPersona]'
GO
ALTER TABLE [dbo].[TatuajesPersona] ADD CONSTRAINT [FK_TatuajesPersona_ClaseTipoPersona] FOREIGN KEY ([idTablaDestino]) REFERENCES [dbo].[ClaseTipoPersona] ([id])
ALTER TABLE [dbo].[TatuajesPersona] ADD CONSTRAINT [FK_TatuajesPersona_ClaseUbicacionSeniaPart] FOREIGN KEY ([idUbicacionTatuaje]) REFERENCES [dbo].[ClaseUbicacionSeniaPart] ([id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT 'The database update succeeded'
COMMIT TRANSACTION
END
ELSE PRINT 'The database update failed'
GO
DROP TABLE #tmpErrors
GO
