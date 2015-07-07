
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 07/31/2013 12:12:50
-- Generated from EDMX file: C:\Proyectos\MVC\SIAC\MPBA.SIAC.Web\Models\ModelSIAC.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SIAC];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Autor_NNClaseEdadAproximada]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Autores] DROP CONSTRAINT [FK_Autor_NNClaseEdadAproximada];
GO
IF OBJECT_ID(N'[dbo].[FK_Autor_NNClaseRostro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Autores] DROP CONSTRAINT [FK_Autor_NNClaseRostro];
GO
IF OBJECT_ID(N'[dbo].[FK_Autor_NNClaseSexo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Autores] DROP CONSTRAINT [FK_Autor_NNClaseSexo];
GO
IF OBJECT_ID(N'[dbo].[FK_Autores_Delitos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Autores] DROP CONSTRAINT [FK_Autores_Delitos];
GO
IF OBJECT_ID(N'[dbo].[FK_Bien Sustraido_NNClaseBienSustraido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BienesSustraidos] DROP CONSTRAINT [FK_Bien Sustraido_NNClaseBienSustraido];
GO
IF OBJECT_ID(N'[dbo].[FK_BienesSustraidoArma_BienesSustraido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BienSustraidoArma] DROP CONSTRAINT [FK_BienesSustraidoArma_BienesSustraido];
GO
IF OBJECT_ID(N'[dbo].[FK_BienesSUstraidos_Delitos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BienesSustraidos] DROP CONSTRAINT [FK_BienesSUstraidos_Delitos];
GO
IF OBJECT_ID(N'[dbo].[FK_BienesSustraidosAnimal_NNClaseGanado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BienesSustraidosAnimal] DROP CONSTRAINT [FK_BienesSustraidosAnimal_NNClaseGanado];
GO
IF OBJECT_ID(N'[dbo].[FK_BienSustraidoAnimal_Bien Sustraido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BienesSustraidosAnimal] DROP CONSTRAINT [FK_BienSustraidoAnimal_Bien Sustraido];
GO
IF OBJECT_ID(N'[dbo].[FK_BienSustraidoCheque_BienSustraido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BienSustraidoCheque] DROP CONSTRAINT [FK_BienSustraidoCheque_BienSustraido];
GO
IF OBJECT_ID(N'[dbo].[FK_BienSustraidoDinero_BienSustraido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BienSustraidoDinero] DROP CONSTRAINT [FK_BienSustraidoDinero_BienSustraido];
GO
IF OBJECT_ID(N'[dbo].[FK_BienSustraidoOtro_Bien Sustraido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BienesSustraidosOtro] DROP CONSTRAINT [FK_BienSustraidoOtro_Bien Sustraido];
GO
IF OBJECT_ID(N'[dbo].[FK_BienSustraidoTEL_BienSustraido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BienSustraidoTelefono] DROP CONSTRAINT [FK_BienSustraidoTEL_BienSustraido];
GO
IF OBJECT_ID(N'[dbo].[FK_Busqueda_Comisaria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Busqueda] DROP CONSTRAINT [FK_Busqueda_Comisaria];
GO
IF OBJECT_ID(N'[dbo].[FK_Busqueda_PBClaseBoolean]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Busqueda] DROP CONSTRAINT [FK_Busqueda_PBClaseBoolean];
GO
IF OBJECT_ID(N'[dbo].[FK_Busqueda_PBClaseMotivoHallazgo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Busqueda] DROP CONSTRAINT [FK_Busqueda_PBClaseMotivoHallazgo];
GO
IF OBJECT_ID(N'[dbo].[FK_Busqueda_PBClaseSexo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Busqueda] DROP CONSTRAINT [FK_Busqueda_PBClaseSexo];
GO
IF OBJECT_ID(N'[dbo].[FK_Busqueda_PBClaseTablaDestino]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Busqueda] DROP CONSTRAINT [FK_Busqueda_PBClaseTablaDestino];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaAspectoCabello_Busqueda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaAspectoCabello] DROP CONSTRAINT [FK_BusquedaAspectoCabello_Busqueda];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaAspectoCabello_PBClaseAspectoCabello]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaAspectoCabello] DROP CONSTRAINT [FK_BusquedaAspectoCabello_PBClaseAspectoCabello];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaCalvicie_Busqueda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaCalvicie] DROP CONSTRAINT [FK_BusquedaCalvicie_Busqueda];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaCalvicie_PBClaseCalvicie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaCalvicie] DROP CONSTRAINT [FK_BusquedaCalvicie_PBClaseCalvicie];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaColorCabello_Busqueda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaColorCabello] DROP CONSTRAINT [FK_BusquedaColorCabello_Busqueda];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaColorCabello_PBClaseColorCabello]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaColorCabello] DROP CONSTRAINT [FK_BusquedaColorCabello_PBClaseColorCabello];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaColorOjos_Busqueda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaColorOjos] DROP CONSTRAINT [FK_BusquedaColorOjos_Busqueda];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaColorOjos_PBClaseColorOjos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaColorOjos] DROP CONSTRAINT [FK_BusquedaColorOjos_PBClaseColorOjos];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaColorPiel_Busqueda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaColorPiel] DROP CONSTRAINT [FK_BusquedaColorPiel_Busqueda];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaColorPiel_PBClaseColorDePiel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaColorPiel] DROP CONSTRAINT [FK_BusquedaColorPiel_PBClaseColorDePiel];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaColorTenido_Busqueda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaColorTenido] DROP CONSTRAINT [FK_BusquedaColorTenido_Busqueda];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaColorTenido_PBClaseColor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaColorTenido] DROP CONSTRAINT [FK_BusquedaColorTenido_PBClaseColor];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaGrupoSanguineo_Busqueda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaGrupoSanguineo] DROP CONSTRAINT [FK_BusquedaGrupoSanguineo_Busqueda];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaGrupoSanguineo_PBGrupoSanguineo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaGrupoSanguineo] DROP CONSTRAINT [FK_BusquedaGrupoSanguineo_PBGrupoSanguineo];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaLongitudCabello_Busqueda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaLongitudCabello] DROP CONSTRAINT [FK_BusquedaLongitudCabello_Busqueda];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaLongitudCabello_PBClaseLongitudCabello]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaLongitudCabello] DROP CONSTRAINT [FK_BusquedaLongitudCabello_PBClaseLongitudCabello];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaRobosDelitosSexualesComisarias_BusquedaRoboDelitosSexuales]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesComisarias] DROP CONSTRAINT [FK_BusquedaRobosDelitosSexualesComisarias_BusquedaRoboDelitosSexuales];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaRobosDelitosSexualesLocalidades_BusquedaRoboDelitosSexuales]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesLocalidades] DROP CONSTRAINT [FK_BusquedaRobosDelitosSexualesLocalidades_BusquedaRoboDelitosSexuales];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaRobosDelitosSexualesSenias_BusquedaRobosDelitosSexuales]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesSenias] DROP CONSTRAINT [FK_BusquedaRobosDelitosSexualesSenias_BusquedaRobosDelitosSexuales];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaRobosDelitosSexualesSenias_ClaseSeniaParticular]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesSenias] DROP CONSTRAINT [FK_BusquedaRobosDelitosSexualesSenias_ClaseSeniaParticular];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaRobosDelitosSexualesSenias_ClaseUbicacionSeniaPart]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesSenias] DROP CONSTRAINT [FK_BusquedaRobosDelitosSexualesSenias_ClaseUbicacionSeniaPart];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaRobosDelitosSexualesTatuajes_BusquedaRobosDelitosSexuales]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesTatuajes] DROP CONSTRAINT [FK_BusquedaRobosDelitosSexualesTatuajes_BusquedaRobosDelitosSexuales];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaRobosDelitosSexualesTatuajes_ClaseTatuaje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesTatuajes] DROP CONSTRAINT [FK_BusquedaRobosDelitosSexualesTatuajes_ClaseTatuaje];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaRobosDelitosSexualesTatuajes_ClaseUbicacionSeniaPart]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesTatuajes] DROP CONSTRAINT [FK_BusquedaRobosDelitosSexualesTatuajes_ClaseUbicacionSeniaPart];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaRostro_Busqueda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaRostro] DROP CONSTRAINT [FK_BusquedaRostro_Busqueda];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaRostro_PBClaseRostro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaRostro] DROP CONSTRAINT [FK_BusquedaRostro_PBClaseRostro];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaSeniasParticulares_Busqueda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaSeniasParticulares] DROP CONSTRAINT [FK_BusquedaSeniasParticulares_Busqueda];
GO
IF OBJECT_ID(N'[dbo].[FK_BusquedaTatuajes_Busqueda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusquedaTatuajes] DROP CONSTRAINT [FK_BusquedaTatuajes_Busqueda];
GO
IF OBJECT_ID(N'[dbo].[FK_Delito_NNClaseAgresion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delito_NNClaseAgresion];
GO
IF OBJECT_ID(N'[dbo].[FK_Delito_NNClaseArma]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delito_NNClaseArma];
GO
IF OBJECT_ID(N'[dbo].[FK_Delito_NNClaseCantAutorReconocidos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delito_NNClaseCantAutorReconocidos];
GO
IF OBJECT_ID(N'[dbo].[FK_Delito_NNClaseCantidadAutores]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delito_NNClaseCantidadAutores];
GO
IF OBJECT_ID(N'[dbo].[FK_Delito_NNClaseFecha]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delito_NNClaseFecha];
GO
IF OBJECT_ID(N'[dbo].[FK_Delito_NNClaseHora]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delito_NNClaseHora];
GO
IF OBJECT_ID(N'[dbo].[FK_Delito_NNClaseLugar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delito_NNClaseLugar];
GO
IF OBJECT_ID(N'[dbo].[FK_Delito_NNClaseModoArriboHuida]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delito_NNClaseModoArriboHuida];
GO
IF OBJECT_ID(N'[dbo].[FK_Delito_NNClaseModusOperandi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delito_NNClaseModusOperandi];
GO
IF OBJECT_ID(N'[dbo].[FK_Delito_NNClaseMomentoDia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delito_NNClaseMomentoDia];
GO
IF OBJECT_ID(N'[dbo].[FK_Delito_NNClaseRubro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delito_NNClaseRubro];
GO
IF OBJECT_ID(N'[dbo].[FK_Delito_NNClaseZonaCuerpoLesionada]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delito_NNClaseZonaCuerpoLesionada];
GO
IF OBJECT_ID(N'[dbo].[FK_Delitos_Comisaria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delitos_Comisaria];
GO
IF OBJECT_ID(N'[dbo].[FK_Delitos_Comisaria1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delitos_Comisaria1];
GO
IF OBJECT_ID(N'[dbo].[FK_Delitos_NNClaseBoolean]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delitos_NNClaseBoolean];
GO
IF OBJECT_ID(N'[dbo].[FK_Delitos_NNClaseBoolean1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delitos_NNClaseBoolean1];
GO
IF OBJECT_ID(N'[dbo].[FK_Delitos_NNClaseBoolean2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delitos_NNClaseBoolean2];
GO
IF OBJECT_ID(N'[dbo].[FK_Delitos_NNClaseBoolean3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delitos_NNClaseBoolean3];
GO
IF OBJECT_ID(N'[dbo].[FK_Delitos_NNClaseBoolean4]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delitos_NNClaseBoolean4];
GO
IF OBJECT_ID(N'[dbo].[FK_Delitos_NNClaseCondicionVictima]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delitos_NNClaseCondicionVictima];
GO
IF OBJECT_ID(N'[dbo].[FK_Delitos_NNClaseSubtipoArma]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delitos_NNClaseSubtipoArma];
GO
IF OBJECT_ID(N'[dbo].[FK_Delitos_NNClaseTipoDelito]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delitos_NNClaseTipoDelito];
GO
IF OBJECT_ID(N'[dbo].[FK_Delitos_Partido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delitos_Partido];
GO
IF OBJECT_ID(N'[dbo].[FK_Delitos_Partido1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Delitos] DROP CONSTRAINT [FK_Delitos_Partido1];
GO
IF OBJECT_ID(N'[dbo].[FK_Localidad_Partido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Localidad] DROP CONSTRAINT [FK_Localidad_Partido];
GO
IF OBJECT_ID(N'[dbo].[FK_Localidad_Provincia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Localidad] DROP CONSTRAINT [FK_Localidad_Provincia];
GO
IF OBJECT_ID(N'[dbo].[FK_LugaresDeTrasladoDeVictimas_Delitos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LugaresDeTrasladoDeVictimas] DROP CONSTRAINT [FK_LugaresDeTrasladoDeVictimas_Delitos];
GO
IF OBJECT_ID(N'[dbo].[FK_Menu_ClaseMenu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Menu] DROP CONSTRAINT [FK_Menu_ClaseMenu];
GO
IF OBJECT_ID(N'[dbo].[FK_Menu_Padre]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Menu] DROP CONSTRAINT [FK_Menu_Padre];
GO
IF OBJECT_ID(N'[dbo].[FK_ModeloVehiculo_MarcaVehiculo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ModeloVehiculo] DROP CONSTRAINT [FK_ModeloVehiculo_MarcaVehiculo];
GO
IF OBJECT_ID(N'[dbo].[FK_NNClaseRubro_NNClaseLugar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NNClaseRubro] DROP CONSTRAINT [FK_NNClaseRubro_NNClaseLugar];
GO
IF OBJECT_ID(N'[dbo].[FK_NNClaseSubtipoArma_NNClaseArma]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NNClaseSubtipoArma] DROP CONSTRAINT [FK_NNClaseSubtipoArma_NNClaseArma];
GO
IF OBJECT_ID(N'[dbo].[FK_Partido_Provincia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Partido] DROP CONSTRAINT [FK_Partido_Provincia];
GO
IF OBJECT_ID(N'[dbo].[FK_Permiso_GrupoUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PermisoGrupo] DROP CONSTRAINT [FK_Permiso_GrupoUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_PermisoGrupo_Recurso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PermisoGrupo] DROP CONSTRAINT [FK_PermisoGrupo_Recurso];
GO
IF OBJECT_ID(N'[dbo].[FK_PermisoUsuario_Recurso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PermisoUsuario] DROP CONSTRAINT [FK_PermisoUsuario_Recurso];
GO
IF OBJECT_ID(N'[dbo].[FK_PermisoUsuario_Usuarios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PermisoUsuario] DROP CONSTRAINT [FK_PermisoUsuario_Usuarios];
GO
IF OBJECT_ID(N'[dbo].[FK_Persona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonaIPP] DROP CONSTRAINT [FK_Persona];
GO
IF OBJECT_ID(N'[dbo].[FK_Persona_ClaseEstadoCivil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persona] DROP CONSTRAINT [FK_Persona_ClaseEstadoCivil];
GO
IF OBJECT_ID(N'[dbo].[FK_Persona_CLaseSexo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persona] DROP CONSTRAINT [FK_Persona_CLaseSexo];
GO
IF OBJECT_ID(N'[dbo].[FK_Persona_Creador]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persona] DROP CONSTRAINT [FK_Persona_Creador];
GO
IF OBJECT_ID(N'[dbo].[FK_Persona_EstadoCivilMaterno]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persona] DROP CONSTRAINT [FK_Persona_EstadoCivilMaterno];
GO
IF OBJECT_ID(N'[dbo].[FK_Persona_EstadoCivilPaterno]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persona] DROP CONSTRAINT [FK_Persona_EstadoCivilPaterno];
GO
IF OBJECT_ID(N'[dbo].[FK_Persona_EstudiosCursados]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persona] DROP CONSTRAINT [FK_Persona_EstudiosCursados];
GO
IF OBJECT_ID(N'[dbo].[FK_Persona_IPP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonaIPP] DROP CONSTRAINT [FK_Persona_IPP];
GO
IF OBJECT_ID(N'[dbo].[FK_Persona_Nacionalidad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persona] DROP CONSTRAINT [FK_Persona_Nacionalidad];
GO
IF OBJECT_ID(N'[dbo].[FK_Persona_Provincia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persona] DROP CONSTRAINT [FK_Persona_Provincia];
GO
IF OBJECT_ID(N'[dbo].[FK_Persona_TipoDocumento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persona] DROP CONSTRAINT [FK_Persona_TipoDocumento];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonalPoderJudicial_Persona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonalPoderJudicial] DROP CONSTRAINT [FK_PersonalPoderJudicial_Persona];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonalPoderJudicial_PuntoGestion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonalPoderJudicial] DROP CONSTRAINT [FK_PersonalPoderJudicial_PuntoGestion];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasDesaparecidas_Comisaria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasDesaparecidas] DROP CONSTRAINT [FK_PersonasDesaparecidas_Comisaria];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasDesaparecidas_PBClaseAspectoCabello]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasDesaparecidas] DROP CONSTRAINT [FK_PersonasDesaparecidas_PBClaseAspectoCabello];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasDesaparecidas_PBClaseBoolean]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasDesaparecidas] DROP CONSTRAINT [FK_PersonasDesaparecidas_PBClaseBoolean];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasDesaparecidas_PBClaseBoolean1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasDesaparecidas] DROP CONSTRAINT [FK_PersonasDesaparecidas_PBClaseBoolean1];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasDesaparecidas_PBClaseBoolean2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasDesaparecidas] DROP CONSTRAINT [FK_PersonasDesaparecidas_PBClaseBoolean2];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasDesaparecidas_PBClaseCalvicie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasDesaparecidas] DROP CONSTRAINT [FK_PersonasDesaparecidas_PBClaseCalvicie];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasDesaparecidas_PBClaseColor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasDesaparecidas] DROP CONSTRAINT [FK_PersonasDesaparecidas_PBClaseColor];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasDesaparecidas_PBClaseColorCabello]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasDesaparecidas] DROP CONSTRAINT [FK_PersonasDesaparecidas_PBClaseColorCabello];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasDesaparecidas_PBClaseColorDePiel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasDesaparecidas] DROP CONSTRAINT [FK_PersonasDesaparecidas_PBClaseColorDePiel];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasDesaparecidas_PBClaseColorOjos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasDesaparecidas] DROP CONSTRAINT [FK_PersonasDesaparecidas_PBClaseColorOjos];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasDesaparecidas_PBClaseLongitudCabello]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasDesaparecidas] DROP CONSTRAINT [FK_PersonasDesaparecidas_PBClaseLongitudCabello];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasDesaparecidas_PBClaseOrganismoInterviniente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasDesaparecidas] DROP CONSTRAINT [FK_PersonasDesaparecidas_PBClaseOrganismoInterviniente];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasDesaparecidas_PBClaseRostro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasDesaparecidas] DROP CONSTRAINT [FK_PersonasDesaparecidas_PBClaseRostro];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasDesaparecidas_PBClaseSexo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasDesaparecidas] DROP CONSTRAINT [FK_PersonasDesaparecidas_PBClaseSexo];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasDesaparecidas_PBGrupoSanguineo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasDesaparecidas] DROP CONSTRAINT [FK_PersonasDesaparecidas_PBGrupoSanguineo];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasHalladas_Comisaria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasHalladas] DROP CONSTRAINT [FK_PersonasHalladas_Comisaria];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasHalladas_PBClaseAspectoCabello]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasHalladas] DROP CONSTRAINT [FK_PersonasHalladas_PBClaseAspectoCabello];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasHalladas_PBClaseBoolean]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasHalladas] DROP CONSTRAINT [FK_PersonasHalladas_PBClaseBoolean];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasHalladas_PBClaseBoolean1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasHalladas] DROP CONSTRAINT [FK_PersonasHalladas_PBClaseBoolean1];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasHalladas_PBClaseBoolean2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasHalladas] DROP CONSTRAINT [FK_PersonasHalladas_PBClaseBoolean2];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasHalladas_PBClaseCalvicie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasHalladas] DROP CONSTRAINT [FK_PersonasHalladas_PBClaseCalvicie];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasHalladas_PBClaseColor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasHalladas] DROP CONSTRAINT [FK_PersonasHalladas_PBClaseColor];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasHalladas_PBClaseColorCabello]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasHalladas] DROP CONSTRAINT [FK_PersonasHalladas_PBClaseColorCabello];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasHalladas_PBClaseColorDePiel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasHalladas] DROP CONSTRAINT [FK_PersonasHalladas_PBClaseColorDePiel];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasHalladas_PBClaseColorOjos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasHalladas] DROP CONSTRAINT [FK_PersonasHalladas_PBClaseColorOjos];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasHalladas_PBClaseLongitudCabello]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasHalladas] DROP CONSTRAINT [FK_PersonasHalladas_PBClaseLongitudCabello];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasHalladas_PBClaseOrganismoInterviniente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasHalladas] DROP CONSTRAINT [FK_PersonasHalladas_PBClaseOrganismoInterviniente];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasHalladas_PBClaseRostro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasHalladas] DROP CONSTRAINT [FK_PersonasHalladas_PBClaseRostro];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasHalladas_PBClaseSexo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasHalladas] DROP CONSTRAINT [FK_PersonasHalladas_PBClaseSexo];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonasHalladas_PBGrupoSanguineo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonasHalladas] DROP CONSTRAINT [FK_PersonasHalladas_PBGrupoSanguineo];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonaTipo_ClasePersona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonaTipo] DROP CONSTRAINT [FK_PersonaTipo_ClasePersona];
GO
IF OBJECT_ID(N'[dbo].[FK_PuntoGestion_ClasePuntoGestion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PuntoGestion] DROP CONSTRAINT [FK_PuntoGestion_ClasePuntoGestion];
GO
IF OBJECT_ID(N'[dbo].[FK_PuntoGestion_Departamento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PuntoGestion] DROP CONSTRAINT [FK_PuntoGestion_Departamento];
GO
IF OBJECT_ID(N'[dbo].[FK_PuntoGestion_Localidad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PuntoGestion] DROP CONSTRAINT [FK_PuntoGestion_Localidad];
GO
IF OBJECT_ID(N'[dbo].[FK_PuntoGestion_Pais]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PuntoGestion] DROP CONSTRAINT [FK_PuntoGestion_Pais];
GO
IF OBJECT_ID(N'[dbo].[FK_PuntoGestion_Partido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PuntoGestion] DROP CONSTRAINT [FK_PuntoGestion_Partido];
GO
IF OBJECT_ID(N'[dbo].[FK_PuntoGestion_Provincia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PuntoGestion] DROP CONSTRAINT [FK_PuntoGestion_Provincia];
GO
IF OBJECT_ID(N'[dbo].[FK_PuntoGestion_PuntoGestionPadre]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PuntoGestion] DROP CONSTRAINT [FK_PuntoGestion_PuntoGestionPadre];
GO
IF OBJECT_ID(N'[dbo].[FK_Rastro_NNClaseEstadoInformeRastro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rastros] DROP CONSTRAINT [FK_Rastro_NNClaseEstadoInformeRastro];
GO
IF OBJECT_ID(N'[dbo].[FK_Rastro_NNClaseRastro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rastros] DROP CONSTRAINT [FK_Rastro_NNClaseRastro];
GO
IF OBJECT_ID(N'[dbo].[FK_Rastros_delitos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rastros] DROP CONSTRAINT [FK_Rastros_delitos];
GO
IF OBJECT_ID(N'[dbo].[FK_SeniasParticulares_Autores]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SeniasParticulares] DROP CONSTRAINT [FK_SeniasParticulares_Autores];
GO
IF OBJECT_ID(N'[dbo].[FK_SeniasParticulares_ClaseSeniaParticular]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SeniasParticulares] DROP CONSTRAINT [FK_SeniasParticulares_ClaseSeniaParticular];
GO
IF OBJECT_ID(N'[dbo].[FK_SeniasParticulares_ClaseTipoPersona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SeniasParticulares] DROP CONSTRAINT [FK_SeniasParticulares_ClaseTipoPersona];
GO
IF OBJECT_ID(N'[dbo].[FK_SeniasParticulares_ClaseUbicacionSeniaPart]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SeniasParticulares] DROP CONSTRAINT [FK_SeniasParticulares_ClaseUbicacionSeniaPart];
GO
IF OBJECT_ID(N'[dbo].[FK_SeniasParticulares_Persona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SeniasParticulares] DROP CONSTRAINT [FK_SeniasParticulares_Persona];
GO
IF OBJECT_ID(N'[dbo].[FK_Tatuajes_Autores]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TatuajesPersona] DROP CONSTRAINT [FK_Tatuajes_Autores];
GO
IF OBJECT_ID(N'[dbo].[FK_TatuajesPersona_ClaseTatuaje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TatuajesPersona] DROP CONSTRAINT [FK_TatuajesPersona_ClaseTatuaje];
GO
IF OBJECT_ID(N'[dbo].[FK_TatuajesPersona_ClaseTipoPersona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TatuajesPersona] DROP CONSTRAINT [FK_TatuajesPersona_ClaseTipoPersona];
GO
IF OBJECT_ID(N'[dbo].[FK_TatuajesPersona_ClaseUbicacionSeniaPart]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TatuajesPersona] DROP CONSTRAINT [FK_TatuajesPersona_ClaseUbicacionSeniaPart];
GO
IF OBJECT_ID(N'[dbo].[FK_TatuajesPersona_Persona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TatuajesPersona] DROP CONSTRAINT [FK_TatuajesPersona_Persona];
GO
IF OBJECT_ID(N'[dbo].[FK_tipoPersonaPersona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonaTipo] DROP CONSTRAINT [FK_tipoPersonaPersona];
GO
IF OBJECT_ID(N'[dbo].[FK_Usuarios_GrupoUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_Usuarios_GrupoUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Usuarios_PersonalPoderJudicial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_Usuarios_PersonalPoderJudicial];
GO
IF OBJECT_ID(N'[dbo].[FK_Vehiculo_Bien Sustraido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehiculos] DROP CONSTRAINT [FK_Vehiculo_Bien Sustraido];
GO
IF OBJECT_ID(N'[dbo].[FK_Vehiculo_NNClaseVidrioVehiculo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehiculos] DROP CONSTRAINT [FK_Vehiculo_NNClaseVidrioVehiculo];
GO
IF OBJECT_ID(N'[dbo].[FK_Vehiculo_NNClaseVinculoVehiculo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehiculos] DROP CONSTRAINT [FK_Vehiculo_NNClaseVinculoVehiculo];
GO
IF OBJECT_ID(N'[dbo].[FK_Vehiculos_ColorVehiculo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehiculos] DROP CONSTRAINT [FK_Vehiculos_ColorVehiculo];
GO
IF OBJECT_ID(N'[dbo].[FK_vehiculos_Delitos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehiculos] DROP CONSTRAINT [FK_vehiculos_Delitos];
GO
IF OBJECT_ID(N'[dbo].[FK_Vehiculos_MarcaVehiculo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehiculos] DROP CONSTRAINT [FK_Vehiculos_MarcaVehiculo];
GO
IF OBJECT_ID(N'[dbo].[FK_Vehiculos_ModeloVehiculo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehiculos] DROP CONSTRAINT [FK_Vehiculos_ModeloVehiculo];
GO
IF OBJECT_ID(N'[dbo].[FK_Vehiculos_NNClaseBoolean]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehiculos] DROP CONSTRAINT [FK_Vehiculos_NNClaseBoolean];
GO
IF OBJECT_ID(N'[dbo].[FK_VinculoMenuBusquedaPrincipal_BusquedaPrincipal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VinculoMenuBusquedaPrincipal] DROP CONSTRAINT [FK_VinculoMenuBusquedaPrincipal_BusquedaPrincipal];
GO
IF OBJECT_ID(N'[dbo].[FK_VinculoMenuRecurso_Menu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VinculoMenuRecurso] DROP CONSTRAINT [FK_VinculoMenuRecurso_Menu];
GO
IF OBJECT_ID(N'[dbo].[FK_VinculoMenuRecurso_Recurso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VinculoMenuRecurso] DROP CONSTRAINT [FK_VinculoMenuRecurso_Recurso];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Autores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Autores];
GO
IF OBJECT_ID(N'[dbo].[BienesSustraidos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BienesSustraidos];
GO
IF OBJECT_ID(N'[dbo].[BienesSustraidosAnimal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BienesSustraidosAnimal];
GO
IF OBJECT_ID(N'[dbo].[BienesSustraidosOtro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BienesSustraidosOtro];
GO
IF OBJECT_ID(N'[dbo].[BienSustraidoArma]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BienSustraidoArma];
GO
IF OBJECT_ID(N'[dbo].[BienSustraidoCheque]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BienSustraidoCheque];
GO
IF OBJECT_ID(N'[dbo].[BienSustraidoDinero]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BienSustraidoDinero];
GO
IF OBJECT_ID(N'[dbo].[BienSustraidoTelefono]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BienSustraidoTelefono];
GO
IF OBJECT_ID(N'[dbo].[Busqueda]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Busqueda];
GO
IF OBJECT_ID(N'[dbo].[BusquedaAspectoCabello]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusquedaAspectoCabello];
GO
IF OBJECT_ID(N'[dbo].[BusquedaCalvicie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusquedaCalvicie];
GO
IF OBJECT_ID(N'[dbo].[BusquedaColorCabello]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusquedaColorCabello];
GO
IF OBJECT_ID(N'[dbo].[BusquedaColorOjos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusquedaColorOjos];
GO
IF OBJECT_ID(N'[dbo].[BusquedaColorPiel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusquedaColorPiel];
GO
IF OBJECT_ID(N'[dbo].[BusquedaColorTenido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusquedaColorTenido];
GO
IF OBJECT_ID(N'[dbo].[BusquedaGrupoSanguineo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusquedaGrupoSanguineo];
GO
IF OBJECT_ID(N'[dbo].[BusquedaLongitudCabello]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusquedaLongitudCabello];
GO
IF OBJECT_ID(N'[dbo].[BusquedaPrincipal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusquedaPrincipal];
GO
IF OBJECT_ID(N'[dbo].[BusquedaRobosDelitosSexuales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusquedaRobosDelitosSexuales];
GO
IF OBJECT_ID(N'[dbo].[BusquedaRobosDelitosSexualesComisarias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusquedaRobosDelitosSexualesComisarias];
GO
IF OBJECT_ID(N'[dbo].[BusquedaRobosDelitosSexualesLocalidades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusquedaRobosDelitosSexualesLocalidades];
GO
IF OBJECT_ID(N'[dbo].[BusquedaRobosDelitosSexualesSenias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusquedaRobosDelitosSexualesSenias];
GO
IF OBJECT_ID(N'[dbo].[BusquedaRobosDelitosSexualesTatuajes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusquedaRobosDelitosSexualesTatuajes];
GO
IF OBJECT_ID(N'[dbo].[BusquedaRostro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusquedaRostro];
GO
IF OBJECT_ID(N'[dbo].[BusquedaSeniasParticulares]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusquedaSeniasParticulares];
GO
IF OBJECT_ID(N'[dbo].[BusquedasFavoritas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusquedasFavoritas];
GO
IF OBJECT_ID(N'[dbo].[BusquedaTatuajes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusquedaTatuajes];
GO
IF OBJECT_ID(N'[dbo].[ClaseBajaBusquedaPersonas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClaseBajaBusquedaPersonas];
GO
IF OBJECT_ID(N'[dbo].[ClaseEstadoCivil]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClaseEstadoCivil];
GO
IF OBJECT_ID(N'[dbo].[ClaseEstudiosCursados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClaseEstudiosCursados];
GO
IF OBJECT_ID(N'[dbo].[ClaseMenu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClaseMenu];
GO
IF OBJECT_ID(N'[dbo].[ClasePersona]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClasePersona];
GO
IF OBJECT_ID(N'[dbo].[ClasePuntoGestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClasePuntoGestion];
GO
IF OBJECT_ID(N'[dbo].[ClaseSeniaParticular]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClaseSeniaParticular];
GO
IF OBJECT_ID(N'[dbo].[ClaseSexo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClaseSexo];
GO
IF OBJECT_ID(N'[dbo].[ClaseTatuaje]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClaseTatuaje];
GO
IF OBJECT_ID(N'[dbo].[ClaseTipoPersona]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClaseTipoPersona];
GO
IF OBJECT_ID(N'[dbo].[ClaseUbicacionSeniaPart]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClaseUbicacionSeniaPart];
GO
IF OBJECT_ID(N'[dbo].[ColorVehiculo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ColorVehiculo];
GO
IF OBJECT_ID(N'[dbo].[Comisaria]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comisaria];
GO
IF OBJECT_ID(N'[dbo].[Delitos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Delitos];
GO
IF OBJECT_ID(N'[dbo].[Departamento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departamento];
GO
IF OBJECT_ID(N'[dbo].[Dientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dientes];
GO
IF OBJECT_ID(N'[dbo].[GrupoUsuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GrupoUsuario];
GO
IF OBJECT_ID(N'[dbo].[IPP]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IPP];
GO
IF OBJECT_ID(N'[dbo].[JerarquiaPoderJudicial]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JerarquiaPoderJudicial];
GO
IF OBJECT_ID(N'[dbo].[Localidad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Localidad];
GO
IF OBJECT_ID(N'[dbo].[LugaresDeTrasladoDeVictimas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LugaresDeTrasladoDeVictimas];
GO
IF OBJECT_ID(N'[dbo].[MailsAsociadosPersonasBuscadas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MailsAsociadosPersonasBuscadas];
GO
IF OBJECT_ID(N'[dbo].[MarcaVehiculo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MarcaVehiculo];
GO
IF OBJECT_ID(N'[dbo].[Menu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Menu];
GO
IF OBJECT_ID(N'[dbo].[ModeloVehiculo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ModeloVehiculo];
GO
IF OBJECT_ID(N'[dbo].[NNClaseAgresion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseAgresion];
GO
IF OBJECT_ID(N'[dbo].[NNClaseArma]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseArma];
GO
IF OBJECT_ID(N'[dbo].[NNClaseBienSustraido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseBienSustraido];
GO
IF OBJECT_ID(N'[dbo].[NNClaseBoolean]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseBoolean];
GO
IF OBJECT_ID(N'[dbo].[NNClaseCantAutorReconocidos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseCantAutorReconocidos];
GO
IF OBJECT_ID(N'[dbo].[NNClaseCantidadAutores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseCantidadAutores];
GO
IF OBJECT_ID(N'[dbo].[NNClaseCondicionVictima]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseCondicionVictima];
GO
IF OBJECT_ID(N'[dbo].[NNClaseDiametroArmaFuego]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseDiametroArmaFuego];
GO
IF OBJECT_ID(N'[dbo].[NNClaseEdadAproximada]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseEdadAproximada];
GO
IF OBJECT_ID(N'[dbo].[NNClaseEstadoInformeRastro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseEstadoInformeRastro];
GO
IF OBJECT_ID(N'[dbo].[NNClaseFecha]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseFecha];
GO
IF OBJECT_ID(N'[dbo].[NNClaseGanado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseGanado];
GO
IF OBJECT_ID(N'[dbo].[NNClaseHora]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseHora];
GO
IF OBJECT_ID(N'[dbo].[NNClaseLugar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseLugar];
GO
IF OBJECT_ID(N'[dbo].[NNClaseModoArriboHuida]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseModoArriboHuida];
GO
IF OBJECT_ID(N'[dbo].[NNClaseModusOperandi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseModusOperandi];
GO
IF OBJECT_ID(N'[dbo].[NNClaseMomentoDia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseMomentoDia];
GO
IF OBJECT_ID(N'[dbo].[NNClaseMoneda]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseMoneda];
GO
IF OBJECT_ID(N'[dbo].[NNClaseRastro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseRastro];
GO
IF OBJECT_ID(N'[dbo].[NNClaseRostro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseRostro];
GO
IF OBJECT_ID(N'[dbo].[NNClaseRubro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseRubro];
GO
IF OBJECT_ID(N'[dbo].[NNClaseSexo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseSexo];
GO
IF OBJECT_ID(N'[dbo].[NNClaseSubtipoArma]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseSubtipoArma];
GO
IF OBJECT_ID(N'[dbo].[NNClaseTipoArmaFuego]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseTipoArmaFuego];
GO
IF OBJECT_ID(N'[dbo].[NNClaseTipoAutor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseTipoAutor];
GO
IF OBJECT_ID(N'[dbo].[NNClaseTipoDelito]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseTipoDelito];
GO
IF OBJECT_ID(N'[dbo].[NNClaseVidrioVehiculo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseVidrioVehiculo];
GO
IF OBJECT_ID(N'[dbo].[NNClaseVinculoVehiculo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseVinculoVehiculo];
GO
IF OBJECT_ID(N'[dbo].[NNClaseZonaCuerpoLesionada]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NNClaseZonaCuerpoLesionada];
GO
IF OBJECT_ID(N'[dbo].[Pais]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pais];
GO
IF OBJECT_ID(N'[dbo].[Partido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Partido];
GO
IF OBJECT_ID(N'[dbo].[PBCausaExtranaJurisdiccion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PBCausaExtranaJurisdiccion];
GO
IF OBJECT_ID(N'[dbo].[PBClaseAspectoCabello]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PBClaseAspectoCabello];
GO
IF OBJECT_ID(N'[dbo].[PBClaseBoolean]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PBClaseBoolean];
GO
IF OBJECT_ID(N'[dbo].[PBClaseCalvicie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PBClaseCalvicie];
GO
IF OBJECT_ID(N'[dbo].[PBClaseColor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PBClaseColor];
GO
IF OBJECT_ID(N'[dbo].[PBClaseColorCabello]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PBClaseColorCabello];
GO
IF OBJECT_ID(N'[dbo].[PBClaseColorDePiel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PBClaseColorDePiel];
GO
IF OBJECT_ID(N'[dbo].[PBClaseColorOjos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PBClaseColorOjos];
GO
IF OBJECT_ID(N'[dbo].[PBClaseFoto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PBClaseFoto];
GO
IF OBJECT_ID(N'[dbo].[PBClaseGrupoSanguineo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PBClaseGrupoSanguineo];
GO
IF OBJECT_ID(N'[dbo].[PBClaseLongitudCabello]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PBClaseLongitudCabello];
GO
IF OBJECT_ID(N'[dbo].[PBClaseMotivoHallazgo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PBClaseMotivoHallazgo];
GO
IF OBJECT_ID(N'[dbo].[PBClaseOrganismoInterviniente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PBClaseOrganismoInterviniente];
GO
IF OBJECT_ID(N'[dbo].[PBClaseRostro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PBClaseRostro];
GO
IF OBJECT_ID(N'[dbo].[PBClaseSexo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PBClaseSexo];
GO
IF OBJECT_ID(N'[dbo].[PBClaseTablaDestino]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PBClaseTablaDestino];
GO
IF OBJECT_ID(N'[dbo].[PBClaseTipoJurisdiccionCausa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PBClaseTipoJurisdiccionCausa];
GO
IF OBJECT_ID(N'[dbo].[PermisoGrupo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PermisoGrupo];
GO
IF OBJECT_ID(N'[dbo].[PermisoUsuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PermisoUsuario];
GO
IF OBJECT_ID(N'[dbo].[Persona]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Persona];
GO
IF OBJECT_ID(N'[dbo].[PersonaIPP]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonaIPP];
GO
IF OBJECT_ID(N'[dbo].[PersonalPoderJudicial]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonalPoderJudicial];
GO
IF OBJECT_ID(N'[dbo].[PersonasDesaparecidas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonasDesaparecidas];
GO
IF OBJECT_ID(N'[MPBASIACWebStoreContainer].[PersonasEncontradas]', 'U') IS NOT NULL
    DROP TABLE [MPBASIACWebStoreContainer].[PersonasEncontradas];
GO
IF OBJECT_ID(N'[dbo].[PersonasHalladas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonasHalladas];
GO
IF OBJECT_ID(N'[dbo].[PersonaTipo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonaTipo];
GO
IF OBJECT_ID(N'[MPBASIACWebStoreContainer].[PreguntasFrecuentes]', 'U') IS NOT NULL
    DROP TABLE [MPBASIACWebStoreContainer].[PreguntasFrecuentes];
GO
IF OBJECT_ID(N'[dbo].[Provincia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Provincia];
GO
IF OBJECT_ID(N'[dbo].[PuntoGestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PuntoGestion];
GO
IF OBJECT_ID(N'[dbo].[Rastros]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rastros];
GO
IF OBJECT_ID(N'[dbo].[Recurso]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Recurso];
GO
IF OBJECT_ID(N'[dbo].[SeniasParticulares]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SeniasParticulares];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TatuajesPersona]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TatuajesPersona];
GO
IF OBJECT_ID(N'[dbo].[TPClaseTipoDNI]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TPClaseTipoDNI];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO
IF OBJECT_ID(N'[dbo].[UsuariosBCKUP]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuariosBCKUP];
GO
IF OBJECT_ID(N'[dbo].[Vehiculos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vehiculos];
GO
IF OBJECT_ID(N'[dbo].[VersionDescriptoras]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VersionDescriptoras];
GO
IF OBJECT_ID(N'[dbo].[VinculoMenuBusquedaPrincipal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VinculoMenuBusquedaPrincipal];
GO
IF OBJECT_ID(N'[dbo].[VinculoMenuRecurso]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VinculoMenuRecurso];
GO
IF OBJECT_ID(N'[dbo].[xBusquedaRobosDelitosSexuales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[xBusquedaRobosDelitosSexuales];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Autores'
CREATE TABLE [dbo].[Autores] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idDelito] int  NOT NULL,
    [idCausa] nchar(12)  NOT NULL,
    [Nro] nchar(10)  NULL,
    [idClaseEdadAproximada] int  NULL,
    [idClaseSexo] int  NULL,
    [idClaseRostro] int  NULL,
    [CubiertoCon] nchar(50)  NULL,
    [OtraCaracteristica] nchar(50)  NULL,
    [Baja] bit  NULL,
    [idUsuarioUltimaModificacion] nchar(30)  NULL,
    [FechaUltimaModificacion] datetime  NULL,
    [idImputadoSimp] nchar(14)  NULL,
    [idPersona] int  NULL
);
GO

-- Creating table 'BienesSustraidos'
CREATE TABLE [dbo].[BienesSustraidos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idDelito] int  NOT NULL,
    [idCausa] nchar(12)  NOT NULL,
    [idClaseBienSustraido] int  NULL,
    [Baja] bit  NULL,
    [FechaUltimaModificacion] datetime  NULL,
    [idUsuarioUltimaModificacion] nchar(20)  NULL
);
GO

-- Creating table 'BienesSustraidosAnimals'
CREATE TABLE [dbo].[BienesSustraidosAnimals] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idNNBienSustraido] int  NOT NULL,
    [idClaseGanado] int  NOT NULL,
    [Marca] nchar(20)  NULL,
    [Cantidad] int  NULL,
    [Baja] bit  NULL,
    [idUsuarioUltimaModificacion] nchar(20)  NULL,
    [FechaUltimaModificacion] datetime  NULL
);
GO

-- Creating table 'BienesSustraidosOtroes'
CREATE TABLE [dbo].[BienesSustraidosOtroes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idNNBienSustraido] int  NOT NULL,
    [Marca] nchar(10)  NULL,
    [Cantidad] int  NULL,
    [NroSerie] nchar(50)  NULL,
    [Baja] bit  NULL,
    [idUsuarioUltimaModificacion] nchar(30)  NULL,
    [FechaUltimaModificacion] datetime  NULL
);
GO

-- Creating table 'BienSustraidoArmas'
CREATE TABLE [dbo].[BienSustraidoArmas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idNNBienSustraido] int  NOT NULL,
    [Marca] nchar(10)  NULL,
    [clase_tipo] int  NULL,
    [NroSerie] nchar(50)  NULL,
    [diametro_calibre] int  NULL,
    [Baja] bit  NULL,
    [idUsuarioUltimaModificacion] nchar(30)  NULL,
    [FechaUltimaModificacion] datetime  NULL
);
GO

-- Creating table 'BienSustraidoCheques'
CREATE TABLE [dbo].[BienSustraidoCheques] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idNNBienSustraido] int  NOT NULL,
    [Banco] nchar(50)  NULL,
    [monto] real  NULL,
    [NroSerie] nchar(50)  NULL,
    [idTipoMoneda] int  NULL,
    [descripcionMoneda] nchar(50)  NULL,
    [Baja] bit  NULL,
    [idUsuarioUltimaModificacion] nchar(30)  NULL,
    [FechaUltimaModificacion] datetime  NULL
);
GO

-- Creating table 'BienSustraidoDineroes'
CREATE TABLE [dbo].[BienSustraidoDineroes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idNNBienSustraido] int  NOT NULL,
    [monto] real  NULL,
    [idTipoMoneda] int  NULL,
    [descripcionMoneda] nchar(50)  NULL,
    [Baja] bit  NULL,
    [idUsuarioUltimaModificacion] nchar(30)  NULL,
    [FechaUltimaModificacion] datetime  NULL
);
GO

-- Creating table 'BienSustraidoTelefonoes'
CREATE TABLE [dbo].[BienSustraidoTelefonoes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idNNBienSustraido] int  NOT NULL,
    [Marca] nchar(10)  NULL,
    [Nro] nchar(50)  NULL,
    [NroSerie] nchar(50)  NULL,
    [IMEI] nchar(50)  NULL,
    [Baja] bit  NULL,
    [idUsuarioUltimaModificacion] nchar(30)  NULL,
    [FechaUltimaModificacion] datetime  NULL
);
GO

-- Creating table 'Busquedas'
CREATE TABLE [dbo].[Busquedas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UFI] nchar(50)  NULL,
    [idOrigen] int  NULL,
    [Usuario] nchar(20)  NULL,
    [TablaDestino] nchar(30)  NULL,
    [DNI] nchar(8)  NULL,
    [Apellido] nchar(50)  NULL,
    [Nombre] nchar(50)  NULL,
    [FechaDesde] datetime  NULL,
    [FechaHasta] datetime  NULL,
    [EdadDesde] int  NULL,
    [EdadHasta] int  NULL,
    [idsexo] int  NULL,
    [TallaDesde] real  NULL,
    [TallaHasta] real  NULL,
    [PesoDesde] real  NULL,
    [PesoHasta] real  NULL,
    [FaltanPiezasDentales] int  NULL,
    [CodigoADN] nchar(80)  NULL,
    [CantidadCoincidencias] int  NULL,
    [FechaUltimaCoincidencia] datetime  NULL,
    [idComisariaIntervinoAparcicion] int  NULL,
    [fechaActuaciones] datetime  NULL,
    [idMotivoHallazgo] int  NULL,
    [MotivoHallazgoDescripcion] nchar(100)  NULL,
    [FechaUltimaModificacion] datetime  NULL,
    [UsuarioUltimaModificacion] nchar(50)  NULL,
    [Baja] bit  NULL,
    [IPP] varchar(50)  NULL,
    [TieneADN] int  NULL
);
GO

-- Creating table 'BusquedaAspectoCabelloes'
CREATE TABLE [dbo].[BusquedaAspectoCabelloes] (
    [id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [idBusqueda] int  NULL,
    [idAspectoCabello] int  NULL
);
GO

-- Creating table 'BusquedaCalvicies'
CREATE TABLE [dbo].[BusquedaCalvicies] (
    [id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [idBusqueda] int  NULL,
    [idClaseCalvicie] int  NULL
);
GO

-- Creating table 'BusquedaColorCabelloes'
CREATE TABLE [dbo].[BusquedaColorCabelloes] (
    [id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [idBusqueda] int  NULL,
    [idClaseColorCabello] int  NULL
);
GO

-- Creating table 'BusquedaColorOjos'
CREATE TABLE [dbo].[BusquedaColorOjos] (
    [id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [idBusqueda] int  NULL,
    [idClaseColorOjos] int  NULL
);
GO

-- Creating table 'BusquedaColorPiels'
CREATE TABLE [dbo].[BusquedaColorPiels] (
    [id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [idBusqueda] int  NULL,
    [idClaseColorPiel] int  NULL
);
GO

-- Creating table 'BusquedaColorTenidoes'
CREATE TABLE [dbo].[BusquedaColorTenidoes] (
    [id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [idBusqueda] int  NULL,
    [idClaseColorTenido] int  NULL
);
GO

-- Creating table 'BusquedaGrupoSanguineos'
CREATE TABLE [dbo].[BusquedaGrupoSanguineos] (
    [id] decimal(18,0)  NOT NULL,
    [idBusqueda] int  NULL,
    [idGrupoSanguineo] int  NULL
);
GO

-- Creating table 'BusquedaLongitudCabelloes'
CREATE TABLE [dbo].[BusquedaLongitudCabelloes] (
    [id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [idBusqueda] int  NULL,
    [idClaseLongitudCabello] int  NULL
);
GO

-- Creating table 'BusquedaPrincipals'
CREATE TABLE [dbo].[BusquedaPrincipals] (
    [Id] int  NOT NULL,
    [Descripcion] nchar(50)  NULL,
    [Campo] nchar(50)  NULL,
    [Tabla] nchar(50)  NULL,
    [Tipo] nchar(50)  NULL,
    [IdPadre] nchar(50)  NULL,
    [Orden] int  NULL,
    [Qry] nchar(100)  NULL
);
GO

-- Creating table 'BusquedaRobosDelitosSexuales'
CREATE TABLE [dbo].[BusquedaRobosDelitosSexuales] (
    [id] int IDENTITY(1,1) NOT NULL,
    [HoraDesde] varchar(50)  NULL,
    [HoraHasta] varchar(50)  NULL,
    [ParajeBarrioH] varchar(50)  NULL,
    [IdCalle] varchar(50)  NULL,
    [IdEntreCalle1] varchar(50)  NULL,
    [IdEntreCalle2] varchar(50)  NULL,
    [IdOtraCalle] varchar(50)  NULL,
    [IdOtraEntreCalle] varchar(50)  NULL,
    [IdOtraEntreCalle2] varchar(50)  NULL,
    [NroH] varchar(50)  NULL,
    [PisoH] varchar(50)  NULL,
    [DeptoH] varchar(50)  NULL,
    [IdComisariaH] varchar(50)  NULL,
    [NomReferenciaLugarRubro] varchar(50)  NULL,
    [IdCausa] varchar(50)  NULL,
    [IdMarcaVehiculoMO] varchar(50)  NULL,
    [IdModeloVehiculoMO] varchar(50)  NULL,
    [DominioMO] varchar(50)  NULL,
    [IdColorVehiculoMO] varchar(50)  NULL,
    [IngresaronPor] varchar(50)  NULL,
    [IdLocalidadTraslado] varchar(50)  NULL,
    [IdPartidoL] varchar(50)  NULL,
    [IdLocalidadL] varchar(50)  NULL,
    [ParajeBarrioL] varchar(50)  NULL,
    [IdCalleL] varchar(50)  NULL,
    [IdOtraCalleL] varchar(50)  NULL,
    [IdEntreCalle1L] varchar(50)  NULL,
    [OtraEntreCalle1L] varchar(50)  NULL,
    [IdEntreCalle2L] varchar(50)  NULL,
    [OtraEntreCalle2L] varchar(50)  NULL,
    [IdComisariaL] varchar(50)  NULL,
    [ExprUtilizadaComienzoDelHecho] varchar(50)  NULL,
    [ExprReiteradaDuranteHecho] varchar(50)  NULL,
    [MarcaGanado] varchar(50)  NULL,
    [MarcaBienSustraidoOtro] varchar(50)  NULL,
    [NroSerieBienSustraidoOtro] varchar(50)  NULL,
    [Nro] varchar(50)  NULL,
    [CubiertoCon] varchar(50)  NULL,
    [UbicacionSeniaParticular] varchar(50)  NULL,
    [OtroTatuaje] varchar(50)  NULL,
    [OtraCaracteristica] varchar(50)  NULL,
    [IdMarcaVehiculoBS] varchar(50)  NULL,
    [IdModeloVehiculoBS] varchar(50)  NULL,
    [AnioBS] varchar(50)  NULL,
    [DominioBS] varchar(50)  NULL,
    [IdColorVehiculoBS] varchar(50)  NULL,
    [NumeroMotorBS] varchar(50)  NULL,
    [NumeroChasisBS] varchar(50)  NULL,
    [IdentificacionGNCBS] varchar(50)  NULL,
    [OtraClaseArma] varchar(50)  NULL,
    [IdDepartamento] varchar(50)  NULL,
    [IdDelito] int  NULL,
    [IdClaseDelito] int  NULL,
    [IdClaseModusOperandi] int  NULL,
    [IdClaseMomentoDelDia] int  NULL,
    [IdPartido] varchar(50)  NULL,
    [IdLocalidad] varchar(50)  NULL,
    [IdClaseLugar] int  NULL,
    [IdClaseRubro] int  NULL,
    [IdClaseModoArriboHuida] int  NULL,
    [IdClaseVidrioVehiculoMO] int  NULL,
    [IdClaseAgresion] int  NULL,
    [IdClaseZonaCuerpoLesionada] int  NULL,
    [IdClaseArma] int  NULL,
    [IdClaseCantidadAutores] int  NULL,
    [IdClaseEdadAproximada] int  NULL,
    [IdClaseSexo] int  NULL,
    [IdClaseRostro] int  NULL,
    [IdClaseSeniaParticular] int  NULL,
    [IdClaseLugarDelCuerpo] int  NULL,
    [IdClaseTatuaje] int  NULL,
    [IdClaseBienSustraido] int  NULL,
    [IdClaseVidrioVehiculoBS] int  NULL,
    [IdClaseGanado] int  NULL,
    [CantidadGanado] int  NULL,
    [CantidadBienSustraidoOtro] int  NULL,
    [IdVicTestRecRueda] int  NULL,
    [IdClaseCondicionVictima] int  NULL,
    [FechaDesde] datetime  NULL,
    [FechaHasta] datetime  NULL,
    [VictimasEnElLugar] int  NULL,
    [HuboAgresionFisicaAVictima] int  NULL,
    [VictimaTrasladadaAOtroLugar] int  NULL,
    [UsoDeArmas] int  NULL,
    [GNCBS] int  NULL,
    [MontoTotalEstimadoBienSustraido] decimal(19,4)  NULL,
    [SusceptibleCotejoRastro] bit  NULL,
    [IdClaseRastro] int  NULL,
    [IdClaseEstadoInformeRastro] int  NULL,
    [FechaCreacion] datetime  NOT NULL,
    [IdPuntoGestion] varchar(50)  NOT NULL,
    [DescripcionBusqueda] varchar(250)  NOT NULL,
    [FechaUltimaModificacion] datetime  NOT NULL,
    [UsuarioUltimaModificacion] varchar(50)  NOT NULL,
    [IdTipoAutor] int  NOT NULL,
    [NombreAutor] varchar(50)  NULL,
    [ApellidoAutor] varchar(50)  NULL,
    [DocNroAutor] int  NULL,
    [idClaseSeniaParticularL] varchar(50)  NULL,
    [idClaseTatuajeL] varchar(50)  NULL
);
GO

-- Creating table 'BusquedaRobosDelitosSexualesComisarias'
CREATE TABLE [dbo].[BusquedaRobosDelitosSexualesComisarias] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idBusquedaRoboDS] int  NULL,
    [idComisaria] int  NULL
);
GO

-- Creating table 'BusquedaRobosDelitosSexualesLocalidades'
CREATE TABLE [dbo].[BusquedaRobosDelitosSexualesLocalidades] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idBusquedaRoboDS] int  NULL,
    [idLocalidad] int  NULL
);
GO

-- Creating table 'BusquedaRobosDelitosSexualesSenias'
CREATE TABLE [dbo].[BusquedaRobosDelitosSexualesSenias] (
    [id] int  NOT NULL,
    [idBusquedaRoboDS] int  NULL,
    [idSenia] int  NULL,
    [idLugarSenia] int  NULL
);
GO

-- Creating table 'BusquedaRobosDelitosSexualesTatuajes'
CREATE TABLE [dbo].[BusquedaRobosDelitosSexualesTatuajes] (
    [id] int  NOT NULL,
    [idBusquedaRoboDS] int  NULL,
    [idTatuaje] int  NULL,
    [idLugarTatuaje] int  NULL
);
GO

-- Creating table 'BusquedaRostroes'
CREATE TABLE [dbo].[BusquedaRostroes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idBusqueda] int  NULL,
    [idClaseRostro] int  NULL
);
GO

-- Creating table 'BusquedaSeniasParticulares'
CREATE TABLE [dbo].[BusquedaSeniasParticulares] (
    [id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [idBusqueda] int  NULL,
    [idClaseSeniaParticular] int  NULL,
    [idUbicacionSeniaParticular] int  NULL
);
GO

-- Creating table 'BusquedasFavoritas'
CREATE TABLE [dbo].[BusquedasFavoritas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idPersona] int  NOT NULL,
    [idTablaDestino] int  NOT NULL,
    [Usuario] varchar(50)  NOT NULL
);
GO

-- Creating table 'BusquedaTatuajes'
CREATE TABLE [dbo].[BusquedaTatuajes] (
    [id] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [idBusqueda] int  NULL,
    [IdClaseTatuaje] int  NULL,
    [IdUbicacionTatuaje] int  NULL
);
GO

-- Creating table 'ClaseBajaBusquedaPersonas'
CREATE TABLE [dbo].[ClaseBajaBusquedaPersonas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(100)  NULL
);
GO

-- Creating table 'ClaseEstadoCiviles'
CREATE TABLE [dbo].[ClaseEstadoCiviles] (
    [id] int  NOT NULL,
    [descripcion] varchar(20)  NULL
);
GO

-- Creating table 'ClaseEstudiosCursados'
CREATE TABLE [dbo].[ClaseEstudiosCursados] (
    [id] int  NOT NULL,
    [Descripcion] nchar(50)  NOT NULL,
    [Version] binary(8)  NOT NULL
);
GO

-- Creating table 'ClaseMenus'
CREATE TABLE [dbo].[ClaseMenus] (
    [Id] int  NOT NULL,
    [Descripcion] char(50)  NOT NULL
);
GO

-- Creating table 'ClasePersonas'
CREATE TABLE [dbo].[ClasePersonas] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'ClasePuntoGestions'
CREATE TABLE [dbo].[ClasePuntoGestions] (
    [id] varchar(14)  NOT NULL,
    [Descripcion] varchar(80)  NULL,
    [DescripcionCorta] varchar(10)  NULL,
    [PermiteDenuncia] bit  NULL,
    [ordenMuestra] int  NULL,
    [UsuarioDelSistema] int  NULL,
    [idMinisterio] int  NULL,
    [idClaseCategoria] varchar(14)  NULL,
    [UsaFicha] int  NULL,
    [UsaPapeles] int  NULL
);
GO

-- Creating table 'ClaseSeniaParticulares'
CREATE TABLE [dbo].[ClaseSeniaParticulares] (
    [id] int  NOT NULL,
    [Descripcion] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'ClaseSexos'
CREATE TABLE [dbo].[ClaseSexos] (
    [id] int  NOT NULL,
    [Descripcion] char(50)  NULL,
    [Version] binary(8)  NOT NULL
);
GO

-- Creating table 'ClaseTatuajes'
CREATE TABLE [dbo].[ClaseTatuajes] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'ClaseTipoPersonas'
CREATE TABLE [dbo].[ClaseTipoPersonas] (
    [id] int  NOT NULL,
    [Descripcion] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'ClaseUbicacionSeniaParticulares'
CREATE TABLE [dbo].[ClaseUbicacionSeniaParticulares] (
    [id] int  NOT NULL,
    [Descripcion] nvarchar(80)  NULL
);
GO

-- Creating table 'ColorVehiculoes'
CREATE TABLE [dbo].[ColorVehiculoes] (
    [id] int  NOT NULL,
    [Descripcion] nchar(50)  NULL
);
GO

-- Creating table 'Comisarias'
CREATE TABLE [dbo].[Comisarias] (
    [id] int  NOT NULL,
    [Comisaria1] nchar(200)  NOT NULL,
    [idDepartamento] int  NOT NULL
);
GO

-- Creating table 'Delitos'
CREATE TABLE [dbo].[Delitos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idCausa] nchar(12)  NOT NULL,
    [idClaseDelito] int  NOT NULL,
    [idClaseFecha] int  NULL,
    [FechaDesde] datetime  NULL,
    [FechaHasta] datetime  NULL,
    [idClaseHora] int  NULL,
    [HoraDesde] nchar(10)  NULL,
    [HoraHasta] nchar(10)  NULL,
    [idClaseMomentoDelDia] int  NULL,
    [idPartido] int  NULL,
    [idLocalidad] int  NULL,
    [idCalle] int  NULL,
    [idOtraCalle] nchar(50)  NULL,
    [idEntreCalle1] int  NULL,
    [idOtraEntreCalle] nchar(50)  NULL,
    [idEntreCalle2] int  NULL,
    [idOtraEntreCalle2] nchar(50)  NULL,
    [NroH] nchar(10)  NULL,
    [PisoH] nchar(10)  NULL,
    [DeptoH] nchar(10)  NULL,
    [ParajeBarrioH] nchar(10)  NULL,
    [idComisariaH] int  NULL,
    [idClaseLugar] int  NULL,
    [idClaseRubro] int  NULL,
    [NomRefLugarRubro] nchar(50)  NULL,
    [idClaseModoArriboHuida] int  NULL,
    [idClaseModusOperandis] int  NULL,
    [ExprUtilizadaComienzoDelHecho] nchar(100)  NULL,
    [ExprReiteradaDuranteHecho] nchar(100)  NULL,
    [IngresaronPor] nchar(50)  NULL,
    [VictimasEnElLugar] int  NULL,
    [UsoDeArmas] int  NULL,
    [idClaseArma] int  NULL,
    [idClaseSubtipoArma] smallint  NULL,
    [OtraClaseArma] nchar(50)  NULL,
    [HuboAgresionFisicaAVictima] int  NULL,
    [idClaseAgresion] int  NULL,
    [idClaseZonaCuerpoLesionada] int  NULL,
    [VictimaTrasladadaAOtroLugar] int  NULL,
    [idPartidoL] int  NULL,
    [idLocalidadL] int  NULL,
    [idCalleL] int  NULL,
    [idOtraCalleL] nchar(50)  NULL,
    [idEntreCalle1L] int  NULL,
    [OtraEntreCalle1L] nchar(50)  NULL,
    [idEntreCalle2L] int  NULL,
    [OtraEntreCalle2L] nchar(50)  NULL,
    [ParajeBarrioL] nchar(50)  NULL,
    [idComisariaL] int  NULL,
    [idClaseCantidadAutores] int  NULL,
    [MontoTotalEstimadoBienSustraido] real  NULL,
    [idVicTestRecRueda] int  NULL,
    [idClaseCantAutorReconocidos] int  NULL,
    [idClaseCondicionVictima] int  NULL,
    [Baja] bit  NULL,
    [idUsuarioUltimaModificacion] nchar(20)  NULL,
    [FechaUltimaModificacion] datetime  NULL,
    [idTipoAutor] int  NULL,
    [idUsuarioAlta] varchar(50)  NULL,
    [FechaAlta] datetime  NULL,
    [MotivoBaja] varchar(max)  NULL,
    [FechaBaja] datetime  NULL
);
GO

-- Creating table 'Departamentoes'
CREATE TABLE [dbo].[Departamentoes] (
    [Id] int  NOT NULL,
    [DescripcionCorta] varchar(4)  NULL,
    [MostrarHechoCompleto] bit  NULL,
    [Departamento1] varchar(255)  NULL,
    [IdCorte] int  NULL
);
GO

-- Creating table 'Dientes'
CREATE TABLE [dbo].[Dientes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [idPersona] int  NULL,
    [idDiente] int  NULL,
    [Existe] bit  NULL,
    [FechaUltimaModificacion] datetime  NULL,
    [UsuarioUltimaModificacion] nchar(50)  NULL,
    [Baja] bit  NULL
);
GO

-- Creating table 'GrupoUsuarios'
CREATE TABLE [dbo].[GrupoUsuarios] (
    [id] varchar(14)  NOT NULL,
    [Descripcion] varchar(150)  NOT NULL
);
GO

-- Creating table 'IPPs'
CREATE TABLE [dbo].[IPPs] (
    [id] int IDENTITY(1,1) NOT NULL,
    [IPP1] nchar(12)  NULL,
    [numero] nchar(12)  NULL,
    [caratula] nchar(100)  NULL,
    [UFI] nchar(100)  NULL,
    [TitularUFI] nchar(100)  NULL,
    [ResponsableUFI] nchar(100)  NULL,
    [CambioRadicacion] bit  NULL,
    [idIncompetencia] int  NULL,
    [fechaInicio] datetime  NULL,
    [FechaIncompetencia] datetime  NULL,
    [NuevaIPP] nchar(12)  NULL,
    [idEtapaIPP] int  NULL,
    [idFormaInicio] int  NULL,
    [Referente] nchar(100)  NULL,
    [idReferente] int  NULL,
    [idEstadoIPP] int  NULL,
    [Baja] bit  NULL,
    [UsuarioUltimaModificacion] nchar(50)  NULL,
    [FechaUltimaModificacion] datetime  NULL,
    [FechaCreacion] datetime  NULL,
    [Version] binary(8)  NOT NULL
);
GO

-- Creating table 'JerarquiaPoderJudicials'
CREATE TABLE [dbo].[JerarquiaPoderJudicials] (
    [id] int  NOT NULL,
    [Descripcion] varchar(50)  NOT NULL,
    [Instruye] bit  NULL,
    [Nivel] int  NOT NULL
);
GO

-- Creating table 'Localidades'
CREATE TABLE [dbo].[Localidades] (
    [id] int  NOT NULL,
    [Localidad1] nchar(50)  NULL,
    [Partido] int  NULL,
    [CodigoPostal] nchar(15)  NULL,
    [Provincia] int  NULL
);
GO

-- Creating table 'LugaresDeTrasladoDeVictimas'
CREATE TABLE [dbo].[LugaresDeTrasladoDeVictimas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idCausa] nchar(12)  NOT NULL,
    [idDelito] int  NOT NULL,
    [idLocalidad] int  NULL,
    [Baja] bit  NULL,
    [FechaUltimaModificacion] datetime  NULL,
    [UsuarioUltimaModificacion] nchar(30)  NULL
);
GO

-- Creating table 'MailsAsociadosPersonasBuscadas'
CREATE TABLE [dbo].[MailsAsociadosPersonasBuscadas] (
    [idPersonaBuscada] int  NOT NULL,
    [idTipoPersona] int  NOT NULL,
    [Mail] varchar(150)  NOT NULL,
    [seleccionado] bit  NOT NULL,
    [Apellido] varchar(50)  NOT NULL,
    [Nombre] varchar(50)  NOT NULL,
    [FechaAlta] datetime  NOT NULL,
    [id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'MarcaVehiculoes'
CREATE TABLE [dbo].[MarcaVehiculoes] (
    [id] int  NOT NULL,
    [Descripcion] nchar(50)  NULL
);
GO

-- Creating table 'Menus'
CREATE TABLE [dbo].[Menus] (
    [Id] int  NOT NULL,
    [IdClaseMenu] int  NOT NULL,
    [IdPadre] int  NULL,
    [Descripcion] varchar(100)  NOT NULL,
    [Hint] varchar(100)  NULL,
    [Orden] int  NULL
);
GO

-- Creating table 'ModeloVehiculoes'
CREATE TABLE [dbo].[ModeloVehiculoes] (
    [id] int  NOT NULL,
    [Descripcion] nchar(50)  NULL,
    [idMarcaVehiculo] int  NULL
);
GO

-- Creating table 'NNClaseAgresions'
CREATE TABLE [dbo].[NNClaseAgresions] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseArmas'
CREATE TABLE [dbo].[NNClaseArmas] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseBienSustraidoes'
CREATE TABLE [dbo].[NNClaseBienSustraidoes] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL,
    [tipo] nchar(15)  NULL
);
GO

-- Creating table 'NNClaseBooleans'
CREATE TABLE [dbo].[NNClaseBooleans] (
    [Id] int  NOT NULL,
    [Descripcion] nchar(10)  NULL
);
GO

-- Creating table 'NNClaseCantAutorReconocidos'
CREATE TABLE [dbo].[NNClaseCantAutorReconocidos] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseCantidadAutores'
CREATE TABLE [dbo].[NNClaseCantidadAutores] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseCondicionVictimas'
CREATE TABLE [dbo].[NNClaseCondicionVictimas] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseDiametroArmaFuegoes'
CREATE TABLE [dbo].[NNClaseDiametroArmaFuegoes] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseEdadAproximadas'
CREATE TABLE [dbo].[NNClaseEdadAproximadas] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseEstadoInformeRastroes'
CREATE TABLE [dbo].[NNClaseEstadoInformeRastroes] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseFechas'
CREATE TABLE [dbo].[NNClaseFechas] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseGanadoes'
CREATE TABLE [dbo].[NNClaseGanadoes] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseHoras'
CREATE TABLE [dbo].[NNClaseHoras] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseLugars'
CREATE TABLE [dbo].[NNClaseLugars] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseModoArriboHuidas'
CREATE TABLE [dbo].[NNClaseModoArriboHuidas] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL,
    [esVehiculo] bit  NULL
);
GO

-- Creating table 'NNClaseModusOperandis'
CREATE TABLE [dbo].[NNClaseModusOperandis] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseMomentoDias'
CREATE TABLE [dbo].[NNClaseMomentoDias] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseMonedas'
CREATE TABLE [dbo].[NNClaseMonedas] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseRastroes'
CREATE TABLE [dbo].[NNClaseRastroes] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseRostroes'
CREATE TABLE [dbo].[NNClaseRostroes] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseRubroes'
CREATE TABLE [dbo].[NNClaseRubroes] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL,
    [idClaseLugar] int  NULL
);
GO

-- Creating table 'NNClaseSexoes'
CREATE TABLE [dbo].[NNClaseSexoes] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseSubtipoArmas'
CREATE TABLE [dbo].[NNClaseSubtipoArmas] (
    [id] smallint  NOT NULL,
    [descripcion] nchar(50)  NULL,
    [idClaseArma] int  NULL
);
GO

-- Creating table 'NNClaseTipoArmaFuegoes'
CREATE TABLE [dbo].[NNClaseTipoArmaFuegoes] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseTipoAutors'
CREATE TABLE [dbo].[NNClaseTipoAutors] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseTipoDelitoes'
CREATE TABLE [dbo].[NNClaseTipoDelitoes] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseVidrioVehiculoes'
CREATE TABLE [dbo].[NNClaseVidrioVehiculoes] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseVinculoVehiculos'
CREATE TABLE [dbo].[NNClaseVinculoVehiculos] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'NNClaseZonaCuerpoLesionadas'
CREATE TABLE [dbo].[NNClaseZonaCuerpoLesionadas] (
    [id] int  NOT NULL,
    [descripcion] nchar(50)  NULL
);
GO

-- Creating table 'Paises'
CREATE TABLE [dbo].[Paises] (
    [id] int  NOT NULL,
    [Pais] nchar(50)  NOT NULL,
    [Nacionalidad] nchar(50)  NULL
);
GO

-- Creating table 'Partidos'
CREATE TABLE [dbo].[Partidos] (
    [id] int  NOT NULL,
    [Partido1] nvarchar(50)  NOT NULL,
    [idDepartamento] int  NULL,
    [idProvincia] int  NOT NULL
);
GO

-- Creating table 'PBCausaExtranaJurisdiccions'
CREATE TABLE [dbo].[PBCausaExtranaJurisdiccions] (
    [id] int IDENTITY(1,1) NOT NULL,
    [OrganoRequirente] varchar(150)  NULL,
    [Jurisdiccion] varchar(150)  NULL,
    [Provincia] varchar(150)  NULL,
    [telefono] varchar(150)  NULL,
    [mail] varchar(150)  NULL,
    [caratula] varchar(250)  NULL,
    [idTipoBusqueda] int  NOT NULL,
    [NroCausa] varchar(50)  NOT NULL
);
GO

-- Creating table 'PBClaseAspectoCabelloes'
CREATE TABLE [dbo].[PBClaseAspectoCabelloes] (
    [Id] int  NOT NULL,
    [Descripcion] nchar(15)  NULL
);
GO

-- Creating table 'PBClaseBooleans'
CREATE TABLE [dbo].[PBClaseBooleans] (
    [Id] int  NOT NULL,
    [Descripcion] nchar(15)  NULL
);
GO

-- Creating table 'PBClaseCalvicies'
CREATE TABLE [dbo].[PBClaseCalvicies] (
    [Id] int  NOT NULL,
    [Descripcion] nchar(25)  NULL
);
GO

-- Creating table 'PBClaseColors'
CREATE TABLE [dbo].[PBClaseColors] (
    [Id] int  NOT NULL,
    [Descripcion] nchar(50)  NULL
);
GO

-- Creating table 'PBClaseColorCabelloes'
CREATE TABLE [dbo].[PBClaseColorCabelloes] (
    [Id] int  NOT NULL,
    [Descripcion] nchar(15)  NULL
);
GO

-- Creating table 'PBClaseColorDePiels'
CREATE TABLE [dbo].[PBClaseColorDePiels] (
    [Id] int  NOT NULL,
    [Descirpcion] nchar(15)  NULL
);
GO

-- Creating table 'PBClaseColorOjos'
CREATE TABLE [dbo].[PBClaseColorOjos] (
    [Id] int  NOT NULL,
    [Descripcion] nchar(20)  NULL
);
GO

-- Creating table 'PBClaseFotoes'
CREATE TABLE [dbo].[PBClaseFotoes] (
    [id] int  NOT NULL,
    [tipoFoto] nchar(50)  NULL
);
GO

-- Creating table 'PBClaseGrupoSanguineos'
CREATE TABLE [dbo].[PBClaseGrupoSanguineos] (
    [Id] int  NOT NULL,
    [Descripcion] nchar(25)  NULL
);
GO

-- Creating table 'PBClaseLongitudCabelloes'
CREATE TABLE [dbo].[PBClaseLongitudCabelloes] (
    [Id] int  NOT NULL,
    [Descripcion] nchar(15)  NULL
);
GO

-- Creating table 'PBClaseMotivoHallazgoes'
CREATE TABLE [dbo].[PBClaseMotivoHallazgoes] (
    [Id] int  NOT NULL,
    [Descripcion] nchar(15)  NULL
);
GO

-- Creating table 'PBClaseOrganismoIntervinientes'
CREATE TABLE [dbo].[PBClaseOrganismoIntervinientes] (
    [Id] int  NOT NULL,
    [Descripcion] nchar(15)  NULL
);
GO

-- Creating table 'PBClaseRostroes'
CREATE TABLE [dbo].[PBClaseRostroes] (
    [Id] int  NOT NULL,
    [Descripcion] nchar(15)  NULL
);
GO

-- Creating table 'PBClaseSexoes'
CREATE TABLE [dbo].[PBClaseSexoes] (
    [Id] int  NOT NULL,
    [Descripcion] nchar(15)  NULL
);
GO

-- Creating table 'PBClaseTablaDestinoes'
CREATE TABLE [dbo].[PBClaseTablaDestinoes] (
    [Id] int  NOT NULL,
    [Descripcion] nchar(30)  NULL
);
GO

-- Creating table 'PBClaseTipoJurisdiccionCausas'
CREATE TABLE [dbo].[PBClaseTipoJurisdiccionCausas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Descripcion] varchar(50)  NOT NULL
);
GO

-- Creating table 'PermisoGrupoes'
CREATE TABLE [dbo].[PermisoGrupoes] (
    [idRecurso] varchar(14)  NOT NULL,
    [idGrupoUsuario] varchar(14)  NOT NULL,
    [Lectura] bit  NULL,
    [Escritura] bit  NULL,
    [Creacion] bit  NULL,
    [Eliminacion] bit  NULL,
    [Id] varchar(14)  NOT NULL
);
GO

-- Creating table 'PermisoUsuarios'
CREATE TABLE [dbo].[PermisoUsuarios] (
    [idRecurso] varchar(14)  NOT NULL,
    [idUsuario] varchar(30)  NOT NULL,
    [Lectura] bit  NULL,
    [Escritura] bit  NULL,
    [Creacion] bit  NULL,
    [Eliminacion] bit  NULL,
    [Id] varchar(14)  NOT NULL
);
GO

-- Creating table 'Personas'
CREATE TABLE [dbo].[Personas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(100)  NULL,
    [Apellido] varchar(255)  NOT NULL,
    [Apodo] varchar(100)  NULL,
    [idTipoDNI] int  NULL,
    [DocumentoNumero] int  NULL,
    [Sexo] varchar(50)  NULL,
    [Direccion] varchar(255)  NULL,
    [Telefono] varchar(50)  NULL,
    [EMail] varchar(50)  NULL,
    [FechaNacimiento] datetime  NULL,
    [Localidad] int  NULL,
    [Partido] int  NULL,
    [idProvincia] int  NULL,
    [idCreador] varchar(30)  NULL,
    [colegio] varchar(15)  NULL,
    [Tomo] varchar(15)  NULL,
    [Folio] varchar(15)  NULL,
    [FechaAlta] datetime  NULL,
    [PersonalPoderJudicial] int  NULL,
    [activo] bit  NULL,
    [Muerto] bit  NULL,
    [idEstadoCivil] int  NULL,
    [profesion] varchar(25)  NULL,
    [LugarNacimiento] varchar(30)  NULL,
    [idNacionalidad] int  NULL,
    [Padre] varchar(50)  NULL,
    [Madre] varchar(50)  NULL,
    [ProfesionPadre] varchar(25)  NULL,
    [ProfesionMadre] varchar(25)  NULL,
    [Conyuge] varchar(50)  NULL,
    [NumeroIRNR] varchar(20)  NULL,
    [NumeroIDAPMS] varchar(20)  NULL,
    [DefensorParticular] varchar(50)  NULL,
    [Edad] smallint  NULL,
    [IdEstadoCivilMaterno] int  NOT NULL,
    [IdEstadoCivilPaterno] int  NOT NULL,
    [idTipoPersona] int  NULL,
    [EstudiosCursados] int  NULL,
    [idSexo] int  NULL,
    [Version] binary(8)  NULL
);
GO

-- Creating table 'PersonaIPPs'
CREATE TABLE [dbo].[PersonaIPPs] (
    [id] int  NOT NULL,
    [idIPP] int  NOT NULL,
    [idPersona] int  NOT NULL
);
GO

-- Creating table 'PersonalPoderJudicials'
CREATE TABLE [dbo].[PersonalPoderJudicials] (
    [id] varchar(14)  NOT NULL,
    [idPersona] int  NOT NULL,
    [idJerarquia] int  NOT NULL,
    [idPuntoGestion] varchar(14)  NOT NULL,
    [fechaDesde] datetime  NULL,
    [fechaHasta] datetime  NULL,
    [activo] bit  NULL,
    [Instruye] bit  NULL
);
GO

-- Creating table 'PersonasDesaparecidas'
CREATE TABLE [dbo].[PersonasDesaparecidas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ipp] nchar(12)  NULL,
    [UFI] nchar(50)  NULL,
    [idOrganismoInterviniente] int  NULL,
    [idComisaria] int  NULL,
    [DNI] nchar(8)  NULL,
    [Apellido] nchar(50)  NULL,
    [Nombre] nchar(50)  NULL,
    [idLugarDesaparicion] int  NULL,
    [FechaDesaparicion] datetime  NULL,
    [idSexo] int  NULL,
    [FechaNacimiento] datetime  NULL,
    [EdadMomentoDesaparicion] int  NULL,
    [Talla] real  NULL,
    [Peso] real  NULL,
    [idColorPiel] int  NULL,
    [idColorCabello] int  NULL,
    [idColorTenido] int  NULL,
    [idLongitudCabello] int  NULL,
    [idAspectoCabello] int  NULL,
    [idCalvicie] int  NULL,
    [idColorOjos] int  NULL,
    [idRostro] int  NULL,
    [CantidadDiasNoAfeitado] int  NULL,
    [FaltanPiezasDentales] int  NULL,
    [idDentadura] int  NULL,
    [tieneADN] int  NULL,
    [ADN] nchar(80)  NULL,
    [idGrupoSanguineo] int  NULL,
    [Foto] int  NULL,
    [FichasDactilares] int  NULL,
    [Ropa] nchar(100)  NULL,
    [ArticulosPersonales] nchar(100)  NULL,
    [ExistenRadiografia] int  NULL,
    [idBusqueda] int  NULL,
    [FechaUltimaModificacion] datetime  NULL,
    [UsuarioUltimaModificacion] nchar(50)  NULL,
    [Baja] bit  NULL,
    [UsuarioAlta] varchar(50)  NOT NULL,
    [FechaAlta] datetime  NOT NULL,
    [esExtJurisdiccion] bit  NOT NULL,
    [MotivoDeBaja] int  NULL,
    [FechaDeBaja] datetime  NULL,
    [idTipoDNI] int  NULL
);
GO

-- Creating table 'PersonasEncontradas'
CREATE TABLE [dbo].[PersonasEncontradas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [IppHallada_] nchar(12)  NOT NULL,
    [IppDesaparecida_] nchar(12)  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Usuario] nchar(50)  NOT NULL,
    [IppOrigen] int  NOT NULL
);
GO

-- Creating table 'PersonasHalladas'
CREATE TABLE [dbo].[PersonasHalladas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ipp] nchar(12)  NULL,
    [UFI] nchar(50)  NULL,
    [DNI] nchar(8)  NULL,
    [Apellido] nchar(50)  NULL,
    [Nombre] nchar(50)  NULL,
    [idOrganismoInterviniente] int  NULL,
    [idComisaria] int  NULL,
    [idLugarHallazgo] int  NULL,
    [FechaHallazgo] datetime  NULL,
    [idSexo] int  NULL,
    [EdadAparente] int  NULL,
    [EdadCientifica] int  NULL,
    [Talla] real  NULL,
    [Peso] real  NULL,
    [idColorPiel] int  NULL,
    [idColorCabello] int  NULL,
    [idColorTenido] int  NULL,
    [idLongitudCabello] int  NULL,
    [idAspectoCabello] int  NULL,
    [idCalvicie] int  NULL,
    [idColorOjos] int  NULL,
    [idRostro] int  NULL,
    [CantidadDiasNoAfeitado] int  NULL,
    [FaltanPiezasDentales] int  NULL,
    [idDentadura] int  NULL,
    [tieneADN] int  NULL,
    [ADN] nchar(80)  NULL,
    [idGrupoSanguineo] int  NULL,
    [Foto] int  NULL,
    [FichasDactilares] int  NULL,
    [Ropa] nchar(100)  NULL,
    [ArticulosPersonales] nchar(100)  NULL,
    [ExistenRadiografia] int  NULL,
    [Vive] int  NULL,
    [idBusqueda] int  NULL,
    [FechaUltimaModificacion] datetime  NULL,
    [UsuarioUltimaModificacion] nchar(50)  NULL,
    [Baja] bit  NULL,
    [UsuarioAlta] varchar(50)  NOT NULL,
    [FechaAlta] datetime  NOT NULL,
    [esExtJurisdiccion] bit  NOT NULL,
    [RestosOseos] bit  NOT NULL,
    [MotivoDeBaja] int  NULL,
    [FechaDeBaja] datetime  NULL,
    [idTipoDNI] int  NULL
);
GO

-- Creating table 'PersonaTipoes'
CREATE TABLE [dbo].[PersonaTipoes] (
    [id] int  NOT NULL,
    [idPersona] int  NOT NULL,
    [idClasePersona] int  NOT NULL,
    [Version] binary(8)  NOT NULL,
    [FechaAlta] datetime  NOT NULL,
    [Usuario] varchar(50)  NULL
);
GO

-- Creating table 'PreguntasFrecuentes'
CREATE TABLE [dbo].[PreguntasFrecuentes] (
    [id] int  NOT NULL,
    [pregunta] bit  NOT NULL,
    [texto] nvarchar(max)  NOT NULL,
    [grupo] int  NOT NULL
);
GO

-- Creating table 'Provincias'
CREATE TABLE [dbo].[Provincias] (
    [id] int  NOT NULL,
    [Provincia1] nchar(50)  NOT NULL
);
GO

-- Creating table 'PuntoGestions'
CREATE TABLE [dbo].[PuntoGestions] (
    [id] varchar(14)  NOT NULL,
    [idClasePuntoGestion] varchar(14)  NULL,
    [Descripcion] varchar(255)  NULL,
    [Numero] int  NULL,
    [Externo] bit  NULL,
    [idPais] int  NULL,
    [idProvincia] int  NULL,
    [idDepartamento] int  NOT NULL,
    [idLocalidad] int  NULL,
    [idPartido] int  NULL,
    [Direccion] varchar(255)  NULL,
    [Telefonos] varchar(255)  NULL,
    [DescripcionCorta] varchar(10)  NULL,
    [OrdenMuestra] int  NULL,
    [titular] varchar(255)  NULL,
    [idDescentralizada] int  NULL,
    [activo] bit  NOT NULL,
    [Email] varchar(50)  NULL,
    [idPadrePG] varchar(14)  NULL,
    [IdTitular] varchar(14)  NULL,
    [codi_Corte] nvarchar(10)  NULL,
    [area_Corte] smallint  NULL,
    [idClaseMarca] int  NULL
);
GO

-- Creating table 'Rastros'
CREATE TABLE [dbo].[Rastros] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idDelito] int  NOT NULL,
    [idCausa] nchar(12)  NOT NULL,
    [idClaseRastro] int  NULL,
    [idClaseEstadoInformeRastro] int  NULL,
    [SusceptibleCotejoRastro] bit  NULL,
    [Descripcion] nchar(50)  NULL,
    [Baja] bit  NULL,
    [idUsuarioUltimaModificacion] nchar(20)  NULL,
    [FechaUltimaModificacion] datetime  NULL
);
GO

-- Creating table 'Recursoes'
CREATE TABLE [dbo].[Recursoes] (
    [id] varchar(14)  NOT NULL,
    [Descripcion] varchar(50)  NOT NULL,
    [Detalle] varchar(max)  NULL
);
GO

-- Creating table 'SeniasParticulares'
CREATE TABLE [dbo].[SeniasParticulares] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idPersona] int  NULL,
    [idSeniaParticular] int  NULL,
    [idUbicacionSeniaParticular] int  NULL,
    [idTablaDestino] int  NULL,
    [descripcion] nchar(255)  NULL,
    [idAutor] int  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TatuajesPersonas'
CREATE TABLE [dbo].[TatuajesPersonas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idPersona] int  NULL,
    [idTablaDestino] int  NOT NULL,
    [idTatuaje] int  NOT NULL,
    [idUbicacionTatuaje] int  NOT NULL,
    [descripcion] nchar(255)  NULL,
    [idAutor] int  NULL
);
GO

-- Creating table 'TPClaseTipoDNIs'
CREATE TABLE [dbo].[TPClaseTipoDNIs] (
    [id] int  NOT NULL,
    [Descripcion] nchar(50)  NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [id] varchar(30)  NOT NULL,
    [idPersonalPoderJudicial] varchar(14)  NOT NULL,
    [NombreUsuario] varchar(30)  NOT NULL,
    [ClaveUsuario] varchar(30)  NULL,
    [idGrupoUsuario] varchar(14)  NULL,
    [activo] bit  NULL,
    [Actividad] datetime  NULL,
    [version] varchar(15)  NULL,
    [bitacoraMemoria] bit  NULL,
    [MargenArriba] smallint  NULL,
    [MargenIzquierda] smallint  NULL,
    [MargenAbajo] smallint  NULL,
    [MargenDerecha] smallint  NULL,
    [EsReferenteTrata] bit  NULL
);
GO

-- Creating table 'UsuariosBCKUPs'
CREATE TABLE [dbo].[UsuariosBCKUPs] (
    [id] varchar(30)  NOT NULL,
    [idPersonalPoderJudicial] varchar(14)  NOT NULL,
    [NombreUsuario] varchar(30)  NOT NULL,
    [ClaveUsuario] varchar(30)  NULL,
    [idGrupoUsuario] varchar(14)  NULL,
    [activo] bit  NULL,
    [Actividad] datetime  NULL,
    [version] varchar(15)  NULL,
    [bitacoraMemoria] bit  NULL,
    [MargenArriba] smallint  NULL,
    [MargenIzquierda] smallint  NULL,
    [MargenAbajo] smallint  NULL,
    [MargenDerecha] smallint  NULL,
    [EsReferenteTrata] bit  NULL
);
GO

-- Creating table 'Vehiculos'
CREATE TABLE [dbo].[Vehiculos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idBienSustraido] int  NULL,
    [idDelito] int  NOT NULL,
    [idCausa] nchar(12)  NOT NULL,
    [idClaseVinculoVehiculo] int  NULL,
    [idMarcaVehiculo] int  NULL,
    [idModeloVehiculo] int  NULL,
    [Dominio] nchar(10)  NULL,
    [NumeroChasis] nchar(50)  NULL,
    [NumeroMotor] nchar(50)  NULL,
    [idColorVehiculo] int  NULL,
    [anio] nchar(4)  NULL,
    [GNC] int  NULL,
    [IdentificacionGNC] nchar(30)  NULL,
    [idClaseVidrioVehiculo] int  NULL,
    [Baja] bit  NULL,
    [idUsuarioUltimaModificacion] nchar(30)  NULL,
    [FechaUltimaModificacion] datetime  NULL
);
GO

-- Creating table 'VersionDescriptoras'
CREATE TABLE [dbo].[VersionDescriptoras] (
    [Version] int  NULL,
    [Tabla] nchar(50)  NOT NULL
);
GO

-- Creating table 'VinculoMenuBusquedaPrincipals'
CREATE TABLE [dbo].[VinculoMenuBusquedaPrincipals] (
    [Id] int  NOT NULL,
    [IdMenu] int  NULL,
    [IdBusquedaPrincipal] int  NULL,
    [Orden] int  NULL
);
GO

-- Creating table 'VinculoMenuRecursoes'
CREATE TABLE [dbo].[VinculoMenuRecursoes] (
    [Id] varchar(14)  NOT NULL,
    [IdMenu] int  NOT NULL,
    [IdRecurso] varchar(14)  NOT NULL,
    [PermisoRecurso] int  NULL,
    [Url] varchar(200)  NULL,
    [Criterio] varchar(max)  NULL
);
GO

-- Creating table 'xBusquedaRobosDelitosSexuales'
CREATE TABLE [dbo].[xBusquedaRobosDelitosSexuales] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idClaseDelito] int  NULL,
    [Departamento] int  NULL,
    [idPuntoGestion] varchar(14)  NULL,
    [FechaDesde] datetime  NULL,
    [FechaHasta] datetime  NULL,
    [idClaseLugar] int  NULL,
    [idClaseRubro] int  NULL,
    [idClaseModusOperandi] int  NULL,
    [idClaseModoArriboHuida] int  NULL,
    [idVictimasEnElLugar] int  NULL,
    [idUsoArmas] int  NULL,
    [idClaseArma] int  NULL,
    [idClaseSubtipoArma] int  NULL,
    [idHuboAgresionFisica] int  NULL,
    [idClaseCantidadAutores] int  NULL,
    [Baja] bit  NULL,
    [UsuarioUltimaModificacion] nchar(20)  NULL,
    [FechaUltimaModificacion] datetime  NULL,
    [FechaCreacion] datetime  NULL,
    [DescripcionBusqueda] varchar(250)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Autores'
ALTER TABLE [dbo].[Autores]
ADD CONSTRAINT [PK_Autores]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BienesSustraidos'
ALTER TABLE [dbo].[BienesSustraidos]
ADD CONSTRAINT [PK_BienesSustraidos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BienesSustraidosAnimals'
ALTER TABLE [dbo].[BienesSustraidosAnimals]
ADD CONSTRAINT [PK_BienesSustraidosAnimals]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BienesSustraidosOtroes'
ALTER TABLE [dbo].[BienesSustraidosOtroes]
ADD CONSTRAINT [PK_BienesSustraidosOtroes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BienSustraidoArmas'
ALTER TABLE [dbo].[BienSustraidoArmas]
ADD CONSTRAINT [PK_BienSustraidoArmas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BienSustraidoCheques'
ALTER TABLE [dbo].[BienSustraidoCheques]
ADD CONSTRAINT [PK_BienSustraidoCheques]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BienSustraidoDineroes'
ALTER TABLE [dbo].[BienSustraidoDineroes]
ADD CONSTRAINT [PK_BienSustraidoDineroes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BienSustraidoTelefonoes'
ALTER TABLE [dbo].[BienSustraidoTelefonoes]
ADD CONSTRAINT [PK_BienSustraidoTelefonoes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'Busquedas'
ALTER TABLE [dbo].[Busquedas]
ADD CONSTRAINT [PK_Busquedas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'BusquedaAspectoCabelloes'
ALTER TABLE [dbo].[BusquedaAspectoCabelloes]
ADD CONSTRAINT [PK_BusquedaAspectoCabelloes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BusquedaCalvicies'
ALTER TABLE [dbo].[BusquedaCalvicies]
ADD CONSTRAINT [PK_BusquedaCalvicies]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BusquedaColorCabelloes'
ALTER TABLE [dbo].[BusquedaColorCabelloes]
ADD CONSTRAINT [PK_BusquedaColorCabelloes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BusquedaColorOjos'
ALTER TABLE [dbo].[BusquedaColorOjos]
ADD CONSTRAINT [PK_BusquedaColorOjos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BusquedaColorPiels'
ALTER TABLE [dbo].[BusquedaColorPiels]
ADD CONSTRAINT [PK_BusquedaColorPiels]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BusquedaColorTenidoes'
ALTER TABLE [dbo].[BusquedaColorTenidoes]
ADD CONSTRAINT [PK_BusquedaColorTenidoes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BusquedaGrupoSanguineos'
ALTER TABLE [dbo].[BusquedaGrupoSanguineos]
ADD CONSTRAINT [PK_BusquedaGrupoSanguineos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BusquedaLongitudCabelloes'
ALTER TABLE [dbo].[BusquedaLongitudCabelloes]
ADD CONSTRAINT [PK_BusquedaLongitudCabelloes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'BusquedaPrincipals'
ALTER TABLE [dbo].[BusquedaPrincipals]
ADD CONSTRAINT [PK_BusquedaPrincipals]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'BusquedaRobosDelitosSexuales'
ALTER TABLE [dbo].[BusquedaRobosDelitosSexuales]
ADD CONSTRAINT [PK_BusquedaRobosDelitosSexuales]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BusquedaRobosDelitosSexualesComisarias'
ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesComisarias]
ADD CONSTRAINT [PK_BusquedaRobosDelitosSexualesComisarias]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BusquedaRobosDelitosSexualesLocalidades'
ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesLocalidades]
ADD CONSTRAINT [PK_BusquedaRobosDelitosSexualesLocalidades]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BusquedaRobosDelitosSexualesSenias'
ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesSenias]
ADD CONSTRAINT [PK_BusquedaRobosDelitosSexualesSenias]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BusquedaRobosDelitosSexualesTatuajes'
ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesTatuajes]
ADD CONSTRAINT [PK_BusquedaRobosDelitosSexualesTatuajes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BusquedaRostroes'
ALTER TABLE [dbo].[BusquedaRostroes]
ADD CONSTRAINT [PK_BusquedaRostroes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BusquedaSeniasParticulares'
ALTER TABLE [dbo].[BusquedaSeniasParticulares]
ADD CONSTRAINT [PK_BusquedaSeniasParticulares]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [idPersona], [idTablaDestino] in table 'BusquedasFavoritas'
ALTER TABLE [dbo].[BusquedasFavoritas]
ADD CONSTRAINT [PK_BusquedasFavoritas]
    PRIMARY KEY CLUSTERED ([idPersona], [idTablaDestino] ASC);
GO

-- Creating primary key on [id] in table 'BusquedaTatuajes'
ALTER TABLE [dbo].[BusquedaTatuajes]
ADD CONSTRAINT [PK_BusquedaTatuajes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ClaseBajaBusquedaPersonas'
ALTER TABLE [dbo].[ClaseBajaBusquedaPersonas]
ADD CONSTRAINT [PK_ClaseBajaBusquedaPersonas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ClaseEstadoCiviles'
ALTER TABLE [dbo].[ClaseEstadoCiviles]
ADD CONSTRAINT [PK_ClaseEstadoCiviles]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ClaseEstudiosCursados'
ALTER TABLE [dbo].[ClaseEstudiosCursados]
ADD CONSTRAINT [PK_ClaseEstudiosCursados]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'ClaseMenus'
ALTER TABLE [dbo].[ClaseMenus]
ADD CONSTRAINT [PK_ClaseMenus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'ClasePersonas'
ALTER TABLE [dbo].[ClasePersonas]
ADD CONSTRAINT [PK_ClasePersonas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ClasePuntoGestions'
ALTER TABLE [dbo].[ClasePuntoGestions]
ADD CONSTRAINT [PK_ClasePuntoGestions]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ClaseSeniaParticulares'
ALTER TABLE [dbo].[ClaseSeniaParticulares]
ADD CONSTRAINT [PK_ClaseSeniaParticulares]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ClaseSexos'
ALTER TABLE [dbo].[ClaseSexos]
ADD CONSTRAINT [PK_ClaseSexos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ClaseTatuajes'
ALTER TABLE [dbo].[ClaseTatuajes]
ADD CONSTRAINT [PK_ClaseTatuajes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ClaseTipoPersonas'
ALTER TABLE [dbo].[ClaseTipoPersonas]
ADD CONSTRAINT [PK_ClaseTipoPersonas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ClaseUbicacionSeniaParticulares'
ALTER TABLE [dbo].[ClaseUbicacionSeniaParticulares]
ADD CONSTRAINT [PK_ClaseUbicacionSeniaParticulares]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ColorVehiculoes'
ALTER TABLE [dbo].[ColorVehiculoes]
ADD CONSTRAINT [PK_ColorVehiculoes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Comisarias'
ALTER TABLE [dbo].[Comisarias]
ADD CONSTRAINT [PK_Comisarias]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [PK_Delitos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'Departamentoes'
ALTER TABLE [dbo].[Departamentoes]
ADD CONSTRAINT [PK_Departamentoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Dientes'
ALTER TABLE [dbo].[Dientes]
ADD CONSTRAINT [PK_Dientes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'GrupoUsuarios'
ALTER TABLE [dbo].[GrupoUsuarios]
ADD CONSTRAINT [PK_GrupoUsuarios]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'IPPs'
ALTER TABLE [dbo].[IPPs]
ADD CONSTRAINT [PK_IPPs]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'JerarquiaPoderJudicials'
ALTER TABLE [dbo].[JerarquiaPoderJudicials]
ADD CONSTRAINT [PK_JerarquiaPoderJudicials]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Localidades'
ALTER TABLE [dbo].[Localidades]
ADD CONSTRAINT [PK_Localidades]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'LugaresDeTrasladoDeVictimas'
ALTER TABLE [dbo].[LugaresDeTrasladoDeVictimas]
ADD CONSTRAINT [PK_LugaresDeTrasladoDeVictimas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'MailsAsociadosPersonasBuscadas'
ALTER TABLE [dbo].[MailsAsociadosPersonasBuscadas]
ADD CONSTRAINT [PK_MailsAsociadosPersonasBuscadas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'MarcaVehiculoes'
ALTER TABLE [dbo].[MarcaVehiculoes]
ADD CONSTRAINT [PK_MarcaVehiculoes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'Menus'
ALTER TABLE [dbo].[Menus]
ADD CONSTRAINT [PK_Menus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'ModeloVehiculoes'
ALTER TABLE [dbo].[ModeloVehiculoes]
ADD CONSTRAINT [PK_ModeloVehiculoes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseAgresions'
ALTER TABLE [dbo].[NNClaseAgresions]
ADD CONSTRAINT [PK_NNClaseAgresions]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseArmas'
ALTER TABLE [dbo].[NNClaseArmas]
ADD CONSTRAINT [PK_NNClaseArmas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseBienSustraidoes'
ALTER TABLE [dbo].[NNClaseBienSustraidoes]
ADD CONSTRAINT [PK_NNClaseBienSustraidoes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'NNClaseBooleans'
ALTER TABLE [dbo].[NNClaseBooleans]
ADD CONSTRAINT [PK_NNClaseBooleans]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseCantAutorReconocidos'
ALTER TABLE [dbo].[NNClaseCantAutorReconocidos]
ADD CONSTRAINT [PK_NNClaseCantAutorReconocidos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseCantidadAutores'
ALTER TABLE [dbo].[NNClaseCantidadAutores]
ADD CONSTRAINT [PK_NNClaseCantidadAutores]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseCondicionVictimas'
ALTER TABLE [dbo].[NNClaseCondicionVictimas]
ADD CONSTRAINT [PK_NNClaseCondicionVictimas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseDiametroArmaFuegoes'
ALTER TABLE [dbo].[NNClaseDiametroArmaFuegoes]
ADD CONSTRAINT [PK_NNClaseDiametroArmaFuegoes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseEdadAproximadas'
ALTER TABLE [dbo].[NNClaseEdadAproximadas]
ADD CONSTRAINT [PK_NNClaseEdadAproximadas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseEstadoInformeRastroes'
ALTER TABLE [dbo].[NNClaseEstadoInformeRastroes]
ADD CONSTRAINT [PK_NNClaseEstadoInformeRastroes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseFechas'
ALTER TABLE [dbo].[NNClaseFechas]
ADD CONSTRAINT [PK_NNClaseFechas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseGanadoes'
ALTER TABLE [dbo].[NNClaseGanadoes]
ADD CONSTRAINT [PK_NNClaseGanadoes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseHoras'
ALTER TABLE [dbo].[NNClaseHoras]
ADD CONSTRAINT [PK_NNClaseHoras]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseLugars'
ALTER TABLE [dbo].[NNClaseLugars]
ADD CONSTRAINT [PK_NNClaseLugars]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseModoArriboHuidas'
ALTER TABLE [dbo].[NNClaseModoArriboHuidas]
ADD CONSTRAINT [PK_NNClaseModoArriboHuidas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseModusOperandis'
ALTER TABLE [dbo].[NNClaseModusOperandis]
ADD CONSTRAINT [PK_NNClaseModusOperandis]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseMomentoDias'
ALTER TABLE [dbo].[NNClaseMomentoDias]
ADD CONSTRAINT [PK_NNClaseMomentoDias]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseMonedas'
ALTER TABLE [dbo].[NNClaseMonedas]
ADD CONSTRAINT [PK_NNClaseMonedas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseRastroes'
ALTER TABLE [dbo].[NNClaseRastroes]
ADD CONSTRAINT [PK_NNClaseRastroes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseRostroes'
ALTER TABLE [dbo].[NNClaseRostroes]
ADD CONSTRAINT [PK_NNClaseRostroes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseRubroes'
ALTER TABLE [dbo].[NNClaseRubroes]
ADD CONSTRAINT [PK_NNClaseRubroes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseSexoes'
ALTER TABLE [dbo].[NNClaseSexoes]
ADD CONSTRAINT [PK_NNClaseSexoes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseSubtipoArmas'
ALTER TABLE [dbo].[NNClaseSubtipoArmas]
ADD CONSTRAINT [PK_NNClaseSubtipoArmas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseTipoArmaFuegoes'
ALTER TABLE [dbo].[NNClaseTipoArmaFuegoes]
ADD CONSTRAINT [PK_NNClaseTipoArmaFuegoes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseTipoAutors'
ALTER TABLE [dbo].[NNClaseTipoAutors]
ADD CONSTRAINT [PK_NNClaseTipoAutors]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseTipoDelitoes'
ALTER TABLE [dbo].[NNClaseTipoDelitoes]
ADD CONSTRAINT [PK_NNClaseTipoDelitoes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseVidrioVehiculoes'
ALTER TABLE [dbo].[NNClaseVidrioVehiculoes]
ADD CONSTRAINT [PK_NNClaseVidrioVehiculoes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseVinculoVehiculos'
ALTER TABLE [dbo].[NNClaseVinculoVehiculos]
ADD CONSTRAINT [PK_NNClaseVinculoVehiculos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'NNClaseZonaCuerpoLesionadas'
ALTER TABLE [dbo].[NNClaseZonaCuerpoLesionadas]
ADD CONSTRAINT [PK_NNClaseZonaCuerpoLesionadas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Paises'
ALTER TABLE [dbo].[Paises]
ADD CONSTRAINT [PK_Paises]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Partidos'
ALTER TABLE [dbo].[Partidos]
ADD CONSTRAINT [PK_Partidos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'PBCausaExtranaJurisdiccions'
ALTER TABLE [dbo].[PBCausaExtranaJurisdiccions]
ADD CONSTRAINT [PK_PBCausaExtranaJurisdiccions]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'PBClaseAspectoCabelloes'
ALTER TABLE [dbo].[PBClaseAspectoCabelloes]
ADD CONSTRAINT [PK_PBClaseAspectoCabelloes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PBClaseBooleans'
ALTER TABLE [dbo].[PBClaseBooleans]
ADD CONSTRAINT [PK_PBClaseBooleans]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PBClaseCalvicies'
ALTER TABLE [dbo].[PBClaseCalvicies]
ADD CONSTRAINT [PK_PBClaseCalvicies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PBClaseColors'
ALTER TABLE [dbo].[PBClaseColors]
ADD CONSTRAINT [PK_PBClaseColors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PBClaseColorCabelloes'
ALTER TABLE [dbo].[PBClaseColorCabelloes]
ADD CONSTRAINT [PK_PBClaseColorCabelloes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PBClaseColorDePiels'
ALTER TABLE [dbo].[PBClaseColorDePiels]
ADD CONSTRAINT [PK_PBClaseColorDePiels]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PBClaseColorOjos'
ALTER TABLE [dbo].[PBClaseColorOjos]
ADD CONSTRAINT [PK_PBClaseColorOjos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'PBClaseFotoes'
ALTER TABLE [dbo].[PBClaseFotoes]
ADD CONSTRAINT [PK_PBClaseFotoes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'PBClaseGrupoSanguineos'
ALTER TABLE [dbo].[PBClaseGrupoSanguineos]
ADD CONSTRAINT [PK_PBClaseGrupoSanguineos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PBClaseLongitudCabelloes'
ALTER TABLE [dbo].[PBClaseLongitudCabelloes]
ADD CONSTRAINT [PK_PBClaseLongitudCabelloes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PBClaseMotivoHallazgoes'
ALTER TABLE [dbo].[PBClaseMotivoHallazgoes]
ADD CONSTRAINT [PK_PBClaseMotivoHallazgoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PBClaseOrganismoIntervinientes'
ALTER TABLE [dbo].[PBClaseOrganismoIntervinientes]
ADD CONSTRAINT [PK_PBClaseOrganismoIntervinientes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PBClaseRostroes'
ALTER TABLE [dbo].[PBClaseRostroes]
ADD CONSTRAINT [PK_PBClaseRostroes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PBClaseSexoes'
ALTER TABLE [dbo].[PBClaseSexoes]
ADD CONSTRAINT [PK_PBClaseSexoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PBClaseTablaDestinoes'
ALTER TABLE [dbo].[PBClaseTablaDestinoes]
ADD CONSTRAINT [PK_PBClaseTablaDestinoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'PBClaseTipoJurisdiccionCausas'
ALTER TABLE [dbo].[PBClaseTipoJurisdiccionCausas]
ADD CONSTRAINT [PK_PBClaseTipoJurisdiccionCausas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [idRecurso], [Id] in table 'PermisoGrupoes'
ALTER TABLE [dbo].[PermisoGrupoes]
ADD CONSTRAINT [PK_PermisoGrupoes]
    PRIMARY KEY CLUSTERED ([idRecurso], [Id] ASC);
GO

-- Creating primary key on [Id] in table 'PermisoUsuarios'
ALTER TABLE [dbo].[PermisoUsuarios]
ADD CONSTRAINT [PK_PermisoUsuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'Personas'
ALTER TABLE [dbo].[Personas]
ADD CONSTRAINT [PK_Personas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'PersonaIPPs'
ALTER TABLE [dbo].[PersonaIPPs]
ADD CONSTRAINT [PK_PersonaIPPs]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'PersonalPoderJudicials'
ALTER TABLE [dbo].[PersonalPoderJudicials]
ADD CONSTRAINT [PK_PersonalPoderJudicials]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonasDesaparecidas'
ALTER TABLE [dbo].[PersonasDesaparecidas]
ADD CONSTRAINT [PK_PersonasDesaparecidas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id], [IppHallada_], [IppDesaparecida_], [Fecha], [Usuario], [IppOrigen] in table 'PersonasEncontradas'
ALTER TABLE [dbo].[PersonasEncontradas]
ADD CONSTRAINT [PK_PersonasEncontradas]
    PRIMARY KEY CLUSTERED ([id], [IppHallada_], [IppDesaparecida_], [Fecha], [Usuario], [IppOrigen] ASC);
GO

-- Creating primary key on [Id] in table 'PersonasHalladas'
ALTER TABLE [dbo].[PersonasHalladas]
ADD CONSTRAINT [PK_PersonasHalladas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'PersonaTipoes'
ALTER TABLE [dbo].[PersonaTipoes]
ADD CONSTRAINT [PK_PersonaTipoes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [pregunta], [texto], [grupo] in table 'PreguntasFrecuentes'
ALTER TABLE [dbo].[PreguntasFrecuentes]
ADD CONSTRAINT [PK_PreguntasFrecuentes]
    PRIMARY KEY CLUSTERED ([id], [pregunta], [texto], [grupo] ASC);
GO

-- Creating primary key on [id] in table 'Provincias'
ALTER TABLE [dbo].[Provincias]
ADD CONSTRAINT [PK_Provincias]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'PuntoGestions'
ALTER TABLE [dbo].[PuntoGestions]
ADD CONSTRAINT [PK_PuntoGestions]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Rastros'
ALTER TABLE [dbo].[Rastros]
ADD CONSTRAINT [PK_Rastros]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Recursoes'
ALTER TABLE [dbo].[Recursoes]
ADD CONSTRAINT [PK_Recursoes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'SeniasParticulares'
ALTER TABLE [dbo].[SeniasParticulares]
ADD CONSTRAINT [PK_SeniasParticulares]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [id] in table 'TatuajesPersonas'
ALTER TABLE [dbo].[TatuajesPersonas]
ADD CONSTRAINT [PK_TatuajesPersonas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TPClaseTipoDNIs'
ALTER TABLE [dbo].[TPClaseTipoDNIs]
ADD CONSTRAINT [PK_TPClaseTipoDNIs]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'UsuariosBCKUPs'
ALTER TABLE [dbo].[UsuariosBCKUPs]
ADD CONSTRAINT [PK_UsuariosBCKUPs]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Vehiculos'
ALTER TABLE [dbo].[Vehiculos]
ADD CONSTRAINT [PK_Vehiculos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Tabla] in table 'VersionDescriptoras'
ALTER TABLE [dbo].[VersionDescriptoras]
ADD CONSTRAINT [PK_VersionDescriptoras]
    PRIMARY KEY CLUSTERED ([Tabla] ASC);
GO

-- Creating primary key on [Id] in table 'VinculoMenuBusquedaPrincipals'
ALTER TABLE [dbo].[VinculoMenuBusquedaPrincipals]
ADD CONSTRAINT [PK_VinculoMenuBusquedaPrincipals]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VinculoMenuRecursoes'
ALTER TABLE [dbo].[VinculoMenuRecursoes]
ADD CONSTRAINT [PK_VinculoMenuRecursoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'xBusquedaRobosDelitosSexuales'
ALTER TABLE [dbo].[xBusquedaRobosDelitosSexuales]
ADD CONSTRAINT [PK_xBusquedaRobosDelitosSexuales]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idClaseEdadAproximada] in table 'Autores'
ALTER TABLE [dbo].[Autores]
ADD CONSTRAINT [FK_Autor_NNClaseEdadAproximada]
    FOREIGN KEY ([idClaseEdadAproximada])
    REFERENCES [dbo].[NNClaseEdadAproximadas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Autor_NNClaseEdadAproximada'
CREATE INDEX [IX_FK_Autor_NNClaseEdadAproximada]
ON [dbo].[Autores]
    ([idClaseEdadAproximada]);
GO

-- Creating foreign key on [idClaseRostro] in table 'Autores'
ALTER TABLE [dbo].[Autores]
ADD CONSTRAINT [FK_Autor_NNClaseRostro]
    FOREIGN KEY ([idClaseRostro])
    REFERENCES [dbo].[NNClaseRostroes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Autor_NNClaseRostro'
CREATE INDEX [IX_FK_Autor_NNClaseRostro]
ON [dbo].[Autores]
    ([idClaseRostro]);
GO

-- Creating foreign key on [idClaseSexo] in table 'Autores'
ALTER TABLE [dbo].[Autores]
ADD CONSTRAINT [FK_Autor_NNClaseSexo]
    FOREIGN KEY ([idClaseSexo])
    REFERENCES [dbo].[NNClaseSexoes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Autor_NNClaseSexo'
CREATE INDEX [IX_FK_Autor_NNClaseSexo]
ON [dbo].[Autores]
    ([idClaseSexo]);
GO

-- Creating foreign key on [idDelito] in table 'Autores'
ALTER TABLE [dbo].[Autores]
ADD CONSTRAINT [FK_Autores_Delitos]
    FOREIGN KEY ([idDelito])
    REFERENCES [dbo].[Delitos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Autores_Delitos'
CREATE INDEX [IX_FK_Autores_Delitos]
ON [dbo].[Autores]
    ([idDelito]);
GO

-- Creating foreign key on [idAutor] in table 'SeniasParticulares'
ALTER TABLE [dbo].[SeniasParticulares]
ADD CONSTRAINT [FK_SeniasParticulares_Autores]
    FOREIGN KEY ([idAutor])
    REFERENCES [dbo].[Autores]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SeniasParticulares_Autores'
CREATE INDEX [IX_FK_SeniasParticulares_Autores]
ON [dbo].[SeniasParticulares]
    ([idAutor]);
GO

-- Creating foreign key on [idAutor] in table 'TatuajesPersonas'
ALTER TABLE [dbo].[TatuajesPersonas]
ADD CONSTRAINT [FK_Tatuajes_Autores]
    FOREIGN KEY ([idAutor])
    REFERENCES [dbo].[Autores]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Tatuajes_Autores'
CREATE INDEX [IX_FK_Tatuajes_Autores]
ON [dbo].[TatuajesPersonas]
    ([idAutor]);
GO

-- Creating foreign key on [idClaseBienSustraido] in table 'BienesSustraidos'
ALTER TABLE [dbo].[BienesSustraidos]
ADD CONSTRAINT [FK_Bien_Sustraido_NNClaseBienSustraido]
    FOREIGN KEY ([idClaseBienSustraido])
    REFERENCES [dbo].[NNClaseBienSustraidoes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Bien_Sustraido_NNClaseBienSustraido'
CREATE INDEX [IX_FK_Bien_Sustraido_NNClaseBienSustraido]
ON [dbo].[BienesSustraidos]
    ([idClaseBienSustraido]);
GO

-- Creating foreign key on [idNNBienSustraido] in table 'BienSustraidoArmas'
ALTER TABLE [dbo].[BienSustraidoArmas]
ADD CONSTRAINT [FK_BienesSustraidoArma_BienesSustraido]
    FOREIGN KEY ([idNNBienSustraido])
    REFERENCES [dbo].[BienesSustraidos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BienesSustraidoArma_BienesSustraido'
CREATE INDEX [IX_FK_BienesSustraidoArma_BienesSustraido]
ON [dbo].[BienSustraidoArmas]
    ([idNNBienSustraido]);
GO

-- Creating foreign key on [idDelito] in table 'BienesSustraidos'
ALTER TABLE [dbo].[BienesSustraidos]
ADD CONSTRAINT [FK_BienesSUstraidos_Delitos]
    FOREIGN KEY ([idDelito])
    REFERENCES [dbo].[Delitos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BienesSUstraidos_Delitos'
CREATE INDEX [IX_FK_BienesSUstraidos_Delitos]
ON [dbo].[BienesSustraidos]
    ([idDelito]);
GO

-- Creating foreign key on [idNNBienSustraido] in table 'BienesSustraidosAnimals'
ALTER TABLE [dbo].[BienesSustraidosAnimals]
ADD CONSTRAINT [FK_BienSustraidoAnimal_Bien_Sustraido]
    FOREIGN KEY ([idNNBienSustraido])
    REFERENCES [dbo].[BienesSustraidos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BienSustraidoAnimal_Bien_Sustraido'
CREATE INDEX [IX_FK_BienSustraidoAnimal_Bien_Sustraido]
ON [dbo].[BienesSustraidosAnimals]
    ([idNNBienSustraido]);
GO

-- Creating foreign key on [idNNBienSustraido] in table 'BienSustraidoCheques'
ALTER TABLE [dbo].[BienSustraidoCheques]
ADD CONSTRAINT [FK_BienSustraidoCheque_BienSustraido]
    FOREIGN KEY ([idNNBienSustraido])
    REFERENCES [dbo].[BienesSustraidos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BienSustraidoCheque_BienSustraido'
CREATE INDEX [IX_FK_BienSustraidoCheque_BienSustraido]
ON [dbo].[BienSustraidoCheques]
    ([idNNBienSustraido]);
GO

-- Creating foreign key on [idNNBienSustraido] in table 'BienSustraidoDineroes'
ALTER TABLE [dbo].[BienSustraidoDineroes]
ADD CONSTRAINT [FK_BienSustraidoDinero_BienSustraido]
    FOREIGN KEY ([idNNBienSustraido])
    REFERENCES [dbo].[BienesSustraidos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BienSustraidoDinero_BienSustraido'
CREATE INDEX [IX_FK_BienSustraidoDinero_BienSustraido]
ON [dbo].[BienSustraidoDineroes]
    ([idNNBienSustraido]);
GO

-- Creating foreign key on [idNNBienSustraido] in table 'BienesSustraidosOtroes'
ALTER TABLE [dbo].[BienesSustraidosOtroes]
ADD CONSTRAINT [FK_BienSustraidoOtro_Bien_Sustraido]
    FOREIGN KEY ([idNNBienSustraido])
    REFERENCES [dbo].[BienesSustraidos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BienSustraidoOtro_Bien_Sustraido'
CREATE INDEX [IX_FK_BienSustraidoOtro_Bien_Sustraido]
ON [dbo].[BienesSustraidosOtroes]
    ([idNNBienSustraido]);
GO

-- Creating foreign key on [idNNBienSustraido] in table 'BienSustraidoTelefonoes'
ALTER TABLE [dbo].[BienSustraidoTelefonoes]
ADD CONSTRAINT [FK_BienSustraidoTEL_BienSustraido]
    FOREIGN KEY ([idNNBienSustraido])
    REFERENCES [dbo].[BienesSustraidos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BienSustraidoTEL_BienSustraido'
CREATE INDEX [IX_FK_BienSustraidoTEL_BienSustraido]
ON [dbo].[BienSustraidoTelefonoes]
    ([idNNBienSustraido]);
GO

-- Creating foreign key on [idBienSustraido] in table 'Vehiculos'
ALTER TABLE [dbo].[Vehiculos]
ADD CONSTRAINT [FK_Vehiculo_Bien_Sustraido]
    FOREIGN KEY ([idBienSustraido])
    REFERENCES [dbo].[BienesSustraidos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Vehiculo_Bien_Sustraido'
CREATE INDEX [IX_FK_Vehiculo_Bien_Sustraido]
ON [dbo].[Vehiculos]
    ([idBienSustraido]);
GO

-- Creating foreign key on [idClaseGanado] in table 'BienesSustraidosAnimals'
ALTER TABLE [dbo].[BienesSustraidosAnimals]
ADD CONSTRAINT [FK_BienesSustraidosAnimal_NNClaseGanado]
    FOREIGN KEY ([idClaseGanado])
    REFERENCES [dbo].[NNClaseGanadoes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BienesSustraidosAnimal_NNClaseGanado'
CREATE INDEX [IX_FK_BienesSustraidosAnimal_NNClaseGanado]
ON [dbo].[BienesSustraidosAnimals]
    ([idClaseGanado]);
GO

-- Creating foreign key on [idComisariaIntervinoAparcicion] in table 'Busquedas'
ALTER TABLE [dbo].[Busquedas]
ADD CONSTRAINT [FK_Busqueda_Comisaria]
    FOREIGN KEY ([idComisariaIntervinoAparcicion])
    REFERENCES [dbo].[Comisarias]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Busqueda_Comisaria'
CREATE INDEX [IX_FK_Busqueda_Comisaria]
ON [dbo].[Busquedas]
    ([idComisariaIntervinoAparcicion]);
GO

-- Creating foreign key on [FaltanPiezasDentales] in table 'Busquedas'
ALTER TABLE [dbo].[Busquedas]
ADD CONSTRAINT [FK_Busqueda_PBClaseBoolean]
    FOREIGN KEY ([FaltanPiezasDentales])
    REFERENCES [dbo].[PBClaseBooleans]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Busqueda_PBClaseBoolean'
CREATE INDEX [IX_FK_Busqueda_PBClaseBoolean]
ON [dbo].[Busquedas]
    ([FaltanPiezasDentales]);
GO

-- Creating foreign key on [idMotivoHallazgo] in table 'Busquedas'
ALTER TABLE [dbo].[Busquedas]
ADD CONSTRAINT [FK_Busqueda_PBClaseMotivoHallazgo]
    FOREIGN KEY ([idMotivoHallazgo])
    REFERENCES [dbo].[PBClaseMotivoHallazgoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Busqueda_PBClaseMotivoHallazgo'
CREATE INDEX [IX_FK_Busqueda_PBClaseMotivoHallazgo]
ON [dbo].[Busquedas]
    ([idMotivoHallazgo]);
GO

-- Creating foreign key on [idsexo] in table 'Busquedas'
ALTER TABLE [dbo].[Busquedas]
ADD CONSTRAINT [FK_Busqueda_PBClaseSexo]
    FOREIGN KEY ([idsexo])
    REFERENCES [dbo].[PBClaseSexoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Busqueda_PBClaseSexo'
CREATE INDEX [IX_FK_Busqueda_PBClaseSexo]
ON [dbo].[Busquedas]
    ([idsexo]);
GO

-- Creating foreign key on [idOrigen] in table 'Busquedas'
ALTER TABLE [dbo].[Busquedas]
ADD CONSTRAINT [FK_Busqueda_PBClaseTablaDestino]
    FOREIGN KEY ([idOrigen])
    REFERENCES [dbo].[PBClaseTablaDestinoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Busqueda_PBClaseTablaDestino'
CREATE INDEX [IX_FK_Busqueda_PBClaseTablaDestino]
ON [dbo].[Busquedas]
    ([idOrigen]);
GO

-- Creating foreign key on [idBusqueda] in table 'BusquedaAspectoCabelloes'
ALTER TABLE [dbo].[BusquedaAspectoCabelloes]
ADD CONSTRAINT [FK_BusquedaAspectoCabello_Busqueda]
    FOREIGN KEY ([idBusqueda])
    REFERENCES [dbo].[Busquedas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaAspectoCabello_Busqueda'
CREATE INDEX [IX_FK_BusquedaAspectoCabello_Busqueda]
ON [dbo].[BusquedaAspectoCabelloes]
    ([idBusqueda]);
GO

-- Creating foreign key on [idBusqueda] in table 'BusquedaCalvicies'
ALTER TABLE [dbo].[BusquedaCalvicies]
ADD CONSTRAINT [FK_BusquedaCalvicie_Busqueda]
    FOREIGN KEY ([idBusqueda])
    REFERENCES [dbo].[Busquedas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaCalvicie_Busqueda'
CREATE INDEX [IX_FK_BusquedaCalvicie_Busqueda]
ON [dbo].[BusquedaCalvicies]
    ([idBusqueda]);
GO

-- Creating foreign key on [idBusqueda] in table 'BusquedaColorCabelloes'
ALTER TABLE [dbo].[BusquedaColorCabelloes]
ADD CONSTRAINT [FK_BusquedaColorCabello_Busqueda]
    FOREIGN KEY ([idBusqueda])
    REFERENCES [dbo].[Busquedas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaColorCabello_Busqueda'
CREATE INDEX [IX_FK_BusquedaColorCabello_Busqueda]
ON [dbo].[BusquedaColorCabelloes]
    ([idBusqueda]);
GO

-- Creating foreign key on [idBusqueda] in table 'BusquedaColorOjos'
ALTER TABLE [dbo].[BusquedaColorOjos]
ADD CONSTRAINT [FK_BusquedaColorOjos_Busqueda]
    FOREIGN KEY ([idBusqueda])
    REFERENCES [dbo].[Busquedas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaColorOjos_Busqueda'
CREATE INDEX [IX_FK_BusquedaColorOjos_Busqueda]
ON [dbo].[BusquedaColorOjos]
    ([idBusqueda]);
GO

-- Creating foreign key on [idBusqueda] in table 'BusquedaColorPiels'
ALTER TABLE [dbo].[BusquedaColorPiels]
ADD CONSTRAINT [FK_BusquedaColorPiel_Busqueda]
    FOREIGN KEY ([idBusqueda])
    REFERENCES [dbo].[Busquedas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaColorPiel_Busqueda'
CREATE INDEX [IX_FK_BusquedaColorPiel_Busqueda]
ON [dbo].[BusquedaColorPiels]
    ([idBusqueda]);
GO

-- Creating foreign key on [idBusqueda] in table 'BusquedaColorTenidoes'
ALTER TABLE [dbo].[BusquedaColorTenidoes]
ADD CONSTRAINT [FK_BusquedaColorTenido_Busqueda]
    FOREIGN KEY ([idBusqueda])
    REFERENCES [dbo].[Busquedas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaColorTenido_Busqueda'
CREATE INDEX [IX_FK_BusquedaColorTenido_Busqueda]
ON [dbo].[BusquedaColorTenidoes]
    ([idBusqueda]);
GO

-- Creating foreign key on [idBusqueda] in table 'BusquedaGrupoSanguineos'
ALTER TABLE [dbo].[BusquedaGrupoSanguineos]
ADD CONSTRAINT [FK_BusquedaGrupoSanguineo_Busqueda]
    FOREIGN KEY ([idBusqueda])
    REFERENCES [dbo].[Busquedas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaGrupoSanguineo_Busqueda'
CREATE INDEX [IX_FK_BusquedaGrupoSanguineo_Busqueda]
ON [dbo].[BusquedaGrupoSanguineos]
    ([idBusqueda]);
GO

-- Creating foreign key on [idBusqueda] in table 'BusquedaLongitudCabelloes'
ALTER TABLE [dbo].[BusquedaLongitudCabelloes]
ADD CONSTRAINT [FK_BusquedaLongitudCabello_Busqueda]
    FOREIGN KEY ([idBusqueda])
    REFERENCES [dbo].[Busquedas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaLongitudCabello_Busqueda'
CREATE INDEX [IX_FK_BusquedaLongitudCabello_Busqueda]
ON [dbo].[BusquedaLongitudCabelloes]
    ([idBusqueda]);
GO

-- Creating foreign key on [idBusqueda] in table 'BusquedaRostroes'
ALTER TABLE [dbo].[BusquedaRostroes]
ADD CONSTRAINT [FK_BusquedaRostro_Busqueda]
    FOREIGN KEY ([idBusqueda])
    REFERENCES [dbo].[Busquedas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaRostro_Busqueda'
CREATE INDEX [IX_FK_BusquedaRostro_Busqueda]
ON [dbo].[BusquedaRostroes]
    ([idBusqueda]);
GO

-- Creating foreign key on [idBusqueda] in table 'BusquedaSeniasParticulares'
ALTER TABLE [dbo].[BusquedaSeniasParticulares]
ADD CONSTRAINT [FK_BusquedaSeniasParticulares_Busqueda]
    FOREIGN KEY ([idBusqueda])
    REFERENCES [dbo].[Busquedas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaSeniasParticulares_Busqueda'
CREATE INDEX [IX_FK_BusquedaSeniasParticulares_Busqueda]
ON [dbo].[BusquedaSeniasParticulares]
    ([idBusqueda]);
GO

-- Creating foreign key on [idBusqueda] in table 'BusquedaTatuajes'
ALTER TABLE [dbo].[BusquedaTatuajes]
ADD CONSTRAINT [FK_BusquedaTatuajes_Busqueda]
    FOREIGN KEY ([idBusqueda])
    REFERENCES [dbo].[Busquedas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaTatuajes_Busqueda'
CREATE INDEX [IX_FK_BusquedaTatuajes_Busqueda]
ON [dbo].[BusquedaTatuajes]
    ([idBusqueda]);
GO

-- Creating foreign key on [idAspectoCabello] in table 'BusquedaAspectoCabelloes'
ALTER TABLE [dbo].[BusquedaAspectoCabelloes]
ADD CONSTRAINT [FK_BusquedaAspectoCabello_PBClaseAspectoCabello]
    FOREIGN KEY ([idAspectoCabello])
    REFERENCES [dbo].[PBClaseAspectoCabelloes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaAspectoCabello_PBClaseAspectoCabello'
CREATE INDEX [IX_FK_BusquedaAspectoCabello_PBClaseAspectoCabello]
ON [dbo].[BusquedaAspectoCabelloes]
    ([idAspectoCabello]);
GO

-- Creating foreign key on [idClaseCalvicie] in table 'BusquedaCalvicies'
ALTER TABLE [dbo].[BusquedaCalvicies]
ADD CONSTRAINT [FK_BusquedaCalvicie_PBClaseCalvicie]
    FOREIGN KEY ([idClaseCalvicie])
    REFERENCES [dbo].[PBClaseCalvicies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaCalvicie_PBClaseCalvicie'
CREATE INDEX [IX_FK_BusquedaCalvicie_PBClaseCalvicie]
ON [dbo].[BusquedaCalvicies]
    ([idClaseCalvicie]);
GO

-- Creating foreign key on [idClaseColorCabello] in table 'BusquedaColorCabelloes'
ALTER TABLE [dbo].[BusquedaColorCabelloes]
ADD CONSTRAINT [FK_BusquedaColorCabello_PBClaseColorCabello]
    FOREIGN KEY ([idClaseColorCabello])
    REFERENCES [dbo].[PBClaseColorCabelloes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaColorCabello_PBClaseColorCabello'
CREATE INDEX [IX_FK_BusquedaColorCabello_PBClaseColorCabello]
ON [dbo].[BusquedaColorCabelloes]
    ([idClaseColorCabello]);
GO

-- Creating foreign key on [idClaseColorOjos] in table 'BusquedaColorOjos'
ALTER TABLE [dbo].[BusquedaColorOjos]
ADD CONSTRAINT [FK_BusquedaColorOjos_PBClaseColorOjos]
    FOREIGN KEY ([idClaseColorOjos])
    REFERENCES [dbo].[PBClaseColorOjos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaColorOjos_PBClaseColorOjos'
CREATE INDEX [IX_FK_BusquedaColorOjos_PBClaseColorOjos]
ON [dbo].[BusquedaColorOjos]
    ([idClaseColorOjos]);
GO

-- Creating foreign key on [idClaseColorPiel] in table 'BusquedaColorPiels'
ALTER TABLE [dbo].[BusquedaColorPiels]
ADD CONSTRAINT [FK_BusquedaColorPiel_PBClaseColorDePiel]
    FOREIGN KEY ([idClaseColorPiel])
    REFERENCES [dbo].[PBClaseColorDePiels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaColorPiel_PBClaseColorDePiel'
CREATE INDEX [IX_FK_BusquedaColorPiel_PBClaseColorDePiel]
ON [dbo].[BusquedaColorPiels]
    ([idClaseColorPiel]);
GO

-- Creating foreign key on [idClaseColorTenido] in table 'BusquedaColorTenidoes'
ALTER TABLE [dbo].[BusquedaColorTenidoes]
ADD CONSTRAINT [FK_BusquedaColorTenido_PBClaseColor]
    FOREIGN KEY ([idClaseColorTenido])
    REFERENCES [dbo].[PBClaseColors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaColorTenido_PBClaseColor'
CREATE INDEX [IX_FK_BusquedaColorTenido_PBClaseColor]
ON [dbo].[BusquedaColorTenidoes]
    ([idClaseColorTenido]);
GO

-- Creating foreign key on [idGrupoSanguineo] in table 'BusquedaGrupoSanguineos'
ALTER TABLE [dbo].[BusquedaGrupoSanguineos]
ADD CONSTRAINT [FK_BusquedaGrupoSanguineo_PBGrupoSanguineo]
    FOREIGN KEY ([idGrupoSanguineo])
    REFERENCES [dbo].[PBClaseGrupoSanguineos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaGrupoSanguineo_PBGrupoSanguineo'
CREATE INDEX [IX_FK_BusquedaGrupoSanguineo_PBGrupoSanguineo]
ON [dbo].[BusquedaGrupoSanguineos]
    ([idGrupoSanguineo]);
GO

-- Creating foreign key on [idClaseLongitudCabello] in table 'BusquedaLongitudCabelloes'
ALTER TABLE [dbo].[BusquedaLongitudCabelloes]
ADD CONSTRAINT [FK_BusquedaLongitudCabello_PBClaseLongitudCabello]
    FOREIGN KEY ([idClaseLongitudCabello])
    REFERENCES [dbo].[PBClaseLongitudCabelloes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaLongitudCabello_PBClaseLongitudCabello'
CREATE INDEX [IX_FK_BusquedaLongitudCabello_PBClaseLongitudCabello]
ON [dbo].[BusquedaLongitudCabelloes]
    ([idClaseLongitudCabello]);
GO

-- Creating foreign key on [IdMenu] in table 'VinculoMenuBusquedaPrincipals'
ALTER TABLE [dbo].[VinculoMenuBusquedaPrincipals]
ADD CONSTRAINT [FK_VinculoMenuBusquedaPrincipal_BusquedaPrincipal]
    FOREIGN KEY ([IdMenu])
    REFERENCES [dbo].[BusquedaPrincipals]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VinculoMenuBusquedaPrincipal_BusquedaPrincipal'
CREATE INDEX [IX_FK_VinculoMenuBusquedaPrincipal_BusquedaPrincipal]
ON [dbo].[VinculoMenuBusquedaPrincipals]
    ([IdMenu]);
GO

-- Creating foreign key on [idBusquedaRoboDS] in table 'BusquedaRobosDelitosSexualesComisarias'
ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesComisarias]
ADD CONSTRAINT [FK_BusquedaRobosDelitosSexualesComisarias_BusquedaRoboDelitosSexuales]
    FOREIGN KEY ([idBusquedaRoboDS])
    REFERENCES [dbo].[BusquedaRobosDelitosSexuales]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaRobosDelitosSexualesComisarias_BusquedaRoboDelitosSexuales'
CREATE INDEX [IX_FK_BusquedaRobosDelitosSexualesComisarias_BusquedaRoboDelitosSexuales]
ON [dbo].[BusquedaRobosDelitosSexualesComisarias]
    ([idBusquedaRoboDS]);
GO

-- Creating foreign key on [idBusquedaRoboDS] in table 'BusquedaRobosDelitosSexualesLocalidades'
ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesLocalidades]
ADD CONSTRAINT [FK_BusquedaRobosDelitosSexualesLocalidades_BusquedaRoboDelitosSexuales]
    FOREIGN KEY ([idBusquedaRoboDS])
    REFERENCES [dbo].[BusquedaRobosDelitosSexuales]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaRobosDelitosSexualesLocalidades_BusquedaRoboDelitosSexuales'
CREATE INDEX [IX_FK_BusquedaRobosDelitosSexualesLocalidades_BusquedaRoboDelitosSexuales]
ON [dbo].[BusquedaRobosDelitosSexualesLocalidades]
    ([idBusquedaRoboDS]);
GO

-- Creating foreign key on [idBusquedaRoboDS] in table 'BusquedaRobosDelitosSexualesSenias'
ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesSenias]
ADD CONSTRAINT [FK_BusquedaRobosDelitosSexualesSenias_BusquedaRobosDelitosSexuales]
    FOREIGN KEY ([idBusquedaRoboDS])
    REFERENCES [dbo].[BusquedaRobosDelitosSexuales]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaRobosDelitosSexualesSenias_BusquedaRobosDelitosSexuales'
CREATE INDEX [IX_FK_BusquedaRobosDelitosSexualesSenias_BusquedaRobosDelitosSexuales]
ON [dbo].[BusquedaRobosDelitosSexualesSenias]
    ([idBusquedaRoboDS]);
GO

-- Creating foreign key on [idBusquedaRoboDS] in table 'BusquedaRobosDelitosSexualesTatuajes'
ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesTatuajes]
ADD CONSTRAINT [FK_BusquedaRobosDelitosSexualesTatuajes_BusquedaRobosDelitosSexuales]
    FOREIGN KEY ([idBusquedaRoboDS])
    REFERENCES [dbo].[BusquedaRobosDelitosSexuales]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaRobosDelitosSexualesTatuajes_BusquedaRobosDelitosSexuales'
CREATE INDEX [IX_FK_BusquedaRobosDelitosSexualesTatuajes_BusquedaRobosDelitosSexuales]
ON [dbo].[BusquedaRobosDelitosSexualesTatuajes]
    ([idBusquedaRoboDS]);
GO

-- Creating foreign key on [idSenia] in table 'BusquedaRobosDelitosSexualesSenias'
ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesSenias]
ADD CONSTRAINT [FK_BusquedaRobosDelitosSexualesSenias_ClaseSeniaParticular]
    FOREIGN KEY ([idSenia])
    REFERENCES [dbo].[ClaseSeniaParticulares]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaRobosDelitosSexualesSenias_ClaseSeniaParticular'
CREATE INDEX [IX_FK_BusquedaRobosDelitosSexualesSenias_ClaseSeniaParticular]
ON [dbo].[BusquedaRobosDelitosSexualesSenias]
    ([idSenia]);
GO

-- Creating foreign key on [idLugarSenia] in table 'BusquedaRobosDelitosSexualesSenias'
ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesSenias]
ADD CONSTRAINT [FK_BusquedaRobosDelitosSexualesSenias_ClaseUbicacionSeniaPart]
    FOREIGN KEY ([idLugarSenia])
    REFERENCES [dbo].[ClaseUbicacionSeniaParticulares]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaRobosDelitosSexualesSenias_ClaseUbicacionSeniaPart'
CREATE INDEX [IX_FK_BusquedaRobosDelitosSexualesSenias_ClaseUbicacionSeniaPart]
ON [dbo].[BusquedaRobosDelitosSexualesSenias]
    ([idLugarSenia]);
GO

-- Creating foreign key on [idTatuaje] in table 'BusquedaRobosDelitosSexualesTatuajes'
ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesTatuajes]
ADD CONSTRAINT [FK_BusquedaRobosDelitosSexualesTatuajes_ClaseTatuaje]
    FOREIGN KEY ([idTatuaje])
    REFERENCES [dbo].[ClaseTatuajes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaRobosDelitosSexualesTatuajes_ClaseTatuaje'
CREATE INDEX [IX_FK_BusquedaRobosDelitosSexualesTatuajes_ClaseTatuaje]
ON [dbo].[BusquedaRobosDelitosSexualesTatuajes]
    ([idTatuaje]);
GO

-- Creating foreign key on [idLugarTatuaje] in table 'BusquedaRobosDelitosSexualesTatuajes'
ALTER TABLE [dbo].[BusquedaRobosDelitosSexualesTatuajes]
ADD CONSTRAINT [FK_BusquedaRobosDelitosSexualesTatuajes_ClaseUbicacionSeniaPart]
    FOREIGN KEY ([idLugarTatuaje])
    REFERENCES [dbo].[ClaseUbicacionSeniaParticulares]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaRobosDelitosSexualesTatuajes_ClaseUbicacionSeniaPart'
CREATE INDEX [IX_FK_BusquedaRobosDelitosSexualesTatuajes_ClaseUbicacionSeniaPart]
ON [dbo].[BusquedaRobosDelitosSexualesTatuajes]
    ([idLugarTatuaje]);
GO

-- Creating foreign key on [idClaseRostro] in table 'BusquedaRostroes'
ALTER TABLE [dbo].[BusquedaRostroes]
ADD CONSTRAINT [FK_BusquedaRostro_PBClaseRostro]
    FOREIGN KEY ([idClaseRostro])
    REFERENCES [dbo].[PBClaseRostroes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BusquedaRostro_PBClaseRostro'
CREATE INDEX [IX_FK_BusquedaRostro_PBClaseRostro]
ON [dbo].[BusquedaRostroes]
    ([idClaseRostro]);
GO

-- Creating foreign key on [idEstadoCivil] in table 'Personas'
ALTER TABLE [dbo].[Personas]
ADD CONSTRAINT [FK_Persona_ClaseEstadoCivil]
    FOREIGN KEY ([idEstadoCivil])
    REFERENCES [dbo].[ClaseEstadoCiviles]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Persona_ClaseEstadoCivil'
CREATE INDEX [IX_FK_Persona_ClaseEstadoCivil]
ON [dbo].[Personas]
    ([idEstadoCivil]);
GO

-- Creating foreign key on [IdEstadoCivilMaterno] in table 'Personas'
ALTER TABLE [dbo].[Personas]
ADD CONSTRAINT [FK_Persona_EstadoCivilMaterno]
    FOREIGN KEY ([IdEstadoCivilMaterno])
    REFERENCES [dbo].[ClaseEstadoCiviles]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Persona_EstadoCivilMaterno'
CREATE INDEX [IX_FK_Persona_EstadoCivilMaterno]
ON [dbo].[Personas]
    ([IdEstadoCivilMaterno]);
GO

-- Creating foreign key on [IdEstadoCivilPaterno] in table 'Personas'
ALTER TABLE [dbo].[Personas]
ADD CONSTRAINT [FK_Persona_EstadoCivilPaterno]
    FOREIGN KEY ([IdEstadoCivilPaterno])
    REFERENCES [dbo].[ClaseEstadoCiviles]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Persona_EstadoCivilPaterno'
CREATE INDEX [IX_FK_Persona_EstadoCivilPaterno]
ON [dbo].[Personas]
    ([IdEstadoCivilPaterno]);
GO

-- Creating foreign key on [EstudiosCursados] in table 'Personas'
ALTER TABLE [dbo].[Personas]
ADD CONSTRAINT [FK_Persona_EstudiosCursados]
    FOREIGN KEY ([EstudiosCursados])
    REFERENCES [dbo].[ClaseEstudiosCursados]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Persona_EstudiosCursados'
CREATE INDEX [IX_FK_Persona_EstudiosCursados]
ON [dbo].[Personas]
    ([EstudiosCursados]);
GO

-- Creating foreign key on [IdClaseMenu] in table 'Menus'
ALTER TABLE [dbo].[Menus]
ADD CONSTRAINT [FK_Menu_ClaseMenu]
    FOREIGN KEY ([IdClaseMenu])
    REFERENCES [dbo].[ClaseMenus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Menu_ClaseMenu'
CREATE INDEX [IX_FK_Menu_ClaseMenu]
ON [dbo].[Menus]
    ([IdClaseMenu]);
GO

-- Creating foreign key on [idClasePuntoGestion] in table 'PuntoGestions'
ALTER TABLE [dbo].[PuntoGestions]
ADD CONSTRAINT [FK_PuntoGestion_ClasePuntoGestion]
    FOREIGN KEY ([idClasePuntoGestion])
    REFERENCES [dbo].[ClasePuntoGestions]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PuntoGestion_ClasePuntoGestion'
CREATE INDEX [IX_FK_PuntoGestion_ClasePuntoGestion]
ON [dbo].[PuntoGestions]
    ([idClasePuntoGestion]);
GO

-- Creating foreign key on [idSeniaParticular] in table 'SeniasParticulares'
ALTER TABLE [dbo].[SeniasParticulares]
ADD CONSTRAINT [FK_SeniasParticulares_ClaseSeniaParticular]
    FOREIGN KEY ([idSeniaParticular])
    REFERENCES [dbo].[ClaseSeniaParticulares]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SeniasParticulares_ClaseSeniaParticular'
CREATE INDEX [IX_FK_SeniasParticulares_ClaseSeniaParticular]
ON [dbo].[SeniasParticulares]
    ([idSeniaParticular]);
GO

-- Creating foreign key on [idSexo] in table 'Personas'
ALTER TABLE [dbo].[Personas]
ADD CONSTRAINT [FK_Persona_CLaseSexo]
    FOREIGN KEY ([idSexo])
    REFERENCES [dbo].[ClaseSexos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Persona_CLaseSexo'
CREATE INDEX [IX_FK_Persona_CLaseSexo]
ON [dbo].[Personas]
    ([idSexo]);
GO

-- Creating foreign key on [idTatuaje] in table 'TatuajesPersonas'
ALTER TABLE [dbo].[TatuajesPersonas]
ADD CONSTRAINT [FK_TatuajesPersona_ClaseTatuaje]
    FOREIGN KEY ([idTatuaje])
    REFERENCES [dbo].[ClaseTatuajes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TatuajesPersona_ClaseTatuaje'
CREATE INDEX [IX_FK_TatuajesPersona_ClaseTatuaje]
ON [dbo].[TatuajesPersonas]
    ([idTatuaje]);
GO

-- Creating foreign key on [idClasePersona] in table 'PersonaTipoes'
ALTER TABLE [dbo].[PersonaTipoes]
ADD CONSTRAINT [FK_PersonaTipo_ClasePersona]
    FOREIGN KEY ([idClasePersona])
    REFERENCES [dbo].[ClaseTipoPersonas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonaTipo_ClasePersona'
CREATE INDEX [IX_FK_PersonaTipo_ClasePersona]
ON [dbo].[PersonaTipoes]
    ([idClasePersona]);
GO

-- Creating foreign key on [idTablaDestino] in table 'SeniasParticulares'
ALTER TABLE [dbo].[SeniasParticulares]
ADD CONSTRAINT [FK_SeniasParticulares_ClaseTipoPersona]
    FOREIGN KEY ([idTablaDestino])
    REFERENCES [dbo].[ClaseTipoPersonas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SeniasParticulares_ClaseTipoPersona'
CREATE INDEX [IX_FK_SeniasParticulares_ClaseTipoPersona]
ON [dbo].[SeniasParticulares]
    ([idTablaDestino]);
GO

-- Creating foreign key on [idTablaDestino] in table 'TatuajesPersonas'
ALTER TABLE [dbo].[TatuajesPersonas]
ADD CONSTRAINT [FK_TatuajesPersona_ClaseTipoPersona]
    FOREIGN KEY ([idTablaDestino])
    REFERENCES [dbo].[ClaseTipoPersonas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TatuajesPersona_ClaseTipoPersona'
CREATE INDEX [IX_FK_TatuajesPersona_ClaseTipoPersona]
ON [dbo].[TatuajesPersonas]
    ([idTablaDestino]);
GO

-- Creating foreign key on [idUbicacionSeniaParticular] in table 'SeniasParticulares'
ALTER TABLE [dbo].[SeniasParticulares]
ADD CONSTRAINT [FK_SeniasParticulares_ClaseUbicacionSeniaPart]
    FOREIGN KEY ([idUbicacionSeniaParticular])
    REFERENCES [dbo].[ClaseUbicacionSeniaParticulares]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SeniasParticulares_ClaseUbicacionSeniaPart'
CREATE INDEX [IX_FK_SeniasParticulares_ClaseUbicacionSeniaPart]
ON [dbo].[SeniasParticulares]
    ([idUbicacionSeniaParticular]);
GO

-- Creating foreign key on [idUbicacionTatuaje] in table 'TatuajesPersonas'
ALTER TABLE [dbo].[TatuajesPersonas]
ADD CONSTRAINT [FK_TatuajesPersona_ClaseUbicacionSeniaPart]
    FOREIGN KEY ([idUbicacionTatuaje])
    REFERENCES [dbo].[ClaseUbicacionSeniaParticulares]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TatuajesPersona_ClaseUbicacionSeniaPart'
CREATE INDEX [IX_FK_TatuajesPersona_ClaseUbicacionSeniaPart]
ON [dbo].[TatuajesPersonas]
    ([idUbicacionTatuaje]);
GO

-- Creating foreign key on [idColorVehiculo] in table 'Vehiculos'
ALTER TABLE [dbo].[Vehiculos]
ADD CONSTRAINT [FK_Vehiculos_ColorVehiculo]
    FOREIGN KEY ([idColorVehiculo])
    REFERENCES [dbo].[ColorVehiculoes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Vehiculos_ColorVehiculo'
CREATE INDEX [IX_FK_Vehiculos_ColorVehiculo]
ON [dbo].[Vehiculos]
    ([idColorVehiculo]);
GO

-- Creating foreign key on [idComisariaH] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delitos_Comisaria]
    FOREIGN KEY ([idComisariaH])
    REFERENCES [dbo].[Comisarias]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delitos_Comisaria'
CREATE INDEX [IX_FK_Delitos_Comisaria]
ON [dbo].[Delitos]
    ([idComisariaH]);
GO

-- Creating foreign key on [idComisariaL] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delitos_Comisaria1]
    FOREIGN KEY ([idComisariaL])
    REFERENCES [dbo].[Comisarias]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delitos_Comisaria1'
CREATE INDEX [IX_FK_Delitos_Comisaria1]
ON [dbo].[Delitos]
    ([idComisariaL]);
GO

-- Creating foreign key on [idComisaria] in table 'PersonasDesaparecidas'
ALTER TABLE [dbo].[PersonasDesaparecidas]
ADD CONSTRAINT [FK_PersonasDesaparecidas_Comisaria]
    FOREIGN KEY ([idComisaria])
    REFERENCES [dbo].[Comisarias]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasDesaparecidas_Comisaria'
CREATE INDEX [IX_FK_PersonasDesaparecidas_Comisaria]
ON [dbo].[PersonasDesaparecidas]
    ([idComisaria]);
GO

-- Creating foreign key on [idComisaria] in table 'PersonasHalladas'
ALTER TABLE [dbo].[PersonasHalladas]
ADD CONSTRAINT [FK_PersonasHalladas_Comisaria]
    FOREIGN KEY ([idComisaria])
    REFERENCES [dbo].[Comisarias]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasHalladas_Comisaria'
CREATE INDEX [IX_FK_PersonasHalladas_Comisaria]
ON [dbo].[PersonasHalladas]
    ([idComisaria]);
GO

-- Creating foreign key on [idClaseAgresion] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delito_NNClaseAgresion]
    FOREIGN KEY ([idClaseAgresion])
    REFERENCES [dbo].[NNClaseAgresions]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delito_NNClaseAgresion'
CREATE INDEX [IX_FK_Delito_NNClaseAgresion]
ON [dbo].[Delitos]
    ([idClaseAgresion]);
GO

-- Creating foreign key on [idClaseArma] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delito_NNClaseArma]
    FOREIGN KEY ([idClaseArma])
    REFERENCES [dbo].[NNClaseArmas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delito_NNClaseArma'
CREATE INDEX [IX_FK_Delito_NNClaseArma]
ON [dbo].[Delitos]
    ([idClaseArma]);
GO

-- Creating foreign key on [idClaseCantAutorReconocidos] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delito_NNClaseCantAutorReconocidos]
    FOREIGN KEY ([idClaseCantAutorReconocidos])
    REFERENCES [dbo].[NNClaseCantAutorReconocidos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delito_NNClaseCantAutorReconocidos'
CREATE INDEX [IX_FK_Delito_NNClaseCantAutorReconocidos]
ON [dbo].[Delitos]
    ([idClaseCantAutorReconocidos]);
GO

-- Creating foreign key on [idClaseCantidadAutores] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delito_NNClaseCantidadAutores]
    FOREIGN KEY ([idClaseCantidadAutores])
    REFERENCES [dbo].[NNClaseCantidadAutores]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delito_NNClaseCantidadAutores'
CREATE INDEX [IX_FK_Delito_NNClaseCantidadAutores]
ON [dbo].[Delitos]
    ([idClaseCantidadAutores]);
GO

-- Creating foreign key on [idClaseFecha] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delito_NNClaseFecha]
    FOREIGN KEY ([idClaseFecha])
    REFERENCES [dbo].[NNClaseFechas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delito_NNClaseFecha'
CREATE INDEX [IX_FK_Delito_NNClaseFecha]
ON [dbo].[Delitos]
    ([idClaseFecha]);
GO

-- Creating foreign key on [idClaseHora] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delito_NNClaseHora]
    FOREIGN KEY ([idClaseHora])
    REFERENCES [dbo].[NNClaseHoras]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delito_NNClaseHora'
CREATE INDEX [IX_FK_Delito_NNClaseHora]
ON [dbo].[Delitos]
    ([idClaseHora]);
GO

-- Creating foreign key on [idClaseLugar] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delito_NNClaseLugar]
    FOREIGN KEY ([idClaseLugar])
    REFERENCES [dbo].[NNClaseLugars]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delito_NNClaseLugar'
CREATE INDEX [IX_FK_Delito_NNClaseLugar]
ON [dbo].[Delitos]
    ([idClaseLugar]);
GO

-- Creating foreign key on [idClaseModoArriboHuida] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delito_NNClaseModoArriboHuida]
    FOREIGN KEY ([idClaseModoArriboHuida])
    REFERENCES [dbo].[NNClaseModoArriboHuidas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delito_NNClaseModoArriboHuida'
CREATE INDEX [IX_FK_Delito_NNClaseModoArriboHuida]
ON [dbo].[Delitos]
    ([idClaseModoArriboHuida]);
GO

-- Creating foreign key on [idClaseModusOperandis] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delito_NNClaseModusOperandi]
    FOREIGN KEY ([idClaseModusOperandis])
    REFERENCES [dbo].[NNClaseModusOperandis]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delito_NNClaseModusOperandi'
CREATE INDEX [IX_FK_Delito_NNClaseModusOperandi]
ON [dbo].[Delitos]
    ([idClaseModusOperandis]);
GO

-- Creating foreign key on [idClaseMomentoDelDia] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delito_NNClaseMomentoDia]
    FOREIGN KEY ([idClaseMomentoDelDia])
    REFERENCES [dbo].[NNClaseMomentoDias]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delito_NNClaseMomentoDia'
CREATE INDEX [IX_FK_Delito_NNClaseMomentoDia]
ON [dbo].[Delitos]
    ([idClaseMomentoDelDia]);
GO

-- Creating foreign key on [idClaseRubro] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delito_NNClaseRubro]
    FOREIGN KEY ([idClaseRubro])
    REFERENCES [dbo].[NNClaseRubroes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delito_NNClaseRubro'
CREATE INDEX [IX_FK_Delito_NNClaseRubro]
ON [dbo].[Delitos]
    ([idClaseRubro]);
GO

-- Creating foreign key on [idClaseZonaCuerpoLesionada] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delito_NNClaseZonaCuerpoLesionada]
    FOREIGN KEY ([idClaseZonaCuerpoLesionada])
    REFERENCES [dbo].[NNClaseZonaCuerpoLesionadas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delito_NNClaseZonaCuerpoLesionada'
CREATE INDEX [IX_FK_Delito_NNClaseZonaCuerpoLesionada]
ON [dbo].[Delitos]
    ([idClaseZonaCuerpoLesionada]);
GO

-- Creating foreign key on [HuboAgresionFisicaAVictima] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delitos_NNClaseBoolean]
    FOREIGN KEY ([HuboAgresionFisicaAVictima])
    REFERENCES [dbo].[NNClaseBooleans]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delitos_NNClaseBoolean'
CREATE INDEX [IX_FK_Delitos_NNClaseBoolean]
ON [dbo].[Delitos]
    ([HuboAgresionFisicaAVictima]);
GO

-- Creating foreign key on [UsoDeArmas] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delitos_NNClaseBoolean1]
    FOREIGN KEY ([UsoDeArmas])
    REFERENCES [dbo].[NNClaseBooleans]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delitos_NNClaseBoolean1'
CREATE INDEX [IX_FK_Delitos_NNClaseBoolean1]
ON [dbo].[Delitos]
    ([UsoDeArmas]);
GO

-- Creating foreign key on [VictimasEnElLugar] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delitos_NNClaseBoolean2]
    FOREIGN KEY ([VictimasEnElLugar])
    REFERENCES [dbo].[NNClaseBooleans]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delitos_NNClaseBoolean2'
CREATE INDEX [IX_FK_Delitos_NNClaseBoolean2]
ON [dbo].[Delitos]
    ([VictimasEnElLugar]);
GO

-- Creating foreign key on [VictimaTrasladadaAOtroLugar] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delitos_NNClaseBoolean3]
    FOREIGN KEY ([VictimaTrasladadaAOtroLugar])
    REFERENCES [dbo].[NNClaseBooleans]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delitos_NNClaseBoolean3'
CREATE INDEX [IX_FK_Delitos_NNClaseBoolean3]
ON [dbo].[Delitos]
    ([VictimaTrasladadaAOtroLugar]);
GO

-- Creating foreign key on [idVicTestRecRueda] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delitos_NNClaseBoolean4]
    FOREIGN KEY ([idVicTestRecRueda])
    REFERENCES [dbo].[NNClaseBooleans]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delitos_NNClaseBoolean4'
CREATE INDEX [IX_FK_Delitos_NNClaseBoolean4]
ON [dbo].[Delitos]
    ([idVicTestRecRueda]);
GO

-- Creating foreign key on [idClaseCondicionVictima] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delitos_NNClaseCondicionVictima]
    FOREIGN KEY ([idClaseCondicionVictima])
    REFERENCES [dbo].[NNClaseCondicionVictimas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delitos_NNClaseCondicionVictima'
CREATE INDEX [IX_FK_Delitos_NNClaseCondicionVictima]
ON [dbo].[Delitos]
    ([idClaseCondicionVictima]);
GO

-- Creating foreign key on [idClaseSubtipoArma] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delitos_NNClaseSubtipoArma]
    FOREIGN KEY ([idClaseSubtipoArma])
    REFERENCES [dbo].[NNClaseSubtipoArmas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delitos_NNClaseSubtipoArma'
CREATE INDEX [IX_FK_Delitos_NNClaseSubtipoArma]
ON [dbo].[Delitos]
    ([idClaseSubtipoArma]);
GO

-- Creating foreign key on [idClaseDelito] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delitos_NNClaseTipoDelito]
    FOREIGN KEY ([idClaseDelito])
    REFERENCES [dbo].[NNClaseTipoDelitoes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delitos_NNClaseTipoDelito'
CREATE INDEX [IX_FK_Delitos_NNClaseTipoDelito]
ON [dbo].[Delitos]
    ([idClaseDelito]);
GO

-- Creating foreign key on [idPartido] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delitos_Partido]
    FOREIGN KEY ([idPartido])
    REFERENCES [dbo].[Partidos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delitos_Partido'
CREATE INDEX [IX_FK_Delitos_Partido]
ON [dbo].[Delitos]
    ([idPartido]);
GO

-- Creating foreign key on [idPartidoL] in table 'Delitos'
ALTER TABLE [dbo].[Delitos]
ADD CONSTRAINT [FK_Delitos_Partido1]
    FOREIGN KEY ([idPartidoL])
    REFERENCES [dbo].[Partidos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Delitos_Partido1'
CREATE INDEX [IX_FK_Delitos_Partido1]
ON [dbo].[Delitos]
    ([idPartidoL]);
GO

-- Creating foreign key on [idDelito] in table 'LugaresDeTrasladoDeVictimas'
ALTER TABLE [dbo].[LugaresDeTrasladoDeVictimas]
ADD CONSTRAINT [FK_LugaresDeTrasladoDeVictimas_Delitos]
    FOREIGN KEY ([idDelito])
    REFERENCES [dbo].[Delitos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LugaresDeTrasladoDeVictimas_Delitos'
CREATE INDEX [IX_FK_LugaresDeTrasladoDeVictimas_Delitos]
ON [dbo].[LugaresDeTrasladoDeVictimas]
    ([idDelito]);
GO

-- Creating foreign key on [idDelito] in table 'Rastros'
ALTER TABLE [dbo].[Rastros]
ADD CONSTRAINT [FK_Rastros_delitos]
    FOREIGN KEY ([idDelito])
    REFERENCES [dbo].[Delitos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Rastros_delitos'
CREATE INDEX [IX_FK_Rastros_delitos]
ON [dbo].[Rastros]
    ([idDelito]);
GO

-- Creating foreign key on [idDelito] in table 'Vehiculos'
ALTER TABLE [dbo].[Vehiculos]
ADD CONSTRAINT [FK_vehiculos_Delitos]
    FOREIGN KEY ([idDelito])
    REFERENCES [dbo].[Delitos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_vehiculos_Delitos'
CREATE INDEX [IX_FK_vehiculos_Delitos]
ON [dbo].[Vehiculos]
    ([idDelito]);
GO

-- Creating foreign key on [idDepartamento] in table 'PuntoGestions'
ALTER TABLE [dbo].[PuntoGestions]
ADD CONSTRAINT [FK_PuntoGestion_Departamento]
    FOREIGN KEY ([idDepartamento])
    REFERENCES [dbo].[Departamentoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PuntoGestion_Departamento'
CREATE INDEX [IX_FK_PuntoGestion_Departamento]
ON [dbo].[PuntoGestions]
    ([idDepartamento]);
GO

-- Creating foreign key on [idGrupoUsuario] in table 'PermisoGrupoes'
ALTER TABLE [dbo].[PermisoGrupoes]
ADD CONSTRAINT [FK_Permiso_GrupoUsuario]
    FOREIGN KEY ([idGrupoUsuario])
    REFERENCES [dbo].[GrupoUsuarios]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Permiso_GrupoUsuario'
CREATE INDEX [IX_FK_Permiso_GrupoUsuario]
ON [dbo].[PermisoGrupoes]
    ([idGrupoUsuario]);
GO

-- Creating foreign key on [idGrupoUsuario] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_Usuarios_GrupoUsuario]
    FOREIGN KEY ([idGrupoUsuario])
    REFERENCES [dbo].[GrupoUsuarios]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Usuarios_GrupoUsuario'
CREATE INDEX [IX_FK_Usuarios_GrupoUsuario]
ON [dbo].[Usuarios]
    ([idGrupoUsuario]);
GO

-- Creating foreign key on [idIPP] in table 'PersonaIPPs'
ALTER TABLE [dbo].[PersonaIPPs]
ADD CONSTRAINT [FK_Persona_IPP]
    FOREIGN KEY ([idIPP])
    REFERENCES [dbo].[IPPs]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Persona_IPP'
CREATE INDEX [IX_FK_Persona_IPP]
ON [dbo].[PersonaIPPs]
    ([idIPP]);
GO

-- Creating foreign key on [Partido] in table 'Localidades'
ALTER TABLE [dbo].[Localidades]
ADD CONSTRAINT [FK_Localidad_Partido]
    FOREIGN KEY ([Partido])
    REFERENCES [dbo].[Partidos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Localidad_Partido'
CREATE INDEX [IX_FK_Localidad_Partido]
ON [dbo].[Localidades]
    ([Partido]);
GO

-- Creating foreign key on [Provincia] in table 'Localidades'
ALTER TABLE [dbo].[Localidades]
ADD CONSTRAINT [FK_Localidad_Provincia]
    FOREIGN KEY ([Provincia])
    REFERENCES [dbo].[Provincias]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Localidad_Provincia'
CREATE INDEX [IX_FK_Localidad_Provincia]
ON [dbo].[Localidades]
    ([Provincia]);
GO

-- Creating foreign key on [idLocalidad] in table 'PuntoGestions'
ALTER TABLE [dbo].[PuntoGestions]
ADD CONSTRAINT [FK_PuntoGestion_Localidad]
    FOREIGN KEY ([idLocalidad])
    REFERENCES [dbo].[Localidades]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PuntoGestion_Localidad'
CREATE INDEX [IX_FK_PuntoGestion_Localidad]
ON [dbo].[PuntoGestions]
    ([idLocalidad]);
GO

-- Creating foreign key on [idMarcaVehiculo] in table 'ModeloVehiculoes'
ALTER TABLE [dbo].[ModeloVehiculoes]
ADD CONSTRAINT [FK_ModeloVehiculo_MarcaVehiculo]
    FOREIGN KEY ([idMarcaVehiculo])
    REFERENCES [dbo].[MarcaVehiculoes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ModeloVehiculo_MarcaVehiculo'
CREATE INDEX [IX_FK_ModeloVehiculo_MarcaVehiculo]
ON [dbo].[ModeloVehiculoes]
    ([idMarcaVehiculo]);
GO

-- Creating foreign key on [idMarcaVehiculo] in table 'Vehiculos'
ALTER TABLE [dbo].[Vehiculos]
ADD CONSTRAINT [FK_Vehiculos_MarcaVehiculo]
    FOREIGN KEY ([idMarcaVehiculo])
    REFERENCES [dbo].[MarcaVehiculoes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Vehiculos_MarcaVehiculo'
CREATE INDEX [IX_FK_Vehiculos_MarcaVehiculo]
ON [dbo].[Vehiculos]
    ([idMarcaVehiculo]);
GO

-- Creating foreign key on [IdPadre] in table 'Menus'
ALTER TABLE [dbo].[Menus]
ADD CONSTRAINT [FK_Menu_Padre]
    FOREIGN KEY ([IdPadre])
    REFERENCES [dbo].[Menus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Menu_Padre'
CREATE INDEX [IX_FK_Menu_Padre]
ON [dbo].[Menus]
    ([IdPadre]);
GO

-- Creating foreign key on [IdMenu] in table 'VinculoMenuRecursoes'
ALTER TABLE [dbo].[VinculoMenuRecursoes]
ADD CONSTRAINT [FK_VinculoMenuRecurso_Menu]
    FOREIGN KEY ([IdMenu])
    REFERENCES [dbo].[Menus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VinculoMenuRecurso_Menu'
CREATE INDEX [IX_FK_VinculoMenuRecurso_Menu]
ON [dbo].[VinculoMenuRecursoes]
    ([IdMenu]);
GO

-- Creating foreign key on [idModeloVehiculo] in table 'Vehiculos'
ALTER TABLE [dbo].[Vehiculos]
ADD CONSTRAINT [FK_Vehiculos_ModeloVehiculo]
    FOREIGN KEY ([idModeloVehiculo])
    REFERENCES [dbo].[ModeloVehiculoes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Vehiculos_ModeloVehiculo'
CREATE INDEX [IX_FK_Vehiculos_ModeloVehiculo]
ON [dbo].[Vehiculos]
    ([idModeloVehiculo]);
GO

-- Creating foreign key on [idClaseArma] in table 'NNClaseSubtipoArmas'
ALTER TABLE [dbo].[NNClaseSubtipoArmas]
ADD CONSTRAINT [FK_NNClaseSubtipoArma_NNClaseArma]
    FOREIGN KEY ([idClaseArma])
    REFERENCES [dbo].[NNClaseArmas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_NNClaseSubtipoArma_NNClaseArma'
CREATE INDEX [IX_FK_NNClaseSubtipoArma_NNClaseArma]
ON [dbo].[NNClaseSubtipoArmas]
    ([idClaseArma]);
GO

-- Creating foreign key on [GNC] in table 'Vehiculos'
ALTER TABLE [dbo].[Vehiculos]
ADD CONSTRAINT [FK_Vehiculos_NNClaseBoolean]
    FOREIGN KEY ([GNC])
    REFERENCES [dbo].[NNClaseBooleans]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Vehiculos_NNClaseBoolean'
CREATE INDEX [IX_FK_Vehiculos_NNClaseBoolean]
ON [dbo].[Vehiculos]
    ([GNC]);
GO

-- Creating foreign key on [idClaseEstadoInformeRastro] in table 'Rastros'
ALTER TABLE [dbo].[Rastros]
ADD CONSTRAINT [FK_Rastro_NNClaseEstadoInformeRastro]
    FOREIGN KEY ([idClaseEstadoInformeRastro])
    REFERENCES [dbo].[NNClaseEstadoInformeRastroes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Rastro_NNClaseEstadoInformeRastro'
CREATE INDEX [IX_FK_Rastro_NNClaseEstadoInformeRastro]
ON [dbo].[Rastros]
    ([idClaseEstadoInformeRastro]);
GO

-- Creating foreign key on [idClaseLugar] in table 'NNClaseRubroes'
ALTER TABLE [dbo].[NNClaseRubroes]
ADD CONSTRAINT [FK_NNClaseRubro_NNClaseLugar]
    FOREIGN KEY ([idClaseLugar])
    REFERENCES [dbo].[NNClaseLugars]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_NNClaseRubro_NNClaseLugar'
CREATE INDEX [IX_FK_NNClaseRubro_NNClaseLugar]
ON [dbo].[NNClaseRubroes]
    ([idClaseLugar]);
GO

-- Creating foreign key on [idClaseRastro] in table 'Rastros'
ALTER TABLE [dbo].[Rastros]
ADD CONSTRAINT [FK_Rastro_NNClaseRastro]
    FOREIGN KEY ([idClaseRastro])
    REFERENCES [dbo].[NNClaseRastroes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Rastro_NNClaseRastro'
CREATE INDEX [IX_FK_Rastro_NNClaseRastro]
ON [dbo].[Rastros]
    ([idClaseRastro]);
GO

-- Creating foreign key on [idClaseVidrioVehiculo] in table 'Vehiculos'
ALTER TABLE [dbo].[Vehiculos]
ADD CONSTRAINT [FK_Vehiculo_NNClaseVidrioVehiculo]
    FOREIGN KEY ([idClaseVidrioVehiculo])
    REFERENCES [dbo].[NNClaseVidrioVehiculoes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Vehiculo_NNClaseVidrioVehiculo'
CREATE INDEX [IX_FK_Vehiculo_NNClaseVidrioVehiculo]
ON [dbo].[Vehiculos]
    ([idClaseVidrioVehiculo]);
GO

-- Creating foreign key on [idClaseVinculoVehiculo] in table 'Vehiculos'
ALTER TABLE [dbo].[Vehiculos]
ADD CONSTRAINT [FK_Vehiculo_NNClaseVinculoVehiculo]
    FOREIGN KEY ([idClaseVinculoVehiculo])
    REFERENCES [dbo].[NNClaseVinculoVehiculos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Vehiculo_NNClaseVinculoVehiculo'
CREATE INDEX [IX_FK_Vehiculo_NNClaseVinculoVehiculo]
ON [dbo].[Vehiculos]
    ([idClaseVinculoVehiculo]);
GO

-- Creating foreign key on [idNacionalidad] in table 'Personas'
ALTER TABLE [dbo].[Personas]
ADD CONSTRAINT [FK_Persona_Nacionalidad]
    FOREIGN KEY ([idNacionalidad])
    REFERENCES [dbo].[Paises]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Persona_Nacionalidad'
CREATE INDEX [IX_FK_Persona_Nacionalidad]
ON [dbo].[Personas]
    ([idNacionalidad]);
GO

-- Creating foreign key on [idPais] in table 'PuntoGestions'
ALTER TABLE [dbo].[PuntoGestions]
ADD CONSTRAINT [FK_PuntoGestion_Pais]
    FOREIGN KEY ([idPais])
    REFERENCES [dbo].[Paises]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PuntoGestion_Pais'
CREATE INDEX [IX_FK_PuntoGestion_Pais]
ON [dbo].[PuntoGestions]
    ([idPais]);
GO

-- Creating foreign key on [idProvincia] in table 'Partidos'
ALTER TABLE [dbo].[Partidos]
ADD CONSTRAINT [FK_Partido_Provincia]
    FOREIGN KEY ([idProvincia])
    REFERENCES [dbo].[Provincias]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Partido_Provincia'
CREATE INDEX [IX_FK_Partido_Provincia]
ON [dbo].[Partidos]
    ([idProvincia]);
GO

-- Creating foreign key on [idPartido] in table 'PuntoGestions'
ALTER TABLE [dbo].[PuntoGestions]
ADD CONSTRAINT [FK_PuntoGestion_Partido]
    FOREIGN KEY ([idPartido])
    REFERENCES [dbo].[Partidos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PuntoGestion_Partido'
CREATE INDEX [IX_FK_PuntoGestion_Partido]
ON [dbo].[PuntoGestions]
    ([idPartido]);
GO

-- Creating foreign key on [idAspectoCabello] in table 'PersonasDesaparecidas'
ALTER TABLE [dbo].[PersonasDesaparecidas]
ADD CONSTRAINT [FK_PersonasDesaparecidas_PBClaseAspectoCabello]
    FOREIGN KEY ([idAspectoCabello])
    REFERENCES [dbo].[PBClaseAspectoCabelloes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasDesaparecidas_PBClaseAspectoCabello'
CREATE INDEX [IX_FK_PersonasDesaparecidas_PBClaseAspectoCabello]
ON [dbo].[PersonasDesaparecidas]
    ([idAspectoCabello]);
GO

-- Creating foreign key on [idAspectoCabello] in table 'PersonasHalladas'
ALTER TABLE [dbo].[PersonasHalladas]
ADD CONSTRAINT [FK_PersonasHalladas_PBClaseAspectoCabello]
    FOREIGN KEY ([idAspectoCabello])
    REFERENCES [dbo].[PBClaseAspectoCabelloes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasHalladas_PBClaseAspectoCabello'
CREATE INDEX [IX_FK_PersonasHalladas_PBClaseAspectoCabello]
ON [dbo].[PersonasHalladas]
    ([idAspectoCabello]);
GO

-- Creating foreign key on [FaltanPiezasDentales] in table 'PersonasDesaparecidas'
ALTER TABLE [dbo].[PersonasDesaparecidas]
ADD CONSTRAINT [FK_PersonasDesaparecidas_PBClaseBoolean]
    FOREIGN KEY ([FaltanPiezasDentales])
    REFERENCES [dbo].[PBClaseBooleans]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasDesaparecidas_PBClaseBoolean'
CREATE INDEX [IX_FK_PersonasDesaparecidas_PBClaseBoolean]
ON [dbo].[PersonasDesaparecidas]
    ([FaltanPiezasDentales]);
GO

-- Creating foreign key on [FichasDactilares] in table 'PersonasDesaparecidas'
ALTER TABLE [dbo].[PersonasDesaparecidas]
ADD CONSTRAINT [FK_PersonasDesaparecidas_PBClaseBoolean1]
    FOREIGN KEY ([FichasDactilares])
    REFERENCES [dbo].[PBClaseBooleans]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasDesaparecidas_PBClaseBoolean1'
CREATE INDEX [IX_FK_PersonasDesaparecidas_PBClaseBoolean1]
ON [dbo].[PersonasDesaparecidas]
    ([FichasDactilares]);
GO

-- Creating foreign key on [ExistenRadiografia] in table 'PersonasDesaparecidas'
ALTER TABLE [dbo].[PersonasDesaparecidas]
ADD CONSTRAINT [FK_PersonasDesaparecidas_PBClaseBoolean2]
    FOREIGN KEY ([ExistenRadiografia])
    REFERENCES [dbo].[PBClaseBooleans]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasDesaparecidas_PBClaseBoolean2'
CREATE INDEX [IX_FK_PersonasDesaparecidas_PBClaseBoolean2]
ON [dbo].[PersonasDesaparecidas]
    ([ExistenRadiografia]);
GO

-- Creating foreign key on [ExistenRadiografia] in table 'PersonasHalladas'
ALTER TABLE [dbo].[PersonasHalladas]
ADD CONSTRAINT [FK_PersonasHalladas_PBClaseBoolean]
    FOREIGN KEY ([ExistenRadiografia])
    REFERENCES [dbo].[PBClaseBooleans]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasHalladas_PBClaseBoolean'
CREATE INDEX [IX_FK_PersonasHalladas_PBClaseBoolean]
ON [dbo].[PersonasHalladas]
    ([ExistenRadiografia]);
GO

-- Creating foreign key on [FichasDactilares] in table 'PersonasHalladas'
ALTER TABLE [dbo].[PersonasHalladas]
ADD CONSTRAINT [FK_PersonasHalladas_PBClaseBoolean1]
    FOREIGN KEY ([FichasDactilares])
    REFERENCES [dbo].[PBClaseBooleans]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasHalladas_PBClaseBoolean1'
CREATE INDEX [IX_FK_PersonasHalladas_PBClaseBoolean1]
ON [dbo].[PersonasHalladas]
    ([FichasDactilares]);
GO

-- Creating foreign key on [FaltanPiezasDentales] in table 'PersonasHalladas'
ALTER TABLE [dbo].[PersonasHalladas]
ADD CONSTRAINT [FK_PersonasHalladas_PBClaseBoolean2]
    FOREIGN KEY ([FaltanPiezasDentales])
    REFERENCES [dbo].[PBClaseBooleans]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasHalladas_PBClaseBoolean2'
CREATE INDEX [IX_FK_PersonasHalladas_PBClaseBoolean2]
ON [dbo].[PersonasHalladas]
    ([FaltanPiezasDentales]);
GO

-- Creating foreign key on [idCalvicie] in table 'PersonasDesaparecidas'
ALTER TABLE [dbo].[PersonasDesaparecidas]
ADD CONSTRAINT [FK_PersonasDesaparecidas_PBClaseCalvicie]
    FOREIGN KEY ([idCalvicie])
    REFERENCES [dbo].[PBClaseCalvicies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasDesaparecidas_PBClaseCalvicie'
CREATE INDEX [IX_FK_PersonasDesaparecidas_PBClaseCalvicie]
ON [dbo].[PersonasDesaparecidas]
    ([idCalvicie]);
GO

-- Creating foreign key on [idCalvicie] in table 'PersonasHalladas'
ALTER TABLE [dbo].[PersonasHalladas]
ADD CONSTRAINT [FK_PersonasHalladas_PBClaseCalvicie]
    FOREIGN KEY ([idCalvicie])
    REFERENCES [dbo].[PBClaseCalvicies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasHalladas_PBClaseCalvicie'
CREATE INDEX [IX_FK_PersonasHalladas_PBClaseCalvicie]
ON [dbo].[PersonasHalladas]
    ([idCalvicie]);
GO

-- Creating foreign key on [idColorTenido] in table 'PersonasDesaparecidas'
ALTER TABLE [dbo].[PersonasDesaparecidas]
ADD CONSTRAINT [FK_PersonasDesaparecidas_PBClaseColor]
    FOREIGN KEY ([idColorTenido])
    REFERENCES [dbo].[PBClaseColors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasDesaparecidas_PBClaseColor'
CREATE INDEX [IX_FK_PersonasDesaparecidas_PBClaseColor]
ON [dbo].[PersonasDesaparecidas]
    ([idColorTenido]);
GO

-- Creating foreign key on [idColorTenido] in table 'PersonasHalladas'
ALTER TABLE [dbo].[PersonasHalladas]
ADD CONSTRAINT [FK_PersonasHalladas_PBClaseColor]
    FOREIGN KEY ([idColorTenido])
    REFERENCES [dbo].[PBClaseColors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasHalladas_PBClaseColor'
CREATE INDEX [IX_FK_PersonasHalladas_PBClaseColor]
ON [dbo].[PersonasHalladas]
    ([idColorTenido]);
GO

-- Creating foreign key on [idColorCabello] in table 'PersonasDesaparecidas'
ALTER TABLE [dbo].[PersonasDesaparecidas]
ADD CONSTRAINT [FK_PersonasDesaparecidas_PBClaseColorCabello]
    FOREIGN KEY ([idColorCabello])
    REFERENCES [dbo].[PBClaseColorCabelloes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasDesaparecidas_PBClaseColorCabello'
CREATE INDEX [IX_FK_PersonasDesaparecidas_PBClaseColorCabello]
ON [dbo].[PersonasDesaparecidas]
    ([idColorCabello]);
GO

-- Creating foreign key on [idColorCabello] in table 'PersonasHalladas'
ALTER TABLE [dbo].[PersonasHalladas]
ADD CONSTRAINT [FK_PersonasHalladas_PBClaseColorCabello]
    FOREIGN KEY ([idColorCabello])
    REFERENCES [dbo].[PBClaseColorCabelloes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasHalladas_PBClaseColorCabello'
CREATE INDEX [IX_FK_PersonasHalladas_PBClaseColorCabello]
ON [dbo].[PersonasHalladas]
    ([idColorCabello]);
GO

-- Creating foreign key on [idColorPiel] in table 'PersonasDesaparecidas'
ALTER TABLE [dbo].[PersonasDesaparecidas]
ADD CONSTRAINT [FK_PersonasDesaparecidas_PBClaseColorDePiel]
    FOREIGN KEY ([idColorPiel])
    REFERENCES [dbo].[PBClaseColorDePiels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasDesaparecidas_PBClaseColorDePiel'
CREATE INDEX [IX_FK_PersonasDesaparecidas_PBClaseColorDePiel]
ON [dbo].[PersonasDesaparecidas]
    ([idColorPiel]);
GO

-- Creating foreign key on [idColorPiel] in table 'PersonasHalladas'
ALTER TABLE [dbo].[PersonasHalladas]
ADD CONSTRAINT [FK_PersonasHalladas_PBClaseColorDePiel]
    FOREIGN KEY ([idColorPiel])
    REFERENCES [dbo].[PBClaseColorDePiels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasHalladas_PBClaseColorDePiel'
CREATE INDEX [IX_FK_PersonasHalladas_PBClaseColorDePiel]
ON [dbo].[PersonasHalladas]
    ([idColorPiel]);
GO

-- Creating foreign key on [idColorOjos] in table 'PersonasDesaparecidas'
ALTER TABLE [dbo].[PersonasDesaparecidas]
ADD CONSTRAINT [FK_PersonasDesaparecidas_PBClaseColorOjos]
    FOREIGN KEY ([idColorOjos])
    REFERENCES [dbo].[PBClaseColorOjos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasDesaparecidas_PBClaseColorOjos'
CREATE INDEX [IX_FK_PersonasDesaparecidas_PBClaseColorOjos]
ON [dbo].[PersonasDesaparecidas]
    ([idColorOjos]);
GO

-- Creating foreign key on [idColorOjos] in table 'PersonasHalladas'
ALTER TABLE [dbo].[PersonasHalladas]
ADD CONSTRAINT [FK_PersonasHalladas_PBClaseColorOjos]
    FOREIGN KEY ([idColorOjos])
    REFERENCES [dbo].[PBClaseColorOjos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasHalladas_PBClaseColorOjos'
CREATE INDEX [IX_FK_PersonasHalladas_PBClaseColorOjos]
ON [dbo].[PersonasHalladas]
    ([idColorOjos]);
GO

-- Creating foreign key on [idGrupoSanguineo] in table 'PersonasDesaparecidas'
ALTER TABLE [dbo].[PersonasDesaparecidas]
ADD CONSTRAINT [FK_PersonasDesaparecidas_PBGrupoSanguineo]
    FOREIGN KEY ([idGrupoSanguineo])
    REFERENCES [dbo].[PBClaseGrupoSanguineos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasDesaparecidas_PBGrupoSanguineo'
CREATE INDEX [IX_FK_PersonasDesaparecidas_PBGrupoSanguineo]
ON [dbo].[PersonasDesaparecidas]
    ([idGrupoSanguineo]);
GO

-- Creating foreign key on [idGrupoSanguineo] in table 'PersonasHalladas'
ALTER TABLE [dbo].[PersonasHalladas]
ADD CONSTRAINT [FK_PersonasHalladas_PBGrupoSanguineo]
    FOREIGN KEY ([idGrupoSanguineo])
    REFERENCES [dbo].[PBClaseGrupoSanguineos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasHalladas_PBGrupoSanguineo'
CREATE INDEX [IX_FK_PersonasHalladas_PBGrupoSanguineo]
ON [dbo].[PersonasHalladas]
    ([idGrupoSanguineo]);
GO

-- Creating foreign key on [idLongitudCabello] in table 'PersonasDesaparecidas'
ALTER TABLE [dbo].[PersonasDesaparecidas]
ADD CONSTRAINT [FK_PersonasDesaparecidas_PBClaseLongitudCabello]
    FOREIGN KEY ([idLongitudCabello])
    REFERENCES [dbo].[PBClaseLongitudCabelloes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasDesaparecidas_PBClaseLongitudCabello'
CREATE INDEX [IX_FK_PersonasDesaparecidas_PBClaseLongitudCabello]
ON [dbo].[PersonasDesaparecidas]
    ([idLongitudCabello]);
GO

-- Creating foreign key on [idLongitudCabello] in table 'PersonasHalladas'
ALTER TABLE [dbo].[PersonasHalladas]
ADD CONSTRAINT [FK_PersonasHalladas_PBClaseLongitudCabello]
    FOREIGN KEY ([idLongitudCabello])
    REFERENCES [dbo].[PBClaseLongitudCabelloes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasHalladas_PBClaseLongitudCabello'
CREATE INDEX [IX_FK_PersonasHalladas_PBClaseLongitudCabello]
ON [dbo].[PersonasHalladas]
    ([idLongitudCabello]);
GO

-- Creating foreign key on [idOrganismoInterviniente] in table 'PersonasDesaparecidas'
ALTER TABLE [dbo].[PersonasDesaparecidas]
ADD CONSTRAINT [FK_PersonasDesaparecidas_PBClaseOrganismoInterviniente]
    FOREIGN KEY ([idOrganismoInterviniente])
    REFERENCES [dbo].[PBClaseOrganismoIntervinientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasDesaparecidas_PBClaseOrganismoInterviniente'
CREATE INDEX [IX_FK_PersonasDesaparecidas_PBClaseOrganismoInterviniente]
ON [dbo].[PersonasDesaparecidas]
    ([idOrganismoInterviniente]);
GO

-- Creating foreign key on [idOrganismoInterviniente] in table 'PersonasHalladas'
ALTER TABLE [dbo].[PersonasHalladas]
ADD CONSTRAINT [FK_PersonasHalladas_PBClaseOrganismoInterviniente]
    FOREIGN KEY ([idOrganismoInterviniente])
    REFERENCES [dbo].[PBClaseOrganismoIntervinientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasHalladas_PBClaseOrganismoInterviniente'
CREATE INDEX [IX_FK_PersonasHalladas_PBClaseOrganismoInterviniente]
ON [dbo].[PersonasHalladas]
    ([idOrganismoInterviniente]);
GO

-- Creating foreign key on [idRostro] in table 'PersonasDesaparecidas'
ALTER TABLE [dbo].[PersonasDesaparecidas]
ADD CONSTRAINT [FK_PersonasDesaparecidas_PBClaseRostro]
    FOREIGN KEY ([idRostro])
    REFERENCES [dbo].[PBClaseRostroes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasDesaparecidas_PBClaseRostro'
CREATE INDEX [IX_FK_PersonasDesaparecidas_PBClaseRostro]
ON [dbo].[PersonasDesaparecidas]
    ([idRostro]);
GO

-- Creating foreign key on [idRostro] in table 'PersonasHalladas'
ALTER TABLE [dbo].[PersonasHalladas]
ADD CONSTRAINT [FK_PersonasHalladas_PBClaseRostro]
    FOREIGN KEY ([idRostro])
    REFERENCES [dbo].[PBClaseRostroes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasHalladas_PBClaseRostro'
CREATE INDEX [IX_FK_PersonasHalladas_PBClaseRostro]
ON [dbo].[PersonasHalladas]
    ([idRostro]);
GO

-- Creating foreign key on [idSexo] in table 'PersonasDesaparecidas'
ALTER TABLE [dbo].[PersonasDesaparecidas]
ADD CONSTRAINT [FK_PersonasDesaparecidas_PBClaseSexo]
    FOREIGN KEY ([idSexo])
    REFERENCES [dbo].[PBClaseSexoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasDesaparecidas_PBClaseSexo'
CREATE INDEX [IX_FK_PersonasDesaparecidas_PBClaseSexo]
ON [dbo].[PersonasDesaparecidas]
    ([idSexo]);
GO

-- Creating foreign key on [idSexo] in table 'PersonasHalladas'
ALTER TABLE [dbo].[PersonasHalladas]
ADD CONSTRAINT [FK_PersonasHalladas_PBClaseSexo]
    FOREIGN KEY ([idSexo])
    REFERENCES [dbo].[PBClaseSexoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonasHalladas_PBClaseSexo'
CREATE INDEX [IX_FK_PersonasHalladas_PBClaseSexo]
ON [dbo].[PersonasHalladas]
    ([idSexo]);
GO

-- Creating foreign key on [idRecurso] in table 'PermisoGrupoes'
ALTER TABLE [dbo].[PermisoGrupoes]
ADD CONSTRAINT [FK_PermisoGrupo_Recurso]
    FOREIGN KEY ([idRecurso])
    REFERENCES [dbo].[Recursoes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [idRecurso] in table 'PermisoUsuarios'
ALTER TABLE [dbo].[PermisoUsuarios]
ADD CONSTRAINT [FK_PermisoUsuario_Recurso]
    FOREIGN KEY ([idRecurso])
    REFERENCES [dbo].[Recursoes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PermisoUsuario_Recurso'
CREATE INDEX [IX_FK_PermisoUsuario_Recurso]
ON [dbo].[PermisoUsuarios]
    ([idRecurso]);
GO

-- Creating foreign key on [idUsuario] in table 'PermisoUsuarios'
ALTER TABLE [dbo].[PermisoUsuarios]
ADD CONSTRAINT [FK_PermisoUsuario_Usuarios]
    FOREIGN KEY ([idUsuario])
    REFERENCES [dbo].[Usuarios]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PermisoUsuario_Usuarios'
CREATE INDEX [IX_FK_PermisoUsuario_Usuarios]
ON [dbo].[PermisoUsuarios]
    ([idUsuario]);
GO

-- Creating foreign key on [idPersona] in table 'PersonaIPPs'
ALTER TABLE [dbo].[PersonaIPPs]
ADD CONSTRAINT [FK_Persona]
    FOREIGN KEY ([idPersona])
    REFERENCES [dbo].[Personas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Persona'
CREATE INDEX [IX_FK_Persona]
ON [dbo].[PersonaIPPs]
    ([idPersona]);
GO

-- Creating foreign key on [idCreador] in table 'Personas'
ALTER TABLE [dbo].[Personas]
ADD CONSTRAINT [FK_Persona_Creador]
    FOREIGN KEY ([idCreador])
    REFERENCES [dbo].[Usuarios]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Persona_Creador'
CREATE INDEX [IX_FK_Persona_Creador]
ON [dbo].[Personas]
    ([idCreador]);
GO

-- Creating foreign key on [idProvincia] in table 'Personas'
ALTER TABLE [dbo].[Personas]
ADD CONSTRAINT [FK_Persona_Provincia]
    FOREIGN KEY ([idProvincia])
    REFERENCES [dbo].[Provincias]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Persona_Provincia'
CREATE INDEX [IX_FK_Persona_Provincia]
ON [dbo].[Personas]
    ([idProvincia]);
GO

-- Creating foreign key on [idTipoDNI] in table 'Personas'
ALTER TABLE [dbo].[Personas]
ADD CONSTRAINT [FK_Persona_TipoDocumento]
    FOREIGN KEY ([idTipoDNI])
    REFERENCES [dbo].[TPClaseTipoDNIs]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Persona_TipoDocumento'
CREATE INDEX [IX_FK_Persona_TipoDocumento]
ON [dbo].[Personas]
    ([idTipoDNI]);
GO

-- Creating foreign key on [idPersona] in table 'PersonalPoderJudicials'
ALTER TABLE [dbo].[PersonalPoderJudicials]
ADD CONSTRAINT [FK_PersonalPoderJudicial_Persona]
    FOREIGN KEY ([idPersona])
    REFERENCES [dbo].[Personas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonalPoderJudicial_Persona'
CREATE INDEX [IX_FK_PersonalPoderJudicial_Persona]
ON [dbo].[PersonalPoderJudicials]
    ([idPersona]);
GO

-- Creating foreign key on [idPersona] in table 'SeniasParticulares'
ALTER TABLE [dbo].[SeniasParticulares]
ADD CONSTRAINT [FK_SeniasParticulares_Persona]
    FOREIGN KEY ([idPersona])
    REFERENCES [dbo].[Personas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SeniasParticulares_Persona'
CREATE INDEX [IX_FK_SeniasParticulares_Persona]
ON [dbo].[SeniasParticulares]
    ([idPersona]);
GO

-- Creating foreign key on [idPersona] in table 'TatuajesPersonas'
ALTER TABLE [dbo].[TatuajesPersonas]
ADD CONSTRAINT [FK_TatuajesPersona_Persona]
    FOREIGN KEY ([idPersona])
    REFERENCES [dbo].[Personas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TatuajesPersona_Persona'
CREATE INDEX [IX_FK_TatuajesPersona_Persona]
ON [dbo].[TatuajesPersonas]
    ([idPersona]);
GO

-- Creating foreign key on [idPersona] in table 'PersonaTipoes'
ALTER TABLE [dbo].[PersonaTipoes]
ADD CONSTRAINT [FK_tipoPersonaPersona]
    FOREIGN KEY ([idPersona])
    REFERENCES [dbo].[Personas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tipoPersonaPersona'
CREATE INDEX [IX_FK_tipoPersonaPersona]
ON [dbo].[PersonaTipoes]
    ([idPersona]);
GO

-- Creating foreign key on [idPuntoGestion] in table 'PersonalPoderJudicials'
ALTER TABLE [dbo].[PersonalPoderJudicials]
ADD CONSTRAINT [FK_PersonalPoderJudicial_PuntoGestion]
    FOREIGN KEY ([idPuntoGestion])
    REFERENCES [dbo].[PuntoGestions]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonalPoderJudicial_PuntoGestion'
CREATE INDEX [IX_FK_PersonalPoderJudicial_PuntoGestion]
ON [dbo].[PersonalPoderJudicials]
    ([idPuntoGestion]);
GO

-- Creating foreign key on [idPersonalPoderJudicial] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_Usuarios_PersonalPoderJudicial]
    FOREIGN KEY ([idPersonalPoderJudicial])
    REFERENCES [dbo].[PersonalPoderJudicials]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Usuarios_PersonalPoderJudicial'
CREATE INDEX [IX_FK_Usuarios_PersonalPoderJudicial]
ON [dbo].[Usuarios]
    ([idPersonalPoderJudicial]);
GO

-- Creating foreign key on [idProvincia] in table 'PuntoGestions'
ALTER TABLE [dbo].[PuntoGestions]
ADD CONSTRAINT [FK_PuntoGestion_Provincia]
    FOREIGN KEY ([idProvincia])
    REFERENCES [dbo].[Provincias]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PuntoGestion_Provincia'
CREATE INDEX [IX_FK_PuntoGestion_Provincia]
ON [dbo].[PuntoGestions]
    ([idProvincia]);
GO

-- Creating foreign key on [idPadrePG] in table 'PuntoGestions'
ALTER TABLE [dbo].[PuntoGestions]
ADD CONSTRAINT [FK_PuntoGestion_PuntoGestionPadre]
    FOREIGN KEY ([idPadrePG])
    REFERENCES [dbo].[PuntoGestions]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PuntoGestion_PuntoGestionPadre'
CREATE INDEX [IX_FK_PuntoGestion_PuntoGestionPadre]
ON [dbo].[PuntoGestions]
    ([idPadrePG]);
GO

-- Creating foreign key on [IdRecurso] in table 'VinculoMenuRecursoes'
ALTER TABLE [dbo].[VinculoMenuRecursoes]
ADD CONSTRAINT [FK_VinculoMenuRecurso_Recurso]
    FOREIGN KEY ([IdRecurso])
    REFERENCES [dbo].[Recursoes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VinculoMenuRecurso_Recurso'
CREATE INDEX [IX_FK_VinculoMenuRecurso_Recurso]
ON [dbo].[VinculoMenuRecursoes]
    ([IdRecurso]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------