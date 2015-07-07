/*
Run this script on:

        GardelTest.SIAC    -  This database will be modified

to synchronize it with:

        GardelDesa.SIAC

You are recommended to back up your database before running this script

Script created by SQL Compare version 8.1.0 from Red Gate Software Ltd at 19/06/2012 01:13:20 p.m.

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
PRINT N'Dropping foreign keys from [dbo].[PersonalPoderJudicial]'
GO
ALTER TABLE [dbo].[PersonalPoderJudicial] DROP
CONSTRAINT [FK_PersonalPoderJudicial_Persona]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping foreign keys from [dbo].[Persona]'
GO
ALTER TABLE [dbo].[Persona] DROP
CONSTRAINT [FK_Persona_TipoDocumento],
CONSTRAINT [FK_Persona_Provincia],
CONSTRAINT [FK_Persona_Creador],
CONSTRAINT [FK_Persona_ClaseEstadoCivil],
CONSTRAINT [FK_Persona_Nacionalidad],
CONSTRAINT [FK_Persona_EstadoCivilMaterno],
CONSTRAINT [FK_Persona_EstadoCivilPaterno]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping foreign keys from [dbo].[PersonasDesaparecidas]'
GO
ALTER TABLE [dbo].[PersonasDesaparecidas] DROP
CONSTRAINT [FK_PersonasDesaparecidas_Busqueda]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping foreign keys from [dbo].[PersonasHalladas]'
GO
ALTER TABLE [dbo].[PersonasHalladas] DROP
CONSTRAINT [FK_PersonasHalladas_Comisaria],
CONSTRAINT [FK_PersonasHalladas_PBClaseAspectoCabello],
CONSTRAINT [FK_PersonasHalladas_PBClaseBoolean],
CONSTRAINT [FK_PersonasHalladas_PBClaseBoolean1],
CONSTRAINT [FK_PersonasHalladas_PBClaseBoolean2],
CONSTRAINT [FK_PersonasHalladas_PBClaseCalvicie],
CONSTRAINT [FK_PersonasHalladas_PBClaseColor],
CONSTRAINT [FK_PersonasHalladas_PBClaseColorCabello],
CONSTRAINT [FK_PersonasHalladas_PBClaseColorDePiel],
CONSTRAINT [FK_PersonasHalladas_PBClaseColorOjos],
CONSTRAINT [FK_PersonasHalladas_PBClaseLongitudCabello],
CONSTRAINT [FK_PersonasHalladas_PBClaseOrganismoInterviniente],
CONSTRAINT [FK_PersonasHalladas_PBClaseRostro],
CONSTRAINT [FK_PersonasHalladas_PBClaseSexo],
CONSTRAINT [FK_PersonasHalladas_PBGrupoSanguineo],
CONSTRAINT [FK_PersonasHalladas_Busqueda]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[Persona]'
GO
ALTER TABLE [dbo].[Persona] DROP CONSTRAINT [PK_Personas]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[Persona]'
GO
ALTER TABLE [dbo].[Persona] DROP CONSTRAINT [DF__Persona__Edad__76A57D77]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[Persona]'
GO
ALTER TABLE [dbo].[Persona] DROP CONSTRAINT [DF__Persona__IdEst__3522DA76]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[Persona]'
GO
ALTER TABLE [dbo].[Persona] DROP CONSTRAINT [DF__Persona__IdEst__121DCA11]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonalPoderJudicial]'
GO
ALTER TABLE [dbo].[PersonalPoderJudicial] ALTER COLUMN [idPersona] [int] NOT NULL
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonalPoderJudicialInsertUpdateSingleItem]'
GO
ALTER PROCEDURE [dbo].[PersonalPoderJudicialInsertUpdateSingleItem]
(
	@id varchar(14),
	@idPersona int,
	@idJerarquia int,
	@idPuntoGestion varchar(14),
	@fechaDesde datetime = NULL,
	@fechaHasta datetime = NULL,
	@activo bit = NULL,
	@Instruye bit = NULL
)
AS
IF (( (select @id from [PersonalPoderJudicial] where [PersonalPoderJudicial].id = @id) IS  NULL)) -- New Item
BEGIN

	INSERT
	INTO [PersonalPoderJudicial]
	(
		[id],
		[idPersona],
		[idJerarquia],
		[idPuntoGestion],
		[fechaDesde],
		[fechaHasta],
		[activo],
		[Instruye]
	)
		VALUES
		(
		@id,
		@idPersona,
		@idJerarquia,
		@idPuntoGestion,
		@fechaDesde,
		@fechaHasta,
		@activo,
		@Instruye
	)
	
	

	END
	ELSE
	BEGIN

	UPDATE [PersonalPoderJudicial]
	SET
		[idPersona] = @idPersona,
		[idJerarquia] = @idJerarquia,
		[idPuntoGestion] = @idPuntoGestion,
		[fechaDesde] = @fechaDesde,
		[fechaHasta] = @fechaHasta,
		[activo] = @activo,
		[Instruye] = @Instruye
	WHERE
		[id] = @id


END
  IF (@@ERROR != 0)
  BEGIN
    RETURN -1
  END
  ELSE
  BEGIN
    RETURN 0
  END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasDesaparecidasSelectListByidBusqueda]'
GO

ALTER PROCEDURE [dbo].[PersonasDesaparecidasSelectListByidBusqueda]
	@idBusqueda numeric(18,0)

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Ipp],
		[Id],
		[UFI],
		[idOrganismoInterviniente],
		[idComisaria],
		[DNI],
		[Apellido],
		[Nombre],
		[idLugarDesaparicion],
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
		[Baja]
	FROM [PersonasDesaparecidas]
	
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
PRINT N'Altering [dbo].[PersonasDesaparecidasSelectListByIPP]'
GO

ALTER PROCEDURE [dbo].[PersonasDesaparecidasSelectListByIPP]
	@IPP varchar(50)

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[Id],
		[Ipp],
		[UFI],
		[idOrganismoInterviniente],
		[idComisaria],
		[DNI],
		[Apellido],
		[Nombre],
		[idLugarDesaparicion],
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
		[Baja]
	FROM [PersonasDesaparecidas]
	
	WHERE 		([IPP] LIKE ('%'+@IPP+'%'))
	ORDER BY [Ipp]
	
	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[Autores]'
GO
ALTER TABLE [dbo].[Autores] ADD
[idImputadoSimp] [nchar] (14) COLLATE Modern_Spanish_CI_AS NULL,
[idPersona] [int] NULL
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectListByIPP]'
GO

ALTER PROCEDURE [dbo].[PersonasHalladasSelectListByIPP]
	@IPP varchar(50)

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
		[Baja]
	FROM [PersonasHalladas]
	
	WHERE 		([IPP] LIKE ('%'+@IPP+'%'))
	ORDER BY [Ipp]
	
	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienSustraidoArma]'
GO
CREATE TABLE [dbo].[BienSustraidoArma]
(
[id] [int] NOT NULL IDENTITY(1, 1),
[idNNBienSustraido] [int] NOT NULL,
[Marca] [nchar] (10) COLLATE Modern_Spanish_CI_AI NULL,
[clase_tipo] [int] NULL,
[NroSerie] [nchar] (50) COLLATE Modern_Spanish_CI_AI NULL,
[diametro_calibre] [int] NULL,
[Baja] [bit] NULL,
[idUsuarioUltimaModificacion] [nchar] (30) COLLATE Modern_Spanish_CI_AI NULL,
[FechaUltimaModificacion] [datetime] NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_BienSustraidoArma] on [dbo].[BienSustraidoArma]'
GO
ALTER TABLE [dbo].[BienSustraidoArma] ADD CONSTRAINT [PK_BienSustraidoArma] PRIMARY KEY CLUSTERED  ([id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienSustraidoArmaSelectSingleItem]'
GO
CREATE PROCEDURE [BienSustraidoArmaSelectSingleItem]
(
	@id int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idNNBienSustraido],
		[Marca],
		[clase_tipo],
		[NroSerie],
		[diametro_calibre],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [BienSustraidoArma]
	WHERE
		([id] = @id)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienSustraidoArmaSelectList]'
GO
CREATE PROCEDURE [BienSustraidoArmaSelectList]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idNNBienSustraido],
		[Marca],
		[clase_tipo],
		[NroSerie],
		[diametro_calibre],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [BienSustraidoArma]

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienSustraidoArmaInsertUpdateSingleItem]'
GO
CREATE PROCEDURE [BienSustraidoArmaInsertUpdateSingleItem]
(
	@id int,
	@idNNBienSustraido int,
	@Marca nchar(10) = NULL,
	@clase_tipo int = NULL,
	@NroSerie nchar(50) = NULL,
	@diametro_calibre int = NULL,
	@Baja bit = NULL,
	@idUsuarioUltimaModificacion nchar(30) = NULL,
	@FechaUltimaModificacion datetime = NULL
)
AS
DECLARE @ReturnValue int
IF (@id IS NULL) -- New Item
BEGIN

	INSERT
	INTO [BienSustraidoArma]
	(
			[idNNBienSustraido],
		[Marca],
		[clase_tipo],
		[NroSerie],
		[diametro_calibre],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	)
		VALUES
		(
			@idNNBienSustraido,
		@Marca,
		@clase_tipo,
		@NroSerie,
		@diametro_calibre,
		@Baja,
		@idUsuarioUltimaModificacion,
		@FechaUltimaModificacion
	)
	
	SELECT @ReturnValue = SCOPE_IDENTITY()

	END
	ELSE
	BEGIN

	UPDATE [BienSustraidoArma]
	SET
		[idNNBienSustraido] = @idNNBienSustraido,
		[Marca] = @Marca,
		[clase_tipo] = @clase_tipo,
		[NroSerie] = @NroSerie,
		[diametro_calibre] = @diametro_calibre,
		[Baja] = @Baja,
		[idUsuarioUltimaModificacion] = @idUsuarioUltimaModificacion,
		[FechaUltimaModificacion] = @FechaUltimaModificacion
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
PRINT N'Creating [dbo].[BienSustraidoArmaDeleteSingleItem]'
GO
CREATE PROCEDURE [BienSustraidoArmaDeleteSingleItem]
(
	@id int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [BienSustraidoArma]
	WHERE
		[id] = @id
	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienSustraidoCheque]'
GO
CREATE TABLE [dbo].[BienSustraidoCheque]
(
[id] [int] NOT NULL IDENTITY(1, 1),
[idNNBienSustraido] [int] NOT NULL,
[Banco] [nchar] (50) COLLATE Modern_Spanish_CI_AI NULL,
[monto] [real] NULL,
[NroSerie] [nchar] (50) COLLATE Modern_Spanish_CI_AI NULL,
[idTipoMoneda] [int] NULL,
[descripcionMoneda] [nchar] (50) COLLATE Modern_Spanish_CI_AS NULL,
[Baja] [bit] NULL,
[idUsuarioUltimaModificacion] [nchar] (30) COLLATE Modern_Spanish_CI_AI NULL,
[FechaUltimaModificacion] [datetime] NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_BienSustraidoCheque] on [dbo].[BienSustraidoCheque]'
GO
ALTER TABLE [dbo].[BienSustraidoCheque] ADD CONSTRAINT [PK_BienSustraidoCheque] PRIMARY KEY CLUSTERED  ([id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienSustraidoChequeSelectSingleItem]'
GO
CREATE PROCEDURE [BienSustraidoChequeSelectSingleItem]
(
	@id int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idNNBienSustraido],
		[Banco],
		[monto],
		[NroSerie],
		[idTipoMoneda],
		[descripcionMoneda],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [BienSustraidoCheque]
	WHERE
		([id] = @id)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienSustraidoChequeSelectList]'
GO
CREATE PROCEDURE [BienSustraidoChequeSelectList]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idNNBienSustraido],
		[Banco],
		[monto],
		[NroSerie],
		[idTipoMoneda],
		[descripcionMoneda],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [BienSustraidoCheque]

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienSustraidoChequeInsertUpdateSingleItem]'
GO
CREATE PROCEDURE [BienSustraidoChequeInsertUpdateSingleItem]
(
	@id int,
	@idNNBienSustraido int,
	@Banco nchar(50) = NULL,
	@monto real = NULL,
	@NroSerie nchar(50) = NULL,
	@idTipoMoneda int = NULL,
	@descripcionMoneda nchar(50) = NULL,
	@Baja bit = NULL,
	@idUsuarioUltimaModificacion nchar(30) = NULL,
	@FechaUltimaModificacion datetime = NULL
)
AS
DECLARE @ReturnValue int
IF (@id IS NULL) -- New Item
BEGIN

	INSERT
	INTO [BienSustraidoCheque]
	(
			[idNNBienSustraido],
		[Banco],
		[monto],
		[NroSerie],
		[idTipoMoneda],
		[descripcionMoneda],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	)
		VALUES
		(
			@idNNBienSustraido,
		@Banco,
		@monto,
		@NroSerie,
		@idTipoMoneda,
		@descripcionMoneda,
		@Baja,
		@idUsuarioUltimaModificacion,
		@FechaUltimaModificacion
	)
	
	SELECT @ReturnValue = SCOPE_IDENTITY()

	END
	ELSE
	BEGIN

	UPDATE [BienSustraidoCheque]
	SET
		[idNNBienSustraido] = @idNNBienSustraido,
		[Banco] = @Banco,
		[monto] = @monto,
		[NroSerie] = @NroSerie,
		[idTipoMoneda] = @idTipoMoneda,
		[descripcionMoneda] = @descripcionMoneda,
		[Baja] = @Baja,
		[idUsuarioUltimaModificacion] = @idUsuarioUltimaModificacion,
		[FechaUltimaModificacion] = @FechaUltimaModificacion
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
PRINT N'Creating [dbo].[BienSustraidoChequeDeleteSingleItem]'
GO
CREATE PROCEDURE [BienSustraidoChequeDeleteSingleItem]
(
	@id int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [BienSustraidoCheque]
	WHERE
		[id] = @id
	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienSustraidoDinero]'
GO
CREATE TABLE [dbo].[BienSustraidoDinero]
(
[id] [int] NOT NULL IDENTITY(1, 1),
[idNNBienSustraido] [int] NOT NULL,
[monto] [real] NULL,
[idTipoMoneda] [int] NULL,
[descripcionMoneda] [nchar] (50) COLLATE Modern_Spanish_CI_AS NULL,
[Baja] [bit] NULL,
[idUsuarioUltimaModificacion] [nchar] (30) COLLATE Modern_Spanish_CI_AI NULL,
[FechaUltimaModificacion] [datetime] NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_BienSustraidoDinero] on [dbo].[BienSustraidoDinero]'
GO
ALTER TABLE [dbo].[BienSustraidoDinero] ADD CONSTRAINT [PK_BienSustraidoDinero] PRIMARY KEY CLUSTERED  ([id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienSustraidoDineroSelectSingleItem]'
GO
CREATE PROCEDURE [BienSustraidoDineroSelectSingleItem]
(
	@id int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idNNBienSustraido],
		[monto],
		[idTipoMoneda],
		[descripcionMoneda],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [BienSustraidoDinero]
	WHERE
		([id] = @id)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienSustraidoDineroSelectList]'
GO
CREATE PROCEDURE [BienSustraidoDineroSelectList]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idNNBienSustraido],
		[monto],
		[idTipoMoneda],
		[descripcionMoneda],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [BienSustraidoDinero]

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienSustraidoDineroInsertUpdateSingleItem]'
GO
CREATE PROCEDURE [BienSustraidoDineroInsertUpdateSingleItem]
(
	@id int,
	@idNNBienSustraido int,
	@monto real = NULL,
	@idTipoMoneda int = NULL,
	@descripcionMoneda nchar(50) = NULL,
	@Baja bit = NULL,
	@idUsuarioUltimaModificacion nchar(30) = NULL,
	@FechaUltimaModificacion datetime = NULL
)
AS
DECLARE @ReturnValue int
IF (@id IS NULL) -- New Item
BEGIN

	INSERT
	INTO [BienSustraidoDinero]
	(
			[idNNBienSustraido],
		[monto],
		[idTipoMoneda],
		[descripcionMoneda],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	)
		VALUES
		(
			@idNNBienSustraido,
		@monto,
		@idTipoMoneda,
		@descripcionMoneda,
		@Baja,
		@idUsuarioUltimaModificacion,
		@FechaUltimaModificacion
	)
	
	SELECT @ReturnValue = SCOPE_IDENTITY()

	END
	ELSE
	BEGIN

	UPDATE [BienSustraidoDinero]
	SET
		[idNNBienSustraido] = @idNNBienSustraido,
		[monto] = @monto,
		[idTipoMoneda] = @idTipoMoneda,
		[descripcionMoneda] = @descripcionMoneda,
		[Baja] = @Baja,
		[idUsuarioUltimaModificacion] = @idUsuarioUltimaModificacion,
		[FechaUltimaModificacion] = @FechaUltimaModificacion
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
PRINT N'Creating [dbo].[BienSustraidoDineroDeleteSingleItem]'
GO
CREATE PROCEDURE [BienSustraidoDineroDeleteSingleItem]
(
	@id int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [BienSustraidoDinero]
	WHERE
		[id] = @id
	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienSustraidoTelefono]'
GO
CREATE TABLE [dbo].[BienSustraidoTelefono]
(
[id] [int] NOT NULL IDENTITY(1, 1),
[idNNBienSustraido] [int] NOT NULL,
[Marca] [nchar] (10) COLLATE Modern_Spanish_CI_AI NULL,
[Nro] [nchar] (50) COLLATE Modern_Spanish_CI_AS NULL,
[NroSerie] [nchar] (50) COLLATE Modern_Spanish_CI_AI NULL,
[IMEI] [nchar] (50) COLLATE Modern_Spanish_CI_AS NULL,
[Baja] [bit] NULL,
[idUsuarioUltimaModificacion] [nchar] (30) COLLATE Modern_Spanish_CI_AI NULL,
[FechaUltimaModificacion] [datetime] NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_BienSustraidoTelefono] on [dbo].[BienSustraidoTelefono]'
GO
ALTER TABLE [dbo].[BienSustraidoTelefono] ADD CONSTRAINT [PK_BienSustraidoTelefono] PRIMARY KEY CLUSTERED  ([id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienSustraidoTelefonoSelectSingleItem]'
GO
CREATE PROCEDURE [BienSustraidoTelefonoSelectSingleItem]
(
	@id int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idNNBienSustraido],
		[Marca],
		[Nro],
		[NroSerie],
		[IMEI],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [BienSustraidoTelefono]
	WHERE
		([id] = @id)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienSustraidoTelefonoSelectList]'
GO
CREATE PROCEDURE [BienSustraidoTelefonoSelectList]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idNNBienSustraido],
		[Marca],
		[Nro],
		[NroSerie],
		[IMEI],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [BienSustraidoTelefono]

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienSustraidoTelefonoInsertUpdateSingleItem]'
GO
CREATE PROCEDURE [BienSustraidoTelefonoInsertUpdateSingleItem]
(
	@id int,
	@idNNBienSustraido int,
	@Marca nchar(10) = NULL,
	@Nro nchar(50) = NULL,
	@NroSerie nchar(50) = NULL,
	@IMEI nchar(50) = NULL,
	@Baja bit = NULL,
	@idUsuarioUltimaModificacion nchar(30) = NULL,
	@FechaUltimaModificacion datetime = NULL
)
AS
DECLARE @ReturnValue int
IF (@id IS NULL) -- New Item
BEGIN

	INSERT
	INTO [BienSustraidoTelefono]
	(
			[idNNBienSustraido],
		[Marca],
		[Nro],
		[NroSerie],
		[IMEI],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	)
		VALUES
		(
			@idNNBienSustraido,
		@Marca,
		@Nro,
		@NroSerie,
		@IMEI,
		@Baja,
		@idUsuarioUltimaModificacion,
		@FechaUltimaModificacion
	)
	
	SELECT @ReturnValue = SCOPE_IDENTITY()

	END
	ELSE
	BEGIN

	UPDATE [BienSustraidoTelefono]
	SET
		[idNNBienSustraido] = @idNNBienSustraido,
		[Marca] = @Marca,
		[Nro] = @Nro,
		[NroSerie] = @NroSerie,
		[IMEI] = @IMEI,
		[Baja] = @Baja,
		[idUsuarioUltimaModificacion] = @idUsuarioUltimaModificacion,
		[FechaUltimaModificacion] = @FechaUltimaModificacion
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
PRINT N'Creating [dbo].[BienSustraidoTelefonoDeleteSingleItem]'
GO
CREATE PROCEDURE [BienSustraidoTelefonoDeleteSingleItem]
(
	@id int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [BienSustraidoTelefono]
	WHERE
		[id] = @id
	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasDesaparecidasSelectCoincidencias]'
GO

ALTER PROCEDURE [dbo].[PersonasDesaparecidasSelectCoincidencias]
(
    @Apellido char(50)=NULL,
    @Nombre char(50)=NULL,
    @usuario varchar(50)=null,
	@fechaDesde datetime=NULL,
	@fechaHasta datetime=NULL,
	@edadDesde int=NULL,
	@edadHasta int=NULL,
	@tallaDesde real=NULL,
	@tallaHasta real=NULL,
	@pesoDesde real=NULL,
	@pesoHasta real=NULL,
	@sexo int=NULL,
	@colorPiel varchar(50)=NULL,
	@colorCabello varchar(50)=NULL,
	@colorTenido varchar(50)=NULL,
	@longitudCabello varchar(50)=NULL,
	@aspectoCabello varchar(50)=NULL,
	@calvicie varchar(50)=NULL,
	@colorOjos varchar(50)=NULL,
	@faltanPiezasDentales varchar(50)=NULL,
	@seniaParticular varchar(50)=NULL,
	@ubicacionSeniaParticular varchar(50)=NULL,
	@ADN char(80)=NULL,
	@cantidadCoincidencias int=NULL,
	@fechaUltimaModificacion datetime=null
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int
	SELECT *
	FROM (
	SELECT *, CoincidenciaADN+CoincidenciaAspectoCabello+CoincidenciaAspectoCabello+CoincidenciaCalvicie+CoincidenciaCalvicie+CoincidenciaColorCabello+CoincidenciaColorOjos+CoincidenciaColorPiel+CoincidenciaColorTenido+CoincidenciaEdad+CoincidenciaFaltanDientes+CoincidenciaFecha+CoincidenciaLongCabello+CoincidenciaNombreyApellido+CoincidenciaPeso+CoincidenciaSeniasParticulares+CoincidenciaSexo+CoincidenciaTalla AS CantidadCoincidencias FROM(
	SELECT
		[Id],
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
		DATEDIFF(yy, [FechaNacimiento], GETDATE()) - case when ((month([FechaNacimiento]) > month(GETDATE())) or (month([FechaNacimiento]) = month(GETDATE()) and day([FechaNacimiento]) > day (GETDATE()))) then 1 else 0 end AS EdadCalculadaConFechaNacimiento,
		[EdadMomentoDesaparicion] + (DATEDIFF(yy, [FechaDesaparicion], GETDATE())- case when ((month([FechaDesaparicion]) > month(GETDATE())) or (month([FechaDesaparicion]) = month(GETDATE()) and day([FechaDesaparicion]) > day (GETDATE()))) then 1 else 0 end) AS EdadCalculadaConFechaDesaparicion,

		CASE WHEN ([FechaNacimiento] IS NOT NULL) THEN
			CASE WHEN ((@edadDesde IS NOT NULL and @edadHasta IS NOT NULL and DATEDIFF(yy, [FechaNacimiento], GETDATE()) - case when ((month([FechaNacimiento]) > month(GETDATE())) or (month([FechaNacimiento]) = month(GETDATE()) and day([FechaNacimiento]) > day (GETDATE()))) then 1 else 0 end >= @edadDesde and DATEDIFF(yy, [FechaNacimiento], GETDATE()) - case when ((month([FechaNacimiento]) > month(GETDATE())) or (month([FechaNacimiento]) = month(GETDATE()) and day([FechaNacimiento]) > day (GETDATE()))) then 1 else 0 end <= @edadHasta) OR (@edadDesde IS NULL AND DATEDIFF(yy, [FechaNacimiento], GETDATE()) - case when ((month([FechaNacimiento]) > month(GETDATE())) or (month([FechaNacimiento]) = month(GETDATE()) and day([FechaNacimiento]) > day (GETDATE()))) then 1 else 0 end <= @edadHasta) OR (@edadHasta IS NULL AND DATEDIFF(yy, [FechaNacimiento], GETDATE()) - case when ((month([FechaNacimiento]) > month(GETDATE())) or (month([FechaNacimiento]) = month(GETDATE()) and day([FechaNacimiento]) > day (GETDATE()))) then 1 else 0 end >= @edadDesde)) THEN 1 ELSE 0 END
        ELSE
			(CASE WHEN ([EdadMomentoDesaparicion] IS NOT NULL ) AND ([FechaDesaparicion] IS NOT NULL ) THEN
				 CASE WHEN (@edadDesde IS NOT NULL and @edadHasta IS NOT NULL and [EdadMomentoDesaparicion] + (DATEDIFF(yy, [FechaDesaparicion], GETDATE())- case when ((month([FechaDesaparicion]) > month(GETDATE())) or (month([FechaDesaparicion]) = month(GETDATE()) and day([FechaDesaparicion]) > day (GETDATE()))) then 1 else 0 end) >= @edadDesde AND [EdadMomentoDesaparicion] + (DATEDIFF(yy, [FechaDesaparicion], GETDATE())- case when ((month([FechaDesaparicion]) > month(GETDATE())) or (month([FechaDesaparicion]) = month(GETDATE()) and day([FechaDesaparicion]) > day (GETDATE()))) then 1 else 0 end) <= @edadHasta)
							OR ( @edadDesde IS NULL and  [EdadMomentoDesaparicion] + (DATEDIFF(yy, [FechaDesaparicion], GETDATE())- case when ((month([FechaDesaparicion]) > month(GETDATE())) or (month([FechaDesaparicion]) = month(GETDATE()) and day([FechaDesaparicion]) > day (GETDATE()))) then 1 else 0 end) <= @edadHasta )
							OR ( @edadHasta IS NULL and [EdadMomentoDesaparicion] + (DATEDIFF(yy, [FechaDesaparicion], GETDATE())- case when ((month([FechaDesaparicion]) > month(GETDATE())) or (month([FechaDesaparicion]) = month(GETDATE()) and day([FechaDesaparicion]) > day (GETDATE()))) then 1 else 0 end) >= @edadDesde)THEN 1 ELSE 0 END
			ELSE 0 END)
		END AS CoincidenciaEdad,
        CASE WHEN (([Apellido] LIKE N'%' + @Apellido + '%') OR ([Nombre] LIKE N'%' + @Nombre + '%')) THEN 1 ELSE 0 END AS CoincidenciaNombreyApellido,
        CASE WHEN (@fechaDesde IS NOT NULL AND @fechaHasta is not null and [FechaDesaparicion] >= @fechaDesde AND [FechaDesaparicion] <= @fechaHasta) OR (@fechaDesde IS NULL and [FechaDesaparicion] <= @fechaHasta) OR (@fechaHasta IS NULL and [FechaDesaparicion] >= @fechaDesde) THEN 1 ELSE 0 END AS CoincidenciaFecha,
		CASE WHEN ((@tallaDesde IS NOT NULL AND @tallaHasta IS NOT NULL AND [Talla] >= @tallaDesde AND [Talla] <= @tallaHasta)OR (@tallaHasta IS NULL AND [Talla] >= @tallaDesde ) OR (@tallaDesde IS NULL and [Talla] <= @tallaHasta)) THEN 1 ELSE 0 END AS CoincidenciaTalla,
		CASE WHEN ((@pesoDesde IS NOT NULL AND @pesoHasta Is Not NUll AND [Peso] >= @pesoDesde AND [Peso] <= @pesoHasta) OR (@pesoHasta IS NULL AND [Peso] >= @pesoDesde) OR (@pesoDesde IS NULL AND [Peso] <= @pesoHasta )) THEN 1 ELSE 0 END AS CoincidenciaPeso,
		CASE WHEN (@sexo IS NOT NULL AND @sexo != '' AND ([idSexo] = @sexo)) THEN 1 ELSE 0 END AS CoincidenciaSexo,
		CASE WHEN (@colorPiel IS NOT NULL AND @colorPiel != '' AND ([idColorPiel] IN (SELECT ID FROM fnSplitter(@colorPiel)))) THEN 1 ELSE 0 END AS CoincidenciaColorPiel,
		CASE WHEN (@colorCabello IS NOT NULL AND @colorCabello != '' AND ([idColorCabello] IN (SELECT ID FROM fnSplitter(@colorCabello)))) THEN 1 ELSE 0 END AS CoincidenciaColorCabello,
		CASE WHEN (@colorTenido IS NOT NULL AND @colorTenido != '' AND ([idColorTenido] IN (SELECT ID FROM fnSplitter(@colorTenido)))) THEN 1 ELSE 0 END AS CoincidenciaColorTenido,
		CASE WHEN (@longitudCabello IS NOT NULL AND @longitudCabello != '' AND ([idLongitudCabello] IN (SELECT ID FROM fnSplitter(@longitudCabello)))) THEN 1 ELSE 0 END AS CoincidenciaLongCabello,
		CASE WHEN (@aspectoCabello IS NOT NULL AND @aspectoCabello != '' AND ([idAspectoCabello] IN (SELECT ID FROM fnSplitter(@aspectoCabello)))) THEN 1 ELSE 0 END AS CoincidenciaAspectoCabello,
		CASE WHEN (@calvicie IS NOT NULL AND @calvicie != '' AND ([idCalvicie] IN (SELECT ID FROM fnSplitter(@calvicie)))) THEN 1 ELSE 0 END AS CoincidenciaCalvicie,
		CASE WHEN (@colorOjos IS NOT NULL AND @colorOjos != '' AND ([idColorOjos] IN (SELECT ID FROM fnSplitter(@colorOjos)))) THEN 1 ELSE 0 END AS CoincidenciaColorOjos,
		CASE WHEN (@faltanPiezasDentales IS NOT NULL AND @faltanPiezasDentales != '' AND ([FaltanPiezasDentales] = @faltanPiezasDentales)) THEN 1 ELSE 0 END AS CoincidenciaFaltanDientes,
		CASE WHEN (@seniaparticular IS NOT NULL OR @ubicacionseniaparticular IS NOT NULL) AND (select count(*) from seniasparticulares s where s.idpersona=XFECHA.id and idtabladestino=1 and (idseniaparticular IN (SELECT ID FROM fnSplitter(@seniaParticular)) and idubicacionseniaparticular IN (SELECT ID FROM fnSplitter(@ubicacionSeniaParticular))))>0 THEN 1 ELSE 0 END AS CoincidenciaSeniasParticulares,
		CASE WHEN (@ADN IS NOT  NULL AND @ADN='' AND ([ADN] = @ADN)) THEN 1 ELSE 0 END AS CoincidenciaADN
	FROM (
		SELECT * FROM PersonasDesaparecidas
			  WHERE (@fechaUltimaModificacion IS NULL OR @fechaUltimaModificacion='' OR FechaUltimaModificacion IS NULL OR FechaUltimaModificacion>@fechaUltimaModificacion)
			  )XFECHA
		)Q
             WHERE (@sexo IS NULL or  @sexo = [idSexo] or [idSexo] = 1 or [idSexo] = 0)
             AND (@usuario IS NULL OR UsuarioUltimaModificacion=@usuario)
)XCANTCOINCIDENCIAS
		WHERE (@cantidadCoincidencias IS NULL OR CantidadCoincidencias >= @cantidadCoincidencias) 
       order by CantidadCoincidencias DESC
		

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
	@idBusqueda numeric(18,0)

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
		[Baja]
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
PRINT N'Creating [dbo].[NNClaseMoneda]'
GO
CREATE TABLE [dbo].[NNClaseMoneda]
(
[id] [int] NOT NULL,
[descripcion] [nchar] (50) COLLATE Modern_Spanish_CI_AI NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_NNClaseMoneda] on [dbo].[NNClaseMoneda]'
GO
ALTER TABLE [dbo].[NNClaseMoneda] ADD CONSTRAINT [PK_NNClaseMoneda] PRIMARY KEY CLUSTERED  ([id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[NNClaseMonedaSelectSingleItem]'
GO
CREATE PROCEDURE [NNClaseMonedaSelectSingleItem]
(
	@id int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[descripcion]
	FROM [NNClaseMoneda]
	WHERE
		([id] = @id)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[NNClaseMonedaSelectList]'
GO
CREATE PROCEDURE [NNClaseMonedaSelectList]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[descripcion]
	FROM [NNClaseMoneda]

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[NNClaseMonedaInsertUpdateSingleItem]'
GO
CREATE PROCEDURE [NNClaseMonedaInsertUpdateSingleItem]
(
	@id int,
	@descripcion nchar(50) = NULL
)
AS
DECLARE @ReturnValue int
IF (@id IS NULL) -- New Item
BEGIN

	INSERT
	INTO [NNClaseMoneda]
	(
			[id],
		[descripcion]
	)
		VALUES
		(
			@id,
		@descripcion
	)
	
	SELECT @ReturnValue = SCOPE_IDENTITY()

	END
	ELSE
	BEGIN

	UPDATE [NNClaseMoneda]
	SET
		[descripcion] = @descripcion
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
PRINT N'Creating [dbo].[NNClaseMonedaDeleteSingleItem]'
GO
CREATE PROCEDURE [NNClaseMonedaDeleteSingleItem]
(
	@id int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [NNClaseMoneda]
	WHERE
		[id] = @id
	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BusquedaRobosDelitosSexuales]'
GO
CREATE TABLE [dbo].[BusquedaRobosDelitosSexuales]
(
[id] [int] NOT NULL IDENTITY(1, 1),
[idClaseDelito] [int] NULL,
[Departamento] [int] NULL,
[idPuntoGestion] [varchar] (14) COLLATE Modern_Spanish_CI_AS NULL,
[FechaDesde] [date] NULL,
[FechaHasta] [date] NULL,
[idClaseLugar] [int] NULL,
[idClaseRubro] [int] NULL,
[idClaseModusOperandi] [int] NULL,
[idClaseModoArriboHuida] [int] NULL,
[idVictimasEnElLugar] [int] NULL,
[idUsoArmas] [int] NULL,
[idClaseArma] [int] NULL,
[idClaseSubtipoArma] [int] NULL,
[idHuboAgresionFisica] [int] NULL,
[idClaseCantidadAutores] [int] NULL,
[Baja] [bit] NULL,
[UsuarioUltimaModificacion] [nchar] (20) COLLATE Modern_Spanish_CI_AS NULL,
[FechaUltimaModificacion] [datetime] NULL,
[FechaCreacion] [datetime] NULL,
[DescripcionBusqueda] [varchar] (250) COLLATE Modern_Spanish_CI_AS NOT NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_BusquedaRobosDelitosSexuales] on [dbo].[BusquedaRobosDelitosSexuales]'
GO
ALTER TABLE [dbo].[BusquedaRobosDelitosSexuales] ADD CONSTRAINT [PK_BusquedaRobosDelitosSexuales] PRIMARY KEY CLUSTERED  ([id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BusquedaRobosDelitosSexualesSelectSingleItem]'
GO
CREATE PROCEDURE [BusquedaRobosDelitosSexualesSelectSingleItem]
(
	@id int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idClaseDelito],
		[Departamento],
		[idPuntoGestion],
		[FechaDesde],
		[FechaHasta],
		[idClaseLugar],
		[idClaseRubro],
		[idClaseModusOperandi],
		[idClaseModoArriboHuida],
		[idVictimasEnElLugar],
		[idUsoArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[idHuboAgresionFisica],
		[idClaseCantidadAutores],
		[Baja],
		[UsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[FechaCreacion]
	FROM [BusquedaRobosDelitosSexuales]
	WHERE
		([id] = @id)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienesSustraidosArmaSelectSingleItemByBienSustraido]'
GO
CREATE PROCEDURE [dbo].[BienesSustraidosArmaSelectSingleItemByBienSustraido]
(
	@idBienSustraido int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idNNBienSustraido],
		[Marca],
		[clase_tipo],
		[NroSerie],
		[diametro_calibre],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [BienSustraidoArma]
	
	WHERE
		([idNNBienSustraido] = @idBienSustraido) AND ([Baja] = 0)

	SET @Err = @@Error

	RETURN @Err
END

GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BusquedaRobosDelitosSexualesSelectList]'
GO
CREATE PROCEDURE [BusquedaRobosDelitosSexualesSelectList]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idClaseDelito],
		[Departamento],
		[idPuntoGestion],
		[FechaDesde],
		[FechaHasta],
		[idClaseLugar],
		[idClaseRubro],
		[idClaseModusOperandi],
		[idClaseModoArriboHuida],
		[idVictimasEnElLugar],
		[idUsoArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[idHuboAgresionFisica],
		[idClaseCantidadAutores],
		[Baja],
		[UsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[FechaCreacion]
	FROM [BusquedaRobosDelitosSexuales]

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienSustraidoChequeSelectSingleItemByBienSustraido]'
GO
CREATE PROCEDURE [dbo].[BienSustraidoChequeSelectSingleItemByBienSustraido]
(
	@idBienSustraido int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idNNBienSustraido],
		[Banco],
		[monto],
		[NroSerie],
		[idTipoMoneda],
		[descripcionMoneda],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [BienSustraidoCheque]
	WHERE
		([idNNBienSustraido] = @idBienSustraido)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BusquedaRobosDelitosSexualesInsertUpdateSingleItem]'
GO
CREATE PROCEDURE [dbo].[BusquedaRobosDelitosSexualesInsertUpdateSingleItem]
(
	@id int,
	@idClaseDelito int = NULL,
	@Departamento int = NULL,
	@idPuntoGestion varchar(14) = NULL,
	@FechaDesde date = NULL,
	@FechaHasta date = NULL,
	@idClaseLugar int = NULL,
	@idClaseRubro int = NULL,
	@idClaseModusOperandi int = NULL,
	@idClaseModoArriboHuida int = NULL,
	@idVictimasEnElLugar int = NULL,
	@idUsoArmas int = NULL,
	@idClaseArma int = NULL,
	@idClaseSubtipoArma int = NULL,
	@idHuboAgresionFisica int = NULL,
	@idClaseCantidadAutores int = NULL,
	@Baja bit = NULL,
	@UsuarioUltimaModificacion nchar(20) = NULL,
	@FechaUltimaModificacion datetime = NULL,
	@FechaCreacion datetime = NULL,
	@DescripcionBusqueda varchar(250)
)
AS
DECLARE @ReturnValue int
IF (@id IS NULL) -- New Item
BEGIN

	INSERT
	INTO [BusquedaRobosDelitosSexuales]
	(
			[idClaseDelito],
		[Departamento],
		[idPuntoGestion],
		[FechaDesde],
		[FechaHasta],
		[idClaseLugar],
		[idClaseRubro],
		[idClaseModusOperandi],
		[idClaseModoArriboHuida],
		[idVictimasEnElLugar],
		[idUsoArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[idHuboAgresionFisica],
		[idClaseCantidadAutores],
		[DescripcionBusqueda],
		[Baja],
		[UsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[FechaCreacion]
	)
		VALUES
		(
			@idClaseDelito,
		@Departamento,
		@idPuntoGestion,
		@FechaDesde,
		@FechaHasta,
		@idClaseLugar,
		@idClaseRubro,
		@idClaseModusOperandi,
		@idClaseModoArriboHuida,
		@idVictimasEnElLugar,
		@idUsoArmas,
		@idClaseArma,
		@idClaseSubtipoArma,
		@idHuboAgresionFisica,
		@idClaseCantidadAutores,
		@DescripcionBusqueda,
		@Baja,
		@UsuarioUltimaModificacion,
		@FechaUltimaModificacion,
		@FechaCreacion
	)
	
	SELECT @ReturnValue = SCOPE_IDENTITY()

	END
	ELSE
	BEGIN

	UPDATE [BusquedaRobosDelitosSexuales]
	SET
		[idClaseDelito] = @idClaseDelito,
		[Departamento] = @Departamento,
		[idPuntoGestion] = @idPuntoGestion,
		[FechaDesde] = @FechaDesde,
		[FechaHasta] = @FechaHasta,
		[idClaseLugar] = @idClaseLugar,
		[idClaseRubro] = @idClaseRubro,
		[idClaseModusOperandi] = @idClaseModusOperandi,
		[idClaseModoArriboHuida] = @idClaseModoArriboHuida,
		[idVictimasEnElLugar] = @idVictimasEnElLugar,
		[idUsoArmas] = @idUsoArmas,
		[idClaseArma] = @idClaseArma,
		[idClaseSubtipoArma] = @idClaseSubtipoArma,
		[idHuboAgresionFisica] = @idHuboAgresionFisica,
		[idClaseCantidadAutores] = @idClaseCantidadAutores,
		[DescripcionBusqueda] = @DescripcionBusqueda,
		[Baja] = @Baja,
		[UsuarioUltimaModificacion] = @UsuarioUltimaModificacion,
		[FechaUltimaModificacion] = @FechaUltimaModificacion,
		[FechaCreacion] = @FechaCreacion
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
PRINT N'Creating [dbo].[BienSustraidoDineroSelectSingleItemByBienSustraido]'
GO
CREATE PROCEDURE [dbo].[BienSustraidoDineroSelectSingleItemByBienSustraido]
(
	@idBienSustraido int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idNNBienSustraido],
		[monto],
		[idTipoMoneda],
		[descripcionMoneda],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [BienSustraidoDinero]
	WHERE
		([idNNBienSustraido] = @idBienSustraido)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BusquedaRobosDelitosSexualesDeleteSingleItem]'
GO
CREATE PROCEDURE [BusquedaRobosDelitosSexualesDeleteSingleItem]
(
	@id int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [BusquedaRobosDelitosSexuales]
	WHERE
		[id] = @id
	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienSustraidoTelefonoSelectSingleItemByBienSustraido]'
GO
CREATE PROCEDURE [dbo].[BienSustraidoTelefonoSelectSingleItemByBienSustraido]
(
	@idBienSustraido int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idNNBienSustraido],
		[Marca],
		[Nro],
		[NroSerie],
		[IMEI],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [BienSustraidoTelefono]
	WHERE
		([idNNBienSustraido] = @idBienSustraido)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BusquedaRobosDelitosSexualesComisarias]'
GO
CREATE TABLE [dbo].[BusquedaRobosDelitosSexualesComisarias]
(
[id] [numeric] (18, 0) NOT NULL IDENTITY(1, 1),
[idBusquedaRoboDS] [int] NULL,
[idComisaria] [int] NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_BusquedaRobosDelitosSexualesComisarias] on [dbo].[BusquedaRobosDelitosSexualesComisarias]'
GO
ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesComisarias] ADD CONSTRAINT [PK_BusquedaRobosDelitosSexualesComisarias] PRIMARY KEY CLUSTERED  ([id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BusquedaRobosDelitosSexualesComisariasSelectSingleItem]'
GO
CREATE PROCEDURE [BusquedaRobosDelitosSexualesComisariasSelectSingleItem]
(
	@id numeric(18,0)
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idBusquedaRoboDS],
		[idComisaria]
	FROM [BusquedaRobosDelitosSexualesComisarias]
	WHERE
		([id] = @id)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienSustraidoArmaSelectListByidNNBienSustraido]'
GO
CREATE PROCEDURE [dbo].[BienSustraidoArmaSelectListByidNNBienSustraido]
@idNNBienSustraido int
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idNNBienSustraido],
		[Marca],
		[clase_tipo],
		[NroSerie],
		[diametro_calibre],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [BienSustraidoArma]
	
	WHERE 		([idNNBienSustraido] = @idNNBienSustraido) AND ([Baja] = 0)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BusquedaRobosDelitosSexualesComisariasSelectList]'
GO
CREATE PROCEDURE [BusquedaRobosDelitosSexualesComisariasSelectList]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idBusquedaRoboDS],
		[idComisaria]
	FROM [BusquedaRobosDelitosSexualesComisarias]

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienSustraidoChequeSelectListByidNNBienSustraido]'
GO
CREATE PROCEDURE [dbo].[BienSustraidoChequeSelectListByidNNBienSustraido]
@idNNBienSustraido int
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idNNBienSustraido],
		[Banco],
		[monto],
		[NroSerie],
		[idTipoMoneda],
		[descripcionMoneda],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [BienSustraidoCheque]
	
	WHERE 		([idNNBienSustraido] = @idNNBienSustraido) AND ([Baja] = 0)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BusquedaRobosDelitosSexualesComisariasInsertUpdateSingleItem]'
GO
CREATE PROCEDURE [BusquedaRobosDelitosSexualesComisariasInsertUpdateSingleItem]
(
	@id numeric(18,0),
	@idBusquedaRoboDS int = NULL,
	@idComisaria int = NULL
)
AS
DECLARE @ReturnValue int
IF (@id IS NULL) -- New Item
BEGIN

	INSERT
	INTO [BusquedaRobosDelitosSexualesComisarias]
	(
			[idBusquedaRoboDS],
		[idComisaria]
	)
		VALUES
		(
			@idBusquedaRoboDS,
		@idComisaria
	)
	
	SELECT @ReturnValue = SCOPE_IDENTITY()

	END
	ELSE
	BEGIN

	UPDATE [BusquedaRobosDelitosSexualesComisarias]
	SET
		[idBusquedaRoboDS] = @idBusquedaRoboDS,
		[idComisaria] = @idComisaria
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
PRINT N'Creating [dbo].[BienSustraidoDineroSelectListByidNNBienSustraido]'
GO
CREATE PROCEDURE [dbo].[BienSustraidoDineroSelectListByidNNBienSustraido]
@idNNBienSustraido int
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idNNBienSustraido],
		[monto],
		[idTipoMoneda],
		[descripcionMoneda],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [BienSustraidoDinero]
	
	WHERE 		([idNNBienSustraido] = @idNNBienSustraido) AND ([Baja] = 0)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BusquedaRobosDelitosSexualesComisariasDeleteSingleItem]'
GO
CREATE PROCEDURE [BusquedaRobosDelitosSexualesComisariasDeleteSingleItem]
(
	@id numeric(18,0)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [BusquedaRobosDelitosSexualesComisarias]
	WHERE
		[id] = @id
	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BienSustraidoTelefonoSelectListByidNNBienSustraido]'
GO
CREATE PROCEDURE [dbo].[BienSustraidoTelefonoSelectListByidNNBienSustraido]
@idNNBienSustraido int
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idNNBienSustraido],
		[Marca],
		[Nro],
		[NroSerie],
		[IMEI],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [BienSustraidoTelefono]
	
	WHERE 		([idNNBienSustraido] = @idNNBienSustraido) AND ([Baja] = 0)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BusquedaRobosDelitosSexualesLocalidades]'
GO
CREATE TABLE [dbo].[BusquedaRobosDelitosSexualesLocalidades]
(
[id] [numeric] (18, 0) NOT NULL IDENTITY(1, 1),
[idBusquedaRoboDS] [int] NULL,
[idLocalidad] [int] NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_BusquedaRobosDelitosSexualesLocalidades] on [dbo].[BusquedaRobosDelitosSexualesLocalidades]'
GO
ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesLocalidades] ADD CONSTRAINT [PK_BusquedaRobosDelitosSexualesLocalidades] PRIMARY KEY CLUSTERED  ([id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BusquedaRobosDelitosSexualesLocalidadesSelectSingleItem]'
GO
CREATE PROCEDURE [BusquedaRobosDelitosSexualesLocalidadesSelectSingleItem]
(
	@id numeric(18,0)
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idBusquedaRoboDS],
		[idLocalidad]
	FROM [BusquedaRobosDelitosSexualesLocalidades]
	WHERE
		([id] = @id)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BusquedaRobosDelitosSexualesLocalidadesSelectList]'
GO
CREATE PROCEDURE [BusquedaRobosDelitosSexualesLocalidadesSelectList]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idBusquedaRoboDS],
		[idLocalidad]
	FROM [BusquedaRobosDelitosSexualesLocalidades]

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BusquedaRobosDelitosSexualesLocalidadesInsertUpdateSingleItem]'
GO
CREATE PROCEDURE [BusquedaRobosDelitosSexualesLocalidadesInsertUpdateSingleItem]
(
	@id numeric(18,0),
	@idBusquedaRoboDS int = NULL,
	@idLocalidad int = NULL
)
AS
DECLARE @ReturnValue int
IF (@id IS NULL) -- New Item
BEGIN

	INSERT
	INTO [BusquedaRobosDelitosSexualesLocalidades]
	(
			[idBusquedaRoboDS],
		[idLocalidad]
	)
		VALUES
		(
			@idBusquedaRoboDS,
		@idLocalidad
	)
	
	SELECT @ReturnValue = SCOPE_IDENTITY()

	END
	ELSE
	BEGIN

	UPDATE [BusquedaRobosDelitosSexualesLocalidades]
	SET
		[idBusquedaRoboDS] = @idBusquedaRoboDS,
		[idLocalidad] = @idLocalidad
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
PRINT N'Creating [dbo].[BusquedaRobosDelitosSexualesLocalidadesDeleteSingleItem]'
GO
CREATE PROCEDURE [BusquedaRobosDelitosSexualesLocalidadesDeleteSingleItem]
(
	@id numeric(18,0)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [BusquedaRobosDelitosSexualesLocalidades]
	WHERE
		[id] = @id
	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Refreshing [dbo].[vwAutores]'
GO
EXEC sp_refreshview N'[dbo].[vwAutores]'
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonasHalladasSelectCoincidencias]'
GO

ALTER PROCEDURE [dbo].[PersonasHalladasSelectCoincidencias]
(
	@Apellido char(50)=NULL,
    @Nombre char(50)=NULL,
    @usuario varchar(50)=NULL,
    @fechaDesde datetime=NULL,
	@fechaHasta datetime=NULL,
	@edadDesde int=NULL,
	@edadHasta int=NULL,
	@tallaDesde real=NULL,
	@tallaHasta real=NULL,
	@pesoDesde real=NULL,
	@pesoHasta real=NULL,
	@sexo int=NULL,
	@colorPiel varchar(50)=NULL,
	@colorCabello varchar(50)=NULL,
	@colorTenido varchar(50)=NULL,
	@longitudCabello varchar(50)=NULL,
	@aspectoCabello varchar(50)=NULL,
	@calvicie varchar(50)=NULL,
	@colorOjos varchar(50)=NULL,
	@faltanPiezasDentales varchar(50)=NULL,
	@seniaParticular varchar(50)=NULL,
	@ubicacionSeniaParticular varchar(50)=NULL,
	@ADN char(80)=NULL,
	@cantidadCoincidencias int=NULL,
	@fechaUltimaModificacion datetime=NULL
)
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
		[Baja],
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
		CASE WHEN (@ADN IS NOT  NULL AND @ADN='' AND ([ADN] = @ADN)) THEN 1 ELSE 0 END AS CoincidenciaADN,
        CASE WHEN ([Apellido] like N'%' + @Apellido + '%') OR ([Nombre] like N'%' + @Nombre + '%') THEN 1 ELSE 0 END
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
		+ CASE WHEN (@ADN IS NOT  NULL AND @ADN='' AND ([ADN] = @ADN)) THEN 1 ELSE 0 END AS CantidadCoincidencias
  
FROM (
		SELECT * FROM PersonasHalladas
			  WHERE (@fechaUltimaModificacion IS NULL OR @fechaUltimaModificacion='' OR FechaUltimaModificacion IS NULL OR FechaUltimaModificacion>@fechaUltimaModificacion)
			  )XFECHA
)Q
		where (@cantidadCoincidencias IS NULL OR CantidadCoincidencias >= @cantidadCoincidencias) 
             AND (@sexo IS NULL or  @sexo = [idSexo] or [idSexo] = 1 or [idSexo] = 0)
                    AND (@usuario IS NULL OR UsuarioUltimaModificacion=@usuario)
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
PRINT N'Altering [dbo].[AutoresSelectListByidCausa]'
GO
ALTER PROCEDURE [dbo].[AutoresSelectListByidCausa]
	@idCausa nchar(12)

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idDelito],
		[idCausa],
		[Nro],
		[idClaseEdadAproximada],
		[idClaseSexo],
		[idClaseRostro],
		[CubiertoCon],
		[idClaseSeniaParticular],
		[UbicacionSeniaParticular],
		[idClaseLugarDelCuerpo],
		[idClaseTatuaje],
		[OtroTatuaje],
		[OtraCaracteristica],
		[idImputadoSimp],
		[idPersona],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [Autores]
	
	WHERE 		([idCausa] = @idCausa) and ([Baja] = 0)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[AutoresSelectListByidPersona]'
GO
CREATE PROCEDURE [dbo].[AutoresSelectListByidPersona]
	@idPersona int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idDelito],
		[idCausa],
		[Nro],
		[idClaseEdadAproximada],
		[idClaseSexo],
		[idClaseRostro],
		[CubiertoCon],
		[idClaseSeniaParticular],
		[UbicacionSeniaParticular],
		[idClaseLugarDelCuerpo],
		[idClaseTatuaje],
		[OtroTatuaje],
		[OtraCaracteristica],
		[idImputadoSimp],
		[idPersona],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [Autores]
	
	WHERE 		([idPersona] = @idPersona)
                and ([Baja] = 0)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[AutoresSelectSingleItem]'
GO
ALTER PROCEDURE [dbo].[AutoresSelectSingleItem]
(
	@id int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idDelito],
		[idCausa],
		[Nro],
		[idClaseEdadAproximada],
		[idClaseSexo],
		[idClaseRostro],
		[CubiertoCon],
		[idClaseSeniaParticular],
		[UbicacionSeniaParticular],
		[idClaseLugarDelCuerpo],
		[idClaseTatuaje],
		[OtroTatuaje],
		[OtraCaracteristica],
		[idImputadoSimp],
		[idPersona],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [Autores]
	WHERE
		([id] = @id) and ([Baja] = 0)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[AutoresSelectList]'
GO
ALTER PROCEDURE [dbo].[AutoresSelectList]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idDelito],
		[idCausa],
		[Nro],
		[idClaseEdadAproximada],
		[idClaseSexo],
		[idClaseRostro],
		[CubiertoCon],
		[idClaseSeniaParticular],
		[UbicacionSeniaParticular],
		[idClaseLugarDelCuerpo],
		[idClaseTatuaje],
		[OtroTatuaje],
		[OtraCaracteristica],
		[idImputadoSimp],
		[idPersona],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [Autores]
    WHERE [Baja] = 0

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[AutoresSelectListByidDelito]'
GO
ALTER PROCEDURE [dbo].[AutoresSelectListByidDelito]
	@idDelito int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idDelito],
		[idCausa],
		[Nro],
		[idClaseEdadAproximada],
		[idClaseSexo],
		[idClaseRostro],
		[CubiertoCon],
		[idClaseSeniaParticular],
		[UbicacionSeniaParticular],
		[idClaseLugarDelCuerpo],
		[idClaseTatuaje],
		[OtroTatuaje],
		[OtraCaracteristica],
		[idImputadoSimp],
		[idPersona],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [Autores]
	
	WHERE 		([idDelito] = @idDelito)
                and ([Baja] = 0)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[AutoresSelectListByidClaseEdadAproximada]'
GO
ALTER PROCEDURE [dbo].[AutoresSelectListByidClaseEdadAproximada]
	@idClaseEdadAproximada int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idDelito],
		[idCausa],
		[Nro],
		[idClaseEdadAproximada],
		[idClaseSexo],
		[idClaseRostro],
		[CubiertoCon],
		[idClaseSeniaParticular],
		[UbicacionSeniaParticular],
		[idClaseLugarDelCuerpo],
		[idClaseTatuaje],
		[OtroTatuaje],
		[OtraCaracteristica],
		[idImputadoSimp],
		[idPersona],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [Autores]
	
	WHERE 		([idClaseEdadAproximada] = @idClaseEdadAproximada) and ([Baja] = 0)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[BusquedaRobosDelitosSexualesSelectListByidPuntoGestion]'
GO
CREATE PROCEDURE [dbo].[BusquedaRobosDelitosSexualesSelectListByidPuntoGestion]
@idPuntoGestion varchar(50)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int
			

	SELECT
		[id],
		[idClaseDelito],
		[Departamento],
		[idPuntoGestion],
		[FechaDesde],
		[FechaHasta],
		[idClaseLugar],
		[idClaseRubro],
		[idClaseModusOperandi],
		[idClaseModoArriboHuida],
		[idVictimasEnElLugar],
		[idUsoArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[idHuboAgresionFisica],
		[idClaseCantidadAutores],
		[DescripcionBusqueda],
		[Baja],
		[UsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[FechaCreacion]
	FROM [BusquedaRobosDelitosSexuales]
	WHERE [idPuntoGestion]=@idPuntoGestion
	
	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[AutoresSelectListByidClaseLugarDelCuerpo]'
GO
ALTER PROCEDURE [dbo].[AutoresSelectListByidClaseLugarDelCuerpo]
	@idClaseLugarDelCuerpo int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idDelito],
		[idCausa],
		[Nro],
		[idClaseEdadAproximada],
		[idClaseSexo],
		[idClaseRostro],
		[CubiertoCon],
		[idClaseSeniaParticular],
		[UbicacionSeniaParticular],
		[idClaseLugarDelCuerpo],
		[idClaseTatuaje],
		[OtroTatuaje],
		[OtraCaracteristica],
		[idImputadoSimp],
		[idPersona],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [Autores]
	
	WHERE 		([idClaseLugarDelCuerpo] = @idClaseLugarDelCuerpo) and ([Baja] = 0)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[AutoresSelectListByidClaseRostro]'
GO
ALTER PROCEDURE [dbo].[AutoresSelectListByidClaseRostro]
	@idClaseRostro int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idDelito],
		[idCausa],
		[Nro],
		[idClaseEdadAproximada],
		[idClaseSexo],
		[idClaseRostro],
		[CubiertoCon],
		[idClaseSeniaParticular],
		[UbicacionSeniaParticular],
		[idClaseLugarDelCuerpo],
		[idClaseTatuaje],
		[OtroTatuaje],
		[OtraCaracteristica],
		[idImputadoSimp],
		[idPersona],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [Autores]
	
	WHERE 		([idClaseRostro] = @idClaseRostro) and ([Baja] = 0)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[AutoresSelectListByidClaseSeniaParticular]'
GO
ALTER PROCEDURE [dbo].[AutoresSelectListByidClaseSeniaParticular]
	@idClaseSeniaParticular int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idDelito],
		[idCausa],
		[Nro],
		[idClaseEdadAproximada],
		[idClaseSexo],
		[idClaseRostro],
		[CubiertoCon],
		[idClaseSeniaParticular],
		[UbicacionSeniaParticular],
		[idClaseLugarDelCuerpo],
		[idClaseTatuaje],
		[OtroTatuaje],
		[OtraCaracteristica],
		[idImputadoSimp],
		[idPersona],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [Autores]
	
	WHERE 		([idClaseSeniaParticular] = @idClaseSeniaParticular) and ([Baja] = 0)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[AutoresSelectListByidClaseSexo]'
GO
ALTER PROCEDURE [dbo].[AutoresSelectListByidClaseSexo]
	@idClaseSexo int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idDelito],
		[idCausa],
		[Nro],
		[idClaseEdadAproximada],
		[idClaseSexo],
		[idClaseRostro],
		[CubiertoCon],
		[idClaseSeniaParticular],
		[UbicacionSeniaParticular],
		[idClaseLugarDelCuerpo],
		[idClaseTatuaje],
		[OtroTatuaje],
		[OtraCaracteristica],
		[Baja],
		[idImputadoSimp],
		[idPersona],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [Autores]
	
	WHERE 		([idClaseSexo] = @idClaseSexo) and ([Baja] = 0)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[AutoresSelectListByidClaseTatuaje]'
GO
ALTER PROCEDURE [dbo].[AutoresSelectListByidClaseTatuaje]
	@idClaseTatuaje int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idDelito],
		[idCausa],
		[Nro],
		[idClaseEdadAproximada],
		[idClaseSexo],
		[idClaseRostro],
		[CubiertoCon],
		[idClaseSeniaParticular],
		[UbicacionSeniaParticular],
		[idClaseLugarDelCuerpo],
		[idClaseTatuaje],
		[OtroTatuaje],
		[OtraCaracteristica],
		[idImputadoSimp],
		[idPersona],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [Autores]
	
	WHERE 		([idClaseTatuaje] = @idClaseTatuaje)  and ([Baja] = 0)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[NNClaseTipoAutor]'
GO
CREATE TABLE [dbo].[NNClaseTipoAutor]
(
[id] [int] NOT NULL,
[descripcion] [nchar] (50) COLLATE Modern_Spanish_CI_AI NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_NNTipoAutor] on [dbo].[NNClaseTipoAutor]'
GO
ALTER TABLE [dbo].[NNClaseTipoAutor] ADD CONSTRAINT [PK_NNTipoAutor] PRIMARY KEY CLUSTERED  ([id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[NNClaseTipoAutorSelectSingleItem]'
GO
CREATE PROCEDURE [NNClaseTipoAutorSelectSingleItem]
(
	@id int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[descripcion]
	FROM [NNClaseTipoAutor]
	WHERE
		([id] = @id)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[NNClaseTipoAutorSelectList]'
GO
CREATE PROCEDURE [NNClaseTipoAutorSelectList]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[descripcion]
	FROM [NNClaseTipoAutor]

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[AutoresInsertUpdateSingleItem]'
GO
ALTER PROCEDURE [dbo].[AutoresInsertUpdateSingleItem]
(
	@id int,
	@idDelito int,
	@idCausa nchar(12),
	@Nro nchar(10) = NULL,
	@idClaseEdadAproximada int = NULL,
	@idClaseSexo int = NULL,
	@idClaseRostro int = NULL,
	@CubiertoCon nchar(50) = NULL,
	@idClaseSeniaParticular int = NULL,
	@UbicacionSeniaParticular nchar(30) = NULL,
	@idClaseLugarDelCuerpo int = NULL,
	@idClaseTatuaje int = NULL,
	@OtroTatuaje nchar(50) = NULL,
	@OtraCaracteristica nchar(50) = NULL,
	@idImputadoSimp  int = NULL,
	@idPersona int = NULL,
	@Baja bit = NULL,
	@idUsuarioUltimaModificacion nchar(30) = NULL,
	@FechaUltimaModificacion datetime = NULL
)
AS
DECLARE @ReturnValue int
IF (@id IS NULL) -- New Item
BEGIN

	INSERT
	INTO [Autores]
	(
		[idDelito],
		[idCausa],
		[Nro],
		[idClaseEdadAproximada],
		[idClaseSexo],
		[idClaseRostro],
		[CubiertoCon],
		[idClaseSeniaParticular],
		[UbicacionSeniaParticular],
		[idClaseLugarDelCuerpo],
		[idClaseTatuaje],
		[OtroTatuaje],
		[OtraCaracteristica],
		[idImputadoSimp],
		[idPersona],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	)
		VALUES
		(
			@idDelito,
		@idCausa,
		@Nro,
		@idClaseEdadAproximada,
		@idClaseSexo,
		@idClaseRostro,
		@CubiertoCon,
		@idClaseSeniaParticular,
		@UbicacionSeniaParticular,
		@idClaseLugarDelCuerpo,
		@idClaseTatuaje,
		@OtroTatuaje,
		@OtraCaracteristica,
		@idImputadoSimp,
		@idPersona,
		@Baja,
		@idUsuarioUltimaModificacion,
		@FechaUltimaModificacion
	)
	
	SELECT @ReturnValue = SCOPE_IDENTITY()

	END
	ELSE
	BEGIN

	UPDATE [Autores]
	SET
		[idDelito] = @idDelito,
		[idCausa] = @idCausa,
		[Nro] = @Nro,
		[idClaseEdadAproximada] = @idClaseEdadAproximada,
		[idClaseSexo] = @idClaseSexo,
		[idClaseRostro] = @idClaseRostro,
		[CubiertoCon] = @CubiertoCon,
		[idClaseSeniaParticular] = @idClaseSeniaParticular,
		[UbicacionSeniaParticular] = @UbicacionSeniaParticular,
		[idClaseLugarDelCuerpo] = @idClaseLugarDelCuerpo,
		[idClaseTatuaje] = @idClaseTatuaje,
		[OtroTatuaje] = @OtroTatuaje,
		[OtraCaracteristica] = @OtraCaracteristica,
		[idImputadoSimp] = @idImputadoSimp,
		[idPersona] = @idPersona,
		[Baja] = @Baja,
		[idUsuarioUltimaModificacion] = @idUsuarioUltimaModificacion,
		[FechaUltimaModificacion] = @FechaUltimaModificacion
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
PRINT N'Creating [dbo].[NNClaseTipoAutorInsertUpdateSingleItem]'
GO
CREATE PROCEDURE [NNClaseTipoAutorInsertUpdateSingleItem]
(
	@id int,
	@descripcion nchar(50) = NULL
)
AS
DECLARE @ReturnValue int
IF (@id IS NULL) -- New Item
BEGIN

	INSERT
	INTO [NNClaseTipoAutor]
	(
			[id],
		[descripcion]
	)
		VALUES
		(
			@id,
		@descripcion
	)
	
	SELECT @ReturnValue = SCOPE_IDENTITY()

	END
	ELSE
	BEGIN

	UPDATE [NNClaseTipoAutor]
	SET
		[descripcion] = @descripcion
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
PRINT N'Creating [dbo].[NNClaseTipoAutorDeleteSingleItem]'
GO
CREATE PROCEDURE [NNClaseTipoAutorDeleteSingleItem]
(
	@id int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [NNClaseTipoAutor]
	WHERE
		[id] = @id
	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Rebuilding [dbo].[Persona]'
GO
CREATE TABLE [dbo].[tmp_rg_xx_Persona]
(
[id] [int] NOT NULL IDENTITY(1, 1),
[Nombre] [varchar] (50) COLLATE Modern_Spanish_CI_AI NULL,
[Apellido] [varchar] (255) COLLATE Modern_Spanish_CI_AI NOT NULL,
[Apodo] [varchar] (50) COLLATE Modern_Spanish_CI_AI NULL,
[idTipoDNI] [int] NULL,
[DocumentoNumero] [int] NULL,
[Sexo] [varchar] (50) COLLATE Modern_Spanish_CI_AI NULL,
[Direccion] [varchar] (255) COLLATE Modern_Spanish_CI_AI NULL,
[Telefono] [varchar] (50) COLLATE Modern_Spanish_CI_AI NULL,
[EMail] [varchar] (50) COLLATE Modern_Spanish_CI_AI NULL,
[FechaNacimiento] [datetime] NULL,
[Localidad] [int] NULL,
[Partido] [int] NULL,
[idProvincia] [int] NULL,
[idCreador] [varchar] (30) COLLATE Modern_Spanish_CI_AI NULL,
[colegio] [varchar] (15) COLLATE Modern_Spanish_CI_AI NULL,
[Tomo] [varchar] (15) COLLATE Modern_Spanish_CI_AI NULL,
[Folio] [varchar] (15) COLLATE Modern_Spanish_CI_AI NULL,
[FechaAlta] [datetime] NULL,
[PersonalPoderJudicial] [int] NULL,
[activo] [bit] NULL,
[Muerto] [bit] NULL,
[idEstadoCivil] [int] NULL,
[profesion] [varchar] (25) COLLATE Modern_Spanish_CI_AI NULL,
[LugarNacimiento] [varchar] (30) COLLATE Modern_Spanish_CI_AI NULL,
[idNacionalidad] [int] NULL,
[Padre] [varchar] (50) COLLATE Modern_Spanish_CI_AI NULL,
[Madre] [varchar] (50) COLLATE Modern_Spanish_CI_AI NULL,
[ProfesionPadre] [varchar] (25) COLLATE Modern_Spanish_CI_AI NULL,
[ProfesionMadre] [varchar] (25) COLLATE Modern_Spanish_CI_AI NULL,
[Conyuge] [varchar] (50) COLLATE Modern_Spanish_CI_AI NULL,
[NumeroIRNR] [varchar] (20) COLLATE Modern_Spanish_CI_AI NULL,
[NumeroIDAPMS] [varchar] (20) COLLATE Modern_Spanish_CI_AI NULL,
[DefensorParticular] [varchar] (50) COLLATE Modern_Spanish_CI_AI NULL,
[Edad] [smallint] NULL CONSTRAINT [DF__Persona__Edad__76A57D77] DEFAULT ((0)),
[IdEstadoCivilMaterno] [int] NOT NULL CONSTRAINT [DF__Persona__IdEst__3522DA76] DEFAULT ((0)),
[IdEstadoCivilPaterno] [int] NOT NULL CONSTRAINT [DF__Persona__IdEst__121DCA11] DEFAULT ((0)),
[idTipoPersona] [int] NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
SET IDENTITY_INSERT [dbo].[tmp_rg_xx_Persona] ON
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
INSERT INTO [dbo].[tmp_rg_xx_Persona]([id], [Nombre], [Apellido], [Apodo], [idTipoDNI], [DocumentoNumero], [Sexo], [Direccion], [Telefono], [EMail], [FechaNacimiento], [Localidad], [Partido], [idProvincia], [idCreador], [colegio], [Tomo], [Folio], [FechaAlta], [PersonalPoderJudicial], [activo], [Muerto], [idEstadoCivil], [profesion], [LugarNacimiento], [idNacionalidad], [Padre], [Madre], [ProfesionPadre], [ProfesionMadre], [Conyuge], [NumeroIRNR], [NumeroIDAPMS], [DefensorParticular], [Edad], [IdEstadoCivilMaterno], [IdEstadoCivilPaterno], [idTipoPersona]) SELECT [id], [Nombre], [Apellido], [Apodo], [idTipoDNI], [DocumentoNumero], [Sexo], [Direccion], [Telefono], [EMail], [FechaNacimiento], [Localidad], [Partido], [idProvincia], [idCreador], [colegio], [Tomo], [Folio], [FechaAlta], [PersonalPoderJudicial], [activo], [Muerto], [idEstadoCivil], [profesion], [LugarNacimiento], [idNacionalidad], [Padre], [Madre], [ProfesionPadre], [ProfesionMadre], [Conyuge], [NumeroIRNR], [NumeroIDAPMS], [DefensorParticular], [Edad], [IdEstadoCivilMaterno], [IdEstadoCivilPaterno], [idTipoPersona] FROM [dbo].[Persona]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
SET IDENTITY_INSERT [dbo].[tmp_rg_xx_Persona] OFF
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
DROP TABLE [dbo].[Persona]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
EXEC sp_rename N'[dbo].[tmp_rg_xx_Persona]', N'Persona'
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_Personas] on [dbo].[Persona]'
GO
ALTER TABLE [dbo].[Persona] ADD CONSTRAINT [PK_Personas] PRIMARY KEY NONCLUSTERED  ([id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[PersonaSelectListByidTipoPersona]'
GO
CREATE PROCEDURE [dbo].[PersonaSelectListByidTipoPersona]
	@idTipoPersona int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
	
		[id],
		[Nombre],
		[Apellido],
		[Apodo],
		[idTipoDNI],
		[DocumentoNumero],
		[Sexo],
		[Direccion],
		[Telefono],
		[EMail],
		[FechaNacimiento],
		[Localidad],
		[Partido],
		[idProvincia],
		[idCreador],
		[colegio],
		[Tomo],
		[Folio],
		[FechaAlta],
		[PersonalPoderJudicial],
		[activo],
		[Muerto],
		[idEstadoCivil],
		[profesion],
		[LugarNacimiento],
		[idNacionalidad],
		[Padre],
		[Madre],
		[ProfesionPadre],
		[ProfesionMadre],
		[Conyuge],
		[NumeroIRNR],
		[NumeroIDAPMS],
		[DefensorParticular],
		[Edad],
		[IdEstadoCivilMaterno],
		[IdEstadoCivilPaterno],
		[idTipoPersona]
	FROM [Persona]
	
	WHERE 		([idTipoPersona] = @idTipoPersona)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[Delitos]'
GO
ALTER TABLE [dbo].[Delitos] ADD
[idTipoAutor] [int] NULL
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByidClaseZonaCuerpoLesionada]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByidClaseZonaCuerpoLesionada]
	@idClaseZonaCuerpoLesionada int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idClaseZonaCuerpoLesionada] = @idClaseZonaCuerpoLesionada) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByHora]'
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[DelitosSelectListByHora] 
	-- Add the parameters for the stored procedure here
    
    @HoraDesde dateTime,
    @HoraHasta dateTime
	
AS
BEGIN
	
	SET NOCOUNT ON
	DECLARE @Err int
    

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores]
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE (CONVERT(char(8),[HoraDesde],108) >= CONVERT(char(8),@HoraDesde,108) AND CONVERT(char(8),[HoraDesde],108) <= CONVERT(char(8),@HoraHasta,108)) OR
          (CONVERT(char(8),[HoraHasta],108) >= CONVERT(char(8),@HoraDesde,108) AND CONVERT(char(8),[HoraHasta],108) <= CONVERT(char(8),@HoraHasta,108))
    

	SET @Err = @@Error

	RETURN @Err
END



GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByidPartidoL]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByidPartidoL]
	@idPartidoL int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idPartidoL] = @idPartidoL) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByTiempoYTerritorio]'
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[DelitosSelectListByTiempoYTerritorio] 
	-- Add the parameters for the stored procedure here
    @FechaDesde dateTime,
    @FechaHasta dateTime,
    @HoraDesde dateTime,
    @HoraHasta dateTime,
    @idClaseMomentoDelDia int,
    @idPartido int,
    @idLocalidad int,
    @ParajeBarrioH nchar(10),
    @idCalle nchar(50),
    @idEntreCalle1 nchar(50),
    @idEntreCalle2 nchar(50),
    @idOtraCalle nchar(50),
    @idOtraEntreCalle nchar(50),
    @idOtraEntreCalle2 nchar(50),
    @NroH nchar(10),
    @PisoH nchar(10),
    @DeptoH nchar(10),
    @idComisariaH nchar(10),
    @idClaseLugar int,
    @idClaseRubro int,
    @nomReferenciaLugarRubro nchar(50)
	
AS
BEGIN
	
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE ([FechaDesde] = @FechaDesde AND
    [FechaHasta] = @FechaHasta AND
    [HoraDesde] = @HoraDesde AND
    [HoraHasta] = @HoraHasta AND
    [idClaseMomentoDelDia] = @idClaseMomentoDelDia AND
    [idPartido] = @idPartido AND
    [idLocalidad] = @idLocalidad AND
    [ParajeBarrioH] = @ParajeBarrioH AND
    [idCalle] = @idCalle AND
    [idEntreCalle1] = @idEntreCalle1 AND
    [idEntreCalle2] = @idEntreCalle2 AND
    [idOtraCalle] = @idOtraCalle AND
    [idOtraEntreCalle] = @idOtraEntreCalle AND
    [idOtraEntreCalle2] = @idOtraEntreCalle2 AND
    [NroH] = @NroH AND
    [PisoH] = @PisoH AND
    [DeptoH] = @DeptoH AND
    [idComisariaH] = @idComisariaH AND
    [idClaseLugar] = @idClaseLugar AND
    [idClaseRubro] = @idClaseRubro 
    --[nomReferenciaLugarRubro] = @nomReferenciaLugarRubro
)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByFiltroGeneral]'
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[DelitosSelectListByFiltroGeneral] 
	-- Add the parameters for the stored procedure here
	--********* PONGO CEROS EN LOS NULLIF DEL WHERE PORQUE CORRESPONDE A 'INDETERMINADO'
	(@idDelito int = NULL, --si ingreso IdDelito se obvian todos los demas parametros
	@FechaDesde dateTime = NULL,
    @FechaHasta dateTime = NULL,
    @HoraDesde nchar(10) = NULL,
    @HoraHasta nchar(10) = NULL,
    @idClaseDelito int = NULL,
    @idClaseMomentoDelDia int = NULL,
    @idPartido varchar(100) = NULL,
    @idLocalidad varchar(100) = NULL,
    @ParajeBarrioH nchar(10) = NULL,
    @idCalle nchar(50) = NULL,
    @idEntreCalle1 nchar(50) = NULL,
    @idEntreCalle2 nchar(50) = NULL,
    @idOtraCalle nchar(50) = NULL,
    @idOtraEntreCalle nchar(50) = NULL,
    @idOtraEntreCalle2 nchar(50) = NULL,
    @NroH nchar(10) = NULL,
    @PisoH nchar(10) = NULL,
    @DeptoH nchar(10) = NULL,
    @idComisariaH nchar(10) = NULL,
    @idClaseLugar int = NULL,
    @idClaseRubro int = NULL,
    @nomReferenciaLugarRubro nchar(50) = NULL,
    @idClaseModusOperandis int = NULL,
    @idCausa nchar(12) = NULL,
    @idClaseModoArriboHuida int = NULL,
    @idMarcaVehiculoMO nchar(30) = NULL,
    @idModeloVehiculoMO nchar(30) = NULL,
    @DominioMO nchar(10) = NULL,
    @idColorVehiculoMO nchar(30) = NULL,
    @idClaseVidrioVehiculoMO int = NULL,
    @IngresaronPor nchar(50) = NULL,
    @VictimasEnElLugar bit = NULL,
    @HuboAgresionFisicaAVictima bit = NULL,
    @idClaseAgresion int = NULL,
    @idClaseZonaCuerpoLesionada int = NULL,
    @VictimaTrasladadaAOtroLugar bit = NULL,
    @idLocalidadTraslado nchar(50) = NULL,
    @idPartidoL nchar(50) = NULL,
    @idLocalidadL nchar(50) = NULL,
    @ParajeBarrioL nchar(50) = NULL,
    @idCalleL nchar(50) = NULL,
    @idOtraCalleL nchar(50) = NULL,
    @idEntreCalle1L nchar(50) = NULL,
    @OtraEntreCalle1L nchar(50) = NULL,
    @idEntreCalle2L nchar(50) = NULL,
    @OtraEntreCalle2L nchar(50) = NULL,
    @idComisariaL nchar(50) = NULL,
    @UsoDeArmas bit = NULL,
    @idClaseArma int = NULL,
    @OtraClaseArma nchar(50) = NULL,
    @ExprUtilizadaComienzoDelHecho nchar(100) = NULL,
    @ExprReiteradaDuranteHecho nchar(100) = NULL,
    @idClaseCantidadAutores int = NULL,
    @MontoTotalEstimadoBienSustraido real = NULL,
    @idVicTestRecRueda int = NULL,
    @Nro nchar(10) = NULL,
    @idClaseEdadAproximada int = NULL,
    @idClaseSexo int = NULL,
    @idClaseRostro int = NULL,
    @CubiertoCon nchar(50) = NULL,
    @idClaseSeniaParticular int = NULL,
    @UbicacionSeniaParticular nchar(30) = NULL,
    @idClaseLugarDelCuerpo int = NULL,
    @idClaseTatuaje int = NULL,
    @OtroTatuaje nchar(50) = NULL,
    @OtraCaracteristica nchar(50) = NULL,
    @idClaseBienSustraido int = NULL,
    @idMarcaVehiculoBS nchar(30) = NULL,
    @idModeloVehiculoBS nchar(30) = NULL,
    @anioBS nchar(4) = NULL,
    @DominioBS nchar(10) = NULL,
    @idColorVehiculoBS nchar(30) = NULL,
    @idClaseVidrioVehiculoBS int = NULL,
    @NumeroMotorBS nchar(50) = NULL,
    @NumeroChasisBS nchar(50) = NULL,
    @GNCBS bit = NULL,
    @IdentificacionGNCBS nchar(30) = NULL,
    @idClaseGanado int = NULL,
    @CantidadGanado int = NULL,
    @MarcaGanado nchar(20) = NULL,
    @MarcaBienSustraidoOtro nchar(10) = NULL,
    @NroSerieBienSustraidoOtro nchar(50) = NULL,
    @CantidadBienSustraidoOtro int = NULL,
    @idClaseCantAutorReconocidos int = NULL,
    @idClaseCondicionVictima int = NULL,
    @idDepartamento varchar(100) = NULL
    
)
   
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DISTINCT [Delitos].[id],
		[Delitos].[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[Delitos].[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
        [idClaseCondicionVictima], 
		[idClaseCantAutorReconocidos],
		[Delitos].[Baja],
		[Delitos].[idUsuarioUltimaModificacion],
		[Delitos].[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor],
		[idClaseSubtipoArma]
     FROM Delitos 
     LEFT JOIN Vehiculos AS VehiculoMO ON  (Delitos.id = VehiculoMO.idDelito and VehiculoMO.Baja = 0 and VehiculoMO.idClaseVinculoVehiculo = 1)
     LEFT JOIN LugaresDeTrasladoDeVictimas ON (Delitos.id = LugaresDeTrasladoDeVictimas.idDelito AND LugaresDeTrasladoDeVictimas.Baja = 0)
     LEFT JOIN Autores ON (Delitos.id = Autores.idDelito AND Autores.Baja = 0)
     LEFT JOIN BienesSustraidos ON (Delitos.id = BienesSustraidos.idDelito AND BienesSustraidos.Baja = 0)
     LEFT JOIN Vehiculos AS VehiculoBS ON  (Delitos.id = VehiculoBS.idDelito and VehiculoBS.Baja = 0 and VehiculoBS.idClaseVinculoVehiculo = 2)
     LEFT JOIN BienesSustraidosAnimal ON (BienesSustraidos.id = BienesSustraidosAnimal.idNNBienSustraido AND BienesSustraidosAnimal.Baja = 0)
     LEFT JOIN BienesSustraidosOtro ON (BienesSustraidos.id = BienesSustraidosOtro.idNNBienSustraido AND BienesSustraidosOtro.Baja = 0)
     LEFT JOIN Partido ON (Delitos.idPartido = Partido.id)
--WHERE Delitos.idCausa=@idCausa
     WHERE (Delitos.id=@idDelito OR NULLIF(@IdDelito,'') IS NULL
			AND
            ([Delitos].[idCausa] = LTRIM(RTRIM(@idCausa))  OR NULLIF(@idCausa,'') IS NULL)
            AND ([Delitos].[Baja] = 0)
            AND
           (--Condición entre Fechas
            (@FechaDesde IS NULL and @FechaHasta IS NULL)
             or
            ((@FechaDesde IS NOT NULL and @FechaHasta IS NOT NULL)  
              and(
              ((@FechaDesde <= [FechaDesde]) and (@FechaHasta >= [FechaHasta]))
                  or
              ((@FechaDesde >= [FechaDesde]) and (@FechaDesde <= [FechaHasta] ))
                  or
              ((@FechaHasta >= [FechaDesde]) and (@FechaHasta <= [FechaHasta]))
                  or
              (([FechaHasta] IS NULL) and (@FechaDesde <= [FechaDesde])and (@FechaHasta >= [FechaDesde])) 
                 ))
             or ((@FechaDesde IS NOT NULL and @FechaHasta IS NULL)
                 and (([FechaDesde] >= @FechaDesde OR [FechaHasta] >= @FechaDesde)))
             or ((@FechaDesde IS NULL and @FechaHasta IS NOT NULL)
                 and([FechaDesde] <= @FechaHasta))
            )
           AND --Condición entre horas
           (
              (@HoraDesde IS NULL and @HoraHasta IS NULL) or 
              ((@HoraDesde IS NOT NULL and @HoraHasta IS NOT NULL) and
              (  --el parámetro desde es mayor igual que hora desde y menor igual que hora hasta
                ((@HoraDesde >= [HoraDesde]) and  (@HoraDesde <= [HoraHasta]))
                 or
                 --el parámetro hasta es mayor igual que hora desde y menor igual que hora hasta
                ((@HoraHasta >= [HoraDesde]) and  (@HoraHasta <= [HoraHasta]))
                 or
                --el parámetro desde es menor que hora desde y el parametro hasta es mayor que hora hasta
                ((@HoraDesde < [HoraDesde]) and  (@HoraHasta > [HoraHasta]))
               ))
               or
               ((@HoraDesde IS NOT NULL and @HoraHasta IS NULL) and 
                -- el parámetro desde es menor o igual que Hasta
                 ([HoraHasta] >= @HoraDesde)
               ) 
              or
               (
                -- el parámetro hasta es mayor o igual que Hasta
                 (@HoraDesde IS NULL and @HoraHasta IS NOT NULL) AND
                  ([HoraDesde] <= @HoraHasta)
                 
                )
            )
        AND (NULLIF(@idClaseMomentoDelDia,'') IS NULL OR [idClaseMomentoDelDia] = @idClaseMomentoDelDia)
        AND (NULLIF(@idPartido,'') IS NULL OR CONVERT(VARCHAR,[Delitos].[idPartido]) IN(SELECT ID FROM fnSplitter(@idPartido)))
        AND (NULLIF(@idLocalidad,'') IS NULL OR CONVERT(VARCHAR,[Delitos].[idLocalidad]) IN(SELECT ID FROM fnSplitter(@idLocalidad)))
        AND (NULLIF(@idCalle,'') IS NULL OR [Delitos].[idCalle] LIKE  '%' + LTRIM(RTRIM(@idCalle))  + '%')
        AND (NULLIF(@idEntreCalle1,'') IS NULL OR [Delitos].[idEntreCalle1] LIKE  '%' + LTRIM(RTRIM(@idEntreCalle1))  + '%')
        AND (NULLIF(@idEntreCalle2,'') IS NULL OR [Delitos].[idEntreCalle2] LIKE  '%' + LTRIM(RTRIM(@idEntreCalle2))  + '%')
        AND (NULLIF(@idOtraCalle,'') IS NULL OR [Delitos].[idOtraCalle] LIKE  '%' + LTRIM(RTRIM(@idOtraCalle))  + '%')
        AND (NULLIF(@idOtraEntreCalle,'') IS NULL OR [Delitos].[idOtraEntreCalle] LIKE  '%' + LTRIM(RTRIM(@idOtraEntreCalle))  + '%')
        AND (NULLIF(@idOtraEntreCalle2,'') IS NULL OR [Delitos].[idOtraEntreCalle2] LIKE  '%' + LTRIM(RTRIM(@idOtraEntreCalle2))  + '%')
        AND (NULLIF(@NroH,'') IS NULL OR [Delitos].[NroH] LIKE  '%' + LTRIM(RTRIM(@NroH))  + '%')
        AND (NULLIF(@PisoH,'') IS NULL OR [Delitos].[PisoH] LIKE  '%' + LTRIM(RTRIM(@PisoH))  + '%')
        AND (NULLIF(@DeptoH,'') IS NULL OR [Delitos].[DeptoH] LIKE  '%' + LTRIM(RTRIM(@DeptoH))  + '%')
        AND (NULLIF(@ParajeBarrioH,'') IS NULL OR [Delitos].[ParajeBarrioH] LIKE  '%' + LTRIM(RTRIM(@ParajeBarrioH))  + '%')
        AND (NULLIF(@idComisariaH,'0') IS NULL OR [Delitos].[idComisariaH] LIKE  '%' + LTRIM(RTRIM(@idComisariaH))  + '%') 
        AND (NULLIF(@idClaseLugar,'0') IS NULL OR [Delitos].[idClaseLugar] = @idClaseLugar)
        AND (NULLIF(@idClaseRubro,'0') IS NULL OR [Delitos].[idClaseRubro] = @idClaseRubro)
        AND (NULLIF(@nomReferenciaLugarRubro,'') IS NULL OR [Delitos].[NomRefLugarRubro] LIKE  '%' + LTRIM(RTRIM(@nomReferenciaLugarRubro))  + '%')
        AND (NULLIF(@idClaseModusOperandis,'0') IS NULL OR  NULLIF(@idClaseModusOperandis,'') IS NULL OR [Delitos].[idClaseModusOperandis] = @idClaseModusOperandis)
        AND (NULLIF(@idClaseModoArriboHuida,'0') IS NULL OR  NULLIF(@idClaseModoArriboHuida,'') IS NULL OR [Delitos].[idClaseModoArriboHuida] = @idClaseModoArriboHuida)
        AND (NULLIF(@idMarcaVehiculoMO,'0') IS NULL OR NULLIF(@idMarcaVehiculoMO,'') IS NULL OR ltrim(rtrim([VehiculoMO].[idMarcaVehiculo])) LIKE  '%' + LTRIM(RTRIM(@idMarcaVehiculoMO))  + '%')
        AND (NULLIF(@idModeloVehiculoMO,'0') IS NULL OR  NULLIF(@idModeloVehiculoMO,'') IS NULL OR LTRIM(RTRIM([VehiculoMO].[idModeloVehiculo])) LIKE  '%' + LTRIM(RTRIM(@idModeloVehiculoMO))  + '%')
        AND (NULLIF(@DominioMO,'') IS NULL OR LTRIM(RTRIM([VehiculoMO].[Dominio])) LIKE  '%' + LTRIM(RTRIM(@DominioMO))  + '%')
        AND (NULLIF(@idColorVehiculoMO,'0') IS NULL OR  NULLIF(@idColorVehiculoMO,'') IS NULL OR [VehiculoMO].[idColorVehiculo] LIKE  '%' + LTRIM(RTRIM(@idColorVehiculoMO))  + '%')
        AND (NULLIF(@idClaseVidrioVehiculoMO,'0') IS NULL  OR  NULLIF(@idClaseVidrioVehiculoMO,'') IS NULL OR [VehiculoMO].[idClaseVidrioVehiculo] = @idClaseVidrioVehiculoMO)
        AND (NULLIF(@IngresaronPor,'') IS NULL OR [Delitos].[IngresaronPor] LIKE  '%' + LTRIM(RTRIM(@IngresaronPor))  + '%')
        AND (NULLIF(@VictimasEnElLugar,'0') IS NULL OR  NULLIF(@VictimasEnElLugar,'') IS NULL OR [Delitos].[VictimasEnElLugar] = @VictimasEnElLugar)
        AND (NULLIF(@HuboAgresionFisicaAVictima,'0') IS NULL OR  NULLIF(@HuboAgresionFisicaAVictima,'') IS NULL OR [Delitos].[HuboAgresionFisicaAVictima] = @HuboAgresionFisicaAVictima)
        AND (NULLIF(@idClaseAgresion,'0') IS NULL OR  NULLIF(@idClaseAgresion,'') IS NULL OR [Delitos].[idClaseAgresion] = @idClaseAgresion)
        AND (NULLIF(@idClaseZonaCuerpoLesionada,'0') IS NULL OR  NULLIF(@idClaseZonaCuerpoLesionada,'') IS NULL OR [Delitos].[idClaseZonaCuerpoLesionada] = @idClaseZonaCuerpoLesionada)
        AND (NULLIF(@VictimaTrasladadaAOtroLugar,'0') IS NULL OR  NULLIF(@VictimaTrasladadaAOtroLugar,'') IS NULL OR [Delitos].[VictimaTrasladadaAOtroLugar] = @VictimaTrasladadaAOtroLugar)
        AND (NULLIF(@idLocalidadTraslado,'0') IS NULL OR  NULLIF(@idLocalidadTraslado,'') IS NULL OR [LugaresDeTrasladoDeVictimas].[idLocalidad] = @idLocalidadTraslado)
        AND (NULLIF(@idPartidoL,'') IS NULL OR [Delitos].[idPartidoL] = @idPartidoL OR  NULLIF(@idPartidoL,'0') IS NULL)
        AND (NULLIF(@idLocalidadL,'0') IS NULL OR  NULLIF(@idLocalidadL,'') IS NULL OR [Delitos].[idLocalidadL] = @idLocalidadL)
        AND (NULLIF(@idCalleL,'') IS NULL OR [Delitos].[idCalleL] LIKE  '%' + LTRIM(RTRIM(@idCalleL))  + '%')
        AND (NULLIF(@idEntreCalle1L,'') IS NULL OR [Delitos].[idEntreCalle1L] LIKE  '%' + LTRIM(RTRIM(@idEntreCalle1L))  + '%')
        AND (NULLIF(@idEntreCalle2L,'') IS NULL OR [Delitos].[idEntreCalle2L] LIKE  '%' + LTRIM(RTRIM(@idEntreCalle2L))  + '%')
        AND (NULLIF(@idOtraCalleL,'') IS NULL OR [Delitos].[idOtraCalleL] LIKE  '%' + LTRIM(RTRIM(@idOtraCalleL))  + '%')
        AND (NULLIF(@OtraEntreCalle1L,'') IS NULL OR [Delitos].[OtraEntreCalle1L] LIKE  '%' + LTRIM(RTRIM(@OtraEntreCalle1L))  + '%')
        AND (NULLIF(@OtraEntreCalle2L,'') IS NULL OR [Delitos].[OtraEntreCalle2L] LIKE  '%' + LTRIM(RTRIM(@OtraEntreCalle2L))  + '%')
        AND (NULLIF(@ParajeBarrioL,'') IS NULL OR [Delitos].[ParajeBarrioL] LIKE  '%' + LTRIM(RTRIM(@ParajeBarrioL))  + '%')
        AND (NULLIF(@idComisariaL,'0') IS NULL OR NULLIF(@idComisariaL,'') IS NULL OR [Delitos].[idComisariaL] LIKE  '%' + LTRIM(RTRIM(@idComisariaL))  + '%')
        AND (NULLIF(@UsoDeArmas,'0') IS NULL OR  NULLIF(@UsoDeArmas,'') IS NULL OR [Delitos].[UsoDeArmas] = @UsoDeArmas)
        AND (NULLIF(@idClaseArma,'0') IS NULL OR  NULLIF(@idClaseArma,'') IS NULL OR [Delitos].[idClaseArma] = @idClaseArma)
        AND (NULLIF(@OtraClaseArma,'') IS NULL OR [Delitos].[OtraClaseArma] LIKE  '%' + LTRIM(RTRIM(@OtraClaseArma))  + '%')
        AND (NULLIF(@ExprUtilizadaComienzoDelHecho,'') IS NULL OR [Delitos].[ExprUtilizadaComienzoDelHecho] LIKE  '%' + LTRIM(RTRIM(@ExprUtilizadaComienzoDelHecho))  + '%')
        AND (NULLIF(@ExprReiteradaDuranteHecho,'') IS NULL OR [Delitos].[ExprReiteradaDuranteHecho] LIKE  '%' + LTRIM(RTRIM(@ExprReiteradaDuranteHecho))  + '%')
        AND (NULLIF(@idClaseCantidadAutores,'') IS NULL OR [Delitos].[idClaseCantidadAutores] = @idClaseCantidadAutores)
        AND (NULLIF(@Nro,'') IS NULL OR [Autores].[Nro] LIKE  '%' + LTRIM(RTRIM(@Nro))  + '%')
        AND (NULLIF(@idClaseEdadAproximada,'0') IS NULL OR  NULLIF(@idClaseEdadAproximada,'') IS NULL OR [Autores].[idClaseEdadAproximada] = @idClaseEdadAproximada)
        AND (NULLIF(@idClaseSexo,'0') IS NULL OR  NULLIF(@idClaseSexo,'') IS NULL OR [Autores].[idClaseSexo] = @idClaseSexo)
        AND (NULLIF(@idClaseRostro,'0') IS NULL OR  NULLIF(@idClaseRostro,'') IS NULL OR [Autores].[idClaseRostro] = @idClaseRostro)
        AND (NULLIF(@CubiertoCon,'') IS NULL OR [Autores].[CubiertoCon] LIKE  '%' + LTRIM(RTRIM(@CubiertoCon))  + '%')
        AND (NULLIF(@idClaseSeniaParticular,'0') IS NULL OR  NULLIF(@idClaseSeniaParticular,'') IS NULL OR [Autores].[idClaseSeniaParticular] = @idClaseSeniaParticular)
        AND (NULLIF(@UbicacionSeniaParticular,'') IS NULL OR [Autores].[UbicacionSeniaParticular] LIKE  '%' + LTRIM(RTRIM(@UbicacionSeniaParticular))  + '%')
        AND (NULLIF(@idClaseLugarDelCuerpo,'0') IS NULL OR  NULLIF(@idClaseLugarDelCuerpo,'') IS NULL OR [Autores].[idClaseLugarDelCuerpo] = @idClaseLugarDelCuerpo)
        AND (NULLIF(@idClaseTatuaje,'0') IS NULL OR  NULLIF(@idClaseTatuaje,'') IS NULL OR [Autores].[idClaseTatuaje] = @idClaseTatuaje)
        AND (NULLIF(@OtroTatuaje,'') IS NULL OR [Autores].[OtroTatuaje] LIKE  '%' + LTRIM(RTRIM(@OtroTatuaje))  + '%')
        AND (NULLIF(@OtraCaracteristica,'') IS NULL OR [Autores].[OtraCaracteristica] LIKE  '%' + LTRIM(RTRIM(@OtraCaracteristica))  + '%')
        AND (NULLIF(@idClaseBienSustraido,'0') IS NULL OR  NULLIF(@idClaseBienSustraido,'') IS NULL OR [BienesSustraidos].[idClaseBienSustraido] = @idClaseBienSustraido)
        AND (NULLIF(@idMarcaVehiculoBS,'0') IS NULL OR NULLIF(@idMarcaVehiculoBS,'') IS NULL OR [VehiculoBS].[idMarcaVehiculo] LIKE  '%' + LTRIM(RTRIM(@idMarcaVehiculoBS))  + '%')
        AND (NULLIF(@idModeloVehiculoBS,'0') IS NULL OR NULLIF(@idModeloVehiculoBS,'') IS NULL OR [VehiculoBS].[idModeloVehiculo] LIKE  '%' + LTRIM(RTRIM(@idModeloVehiculoBS))  + '%')
        AND (NULLIF(@DominioBS,'') IS NULL OR [VehiculoBS].[Dominio] LIKE  '%' + LTRIM(RTRIM(@DominioBS))  + '%')
        AND (NULLIF(@anioBS,'') IS NULL OR [VehiculoBS].[anio] LIKE  '%' + LTRIM(RTRIM(@anioBS))  + '%')
        AND (NULLIF(@idColorVehiculoBS,'0') IS NULL OR NULLIF(@idColorVehiculoBS,'') IS NULL OR [VehiculoBS].[idColorVehiculo] LIKE  '%' + LTRIM(RTRIM(@idColorVehiculoBS))  + '%')
        AND (NULLIF(@idClaseVidrioVehiculoBS,'0') IS NULL OR  NULLIF(@idClaseVidrioVehiculoBS,'') IS NULL OR [VehiculoBS].[idClaseVidrioVehiculo] = @idClaseVidrioVehiculoBS)
        AND (NULLIF(@NumeroMotorBS,'') IS NULL OR [VehiculoBS].[NumeroMotor] LIKE  '%' + LTRIM(RTRIM(@NumeroMotorBS))  + '%')
        AND (NULLIF(@NumeroChasisBS,'') IS NULL OR [VehiculoBS].[NumeroChasis] LIKE  '%' + LTRIM(RTRIM(@NumeroChasisBS))  + '%')
        AND (NULLIF(@GNCBS,'') IS NULL OR [VehiculoBS].[GNC] = @GNCBS)
        AND (NULLIF(@IdentificacionGNCBS,'') IS NULL OR [VehiculoBS].[IdentificacionGNC] LIKE  '%' + LTRIM(RTRIM(@IdentificacionGNCBS))  + '%')
        AND (NULLIF(@idClaseGanado,'0') IS NULL OR [BienesSustraidosAnimal].[idClaseGanado] = @idClaseGanado)
        AND (NULLIF(@MarcaGanado,'') IS NULL OR [BienesSustraidosAnimal].[Marca] LIKE  '%' + LTRIM(RTRIM(@MarcaGanado))  + '%')
        AND (NULLIF(@CantidadGanado,'') IS NULL OR [BienesSustraidosAnimal].[Cantidad] = @CantidadGanado)
        AND (NULLIF(@MarcaBienSustraidoOtro,'') IS NULL OR [BienesSustraidosOtro].[Marca] LIKE  '%' + LTRIM(RTRIM(@MarcaBienSustraidoOtro))  + '%')
        AND (NULLIF(@NroSerieBienSustraidoOtro,'') IS NULL OR [BienesSustraidosOtro].[NroSerie] LIKE  '%' + LTRIM(RTRIM(@NroSerieBienSustraidoOtro))  + '%')
        AND (NULLIF(@CantidadBienSustraidoOtro,'') IS NULL OR [BienesSustraidosOtro].[Cantidad] = @CantidadBienSustraidoOtro)
        AND (NULLIF(@MontoTotalEstimadoBienSustraido,'') IS NULL OR [Delitos].[MontoTotalEstimadoBienSustraido] = @MontoTotalEstimadoBienSustraido)
        AND (NULLIF(@idVicTestRecRueda,'0') IS NULL OR  NULLIF(@idVicTestRecRueda,'') IS NULL OR [Delitos].[idVicTestRecRueda] = @idVicTestRecRueda)
        AND (NULLIF(@idClaseCondicionVictima,'0') IS NULL OR  NULLIF(@idClaseCondicionVictima,'') IS NULL OR [Delitos].[idClaseCondicionVictima] = @idClaseCondicionVictima)
        AND (NULLIF(@idDepartamento,'0') IS NULL OR  NULLIF(@idDepartamento,'') IS NULL OR CONVERT(VARCHAR,[Partido].[idDepartamento]) IN(SELECT ID FROM fnSplitter(@idDepartamento)))
        AND (NULLIF(@idClaseCantAutorReconocidos,'0') IS NULL OR  NULLIF(@idClaseCantAutorReconocidos,'') IS NULL OR [Delitos].[idClaseCantAutorReconocidos] = @idClaseCantAutorReconocidos)
        AND (NULLIF(@idClaseDelito,'') IS NULL OR [idClaseDelito] = @idClaseDelito)
)
END





GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByidPartido]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByidPartido]
	@idPartido int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idPartido] = @idPartido) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosInsertUpdateSingleItem]'
GO
ALTER PROCEDURE [dbo].[DelitosInsertUpdateSingleItem]
(
	@id int,
	@idCausa nchar(12),
	@idClaseFecha int = NULL,
	@FechaDesde datetime = NULL,
	@FechaHasta datetime = NULL,
	@idClaseHora int = NULL,
	@HoraDesde nchar(10) = NULL,
	@HoraHasta nchar(10) = NULL,
	@idClaseMomentoDelDia int = NULL,
	@idPartido int = NULL,
	@idLocalidad int = NULL,
	@idCalle int = NULL,
	@idOtraCalle nchar(50) = NULL,
	@idEntreCalle1 int = NULL,
	@idOtraEntreCalle nchar(50) = NULL,
	@idEntreCalle2 int = NULL,
	@idOtraEntreCalle2 nchar(50) = NULL,
	@NroH nchar(10) = NULL,
	@PisoH nchar(10) = NULL,
	@DeptoH nchar(10) = NULL,
	@ParajeBarrioH nchar(10) = NULL,
	@idComisariaH int = NULL,
	@idClaseLugar int = NULL,
	@idClaseRubro int = NULL,
	@NomRefLugarRubro nchar(50) = NULL,
	@idClaseModoArriboHuida int = NULL,
	@idClaseModusOperandis int = NULL,
	@ExprUtilizadaComienzoDelHecho nchar(100) = NULL,
	@ExprReiteradaDuranteHecho nchar(100) = NULL,
	@IngresaronPor nchar(50) = NULL,
	@VictimasEnElLugar int = NULL,
	@UsoDeArmas int = NULL,
	@idClaseArma int = NULL,
	@idClaseSubtipoArma smallint = NULL,
	@OtraClaseArma nchar(50) = NULL,
	@HuboAgresionFisicaAVictima int = NULL,
	@idClaseAgresion int = NULL,
	@idClaseZonaCuerpoLesionada int = NULL,
	@VictimaTrasladadaAOtroLugar int = NULL,
	@idPartidoL int = NULL,
	@idLocalidadL int = NULL,
	@idCalleL int = NULL,
	@idOtraCalleL nchar(50) = NULL,
	@idEntreCalle1L int = NULL,
	@OtraEntreCalle1L nchar(50) = NULL,
	@idEntreCalle2L int = NULL,
	@OtraEntreCalle2L nchar(50) = NULL,
	@ParajeBarrioL nchar(50) = NULL,
	@idComisariaL int = NULL,
	@idClaseCantidadAutores int = NULL,
	@MontoTotalEstimadoBienSustraido real = NULL,
	@idVicTestRecRueda int = NULL,
	@idClaseCantAutorReconocidos int = NULL,
	@idClaseCondicionVictima int = NULL,
	@Baja bit = NULL,
	@idUsuarioUltimaModificacion nchar(20) = NULL,
	@FechaUltimaModificacion datetime = NULL,
	@idClaseDelito int = null,
	@idTipoAutor int
)
AS
DECLARE @ReturnValue int
IF (@id IS NULL) -- New Item
BEGIN

	INSERT
	INTO [Delitos]
	(
			[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	)
		VALUES
		(
			@idCausa,
		@idClaseFecha,
		@FechaDesde,
		@FechaHasta,
		@idClaseHora,
		@HoraDesde,
		@HoraHasta,
		@idClaseMomentoDelDia,
		@idPartido,
		@idLocalidad,
		@idCalle,
		@idOtraCalle,
		@idEntreCalle1,
		@idOtraEntreCalle,
		@idEntreCalle2,
		@idOtraEntreCalle2,
		@NroH,
		@PisoH,
		@DeptoH,
		@ParajeBarrioH,
		@idComisariaH,
		@idClaseLugar,
		@idClaseRubro,
		@NomRefLugarRubro,
		@idClaseModoArriboHuida,
		@idClaseModusOperandis,
		@ExprUtilizadaComienzoDelHecho,
		@ExprReiteradaDuranteHecho,
		@IngresaronPor,
		@VictimasEnElLugar,
		@UsoDeArmas,
		@idClaseArma,
		@idClaseSubtipoArma,
		@OtraClaseArma,
		@HuboAgresionFisicaAVictima,
		@idClaseAgresion,
		@idClaseZonaCuerpoLesionada,
		@VictimaTrasladadaAOtroLugar,
		@idPartidoL,
		@idLocalidadL,
		@idCalleL,
		@idOtraCalleL,
		@idEntreCalle1L,
		@OtraEntreCalle1L,
		@idEntreCalle2L,
		@OtraEntreCalle2L,
		@ParajeBarrioL,
		@idComisariaL,
		@idClaseCantidadAutores,
		@MontoTotalEstimadoBienSustraido,
		@idVicTestRecRueda,
		@idClaseCantAutorReconocidos,
		@idClaseCondicionVictima,
		@Baja,
		@idUsuarioUltimaModificacion,
		@FechaUltimaModificacion,
		@idClaseDelito,
		@idTipoAutor
	)
	
	SELECT @ReturnValue = SCOPE_IDENTITY()

	END
	ELSE
	BEGIN

	UPDATE [Delitos]
	SET
		[idCausa] = @idCausa,
		[idClaseFecha] = @idClaseFecha,
		[FechaDesde] = @FechaDesde,
		[FechaHasta] = @FechaHasta,
		[idClaseHora] = @idClaseHora,
		[HoraDesde] = @HoraDesde,
		[HoraHasta] = @HoraHasta,
		[idClaseMomentoDelDia] = @idClaseMomentoDelDia,
		[idPartido] = @idPartido,
		[idLocalidad] = @idLocalidad,
		[idCalle] = @idCalle,
		[idOtraCalle] = @idOtraCalle,
		[idEntreCalle1] = @idEntreCalle1,
		[idOtraEntreCalle] = @idOtraEntreCalle,
		[idEntreCalle2] = @idEntreCalle2,
		[idOtraEntreCalle2] = @idOtraEntreCalle2,
		[NroH] = @NroH,
		[PisoH] = @PisoH,
		[DeptoH] = @DeptoH,
		[ParajeBarrioH] = @ParajeBarrioH,
		[idComisariaH] = @idComisariaH,
		[idClaseLugar] = @idClaseLugar,
		[idClaseRubro] = @idClaseRubro,
		[NomRefLugarRubro] = @NomRefLugarRubro,
		[idClaseModoArriboHuida] = @idClaseModoArriboHuida,
		[idClaseModusOperandis] = @idClaseModusOperandis,
		[ExprUtilizadaComienzoDelHecho] = @ExprUtilizadaComienzoDelHecho,
		[ExprReiteradaDuranteHecho] = @ExprReiteradaDuranteHecho,
		[IngresaronPor] = @IngresaronPor,
		[VictimasEnElLugar] = @VictimasEnElLugar,
		[UsoDeArmas] = @UsoDeArmas,
		[idClaseArma] = @idClaseArma,
		[idClaseSubtipoArma] = @idClaseSubtipoArma,
		[OtraClaseArma] = @OtraClaseArma,
		[HuboAgresionFisicaAVictima] = @HuboAgresionFisicaAVictima,
		[idClaseAgresion] = @idClaseAgresion,
		[idClaseZonaCuerpoLesionada] = @idClaseZonaCuerpoLesionada,
		[VictimaTrasladadaAOtroLugar] = @VictimaTrasladadaAOtroLugar,
		[idPartidoL] = @idPartidoL,
		[idLocalidadL] = @idLocalidadL,
		[idCalleL] = @idCalleL,
		[idOtraCalleL] = @idOtraCalleL,
		[idEntreCalle1L] = @idEntreCalle1L,
		[OtraEntreCalle1L] = @OtraEntreCalle1L,
		[idEntreCalle2L] = @idEntreCalle2L,
		[OtraEntreCalle2L] = @OtraEntreCalle2L,
		[ParajeBarrioL] = @ParajeBarrioL,
		[idComisariaL] = @idComisariaL,
		[idClaseCantidadAutores] = @idClaseCantidadAutores,
		[MontoTotalEstimadoBienSustraido] = @MontoTotalEstimadoBienSustraido,
		[idVicTestRecRueda] = @idVicTestRecRueda,
		[idClaseCantAutorReconocidos] = @idClaseCantAutorReconocidos,
		[idClaseCondicionVictima] = @idClaseCondicionVictima,
		[Baja] = @Baja,
		[idUsuarioUltimaModificacion] = @idUsuarioUltimaModificacion,
		[FechaUltimaModificacion] = @FechaUltimaModificacion,
		[idClaseDelito]=@idClaseDelito,
		[idTipoAutor]= @idTipoAutor
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
PRINT N'Creating [dbo].[DelitosSelectListByidClaseTipoAutor]'
GO
CREATE PROCEDURE [dbo].[DelitosSelectListByidClaseTipoAutor]
	@idTipoAutor int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idTipoAutor] = @idTipoAutor) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonaSelectSingleItem]'
GO
ALTER PROCEDURE [dbo].[PersonaSelectSingleItem]
(
	@id int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
	
		[id],
		[Nombre],
		[Apellido],
		[Apodo],
		[idTipoDNI],
		[DocumentoNumero],
		[Sexo],
		[Direccion],
		[Telefono],
		[EMail],
		[FechaNacimiento],
		[Localidad],
		[Partido],
		[idProvincia],
		[idCreador],
		[colegio],
		[Tomo],
		[Folio],
		[FechaAlta],
		[PersonalPoderJudicial],
		[activo],
		[Muerto],
		[idEstadoCivil],
		[profesion],
		[LugarNacimiento],
		[idNacionalidad],
		[Padre],
		[Madre],
		[ProfesionPadre],
		[ProfesionMadre],
		[Conyuge],
		[NumeroIRNR],
		[NumeroIDAPMS],
		[DefensorParticular],
		[Edad],
		[IdEstadoCivilMaterno],
		[IdEstadoCivilPaterno],
		[idTipoPersona]
	FROM [Persona]
	WHERE
		([id] = @id)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectSingleItemByidCausa]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectSingleItemByidCausa]
	@idCausa nchar(12)

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idCausa] = @idCausa) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END

GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[PuntoGestionSelectListByidDepartamento]'
GO
CREATE PROCEDURE [dbo].[PuntoGestionSelectListByidDepartamento]
	@idDepartamento int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idClasePuntoGestion],
		[Descripcion],
		[Numero],
		[Externo],
		[idPais],
		[idProvincia],
		[idDepartamento],
		[idLocalidad],
		[idPartido],
		[Direccion],
		[Telefonos],
		[DescripcionCorta],
		[OrdenMuestra],
		[titular],
		[idDescentralizada],
		[activo],
		[Email],
		[idPadrePG],
		[IdTitular],
		[codi_Corte],
		[area_Corte]
	FROM [PuntoGestion]
	
	WHERE 		([idDepartamento] = @idDepartamento)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[UsuarioAutorizadoSelectList]'
GO
CREATE PROCEDURE [dbo].[UsuarioAutorizadoSelectList]
	

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT     dbo.Persona.Nombre,
	           dbo.Persona.Apellido,
	           dbo.Usuarios.activo,
	           dbo.Persona.id AS idPersona, 
	           dbo.PersonalPoderJudicial.idJerarquia, 
               dbo.PersonalPoderJudicial.idPuntoGestion, 
               dbo.PersonalPoderJudicial.id AS idPersonalPoderJudicial, 
               dbo.Usuarios.NombreUsuario, 
               dbo.Usuarios.id AS idUsuario, 
               dbo.Usuarios.idGrupoUsuario,
               dbo.Usuarios.EsReferenteTrata,
               dbo.PuntoGestion.idDepartamento
FROM         dbo.PersonalPoderJudicial INNER JOIN
             dbo.Usuarios ON dbo.PersonalPoderJudicial.id = dbo.Usuarios.idPersonalPoderJudicial INNER JOIN
             dbo.Persona ON dbo.PersonalPoderJudicial.id = dbo.Persona.id inner join
             dbo.PuntoGestion on dbo.PersonalPoderJudicial.idPuntoGestion = dbo.PuntoGestion.id
	
	

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[UsuariosAutorizadoSelectSingleItem]'
GO
CREATE PROCEDURE [dbo].[UsuariosAutorizadoSelectSingleItem]
(
	@idUsuario varchar(30)
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT     dbo.Persona.Nombre,
	           dbo.Persona.Apellido,
	           dbo.Usuarios.activo,
	           dbo.Persona.id AS idPersona, 
	           dbo.PersonalPoderJudicial.idJerarquia, 
               dbo.PersonalPoderJudicial.idPuntoGestion, 
               dbo.PersonalPoderJudicial.id AS idPersonalPoderJudicial, 
               dbo.Usuarios.NombreUsuario, 
               dbo.Usuarios.id AS idUsuario, 
               dbo.Usuarios.idGrupoUsuario,
               dbo.Usuarios.EsReferenteTrata,
               dbo.PuntoGestion.idDepartamento
FROM         dbo.PersonalPoderJudicial INNER JOIN
             dbo.Usuarios ON dbo.PersonalPoderJudicial.id = dbo.Usuarios.idPersonalPoderJudicial INNER JOIN
             dbo.Persona ON dbo.PersonalPoderJudicial.id = dbo.Persona.id inner join
             dbo.PuntoGestion on dbo.PersonalPoderJudicial.idPuntoGestion = dbo.PuntoGestion.id
	WHERE
		(dbo.Usuarios.id = @idUsuario)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectSingleItem]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectSingleItem]
(
	@id int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	WHERE
		([id] = @id) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectList]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectList]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
    WHERE [Baja] = 0

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByidComisariaH]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByidComisariaH]
	@idComisariaH int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idComisariaH] = @idComisariaH) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByidComisariaL]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByidComisariaL]
	@idComisariaL int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idComisariaL] = @idComisariaL) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByidLocalidad]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByidLocalidad]
	@idLocalidad int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idLocalidad] = @idLocalidad) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByidLocalidadL]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByidLocalidadL]
	@idLocalidadL int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idLocalidadL] = @idLocalidadL) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByidClaseAgresion]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByidClaseAgresion]
	@idClaseAgresion int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idClaseAgresion] = @idClaseAgresion) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByidClaseArma]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByidClaseArma]
	@idClaseArma int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idClaseArma] = @idClaseArma) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByHuboAgresionFisicaAVictima]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByHuboAgresionFisicaAVictima]
	@HuboAgresionFisicaAVictima int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([HuboAgresionFisicaAVictima] = @HuboAgresionFisicaAVictima) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByUsoDeArmas]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByUsoDeArmas]
	@UsoDeArmas int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([UsoDeArmas] = @UsoDeArmas) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByVictimasEnElLugar]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByVictimasEnElLugar]
	@VictimasEnElLugar int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([VictimasEnElLugar] = @VictimasEnElLugar) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[AutoresJoinedPersonaSelectListByidDelito]'
GO
CREATE PROCEDURE [dbo].[AutoresJoinedPersonaSelectListByidDelito]
	@idDelito int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		a.[id],
		[idDelito],
		[idCausa],
		[Nro],
		[idClaseEdadAproximada],
		[idClaseSexo],
		[idClaseRostro],
		[CubiertoCon],
		[idClaseSeniaParticular],
		[UbicacionSeniaParticular],
		[idClaseLugarDelCuerpo],
		[idClaseTatuaje],
		[OtroTatuaje],
		[OtraCaracteristica],
		[idImputadoSimp],
		[idPersona],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		p.*
	FROM [Autores] a
	LEFT JOIN [Persona]p
	on a.idPersona=p.id
	
	WHERE 		([idDelito] = @idDelito)
                and ([Baja] = 0)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByVictimaTrasladadaAOtroLugar]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByVictimaTrasladadaAOtroLugar]
	@VictimaTrasladadaAOtroLugar int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseSubtipoArma],
		[idClaseArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([VictimaTrasladadaAOtroLugar] = @VictimaTrasladadaAOtroLugar) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[PersonaSelectListByApellido]'
GO
CREATE PROCEDURE [dbo].[PersonaSelectListByApellido]
	@apellido varchar(250)

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
	
		[id],
		[Nombre],
		[Apellido],
		[Apodo],
		[idTipoDNI],
		[DocumentoNumero],
		[Sexo],
		[Direccion],
		[Telefono],
		[EMail],
		[FechaNacimiento],
		[Localidad],
		[Partido],
		[idProvincia],
		[idCreador],
		[colegio],
		[Tomo],
		[Folio],
		[FechaAlta],
		[PersonalPoderJudicial],
		[activo],
		[Muerto],
		[idEstadoCivil],
		[profesion],
		[LugarNacimiento],
		[idNacionalidad],
		[Padre],
		[Madre],
		[ProfesionPadre],
		[ProfesionMadre],
		[Conyuge],
		[NumeroIRNR],
		[NumeroIDAPMS],
		[DefensorParticular],
		[Edad],
		[IdEstadoCivilMaterno],
		[IdEstadoCivilPaterno],
		[idTipoPersona]
	FROM [Persona]
	
	WHERE 		([Apellido] LIKE  '%'+ @apellido + '%')

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[PersonaSelectListByDocNro]'
GO
create PROCEDURE [dbo].[PersonaSelectListByDocNro]
	@docNro int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
	
		[id],
		[Nombre],
		[Apellido],
		[Apodo],
		[idTipoDNI],
		[DocumentoNumero],
		[Sexo],
		[Direccion],
		[Telefono],
		[EMail],
		[FechaNacimiento],
		[Localidad],
		[Partido],
		[idProvincia],
		[idCreador],
		[colegio],
		[Tomo],
		[Folio],
		[FechaAlta],
		[PersonalPoderJudicial],
		[activo],
		[Muerto],
		[idEstadoCivil],
		[profesion],
		[LugarNacimiento],
		[idNacionalidad],
		[Padre],
		[Madre],
		[ProfesionPadre],
		[ProfesionMadre],
		[Conyuge],
		[NumeroIRNR],
		[NumeroIDAPMS],
		[DefensorParticular],
		[Edad],
		[IdEstadoCivilMaterno],
		[IdEstadoCivilPaterno],
		[idTipoPersona]
	FROM [Persona]
	
	WHERE 		([DocumentoNumero] = @docNro)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByidVicTestRecRueda]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByidVicTestRecRueda]
	@idVicTestRecRueda int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[OtraClaseArma],
		[idClaseSubtipoArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idVicTestRecRueda] = @idVicTestRecRueda) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByidClaseCantAutorReconocidos]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByidClaseCantAutorReconocidos]
	@idClaseCantAutorReconocidos int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idClaseCantAutorReconocidos] = @idClaseCantAutorReconocidos) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByidClaseCantidadAutores]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByidClaseCantidadAutores]
	@idClaseCantidadAutores int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseSubtipoArma],
		[idClaseArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idClaseCantidadAutores] = @idClaseCantidadAutores) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[PersonaSelectListByDocNroApellido]'
GO
CREATE PROCEDURE [dbo].[PersonaSelectListByDocNroApellido]
	@docNro int=NULL,
	@apellido varchar(250)=NULL

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
	
		[id],
		[Nombre],
		[Apellido],
		[Apodo],
		[idTipoDNI],
		[DocumentoNumero],
		[Sexo],
		[Direccion],
		[Telefono],
		[EMail],
		[FechaNacimiento],
		[Localidad],
		[Partido],
		[idProvincia],
		[idCreador],
		[colegio],
		[Tomo],
		[Folio],
		[FechaAlta],
		[PersonalPoderJudicial],
		[activo],
		[Muerto],
		[idEstadoCivil],
		[profesion],
		[LugarNacimiento],
		[idNacionalidad],
		[Padre],
		[Madre],
		[ProfesionPadre],
		[ProfesionMadre],
		[Conyuge],
		[NumeroIRNR],
		[NumeroIDAPMS],
		[DefensorParticular],
		[Edad],
		[IdEstadoCivilMaterno],
		[IdEstadoCivilPaterno],
		[idTipoPersona]
	FROM [Persona]
	
	WHERE 		(ISNULL(@docNro,'')='' AND [Apellido] LIKE '%'+@apellido+'%') OR ([DocumentoNumero] = @docNro AND (ISNULL(@apellido,'')='' OR [Apellido] LIKE '%'+@apellido+'%'))

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByidClaseCondicionVictima]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByidClaseCondicionVictima]
	@idClaseCondicionVictima int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idClaseCondicionVictima] = @idClaseCondicionVictima) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[AutoresJoinedPersonasSelectListByidPersona]'
GO
CREATE PROCEDURE [dbo].[AutoresJoinedPersonasSelectListByidPersona]
	@idPersona int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	select a.* from Persona p join Autores a on p.id=a.idPersona 
	
	WHERE 		(p.id = @idPersona)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByidClaseFecha]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByidClaseFecha]
	@idClaseFecha int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idClaseFecha] = @idClaseFecha) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByidClaseHora]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByidClaseHora]
	@idClaseHora int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idClaseHora] = @idClaseHora) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[PersonaInsertUpdateSingleItem]'
GO
ALTER PROCEDURE [dbo].[PersonaInsertUpdateSingleItem]
(
	
	@id int,
	@Nombre varchar(50) = NULL,
	@Apellido varchar(255),
	@Apodo varchar(50) = NULL,
	@idTipoDNI int = NULL,
	@DocumentoNumero int = NULL,
	@Sexo varchar(50) = NULL,
	@Direccion varchar(255) = NULL,
	@Telefono varchar(50) = NULL,
	@EMail varchar(50) = NULL,
	@FechaNacimiento datetime = NULL,
	@Localidad int = NULL,
	@Partido int = NULL,
	@idProvincia int = NULL,
	@idCreador varchar(14) = NULL,
	@colegio varchar(15) = NULL,
	@Tomo varchar(15) = NULL,
	@Folio varchar(15) = NULL,
	@FechaAlta datetime = NULL,
	@PersonalPoderJudicial int = NULL,
	@activo bit = NULL,
	@Muerto bit = NULL,
	@idEstadoCivil int = NULL,
	@profesion varchar(25) = NULL,
	@LugarNacimiento varchar(30) = NULL,
	@idNacionalidad int = NULL,
	@Padre varchar(50) = NULL,
	@Madre varchar(50) = NULL,
	@ProfesionPadre varchar(25) = NULL,
	@ProfesionMadre varchar(25) = NULL,
	@Conyuge varchar(50) = NULL,
	@NumeroIRNR varchar(20) = NULL,
	@NumeroIDAPMS varchar(20) = NULL,
	@DefensorParticular varchar(50) = NULL,
	@Edad smallint = NULL,
	@IdEstadoCivilMaterno int,
	@IdEstadoCivilPaterno int,
	@idTipoPersona int
)
AS
DECLARE @ReturnValue int
IF (@id IS NULL) -- New Item
BEGIN

	INSERT
	INTO [Persona]
	(
		
		
		[Nombre],
		[Apellido],
		[Apodo],
		[idTipoDNI],
		[DocumentoNumero],
		[Sexo],
		[Direccion],
		[Telefono],
		[EMail],
		[FechaNacimiento],
		[Localidad],
		[Partido],
		[idProvincia],
		[idCreador],
		[colegio],
		[Tomo],
		[Folio],
		[FechaAlta],
		[PersonalPoderJudicial],
		[activo],
		[Muerto],
		[idEstadoCivil],
		[profesion],
		[LugarNacimiento],
		[idNacionalidad],
		[Padre],
		[Madre],
		[ProfesionPadre],
		[ProfesionMadre],
		[Conyuge],
		[NumeroIRNR],
		[NumeroIDAPMS],
		[DefensorParticular],
		[Edad],
		[IdEstadoCivilMaterno],
		[IdEstadoCivilPaterno],
		[idTipoPersona]
	)
		VALUES
		(
		@Nombre,
		@Apellido,
		@Apodo,
		@idTipoDNI,
		@DocumentoNumero,
		@Sexo,
		@Direccion,
		@Telefono,
		@EMail,
		@FechaNacimiento,
		@Localidad,
		@Partido,
		@idProvincia,
		@idCreador,
		@colegio,
		@Tomo,
		@Folio,
		@FechaAlta,
		@PersonalPoderJudicial,
		@activo,
		@Muerto,
		@idEstadoCivil,
		@profesion,
		@LugarNacimiento,
		@idNacionalidad,
		@Padre,
		@Madre,
		@ProfesionPadre,
		@ProfesionMadre,
		@Conyuge,
		@NumeroIRNR,
		@NumeroIDAPMS,
		@DefensorParticular,
		@Edad,
		@IdEstadoCivilMaterno,
		@IdEstadoCivilPaterno,
		@idTipoPersona
	)
	
	SELECT @ReturnValue = SCOPE_IDENTITY()

	END
	ELSE
	BEGIN

	UPDATE [Persona]
	SET
	
		[Nombre] = @Nombre,
		[Apellido] = @Apellido,
		[Apodo] = @Apodo,
		[idTipoDNI] = @idTipoDNI,
		[DocumentoNumero] = @DocumentoNumero,
		[Sexo] = @Sexo,
		[Direccion] = @Direccion,
		[Telefono] = @Telefono,
		[EMail] = @EMail,
		[FechaNacimiento] = @FechaNacimiento,
		[Localidad] = @Localidad,
		[Partido] = @Partido,
		[idProvincia] = @idProvincia,
		[idCreador] = @idCreador,
		[colegio] = @colegio,
		[Tomo] = @Tomo,
		[Folio] = @Folio,
		[FechaAlta] = @FechaAlta,
		[PersonalPoderJudicial] = @PersonalPoderJudicial,
		[activo] = @activo,
		[Muerto] = @Muerto,
		[idEstadoCivil] = @idEstadoCivil,
		[profesion] = @profesion,
		[LugarNacimiento] = @LugarNacimiento,
		[idNacionalidad] = @idNacionalidad,
		[Padre] = @Padre,
		[Madre] = @Madre,
		[ProfesionPadre] = @ProfesionPadre,
		[ProfesionMadre] = @ProfesionMadre,
		[Conyuge] = @Conyuge,
		[NumeroIRNR] = @NumeroIRNR,
		[NumeroIDAPMS] = @NumeroIDAPMS,
		[DefensorParticular] = @DefensorParticular,
		[Edad] = @Edad,
		[IdEstadoCivilMaterno] = @IdEstadoCivilMaterno,
		[IdEstadoCivilPaterno] = @IdEstadoCivilPaterno,
		[idTipoPersona] = @idTipoPersona
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
PRINT N'Altering [dbo].[DelitosSelectListByidClaseLugar]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByidClaseLugar]
	@idClaseLugar int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idClaseLugar] = @idClaseLugar) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByidClaseDelito]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByidClaseDelito]
	@idClaseDelito int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseDelito],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idClaseDelito] = @idClaseDelito) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByidClaseModoArriboHuida]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByidClaseModoArriboHuida]
	@idClaseModoArriboHuida int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idClaseModoArriboHuida] = @idClaseModoArriboHuida) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[DelitosSelectListByidClaseSubTipoArma]'
GO
CREATE PROCEDURE [dbo].[DelitosSelectListByidClaseSubTipoArma]
	@idClaseSubtipoArma int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idClaseSubtipoArma] = @idClaseSubtipoArma) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByidClaseModusOperandis]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByidClaseModusOperandis]
	@idClaseModusOperandis int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idClaseModusOperandis] = @idClaseModusOperandis) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByidClaseMomentoDelDia]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByidClaseMomentoDelDia]
	@idClaseMomentoDelDia int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idClaseMomentoDelDia] = @idClaseMomentoDelDia) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[DelitosSelectListByidClaseRubro]'
GO
ALTER PROCEDURE [dbo].[DelitosSelectListByidClaseRubro]
	@idClaseRubro int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idCausa],
		[idClaseFecha],
		[FechaDesde],
		[FechaHasta],
		[idClaseHora],
		[HoraDesde],
		[HoraHasta],
		[idClaseMomentoDelDia],
		[idPartido],
		[idLocalidad],
		[idCalle],
		[idOtraCalle],
		[idEntreCalle1],
		[idOtraEntreCalle],
		[idEntreCalle2],
		[idOtraEntreCalle2],
		[NroH],
		[PisoH],
		[DeptoH],
		[ParajeBarrioH],
		[idComisariaH],
		[idClaseLugar],
		[idClaseRubro],
		[NomRefLugarRubro],
		[idClaseModoArriboHuida],
		[idClaseModusOperandis],
		[ExprUtilizadaComienzoDelHecho],
		[ExprReiteradaDuranteHecho],
		[IngresaronPor],
		[VictimasEnElLugar],
		[UsoDeArmas],
		[idClaseArma],
		[idClaseSubtipoArma],
		[OtraClaseArma],
		[HuboAgresionFisicaAVictima],
		[idClaseAgresion],
		[idClaseZonaCuerpoLesionada],
		[VictimaTrasladadaAOtroLugar],
		[idPartidoL],
		[idLocalidadL],
		[idCalleL],
		[idOtraCalleL],
		[idEntreCalle1L],
		[OtraEntreCalle1L],
		[idEntreCalle2L],
		[OtraEntreCalle2L],
		[ParajeBarrioL],
		[idComisariaL],
		[idClaseCantidadAutores],
		[MontoTotalEstimadoBienSustraido],
		[idVicTestRecRueda],
		[idClaseCantAutorReconocidos],
		[idClaseCondicionVictima],
		[Baja],
		[idUsuarioUltimaModificacion],
		[FechaUltimaModificacion],
		[idClaseDelito],
		[idTipoAutor]
	FROM [Delitos]
	
	WHERE 		([idClaseRubro] = @idClaseRubro) AND ([Baja] = 0) 

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[PuntoGestionSelectPGPoderJudicialListByidDepartamento]'
GO
CREATE PROCEDURE [dbo].[PuntoGestionSelectPGPoderJudicialListByidDepartamento]
	@idDepartamento int

AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		dbo.PuntoGestion.[id],
		[idClasePuntoGestion],
		dbo.PuntoGestion.[Descripcion],
		[Numero],
		[Externo],
		[idPais],
		[idProvincia],
		[idDepartamento],
		[idLocalidad],
		[idPartido],
		[Direccion],
		[Telefonos],
		dbo.PuntoGestion.[DescripcionCorta],
		dbo.PuntoGestion.[OrdenMuestra],
		[titular],
		[idDescentralizada],
		[activo],
		[Email],
		[idPadrePG],
		[IdTitular],
		[codi_Corte],
		[area_Corte]
		FROM
					dbo.PuntoGestion INNER JOIN
                      dbo.ClasePuntoGestion ON dbo.PuntoGestion.idClasePuntoGestion = dbo.ClasePuntoGestion.id
		WHERE      ((dbo.ClasePuntoGestion.UsuarioDelSistema = 1) OR
                      ((dbo.ClasePuntoGestion.UsuarioDelSistema = 2) AND (dbo.PuntoGestion.Externo = 0)))
					AND ([idDepartamento] = @idDepartamento)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[ClasePersona]'
GO
CREATE TABLE [dbo].[ClasePersona]
(
[id] [int] NOT NULL,
[descripcion] [nchar] (50) COLLATE Modern_Spanish_CI_AI NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_ClasePersona] on [dbo].[ClasePersona]'
GO
ALTER TABLE [dbo].[ClasePersona] ADD CONSTRAINT [PK_ClasePersona] PRIMARY KEY CLUSTERED  ([id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[AuditoriaAllanamientoSelectSingleItem]'
GO
CREATE PROCEDURE [AuditoriaAllanamientoSelectSingleItem]
(
	@id numeric(18,0)
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idAllanamiento],
		[idInmueble],
		[fecha],
		[SecuestroArmas],
		[SecuestroDrogas],
		[Observaciones],
		[Baja],
		[UsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [AuditoriaAllanamiento]
	WHERE
		([id] = @id)

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[AuditoriaAllanamientoSelectList]'
GO
CREATE PROCEDURE [AuditoriaAllanamientoSelectList]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[id],
		[idAllanamiento],
		[idInmueble],
		[fecha],
		[SecuestroArmas],
		[SecuestroDrogas],
		[Observaciones],
		[Baja],
		[UsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	FROM [AuditoriaAllanamiento]

	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[AuditoriaAllanamientoInsertUpdateSingleItem]'
GO
CREATE PROCEDURE [AuditoriaAllanamientoInsertUpdateSingleItem]
(
	@id numeric(18,0),
	@idAllanamiento int = NULL,
	@idInmueble numeric(18,0) = NULL,
	@fecha datetime = NULL,
	@SecuestroArmas bit = NULL,
	@SecuestroDrogas bit = NULL,
	@Observaciones nchar(250) = NULL,
	@Baja bit = NULL,
	@UsuarioUltimaModificacion nchar(50) = NULL,
	@FechaUltimaModificacion datetime = NULL
)
AS
DECLARE @ReturnValue int
IF (@id IS NULL) -- New Item
BEGIN

	INSERT
	INTO [AuditoriaAllanamiento]
	(
			[idAllanamiento],
		[idInmueble],
		[fecha],
		[SecuestroArmas],
		[SecuestroDrogas],
		[Observaciones],
		[Baja],
		[UsuarioUltimaModificacion],
		[FechaUltimaModificacion]
	)
		VALUES
		(
			@idAllanamiento,
		@idInmueble,
		@fecha,
		@SecuestroArmas,
		@SecuestroDrogas,
		@Observaciones,
		@Baja,
		@UsuarioUltimaModificacion,
		@FechaUltimaModificacion
	)
	
	SELECT @ReturnValue = SCOPE_IDENTITY()

	END
	ELSE
	BEGIN

	UPDATE [AuditoriaAllanamiento]
	SET
		[idAllanamiento] = @idAllanamiento,
		[idInmueble] = @idInmueble,
		[fecha] = @fecha,
		[SecuestroArmas] = @SecuestroArmas,
		[SecuestroDrogas] = @SecuestroDrogas,
		[Observaciones] = @Observaciones,
		[Baja] = @Baja,
		[UsuarioUltimaModificacion] = @UsuarioUltimaModificacion,
		[FechaUltimaModificacion] = @FechaUltimaModificacion
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
PRINT N'Creating [dbo].[AuditoriaAllanamientoDeleteSingleItem]'
GO
CREATE PROCEDURE [AuditoriaAllanamientoDeleteSingleItem]
(
	@id numeric(18,0)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [AuditoriaAllanamiento]
	WHERE
		[id] = @id
	SET @Err = @@Error

	RETURN @Err
END
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[Persona]'
GO
ALTER TABLE [dbo].[Persona] WITH NOCHECK ADD
CONSTRAINT [FK_Persona_TipoDocumento] FOREIGN KEY ([idTipoDNI]) REFERENCES [dbo].[TPClaseTipoDNI] ([id]),
CONSTRAINT [FK_Persona_Provincia] FOREIGN KEY ([idProvincia]) REFERENCES [dbo].[Provincia] ([id]),
CONSTRAINT [FK_Persona_Creador] FOREIGN KEY ([idCreador]) REFERENCES [dbo].[Usuarios] ([id]),
CONSTRAINT [FK_Persona_ClaseEstadoCivil] FOREIGN KEY ([idEstadoCivil]) REFERENCES [dbo].[ClaseEstadoCivil] ([id]),
CONSTRAINT [FK_Persona_Nacionalidad] FOREIGN KEY ([idNacionalidad]) REFERENCES [dbo].[Pais] ([id]),
CONSTRAINT [FK_Persona_EstadoCivilMaterno] FOREIGN KEY ([IdEstadoCivilMaterno]) REFERENCES [dbo].[ClaseEstadoCivil] ([id]),
CONSTRAINT [FK_Persona_EstadoCivilPaterno] FOREIGN KEY ([IdEstadoCivilPaterno]) REFERENCES [dbo].[ClaseEstadoCivil] ([id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[PersonasHalladas]'
GO
ALTER TABLE [dbo].[PersonasHalladas] WITH NOCHECK ADD
CONSTRAINT [FK_PersonasHalladas_Comisaria] FOREIGN KEY ([idComisaria]) REFERENCES [dbo].[Comisaria] ([id]),
CONSTRAINT [FK_PersonasHalladas_PBClaseAspectoCabello] FOREIGN KEY ([idAspectoCabello]) REFERENCES [dbo].[PBClaseAspectoCabello] ([Id]),
CONSTRAINT [FK_PersonasHalladas_PBClaseBoolean] FOREIGN KEY ([ExistenRadiografia]) REFERENCES [dbo].[PBClaseBoolean] ([Id]),
CONSTRAINT [FK_PersonasHalladas_PBClaseBoolean1] FOREIGN KEY ([FichasDactilares]) REFERENCES [dbo].[PBClaseBoolean] ([Id]),
CONSTRAINT [FK_PersonasHalladas_PBClaseBoolean2] FOREIGN KEY ([FaltanPiezasDentales]) REFERENCES [dbo].[PBClaseBoolean] ([Id]),
CONSTRAINT [FK_PersonasHalladas_PBClaseCalvicie] FOREIGN KEY ([idCalvicie]) REFERENCES [dbo].[PBClaseCalvicie] ([Id]),
CONSTRAINT [FK_PersonasHalladas_PBClaseColor] FOREIGN KEY ([idColorTenido]) REFERENCES [dbo].[PBClaseColor] ([Id]),
CONSTRAINT [FK_PersonasHalladas_PBClaseColorCabello] FOREIGN KEY ([idColorCabello]) REFERENCES [dbo].[PBClaseColorCabello] ([Id]),
CONSTRAINT [FK_PersonasHalladas_PBClaseColorDePiel] FOREIGN KEY ([idColorPiel]) REFERENCES [dbo].[PBClaseColorDePiel] ([Id]),
CONSTRAINT [FK_PersonasHalladas_PBClaseColorOjos] FOREIGN KEY ([idColorOjos]) REFERENCES [dbo].[PBClaseColorOjos] ([Id]),
CONSTRAINT [FK_PersonasHalladas_PBClaseLongitudCabello] FOREIGN KEY ([idLongitudCabello]) REFERENCES [dbo].[PBClaseLongitudCabello] ([Id]),
CONSTRAINT [FK_PersonasHalladas_PBClaseOrganismoInterviniente] FOREIGN KEY ([idOrganismoInterviniente]) REFERENCES [dbo].[PBClaseOrganismoInterviniente] ([Id]),
CONSTRAINT [FK_PersonasHalladas_PBClaseRostro] FOREIGN KEY ([idRostro]) REFERENCES [dbo].[PBClaseRostro] ([Id]),
CONSTRAINT [FK_PersonasHalladas_PBClaseSexo] FOREIGN KEY ([idSexo]) REFERENCES [dbo].[PBClaseSexo] ([Id]),
CONSTRAINT [FK_PersonasHalladas_PBGrupoSanguineo] FOREIGN KEY ([idGrupoSanguineo]) REFERENCES [dbo].[PBClaseGrupoSanguineo] ([Id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[PersonalPoderJudicial]'
GO
ALTER TABLE [dbo].[PersonalPoderJudicial] ADD
CONSTRAINT [FK_PersonalPoderJudicial_Persona] FOREIGN KEY ([idPersona]) REFERENCES [dbo].[Persona] ([id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Disabling constraints on [dbo].[Persona]'
GO
ALTER TABLE [dbo].[Persona] NOCHECK CONSTRAINT
[FK_Persona_TipoDocumento],
[FK_Persona_Provincia],
[FK_Persona_Creador],
[FK_Persona_ClaseEstadoCivil],
[FK_Persona_Nacionalidad],
[FK_Persona_EstadoCivilMaterno],
[FK_Persona_EstadoCivilPaterno]
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
