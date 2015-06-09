
-------------------------------------
--recordar linkear servidores por unica vez
--cambiar los 2 lugares donde dice top 50 acorde a la cantidad que se quiera migrar
------------------------------------------

----------------------------
--descomentar para matar todas las conexiones
--------------------------------------
--use master
--ALTER DATABASE ISIC SET SINGLE_USER WITH ROLLBACK IMMEDIATE 
go

USE SIAC
GO

--DELETE Archivo
--DELETE BioDactilar
--DELETE Imputados
--DELETE SicEstadoTramite
--DELETE Autores
--DELETE Delitos
--DELETE Comisaria
--DELETE AutoresAlias
--DELETE Persona
--DELETE Domicilios
--DELETE localidad
--DELETE Partido
--DELETE Provincia
--DELETE IPP
--DELETE DescripcionTemporal
--DELETE Delitos
--DELETE Archivo
--DELETE ClaseTipoArchivo
--DELETE SeniasParticulares


IF EXISTS (
    SELECT * FROM sysobjects WHERE id = object_id(N'dbo.extraernros') 
    AND xtype IN (N'FN', N'IF', N'TF')
)
	DROP FUNCTION dbo.extraernros
	GO


------------------
--SICESTADOTRAMITE
------------------
--insert into SICEstadoTramite(id, Descripcion) VALUES(1,'Operaciones')
--insert into SICEstadoTramite(id, Descripcion) VALUES(2,'AFIS')
--insert into SICEstadoTramite(id, Descripcion) VALUES(3,'GNA')
--insert into SICEstadoTramite(id, Descripcion) VALUES(4,'Antecedentes')
--insert into SICEstadoTramite(id, Descripcion) VALUES(5,'Mesa de Entradas')
--insert into SICEstadoTramite(id, Descripcion) VALUES(6,'Archivo Mesa de Entradas')
--insert into SICEstadoTramite(id, Descripcion) VALUES(7,'Archivo Definitivo')
--insert into SICEstadoTramite(id, Descripcion) VALUES(8,'Migraciones')
--insert into SICEstadoTramite(id, Descripcion) VALUES(9,'OTIP')

-----------------
--claseseniaparticular
------------------
--SET IDENTITY_INSERT ClaseSeniaParticular ON

--DELETE ClaseSeniaParticular
--INSERT INTO ClaseSeniaParticular(Id,Descripcion) VALUES(0,'Indeterminado')
----INSERT INTO ClaseSeniaParticular(Id,Descripcion) VALUES(1,'Tatuaje')
--INSERT INTO ClaseSeniaParticular(Id,Descripcion) VALUES(1,'Cicatriz')
--INSERT INTO ClaseSeniaParticular(Id,Descripcion) VALUES(2,'Lunares/Verruga')
--SET IDENTITY_INSERT ClaseSeniaParticular OFF

-----------------
--claseubicacionseniapart
------------------
--SET IDENTITY_INSERT ClaseSeniaParticular ON

--DELETE ClaseUbicacionSeniaPart
--INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion)
--SELECT id, descripcion FROM [mpbdsic01].basesic.dbo.partesCuerpo
--INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion) VALUES(23, 'Cuerpo Entero')
--INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion) VALUES(24, 'Axila Izquierda')
--INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion) VALUES(25, 'Axila Derecha')
--INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion) VALUES(26, 'Perfil Derecho')
--INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion) VALUES(27, 'Perfil Izquierdo')
--INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion) VALUES(28, 'Codo Izquierdo')
--INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion) VALUES(29, 'Codo Derecho')
--INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion) VALUES(30, 'Pantorrilla Derecha')
--INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion) VALUES(31, 'Pantorrilla Izquierda')
--INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion) VALUES(32, 'Muslo Derecho')
--INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion) VALUES(33, 'Muslo Izquierdo')
--INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion) VALUES(34, 'Rodilla Derecha')
--INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion) VALUES(35, 'Rodilla Izquierda')
--INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion) VALUES(36, 'Dentadura/Boca')
--INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion) VALUES(37, 'Tobillo Derecho')
--INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion) VALUES(38, 'Tobillo Izquierdo')
--INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion) VALUES(39, 'Glúteos')
--INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion) VALUES(40, 'Pie Izquierdo')
--INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion) VALUES(41, 'Pie Derecho')
--INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion) VALUES(42, 'Otro')
--UPDATE ClaseUbicacionSeniaPart SET Descripcion='Vientre/Abdomen/Cintura' WHERE Descripcion='Vientre'
--UPDATE ClaseUbicacionSeniaPart SET Descripcion='Hombro Derecho' WHERE Descripcion='Hombre Derecho'
--SET IDENTITY_INSERT ClaseSeniaParticular OFF

-----------------
--profesiones
------------------
--DELETE ClaseProfesion
--INSERT INTO ClaseProfesion(Id,Descripcion)
--SELECT id, descripcion FROM [mpbdsic01].isic.dbo.profesiones


-----------------
--ClaseTipoArchivo
------------------

--DELETE ClaseTipoArchivo
--INSERT INTO ClaseTipoArchivo(id, descripcion) VALUES(1,'Foto Rostro')
--INSERT INTO ClaseTipoArchivo(id, descripcion) VALUES(2,'Foto Señas')
--INSERT INTO ClaseTipoArchivo(id, descripcion) VALUES(3,'Foto Tatuaje')
--INSERT INTO ClaseTipoArchivo(id, descripcion) VALUES(4,'Imagen Huellas')
--INSERT INTO ClaseTipoArchivo(id, descripcion) VALUES(5,'Documentación')
--RECORDAR: AGREGAR TATUAJE Y PONER NO TATUAJE A SENAS


-----------------
--ClaseNombre
------------------
--INSERT INTO ClaseNombre(Descripcion, sexo_Id)
--SELECT nombre, CASE WHEN sexo='M' THEN 1 ELSE 2 END AS sexoid FROM  [mpbdsic01].isic.dbo.nombres



-----------------
--ClaseDepartamentoJudicial
------------------
--DELETE ClaseDepartamentoJudicial
--INSERT INTO ClaseDepartamentoJudicial(id,sigDto,descripcion,idSIMP)
--SELECT id,sigDto,descripcion,idSimp FROM  [mpbdsic01].isic.dbo.deptojud


----------------
--VARIOS
----------------

--INSERT LOCALIDAD(Id, Localidad, Partido_Id, Provincia_Id)
--SELECT max(Id)+1,'Adrogue', 955, 15 FROM Localidad
--INSERT LOCALIDAD(Id, Localidad, Partido_Id, Provincia_Id)
--SELECT max(Id)+1,'Don Orione', 955, 15 FROM Localidad
-- INSERT LOCALIDAD(Id, Localidad, Partido_Id, Provincia_Id)
--SELECT max(Id)+1,'Villa Celina', 933, 15 FROM Localidad
--INSERT partido(Id, partido,provincia_id, idprovincia)
--SELECT max(id)+1,'Cañuelas', 15, 15 FROM partido
--INSERT LOCALIDAD(Id, Localidad, Partido_Id, Provincia_Id)
--SELECT max(id)+1,'Cañuelas', 956, 15 FROM Localidad
--INSERT LOCALIDAD(Id, Localidad, Partido_Id, Provincia_Id)
--SELECT max(id)+1,'Ingeniero Budge', 927, 15 FROM Localidad
--INSERT LOCALIDAD(Id, Localidad, Partido_Id, Provincia_Id)
--SELECT max(id)+1,'Billinghurst', 947, 15 FROM Localidad
--INSERT LOCALIDAD(Id, Localidad, Partido_Id, Provincia_Id)
--SELECT max(id)+1,'William Morris', 923, 15 FROM Localidad
--INSERT LOCALIDAD(Id, Localidad, Partido_Id, Provincia_Id)
--SELECT max(id)+1,'Capilla del Señor', 108, 15 FROM Localidad
--update Localidad set localidad='Lavallol' where id=12837
--update Provincia set Provincia='Buenos Aires' where id=15
--insert into localidad(id, Localidad, Partido_Id, Provincia_Id)
--select max(id)+1,'Presidencia Roque Saenz Peña', 693, 3 from localidad
--insert into localidad(id, Localidad, Partido_Id, Provincia_Id)
--select max(id)+1,'Las Breñas', 686, 3 from localidad



-----------------
--AUTORES / IMPUTADOS
------------------

IF object_id('tempdb..#tempGral') IS NOT NULL
	DROP table #tempGral 
GO


IF object_id('tempdb..#tmpArchivos') IS NOT NULL
	DROP table #tmpArchivos
GO

IF NOT EXISTS(SELECT * FROM sys.columns 
        WHERE [name] = N'CodBarra' AND [object_id] = OBJECT_ID(N'Autores'))
BEGIN
	ALTER TABLE Autores ADD CodBarra VARCHAR(13)
END
GO

INSERT INTO Autores(CodBarra, FechaUltimaModificacion, OtrosNombres, Estatura, idDimensionCeja, idTipoCeja, idClaseColorCabello, idClaseColorOjos, idClaseColorPiel, idFormaBoca, idClaseFormaCara, idFormaLabioInferior, idFormaLabioSuperior, idFormaMenton, idFormaNariz, idClaseRobustez, idClaseTipoCabello, idClaseCalvicie, idClaseEstatura)
SELECT DISTINCT TOP 500  d.CodBarra, GETDATE()AS FechaUltimaModificacion, otrosnombres, estatura ,cd.id cd, ct.id ct, cc.id cc, co.id co, cp.id cp, fb.id fb, fc.id fc, fli.id fli, fls.id fls, fm.id fm, fn.id fn, r.id r, tcab.id tcab, tcalv.id tcalv, e.id e
FROM  [mpbdsic01].basesic.dbo.[1TMDELITOSIC] d 
LEFT JOIN  [mpbdsic01].basesic.dbo.[1TOtrosNombresSic] o ON d.codbarra=o.codbarra 
LEFT JOIN  [mpbdsic01].basesic.dbo.[1TAliaSic] a ON d.codbarra=a.codbarra 
LEFT JOIN SICClaseCejasTipo ct ON SUBSTRING(DATI_SOMATICI,6,1)=ct.letra COLLATE DATABASE_DEFAULT
LEFT JOIN SICClaseColorCabello cc ON SUBSTRING(DATI_SOMATICI,54,1)=cc.letra COLLATE DATABASE_DEFAULT
LEFT JOIN SICClaseCejasDimension cd ON SUBSTRING(DATI_SOMATICI,5,1)=cd.letra COLLATE DATABASE_DEFAULT
LEFT JOIN SICClaseColorOjos co ON SUBSTRING(DATI_SOMATICI,53,1)=co.letra COLLATE DATABASE_DEFAULT
LEFT JOIN SICClaseColorPiel cp ON SUBSTRING(DATI_SOMATICI,51,1)=cp.letra COLLATE DATABASE_DEFAULT
LEFT JOIN SICClaseFormaBoca fb ON SUBSTRING(DATI_SOMATICI,17,1)=fb.letra COLLATE DATABASE_DEFAULT
LEFT JOIN SICClaseFormaMenton fm ON SUBSTRING(DATI_SOMATICI,21,1)=fm.letra COLLATE DATABASE_DEFAULT
LEFT JOIN SICClaseFormaNariz fn ON SUBSTRING(DATI_SOMATICI,47,1)=fn.letra COLLATE DATABASE_DEFAULT
LEFT JOIN SICClaseFormaOreja fo ON SUBSTRING(DATI_SOMATICI,25,1)=fo.letra COLLATE DATABASE_DEFAULT
LEFT JOIN SICClaseRobustez r ON SUBSTRING(DATI_SOMATICI,62,1)=r.letra COLLATE DATABASE_DEFAULT
LEFT JOIN SICClaseTipoCabello tcab ON SUBSTRING(DATI_SOMATICI,28,1)=tcab.letra COLLATE DATABASE_DEFAULT
LEFT JOIN SICClaseTipoCalvicie tcalv ON SUBSTRING(DATI_SOMATICI,31,1)=tcalv.letra COLLATE DATABASE_DEFAULT
LEFT JOIN SICClaseFormaLabioInferior fli ON SUBSTRING(DATI_SOMATICI,20,1)=fli.letra COLLATE DATABASE_DEFAULT
LEFT JOIN SICClaseFormaLabioSuperior fls ON SUBSTRING(DATI_SOMATICI,19,1)=fls.letra COLLATE DATABASE_DEFAULT
LEFT JOIN SICClaseFormaCara fc ON SUBSTRING(DATI_SOMATICI,1,1)=fc.letra COLLATE DATABASE_DEFAULT
LEFT JOIN SICClaseEstatura e ON SUBSTRING(DATI_SOMATICI,60,1)=e.letra COLLATE DATABASE_DEFAULT
------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------
--WHERE D.CODBARRA LIKE '0117000029%'--------------------------------------------------------------------------------CAMBIAR!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------
 ORDER BY d.codbarra 

INSERT INTO Imputados(id,ProntuarioSIC, idEstado, idNroCarpeta, CodigoDeBarras, CodigoDeBarrasOriginal,FechaCreacionI, ManoDerecha, ManoIzquierda)
SELECT a.id, d.prontuariosic, st.id, nroCarpeta, d.codbarra, d.codbarra, ISNULL(feentlase,''),0,0
FROM autores a 
JOIN  [mpbdsic01].basesic.dbo.[1TMDELItosic] d ON d.codbarra=a.codbarra COLLATE DATABASE_DEFAULT
LEFT JOIN SicEstadoTramite st ON ISNULL(d.codestado,'0')/100=st.id
----ALIAS
--IF NOT EXISTS(SELECT * FROM sys.columns 
--        WHERE [name] = N'CodBarra' AND [object_id] = OBJECT_ID(N'AutoresAlias'))
--BEGIN
--	ALTER TABLE AutoresAlias ADD CodBarra VARCHAR(13)
--END
--GO

INSERT INTO AutoresAlias(Alias, idAutor)
SELECT DISTINCT   al.alias,  a.id FROM  [mpbdsic01].basesic.dbo.[1TAliaSic] al JOIN Autores a on al.codbarra=a.codbarra COLLATE DATABASE_DEFAULT 
--WHERE NOT EXISTS(SELECT codbarra from AutoresAlias where autoresalias.codbarra=al.codbarra COLLATE DATABASE_DEFAULT)
/*UPDATE aut SET aut.idAlias=aa.id FROM AutoresAlias aa JOIN Autores aut ON aa.codbarra=aut.codbarra */


 
CREATE FUNCTION dbo.extraerNros	(@strAlphaNumeric VARCHAR(256)) RETURNS VARCHAR(256) AS
BEGIN
	DECLARE @intAlpha INT
	SET @intAlpha = PATINDEX('%[^0-9]%', @strAlphaNumeric)
		BEGIN
			WHILE @intAlpha > 0
				BEGIN
					SET @strAlphaNumeric = STUFF(@strAlphaNumeric, @intAlpha, 1, '' )
					SET @intAlpha = PATINDEX('%[^0-9]%', @strAlphaNumeric )
				END
		END
	RETURN ISNULL(@strAlphaNumeric,0)
END
GO


-----PERSONAS
IF NOT EXISTS(SELECT * FROM sys.columns 
        WHERE [name] = N'CodBarra' AND [object_id] = OBJECT_ID(N'Persona'))
BEGIN
	ALTER TABLE Persona ADD CodBarra VARCHAR(13)
END
GO

SELECT top 500 f.apyn as conyuge, d.dependencia,  d.ipp,d.fiscal, d.fecha, d.juzgar, d.codbarra, d.caratula,d.feentlase, apellido, d.ufi, ISNULL(s.Id,0) as idSexo, d.domicilio, docnro, idLocalidad, dd.localidad as localidad2, FecargaOP, FecargaOP as fecargaop2, feNac, d.lugarNac, madre, Nombres, padre, profesion, te, dd.provincia, dd.partido as idPartido,
CASE WHEN d.tipo LIKE '%pas%' THEN 5
				WHEN d.tipo LIKE 'C%' THEN 4
				ELSE ISNULL(doc.Id,0) 
				END AS idTipoDNI,
			CASE WHEN d.ecivil LIKE '%SOLE%' OR d.ecivil LIKE '%SOTE%' THEN 1
				ELSE ISNULL(ec.Id,0)
				END AS idEstadoCivil,
			CASE WHEN d.estudios LIKE '%grad%' OR d.estudios='1' THEN 1 --primaria
				WHEN d.estudios LIKE '%año%' THEN 2 --secundaria
				WHEN d.estudios LIKE '%licenciatura%' THEN 3 --terciaria 
				WHEN d.estudios LIKE '%doctorado' THEN 4 --universitaria
				WHEN d.estudios LIKE '%anal%' THEN 5
				ELSE ISNULL(e.Id,0)
				END as idEstudiosCursados,
			CASE WHEN paisnac LIKE '%nti%' THEN 2
		        WHEN paisnac LIKE '%arg%' THEN 2
			    WHEN paisnac LIKE '%ucran%' THEN 228
	            WHEN paisnac LIKE '%corea%' THEN 59
				WHEN paisnac LIKE '%arabia%' THEN 13
				WHEN paisnac LIKE '%ita%' THEN 113
				WHEN paisnac LIKE '%domi%' THEN 66
				WHEN paisnac LIKE '%espa%' THEN 74
				WHEN paisnac LIKE '%ingla%' THEN 181
				WHEN paisnac LIKE '%ee.%' THEN 76
				WHEN p.id=15 THEN 2
				ELSE pa.id END AS idPaisNac,
			CASE WHEN d.pcianac like 'bs%' then 11 
				WHEN d.pcianac like '%chile%' then 0
				 WHEN d.pcianac like '%negro%' then 25
				WHEN d.pcianac like '%entre%' then 17
				WHEN d.pcianac like '%pampa%' then 20
				WHEN d.pcianac like '%juan%' then 27
				when d.pcianac like 'sgo%' then 31
				when d.pcianac like '%ctes%' then 14
				when d.pcianac like '%sta%' then 30
				when d.pcianac like '%rios%' then 17
				when d.pcianac like '%bue%' then 11
				when d.pcianac like '%luis%' then 28
				when d.pcianac like '%fe%' then 30
				when d.pcianac like '%estero%' then 31
				when d.pcianac like '%doba%' then 13
				when d.pcianac like '%air%' then 11
				when d.pcianac like '%cruz%' then 29
				when d.pcianac like '%tucu%' then 32
				when d.pcianac like '%tierra%' then 33
				when d.pcianac like '%chac%' then 15
				when d.pcianac like '%rioja%' then 21
				when d.pcianac like '%corr%' then 14
				when d.pcianac like '%cap%' then 1
				when d.pcianac like '%caba%' then 1
				when d.pcianac like '%tandil%' then 11
				when d.pcianac like '%mza%' then 22
				when d.pcianac like '%santi%' then 31
				when d.pcianac like '%neuq%' then 24
				when d.pcianac like '%mis%' then 23
				when d.pcianac like '%cba%' then 1
				else p.id END AS idProvNac,
	      CASE WHEN d.lugarnac='capital federal' THEN 1665
				WHEN d.lugarnac like '%federal%' THEN 1665
			   WHEN d.lugarnac='JOSE C. PAZ' THEN 699
				WHEN d.lugarnac='JOSE C PAZ' THEN 699
				WHEN d.lugarnac='LANUS ESTE' THEN 840
				WHEN d.lugarnac='lanus oeste' THEN 841
				WHEN d.lugarnac='escobar' THEN 500
				WHEN d.lugarnac='adrogue' THEN 18 
				WHEN d.lugarnac='LAFERRERE' THEN 620
				WHEN d.lugarnac='Bernal' THEN 183
		       WHEN d.lugarnac='FCIO VARELA' THEN 535
				WHEN d.lugarnac='VILLA TESEI' THEN 1338
				WHEN d.lugarnac='GRAL. RODRIGUEZ' THEN 586
				WHEN d.lugarnac='VILLA FIORITO' THEN 1474
				WHEN d.lugarnac='MAQUINISTA SAVIO' THEN 947
				WHEN d.lugarnac='DON ORIONE' THEN 1613 
				WHEN d.lugarnac='Villa Celina' THEN 1450  
				WHEN d.lugarnac='GRAL RODRIGUEZ' THEN 586
				WHEN d.lugarnac='BILLINGHURST' THEN 186
				WHEN d.lugarnac='CAÑUELAS' THEN 287 
				WHEN d.lugarnac='SOLANO' THEN 1253
				WHEN d.lugarnac='VILLA MADERO' THEN 1517
				WHEN d.lugarnac='ESTEBAN ECHEVERRIA' THEN 512
				WHEN d.lugarnac='CAP FED' THEN 1665
				WHEN d.lugarnac='EZPELETA' THEN 521
				WHEN d.lugarnac='INGENIERO BUDGE' THEN 667 
				WHEN d.lugarnac='FCIO. VARELA' THEN 535
				WHEN d.lugarnac='MTE GRANDE' THEN 1008
				WHEN d.lugarnac='VILLA DORREGO' THEN 1466
				WHEN d.lugarnac='BRANDSEN' THEN 348
				WHEN d.lugarnac='TRANSRADIO' THEN 1572
				WHEN d.lugarnac='WILLIAM MORRIS' THEN 1593
				WHEN d.lugarnac='SPEGAZZINI' THEN 272
				WHEN d.lugarnac='ALTE BROWN' THEN 37
				WHEN d.lugarnac='HUDSON' THEN 631
				WHEN d.lugarnac='G. CATAN' THEN 607
				WHEN d.lugarnac='CAPILLA DEL SEÑOR' THEN 256
				WHEN d.lugarnac='CIUDADELA NORTE' THEN 1651
				WHEN d.lugarnac='HURLINGHAN' THEN 652
				WHEN d.lugarnac='G CATAN' THEN 607
				WHEN d.lugarnac='ING BUDGE' THEN 667
				WHEN d.lugarnac='BUDGE' THEN 667
				WHEN d.lugarnac='VILLA MAIPU' THEN 1518
				WHEN d.lugarnac='R. CALZADA' THEN 1177
				WHEN d.lugarnac='JOSE C.PAZ' THEN 699
				WHEN d.lugarnac='VILLA DIAMANTE' THEN 1461
				WHEN d.lugarnac='LAVALLOL' THEN 887
			    WHEN d.lugarnac='LLAVALLOL' THEN 887
			   WHEN d.lugarnac='GONNET' THEN 940
		       WHEN d.lugarnac='AMEGHINO' THEN 48
				WHEN d.lugarnac='TOLOSA' THEN 1344
				WHEN d.lugarnac='BARRIO MATERA' THEN 1632
				WHEN d.lugarnac='G.CATAN' THEN 607
				WHEN d.lugarnac='VILLA CARAZA' THEN 1448
				WHEN d.lugarnac='CASANOVA' THEN 683
				WHEN d.lugarnac like '%avell%' THEN 107
				WHEN d.lugarnac='lanus' THEN 839
				WHEN d.lugarnac='pergamino' THEN 1104
				WHEN d.lugarnac='lomas de zamora' THEN 896
				WHEN d.lugarnac='quilmes' THEN 1171
				WHEN d.lugarnac='colon' THEN 322
				WHEN d.lugarnac='ezeiza' THEN 520
				WHEN d.lugarnac='LA FERRERE' THEN 620
				WHEN d.lugarnac='CABA' THEN 1665
				WHEN d.lugarnac='autonoma' THEN 1665
				WHEN d.lugarnac='GRAL.RODRIGUEZ' THEN 586
				WHEN d.lugarnac='F. VARELA' THEN 535
				WHEN d.lugarnac='ADOLFO GONZALEZ CHAVES' THEN 608
				WHEN d.lugarnac='PQUE. SAN MARTIN' THEN 1077
				WHEN d.lugarnac='ALTOS DE LAFERRERE' THEN 1612
				WHEN d.lugarnac='ING. BUDGE' THEN 667
				WHEN d.lugarnac='PACHECO' THEN 582
				WHEN d.lugarnac='S.A.DE GILES' THEN 1241
				WHEN d.lugarnac='VILLA BONICH' THEN 1442
				WHEN d.lugarnac='R. CASTILLO' THEN 1178
				WHEN d.lugarnac='I. CASANOVA' THEN 683
				WHEN d.lugarnac='S.A.DE ARECO' THEN 1243
				WHEN d.lugarnac='I.CASANOVA' THEN 683
				WHEN d.lugarnac='CAP. FED.' THEN 1665
				WHEN d.lugarnac='CAPITAL FEDERAL' THEN 1665
				WHEN d.lugarnac='RINGUELET' THEN 1199
				WHEN d.lugarnac='SAN A. DE PADUA' THEN 1237
				WHEN d.lugarnac='G. LAFERRERE' THEN 620
				WHEN d.lugarnac='C. SPEGAZZINI' THEN 272
				WHEN d.lugarnac='EST. ECHEVERRIA' THEN 512
				WHEN d.lugarnac='ALTE. BROWN' THEN 479
				WHEN d.lugarnac='ING.BUDGE' THEN 667
				WHEN d.lugarnac='F VARELA' THEN 535
		       WHEN d.lugarnac= 'TUCUMAN' THEN 21097
		       WHEN d.lugarnac='chaco' THEN 6777
		       WHEN d.lugarnac='ROQUE SAENZ PEÑA' THEN 1225
			   WHEN d.lugarnac='SAENZ PEÑA' THEN 1225
		       WHEN d.lugarnac='CORDOBA' THEN 3029
			   WHEN d.lugarnac='CORDOBA CAPITAL' THEN 3029
			   WHEN d.lugarnac='santa fe capital' THEN 17335
			   WHEN d.lugarnac='GRAL. MADARIAGA' THEN 4970
		       WHEN d.lugarnac='CAPITAL' THEN 1665
		       WHEN d.lugarnac='JUJUY' THEN 8863
		       WHEN d.lugarnac='LAS BREÑAS' THEN 6301
		       WHEN d.lugarnac='CATAMARCA' THEN 2160
		       WHEN d.lugarnac='RAMOS MEJIAS' THEN 1184
		       WHEN d.lugarnac='VTE LOPEZ' THEN 1420
		       WHEN d.lugarnac='MONTERO' THEN 21925
		       WHEN d.lugarnac='GONZALEZ CHAVEZ' THEN 608
			   WHEN d.lugarnac='POLVORINES' THEN 921
			   WHEN d.lugarnac='CIUDAD AUTONOMA DE BUENOS AIRES' THEN 1665
	           ELSE dd.ID END AS idLocNac, 
			CASE WHEN (isnull(pcianac,'')!='' and p.id is null) AND (isnull(paisnac,'')!='' and pa.id is null) AND (isnull(d.lugarnac,'')!='' and dd.ID is null) AND (ISNULL(d.localidad,'')!='' AND idLocalidad IS NULL) THEN 'localidad: '+d.localidad+ '; pciaNac: '+pcianac+'; paisNac: '+paisNac+'; LocNac: '+d.lugarNac + '; ' 
				WHEN (isnull(pcianac,'')!='' and p.id is null) AND (isnull(paisnac,'')!='' and pa.id is null)AND (ISNULL(d.localidad,'')!='' AND idLocalidad IS NULL)  THEN 'localidad: '+d.localidad+ '; pciaNac: '+pcianac+'; paisNac: '+paisNac+'; ' 
				WHEN (isnull(pcianac,'')!='' and p.id is null) AND (isnull(d.lugarnac,'')!='' and dd.ID is null) AND (ISNULL(d.localidad,'')!='' AND idLocalidad IS NULL) THEN 'localidad: '+d.localidad+ '; pciaNac: '+pcianac+'; LocNac: '+d.LugarNac+'; '  
				WHEN (isnull(paisnac,'')!='' and p.id is null) AND (isnull(d.lugarnac,'')!='' and dd.ID is null) AND (ISNULL(d.localidad,'')!='' AND idLocalidad IS NULL) THEN 'localidad: '+d.localidad+ '; pciaNac: '+paisNac+'; LocNac: '+d.LugarNac+'; '  
				WHEN (isnull(paisnac,'')!='' and p.id is null) AND (isnull(d.lugarnac,'')!='' and dd.ID is null) AND (ISNULL(pcianac,'')!='' AND p.id IS NULL) THEN 'pciaNac: '+pcianac+ '; paisNac: '+paisNac+'; LocNac: '+d.LugarNac+'; '  
				WHEN (isnull(paisnac,'')!='' and pa.id is null) AND (isnull(d.lugarnac,'')!='' and dd.ID is null)  THEN 'paisNac: '+paisNac+'; LocNac: '+d.LugarNac+'; '  
				WHEN (isnull(paisnac,'')!='' and pa.id is null) AND (isnull(pcianac,'')!='' and p.ID is null)  THEN 'paisNac: '+paisNac+'; LocNac: '+pcianac+'; '  
				WHEN (isnull(pcianac,'')!='' and p.id is null) AND (isnull(d.lugarnac,'')!='' and dd.ID is null)  THEN 'pciaNac: '+pciaNac+'; LocNac: '+d.LugarNac+'; '  
				WHEN (isnull(pcianac,'')!='' and p.id is null) AND (isnull(d.localidad,'')!='' and idLocalidad is null)  THEN 'pciaNac: '+pciaNac+'; Localidad: '+d.localidad+'; '  
				WHEN (isnull(d.localidad,'')!='' and idLocalidad is null) AND (isnull(d.lugarnac,'')!='' and dd.ID is null)  THEN 'lugarNac: '+d.lugarNac+'; Localidad: '+d.localidad+'; '  
				WHEN (isnull(paisnac,'')!='' and pa.id is null) AND (isnull(d.localidad,'')!='' and idLocalidad is null)  THEN 'paisNac: '+paisNac+'; Localidad: '+d.Localidad+'; '  
				WHEN (isnull(pcianac,'')!='' and p.id is null)  THEN 'pciaNac: '+pcianac+'; '  
				WHEN (isnull(paisnac,'')!='' and pa.id is null)  THEN 'paisNac: '+paisNac+'; '  
				WHEN (isnull(d.lugarNac,'')!='' and dd.ID is null)  THEN 'LocNac: '+d.lugarNac+'; '  
				WHEN isnull(d.localidad,'')!='' AND idLocalidad IS NULL THEN 'Localidad: '+d.localidad+'; '
				ELSE '' END AS ObservacionesMigracion
INTO #tempGral
FROM [mpbdsic01].basesic.dbo.[1Tmdelitosic] d
OUTER APPLY (SELECT TOP 1 * FROM Localidad l  WHERE l.Localidad=d.lugarnac COLLATE Latin1_general_CI_AI  
ORDER BY CASE WHEN Provincia=15 THEN 1 
              WHEN Provincia=1 THEN 2 
              ELSE 3 END, Provincia ) dd 
LEFT JOIN Pais AS pa ON d.paisnac=pa.Nacionalidad COLLATE Latin1_general_CI_AI 
LEFT JOIN ClaseEstudiosCursados e ON SUBSTRING(e.Descripcion,1,4)=SUBSTRING(d.estudios,1,4) COLLATE Latin1_general_CI_AI  
LEFT JOIN ClaseEstadoCivil ec ON SUBSTRING(ec.Descripcion,1,3)=SUBSTRING(d.ecivil,1,3) COLLATE Latin1_general_CI_AI 
LEFT JOIN ClaseSexo s ON SUBSTRING(s.Descripcion,1,1)=SUBSTRING(d.sexo,1,1) COLLATE Latin1_general_CI_AI 
LEFT JOIN ClaseTipoDNI doc ON doc.Descripcion=d.tipo COLLATE Latin1_general_CI_AI 
LEFT JOIN Provincia p on d.pcianac=p.Provincia COLLATE Latin1_general_CI_AI  
LEFT JOIN (SELECT d.codbarra, d.localidad, dd.localidad as localidad2, lugarnac, 
      CASE WHEN d.localidad='capital federal' THEN 1665
           WHEN d.localidad='JOSE C. PAZ' THEN 699
           WHEN d.localidad='JOSE C PAZ' THEN 699
           WHEN d.localidad='LANUS ESTE' THEN 840
           WHEN d.localidad='lanus oeste' THEN 841
           WHEN d.localidad='escobar' THEN 500
           WHEN d.localidad='adrogue' THEN 18 
           WHEN d.localidad='LAFERRERE' THEN 620
           WHEN d.localidad='Bernal' THEN 183
           WHEN d.localidad='FCIO VARELA' THEN 535
           WHEN d.localidad='VILLA TESEI' THEN 1338
           WHEN d.localidad='GRAL. RODRIGUEZ' THEN 586
           WHEN d.localidad='VILLA FIORITO' THEN 1474
           WHEN d.localidad='MAQUINISTA SAVIO' THEN 947
           WHEN d.localidad='DON ORIONE' THEN 1613 
           WHEN d.localidad='Villa Celina' THEN 1450 
           WHEN d.localidad='GRAL RODRIGUEZ' THEN 586
           WHEN d.localidad='BILLINGHURST' THEN 186
           WHEN d.localidad='CAÑUELAS' THEN 287
           WHEN d.localidad='SOLANO' THEN 1253
           WHEN d.localidad='VILLA MADERO' THEN 1517
           WHEN d.localidad='ESTEBAN ECHEVERRIA' THEN 512
		   WHEN d.localidad='CAP FED' THEN 1665
           WHEN d.localidad='EZPELETA' THEN 521
           WHEN d.localidad='INGENIERO BUDGE' THEN 667  
           WHEN d.localidad='FCIO. VARELA' THEN 535
           WHEN d.localidad='MTE GRANDE' THEN 1008
           WHEN d.localidad='VILLA DORREGO' THEN 1466
           WHEN d.localidad='BRANDSEN' THEN 348
           WHEN d.localidad='TRANSRADIO' THEN 1572
           WHEN d.localidad='WILLIAM MORRIS' THEN 1593 
           WHEN d.localidad='SPEGAZZINI' THEN 272
           WHEN d.localidad='ALTE BROWN' THEN 37
           WHEN d.localidad='HUDSON' THEN 631
           WHEN d.localidad='G. CATAN' THEN 607
           WHEN d.localidad='CAPILLA DEL SEÑOR' THEN 256
           WHEN d.localidad='CIUDADELA NORTE' THEN 1651
           WHEN d.localidad='HURLINGHAN' THEN 652
           WHEN d.localidad='G CATAN' THEN 607
           WHEN d.localidad='ING BUDGE' THEN 667
           WHEN d.localidad='BUDGE' THEN 667
           WHEN d.localidad='VILLA MAIPU' THEN 1518
           WHEN d.localidad='R. CALZADA' THEN 1177
           WHEN d.localidad='JOSE C.PAZ' THEN 699
           WHEN d.localidad='VILLA DIAMANTE' THEN 1461
           WHEN d.localidad='LAVALLOL' THEN 887
           WHEN d.localidad='LLAVALLOL' THEN 887
           WHEN d.localidad='GONNET' THEN 940
           WHEN d.localidad='AMEGHINO' THEN 48
           WHEN d.localidad='TOLOSA' THEN 1344
           WHEN d.localidad='BARRIO MATERA' THEN 1632
           WHEN d.localidad='G.CATAN' THEN 607
           WHEN d.localidad='VILLA CARAZA' THEN 1448
           WHEN d.localidad='CASANOVA' THEN 683
           WHEN d.localidad='LA FERRERE' THEN 620
           WHEN d.localidad='CABA' THEN 1665
           WHEN d.localidad='GRAL.RODRIGUEZ' THEN 586
           WHEN d.localidad='F. VARELA' THEN 535
           WHEN d.localidad='ADOLFO GONZALEZ CHAVES' THEN 608
           WHEN d.localidad='PQUE. SAN MARTIN' THEN 1077
           WHEN d.localidad='ALTOS DE LAFERRERE' THEN 1612
           WHEN d.localidad='ING. BUDGE' THEN 667
           WHEN d.localidad='PACHECO' THEN 582
           WHEN d.localidad='S.A.DE GILES' THEN 1241
           WHEN d.localidad='VILLA BONICH' THEN 1442
           WHEN d.localidad='R. CASTILLO' THEN 1178
           WHEN d.localidad='I. CASANOVA' THEN 683
           WHEN d.localidad='S.A.DE ARECO' THEN 1243
           WHEN d.localidad='I.CASANOVA' THEN 683
           WHEN d.localidad='CAP. FED.' THEN 1665
           WHEN d.localidad='RINGUELET' THEN 1199
           WHEN d.localidad='SAN A. DE PADUA' THEN 1237
           WHEN d.localidad='G. LAFERRERE' THEN 620
           WHEN d.localidad='C. SPEGAZZINI' THEN 272
           WHEN d.localidad='EST. ECHEVERRIA' THEN 512
           WHEN d.localidad='ALTE. BROWN' THEN 479
           WHEN d.localidad='ING.BUDGE' THEN 667
           WHEN d.localidad='F VARELA' THEN 535
           ELSE dd.ID END AS idLocalidad, 
			dd.provincia 
FROM [mpbdsic01].basesic.dbo.[1Tmdelitosic] d
OUTER APPLY (SELECT TOP 1 * FROM Localidad l  WHERE l.Localidad=d.localidad COLLATE Latin1_general_CI_AI  
ORDER BY CASE WHEN Provincia=15 THEN 1 
              WHEN Provincia=1 THEN 2 
              ELSE 3 END, Provincia ) dd 
)LOC ON loc.codbarra=d.codbarra
JOIN Autores aut ON aut.codbarra=d.codbarra COLLATE DATABASE_DEFAULT
LEFT JOIN  [mpbdsic01].basesic.dbo.[1TFAMILIA] F ON ( d.codbarra=F.codbarra AND (VINCULO LIKE '%ESPOS%' OR VINCULO LIKE '%CONYU%' OR VINCULO LIKE '%MARID%'))


select provincia_id FROM #tempGral


INSERT INTO Persona(conyuge,Apellido,  Direccion, DocumentoNumero, Edad, EstudiosCursados, FechaAlta, FechaCreacion, FechaNacimiento, idEstadoCivil, idLocalidad, idNacionalidad, idProvinciaNac, idSexo, idTipoDNI, LugarNacimiento, Madre, Nombre, Padre, Partido, profesion, Telefono, Codbarra)
SELECT  conyuge,apellido, domicilio, dbo.extraernros(docnro) as docnro, '' as edad, idEstudiosCursados, fecargaop, fecargaop, fenac, idEstadoCivil, idLocalidad, idPaisNac, idProvNac, idSexo, idTipoDNI, idLocNac, madre, nombres, padre, idPartido, profesion,te, CodBarra 
FROM #tempGral
UPDATE aut set aut.idPersona=p.id FROM Persona p JOIN Autores aut ON p.codbarra=aut.codbarra 

GO


--------------------
--DESCRIPCION TEMPORAL
-------------------
IF NOT EXISTS(SELECT * FROM sys.columns 
        WHERE [name] = N'CodBarra' AND [object_id] = OBJECT_ID(N'DescripcionTemporal'))
BEGIN
	ALTER TABLE DescripcionTemporal ADD CodBarra VARCHAR(13)
END
GO

INSERT INTO DescripcionTemporal(codbarra,FechaDesde,FechaHasta)
SELECT codbarra,fecha, fecha FROM #tempGral 
GO

--------------------
--IPP
-------------------


IF NOT EXISTS(SELECT * FROM sys.columns 
        WHERE [name] = N'CodBarra' AND [object_id] = OBJECT_ID(N'IPP'))
BEGIN
	ALTER TABLE IPP ADD CodBarra VARCHAR(13)
END
GO


INSERT IPP(codbarra, numero,caratula,TipoIPP, ufi, TitularUFI, ResponsableUFI, JuzgadoGarantias, FechaCreacion, FechaUltimaModificacion)
select codbarra, ceros+dbo.extraernros(IPP) AS ipp, caratula, 1, ufi, fiscal, fiscal, juzgar,feentlase,getdate() FROM
(select REPLICATE('0',12-LEN(dbo.extraernros(ipp))) AS ceros,* from #tempGral)a




--------------------
--DELITOS
-------------------
IF NOT EXISTS(SELECT * FROM sys.columns 
        WHERE [name] = N'CodBarra' AND [object_id] = OBJECT_ID(N'Delitos'))
BEGIN
	ALTER TABLE Delitos ADD CodBarra VARCHAR(13)
END
GO

INSERT INTO Delitos(ComisariaMigracion,codbarra, FechaUltimaModificacion, FechaAlta, idDescripcionTemporal,idIPP)
SELECT dependencia, t.codbarra, GETDATE(), feentlase, dt.id, i.id  
FROM #tempGral t 
JOIN IPP i ON t.codbarra=i.codbarra COLLATE Latin1_general_CI_AI  
JOIN DescripcionTemporal dt ON t.codbarra=dt.codbarra COLLATE Latin1_general_CI_AI  

UPDATE aut SET aut.idDelito=d.id FROM Delitos d JOIN Autores aut ON d.codbarra=aut.codbarra 


----------------
--ARCHIVOS
----------------
select id,nombre, '~/Areas/Otip/Content/uploads/'+dir1+'/'+dir2+'/'+nombre AS Url, codbarra, tipo, descripcion, idParteCuerpo, 
    CASE WHEN descripcion LIKE '%CIC%' THEN 1
         WHEN descripcion LIKE '%luna%' OR descripcion LIKE '%verr%' THEN 2
         --WHEN descripcion LIKE '%TAT%' THEN 1
         ELSE 0 END AS idSeniaPart
into #tmpArchivos
from 
(
SELECT I.id, NOMBRE, SUBSTRING(NOMBRE,1,4) AS dir1,REPLICATE('0',2-LEN( CAST(SUBSTRING(Nombre,8,5)AS INT)/1000))+CAST(CAST(SUBSTRING(Nombre,8,5)AS INT)/1000 AS VARCHAR(50))AS dir2, substring(Nombre,1,13) AS codbarra, Tipo ,'ROSTRO' AS descripcion, 2 AS idParteCuerpo
  FROM [mpbdsic01].BaseSIC.dbo.RelCBarraFotosRostros r
  JOIN #tempGral AS tmp ON substring(r.Nombre,1,13)=tmp.codbarra 
  JOIN Imputados i ON tmp.codbarra=i.codigodebarras COLLATE Latin1_general_CI_AI  
  UNION
  SELECT I.id,  nombre, 
        SUBSTRING(NOMBRE,1,4) AS dir1,REPLICATE('0',2-LEN( CAST(SUBSTRING(Nombre,8,5)AS INT)/1000))+CAST(CAST(SUBSTRING(Nombre,8,5)AS INT)/1000 AS VARCHAR(50))AS dir2, substring(Nombre,1,13) AS codbarra, 
        --2 AS Tipo,
         CASE WHEN S.descripcion LIKE '%TATUAJE%' THEN 3 
         ELSE 2 END AS tipo,
      s.descripcion,
      CASE WHEN p.id IS NULL THEN CASE WHEN s.descripcion LIKE '%cabeza%'  THEN 1
                                       WHEN s.descripcion LIKE '%cara%' OR RTRIM(LTRIM(s.descripcion)) like '%ROSTRO%' OR s.descripcion LIKE '%MEJILLA%' THEN 2
                                       WHEN s.descripcion LIKE '%nuca%' THEN 3
                                       WHEN s.descripcion LIKE '%cuello%' THEN 4
                                       WHEN s.descripcion LIKE '%hombro iz%' THEN 5
                                       WHEN s.descripcion LIKE '%hombro de%' THEN 6
                                       WHEN s.descripcion LIKE '%espalda%' OR s.descripcion LIKE '%omoplato%' THEN 7
                                       WHEN s.descripcion LIKE '%pecho%' OR s.descripcion LIKE '%torax%' THEN 8
                                       WHEN s.descripcion LIKE '%vientre%' OR s.descripcion LIKE '%abdomen%' OR s.descripcion LIKE '%cintura%' OR s.descripcion LIKE '%ZONA MEDIA%' OR s.descripcion LIKE '%ESTOMAGO%' THEN 9
                                       WHEN s.descripcion LIKE '%brazo iz%' OR s.descripcion like '%bra%' and s.descripcion like '%izq%' and s.descripcion not like '%ebra%' THEN 10
                                       WHEN s.descripcion LIKE '%brazo de%' OR s.descripcion like '%bra%' and s.descripcion like '%der%' and s.descripcion not like '%ebra%' THEN 11
                                       WHEN s.descripcion LIKE '%mano iz%' THEN 12
                                       WHEN s.descripcion LIKE '%mano de%' THEN 13
                                       WHEN s.descripcion LIKE '%antebrazo iz%' OR s.descripcion LIKE '%ant iz%' OR (s.descripcion like '%anteb%' and s.descripcion like '%der%') THEN 14
                                       WHEN s.descripcion LIKE '%antebrazo de%' OR s.descripcion LIKE '%ant de%' OR (s.descripcion like '%anteb%' and s.descripcion like '%izq%') THEN 15
                                       WHEN s.descripcion LIKE '%pelvis%' THEN 16
                                       WHEN s.descripcion LIKE '%pierna iz%' THEN 17
                                       WHEN s.descripcion LIKE '%pierna de%' THEN 18
                                       WHEN s.descripcion LIKE '%cuerpo entero%' OR RTRIM(LTRIM(s.descripcion))='CUERPO' THEN 19
                                       WHEN s.descripcion LIKE '%axila iz%' THEN 20
                                       WHEN s.descripcion LIKE '%axila de%' THEN 21
                                       WHEN s.descripcion LIKE '%perfil de%' THEN 22
                                       WHEN s.descripcion LIKE '%perfil iz%' THEN 23
                                       WHEN s.descripcion LIKE '%codo iz%' THEN 24
                                       WHEN s.descripcion LIKE '%codo de%' THEN 25
                                       WHEN s.descripcion LIKE '%pantorrilla de%' OR s.descripcion LIKE '%ANTEP DE%' THEN 26
                                       WHEN s.descripcion LIKE '%pantorrilla iz%' OR s.descripcion LIKE '%ANTEP IZ%' THEN 27
                                       WHEN s.descripcion LIKE '%muslo de%' THEN 28
                                       WHEN s.descripcion LIKE '%muslo iz%' THEN 29
                                       WHEN s.descripcion LIKE '%rodilla de%' THEN 30
                                       WHEN s.descripcion LIKE '%rodilla iz%' THEN 31
                                       WHEN s.descripcion LIKE '%dent%' OR s.descripcion LIKE '%BOCA%' THEN 32
                                       WHEN s.descripcion LIKE '%tobillo de%' THEN 33
                                       WHEN s.descripcion LIKE '%tobillo iz%' THEN 34
                                       ELSE CASE WHEN RTRIM(LTRIM(s.Descripcion))='' OR LEN(s.Descripcion)<4 THEN 0 ELSE 38 END
                                       END
      ELSE p.id END AS idParteCuerpo
  FROM [mpbdsic01].basesic.dbo.[relcbarrafotosseñas] s
  JOIN #tempGral AS tmp ON substring(s.Nombre,1,13)=tmp.codbarra 
  LEFT JOIN [mpbdsic01].BASESIC.DBO.partesCuerpo p ON s.Descripcion=p.Descripcion
  JOIN Imputados i ON tmp.codbarra=i.codigodebarras COLLATE Latin1_general_CI_AI  
)ta


INSERT INTO Archivo(nombre,url,idTipoArchivo, FechaUpload, Imputado_Id, descripcion )
SELECT nombre, url,tipo, getdate(), id, descripcion
FROM #tmpArchivos 

----------------
--SeniasParticulares
----------------
INSERT INTO SeniasParticulares(descripcion, idSeniaParticular, idUbicacionSeniaParticular)
SELECT descripcion,idSeniaPart  ,idParteCuerpo  FROM #tmpArchivos

---------------------------
--MODIFICO PARA VER EN OTIP
---------------------------
update top(10) imputados set idestado=9 
---------------------------------------



ALTER TABLE Autores DROP COLUMN CodBarra
ALTER TABLE AutoresAlias DROP COLUMN CodBarra
ALTER TABLE Persona DROP COLUMN CodBarra
ALTER TABLE Delitos DROP COLUMN CodBarra
ALTER TABLE IPP DROP COLUMN CodBarra
DROP FUNCTION dbo.extraerNros
DROP TABLE #tempGral
DROP TABLE #tmpArchivos

 GO


------------------------------------------------------------
---------------FIN-------------------------------
---------------------------------------------------


--select * from ipp
--select * from imputados
--select * from #tempGral
--select * from Archivo
--select * from persona
--select * from ClaseUbicacionSeniaPart
--select * from #tmpArchivos
--select * from claseseniaparticular
--select * from seniasparticulares

