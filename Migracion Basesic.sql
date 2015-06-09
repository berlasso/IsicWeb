

--EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"
DELETE Archivo
DELETE BioDactilar
DELETE Imputados
DELETE SicEstadoTramite
DELETE Autores
DELETE Delitos
DELETE Comisaria
DELETE AutoresAlias
DELETE Persona
DELETE Domicilios
DELETE localidad
DELETE Partido
DELETE Provincia
DELETE IPP
DELETE DescripcionTemporal
DELETE Delitos

IF EXISTS (
    SELECT * FROM sysobjects WHERE id = object_id(N'dbo.extraernros') 
    AND xtype IN (N'FN', N'IF', N'TF')
)
	DROP FUNCTION dbo.extraernros
	GO


------------------
--SICESTADOTRAMITE
------------------
insert into SICEstadoTramite(id, Descripcion) VALUES(1,'100')
insert into SICEstadoTramite(id, Descripcion) VALUES(2,'200')
insert into SICEstadoTramite(id, Descripcion) VALUES(3,'300')
insert into SICEstadoTramite(id, Descripcion) VALUES(4,'400')
insert into SICEstadoTramite(id, Descripcion) VALUES(5,'500')
insert into SICEstadoTramite(id, Descripcion) VALUES(6,'600')
insert into SICEstadoTramite(id, Descripcion) VALUES(7,'700')
-----------------
--ROBUSTEZ
------------------
DELETE SICClaseRobustez
 
INSERT INTO SICClaseRobustez(ID,descripcion,letra) 
SELECT id,descripcion, letra FROM [german-pc\germansql].isic.dbo.somatrobustez
 
-----------------
--CEJAS DIMENSION
------------------
DELETE SICClaseCejasDimension
 
INSERT INTO SICClaseCejasDimension(ID,descripcion,letra) 
SELECT id,descripcion, letra FROM [german-pc\germansql].isic.dbo.somatcejasdimension
 
-----------------
--Cejas Tipo
------------------
DELETE SICClaseCejasTipo
 
INSERT INTO SICClaseCejasTipo(ID,descripcion,letra) 
SELECT id,descripcion, letra FROM [german-pc\germansql].isic.dbo.somatcejastipo
 
 
-----------------
--Clase Estatura
------------------
DELETE SICClaseEstatura
 
INSERT INTO SICClaseEstatura(ID,descripcion,letra) 
SELECT id,descripcion, letra FROM [german-pc\germansql].isic.dbo.somatestatura
 

-----------------
--color cabello
------------------
DELETE SICClaseColorCabello
 
INSERT INTO SICClaseColorCabello(ID,descripcion,letra) 
SELECT id,descripcion, letra FROM [german-pc\germansql].isic.dbo.somatcolorcabello
 
-----------------
--color ojos
------------------
DELETE SICClaseColorOjos
 
INSERT INTO SICClaseColorOjos(ID,descripcion,letra) 
SELECT id,descripcion, letra FROM [german-pc\germansql].isic.dbo.somatcolorojos
 
-----------------
--color piel
------------------
DELETE SICClaseColorPiel
 
INSERT INTO SICClaseColorPiel(ID,descripcion,letra) 
SELECT id,descripcion, letra FROM [german-pc\germansql].isic.dbo.somatcolorpiel
 
-----------------
--forma boca
------------------
DELETE SICClaseFormaBoca
 
INSERT INTO SICClaseFormaBoca(ID,descripcion,letra) 
SELECT id,descripcion, letra FROM [german-pc\germansql].isic.dbo.somatformaboca
 
-----------------
--forma cara
------------------
DELETE SICClaseFormaCara
 
INSERT INTO SICClaseFormaCara(ID,descripcion,letra) 
SELECT id,descripcion, letra FROM [german-pc\germansql].isic.dbo.somatformacara
 
-----------------
--forma labio inferior
------------------
DELETE SICClaseFormaLabioInferior
 
INSERT INTO SICClaseFormaLabioInferior(ID,descripcion,letra) 
SELECT id,descripcion, letra FROM [german-pc\germansql].isic.dbo.somatformalabioinf
 
-----------------
--forma labio superior
------------------
DELETE SICClaseFormaLabioSuperior
 
INSERT INTO SICClaseFormaLabioSuperior(ID,descripcion,letra) 
SELECT id,descripcion, letra FROM [german-pc\germansql].isic.dbo.somatformalabiosup
 
-----------------
--forma menton
------------------
DELETE SICClaseFormaMenton
 
INSERT INTO SICClaseFormaMenton(ID,descripcion,letra) 
SELECT id,descripcion, letra FROM [german-pc\germansql].isic.dbo.somatformamenton
 
-----------------
--forma nariz
------------------
DELETE SICClaseFormaNariz
 
INSERT INTO SICClaseFormaNariz(ID,descripcion,letra) 
SELECT id,descripcion, letra FROM [german-pc\germansql].isic.dbo.somatformanariz
 
-----------------
--forma oreja
------------------
DELETE SICClaseFormaOreja
 
INSERT INTO SICClaseFormaOreja(ID,descripcion,letra) 
SELECT id,descripcion, letra FROM [german-pc\germansql].isic.dbo.somatformaoreja
 
-----------------
--tipo cabello
------------------
DELETE SICClaseTipoCabello
 
INSERT INTO SICClaseTipoCabello(ID,descripcion,letra) 
SELECT id,descripcion, letra FROM [german-pc\germansql].isic.dbo.somattipocabello
 
-----------------
--tipo calvicie
------------------
DELETE SICClaseTipoCalvicie
 
INSERT INTO SICClaseTipoCalvicie(ID,descripcion,letra) 
SELECT id,descripcion, letra FROM [german-pc\germansql].isic.dbo.somattipocalvicie
 


-----------------
--provincias
------------------
DELETE provincia
INSERT INTO provincia(Id,Provincia)
SELECT ROW_NUMBER() OVER(ORDER BY provincia) as id,provincia FROM [german-pc\germansql].isic.dbo.tbl_provincias


-----------------
--partidos
------------------
INSERT INTO Partido(Id,partido,Provincia_Id,idProvincia)
SELECT idpartido,partido, pr.id, pr.id FROM [german-pc\germansql].isic.dbo.tbl_partidos pa 
JOIN [german-pc\germansql].isic.dbo.tbl_provincias p  ON p.codprovincia=pa.codprovincia
JOIN Provincia pr ON p.provincia=pr.provincia COLLATE Latin1_general_CI_AI
ORDER BY partido

-----------------
--localidades
------------------
INSERT INTO Localidad(ID, Localidad, Partido_Id, CodigoPostal,Provincia_Id)
SELECT ROW_NUMBER() OVER(ORDER BY l.localidad) AS idlocalidad, l.localidad, l.idpartido, '' AS codigopostal, p.id AS idprovincia 
FROM [german-pc\germansql].isic.dbo.tbl_localidades l 
JOIN [german-pc\germansql].isic.dbo.tbl_provincias pr ON l.codProvincia=pr.codprovincia 
JOIN [german-pc\germansql].isic.dbo.tbl_partidos pa ON l.idpartido=pa.idpartido
JOIN Provincia p ON p.Provincia=pr.provincia COLLATE Latin1_general_CI_AI
ORDER BY  idlocalidad


-----------------
--paises
------------------
DELETE Pais
INSERT INTO Pais(Id,Descripcion, Nacionalidad)
SELECT id-1, nombre,nombre FROM [german-pc\germansql].isic.dbo.paises
WHERE nombre !='Desconocido'

-----------------
--tipo doc
------------------
DELETE ClaseTipoDNI
INSERT INTO ClaseTipoDNI(Id,Descripcion)
SELECT id, descripcion FROM [german-pc\germansql].isic.dbo.tipodoc

-----------------
--tipo archivo
------------------
DELETE ClaseTipoArchivo
INSERT INTO ClaseTipoArchivo(Id,Descripcion)
SELECT id, descripcion FROM [german-pc\germansql].isic.dbo.tipoarchivo

-----------------
--sexo
------------------
DELETE ClaseNombre
DELETE ClaseSexo
INSERT INTO ClaseSexo(Id,Descripcion)
SELECT id, descripcion FROM [german-pc\germansql].isic.dbo.sexo

-----------------
--claseseniaparticular
------------------
SET IDENTITY_INSERT ClaseSeniaParticular ON

DELETE ClaseSeniaParticular
INSERT INTO ClaseSeniaParticular(Id,Descripcion)
SELECT id, descripcionsena FROM [german-pc\germansql].basesic.dbo.SenasParticulares
SET IDENTITY_INSERT ClaseSeniaParticular OFF

-----------------
--claseubicacionseniapart
------------------
SET IDENTITY_INSERT ClaseSeniaParticular ON

DELETE ClaseUbicacionSeniaPart
INSERT INTO ClaseUbicacionSeniaPart(Id,Descripcion)
SELECT id, descripcion FROM [german-pc\germansql].basesic.dbo.partesCuerpo
SET IDENTITY_INSERT ClaseSeniaParticular OFF

-----------------
--profesiones
------------------
DELETE ClaseProfesion
INSERT INTO ClaseProfesion(Id,Descripcion)
SELECT id, descripcion FROM [german-pc\germansql].isic.dbo.profesiones


-----------------
--ClaseTipoArchivo
------------------
DELETE ClaseTipoArchivo
INSERT INTO ClaseTipoArchivo(Id,Descripcion)
SELECT id, descripcion FROM [german-pc\germansql].isic.dbo.tipoArchivo
--RECORDAR: AGREGAR TATUAJE Y PONER NO TATUAJE A SENAS


-----------------
--ClaseNombre
------------------
INSERT INTO ClaseNombre(Descripcion, sexo_Id)
SELECT nombre, CASE WHEN sexo='M' THEN 1 ELSE 2 END AS sexoid FROM  [german-pc\germansql].isic.dbo.nombres


-----------------
--ClaseEstudiosCursados
------------------
DELETE ClaseEstudiosCursados
INSERT INTO ClaseEstudiosCursados(id,Descripcion)
SELECT id,descripcion FROM  [german-pc\germansql].isic.dbo.estudios


-----------------
--ClaseEstadoCivil
------------------
DELETE ClaseEstadoCivil
INSERT INTO ClaseEstadoCivil(id,Descripcion)
SELECT id,descripcion FROM  [german-pc\germansql].isic.dbo.estcivil



-----------------
--ClaseDepartamentoJudicial
------------------
DELETE ClaseDepartamentoJudicial
INSERT INTO ClaseDepartamentoJudicial(id,sigDto,descripcion,idSIMP)
SELECT id,sigDto,descripcion,idSimp FROM  [german-pc\germansql].isic.dbo.deptojud


----------------
--VARIOS
----------------

INSERT LOCALIDAD(Id, Localidad, Partido_Id, Provincia_Id)
SELECT max(Id)+1,'Adrogue', 955, 15 FROM Localidad
INSERT LOCALIDAD(Id, Localidad, Partido_Id, Provincia_Id)
SELECT max(Id)+1,'Don Orione', 955, 15 FROM Localidad
 INSERT LOCALIDAD(Id, Localidad, Partido_Id, Provincia_Id)
SELECT max(Id)+1,'Villa Celina', 933, 15 FROM Localidad
INSERT partido(Id, partido,provincia_id, idprovincia)
SELECT max(id)+1,'Cañuelas', 15, 15 FROM partido
INSERT LOCALIDAD(Id, Localidad, Partido_Id, Provincia_Id)
SELECT max(id)+1,'Cañuelas', 956, 15 FROM Localidad
INSERT LOCALIDAD(Id, Localidad, Partido_Id, Provincia_Id)
SELECT max(id)+1,'Ingeniero Budge', 927, 15 FROM Localidad
INSERT LOCALIDAD(Id, Localidad, Partido_Id, Provincia_Id)
SELECT max(id)+1,'Billinghurst', 947, 15 FROM Localidad
INSERT LOCALIDAD(Id, Localidad, Partido_Id, Provincia_Id)
SELECT max(id)+1,'William Morris', 923, 15 FROM Localidad
INSERT LOCALIDAD(Id, Localidad, Partido_Id, Provincia_Id)
SELECT max(id)+1,'Capilla del Señor', 108, 15 FROM Localidad
update Localidad set localidad='Lavallol' where id=12837
update Provincia set Provincia='Buenos Aires' where id=15
insert into localidad(id, Localidad, Partido_Id, Provincia_Id)
select max(id)+1,'Presidencia Roque Saenz Peña', 693, 3 from localidad
insert into localidad(id, Localidad, Partido_Id, Provincia_Id)
select max(id)+1,'Las Breñas', 686, 3 from localidad



-----------------
--AUTORES / IMPUTADOS
------------------

IF object_id('tempdb..#tempTable') IS NOT NULL
	DROP table #tempTable 
GO


IF NOT EXISTS(SELECT * FROM sys.columns 
        WHERE [name] = N'CodBarra' AND [object_id] = OBJECT_ID(N'Autores'))
BEGIN
	ALTER TABLE Autores ADD CodBarra VARCHAR(13)
END
GO

INSERT INTO Autores(CodBarra, FechaUltimaModificacion, OtrosNombres, Estatura, idClaseDimensionCeja, idClaseTipoCeja, idClaseColorCabello, idClaseColorOjos, idClaseColorPiel, idClaseFormaBoca, idClaseFormaCara, idClaseFormaLabioInferior, idClaseFormaLabioSuperior, idClaseFormaMenton, idClaseFormaNariz, idClaseRobustez, idClaseTipoCabello, idClaseCalvicie, idClaseEstatura)
SELECT DISTINCT TOP 50  d.CodBarra, GETDATE()AS FechaUltimaModificacion, otrosnombres, estatura ,cd.id cd, ct.id ct, cc.id cc, co.id co, cp.id cp, fb.id fb, fc.id fc, fli.id fli, fls.id fls, fm.id fm, fn.id fn, r.id r, tcab.id tcab, tcalv.id tcalv, e.id e
FROM  [german-pc\germansql].basesic.dbo.[1TMDELITOSIC] d 
LEFT JOIN  [german-pc\germansql].basesic.dbo.[1TOtrosNombresSic] o ON d.codbarra=o.codbarra 
LEFT JOIN  [german-pc\germansql].basesic.dbo.[1TAliaSic] a ON d.codbarra=a.codbarra 
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
--WHERE DATI_SOMATICI IS NOT  NULL 
--and d.codbarra in(select top 100000 codbarra from  [german-pc\germansql].basesic.dbo.[1TAliaSic])
 ORDER BY d.codbarra

INSERT INTO Imputados(id,ProntuarioSIC, idEstado, idNroCarpeta, CodigoDeBarras, CodigoDeBarrasOriginal,FechaCreacionI, ManoDerecha, ManoIzquierda)
SELECT a.id, d.prontuariosic, st.id, nroCarpeta, d.codbarra, d.codbarra, ISNULL(feentlase,''),0,0
FROM autores a 
JOIN  [german-pc\germansql].basesic.dbo.[1TMDELItosic] d ON d.codbarra=a.codbarra COLLATE DATABASE_DEFAULT
LEFT JOIN SicEstadoTramite st ON d.codestado=st.Descripcion COLLATE DATABASE_DEFAULT
----ALIAS
IF NOT EXISTS(SELECT * FROM sys.columns 
        WHERE [name] = N'CodBarra' AND [object_id] = OBJECT_ID(N'AutoresAlias'))
BEGIN
	ALTER TABLE AutoresAlias ADD CodBarra VARCHAR(13)
END
GO

INSERT INTO AutoresAlias(Alias, CodBarra)
SELECT DISTINCT   al.alias, a.codbarra FROM  [german-pc\germansql].basesic.dbo.[1TAliaSic] al JOIN Autores a on al.codbarra=a.codbarra COLLATE DATABASE_DEFAULT 
WHERE NOT EXISTS(SELECT codbarra from AutoresAlias where autoresalias.codbarra=al.codbarra COLLATE DATABASE_DEFAULT)
UPDATE aut SET aut.idAlias=aa.id FROM AutoresAlias aa JOIN Autores aut ON aa.codbarra=aut.codbarra 

-----PERSONAS
IF NOT EXISTS(SELECT * FROM sys.columns 
        WHERE [name] = N'CodBarra' AND [object_id] = OBJECT_ID(N'Persona'))
BEGIN
	ALTER TABLE Persona ADD CodBarra VARCHAR(13)
END
GO

SELECT top 50 d.dependencia, d.ipp,d.fiscal, d.fecha, d.juzgar, d.codbarra, d.caratula,d.feentlase, apellido, d.ufi, ISNULL(s.Id,0) as idSexo, domicilio, docnro, idLocalidad, dd.localidad as localidad2, FecargaOP, FecargaOP as fecargaop2, feNac, d.lugarNac, madre, Nombres, padre, profesion, te, dd.provincia_id, dd.partido_id as idPartido,
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
			CASE WHEN d.pcianac like 'bs%' then 15 
				WHEN d.pcianac like '%chile%' then 0
				 WHEN d.pcianac like '%negro%' then 16
				WHEN d.pcianac like '%entre%' then 7
				WHEN d.pcianac like '%pampa%' then 10
				WHEN d.pcianac like '%juan%' then 18
				when d.pcianac like 'sgo%' then 22
				when d.pcianac like '%ctes%' then 6
				when d.pcianac like '%sta%' then 21
				when d.pcianac like '%rios%' then 7
				when d.pcianac like '%bue%' then 15
				when d.pcianac like '%luis%' then 19
				when d.pcianac like '%fe%' then 21
				when d.pcianac like '%estero%' then 22
				when d.pcianac like '%doba%' then 5
				when d.pcianac like '%air%' then 15
				when d.pcianac like '%cruz%' then 20
				when d.pcianac like '%tucu%' then 24
				when d.pcianac like '%tierra%' then 23
				when d.pcianac like '%chac%' then 3
				when d.pcianac like '%rioja%' then 22
				when d.pcianac like '%corr%' then 6
				when d.pcianac like '%cap%' then 1
				when d.pcianac like '%caba%' then 1
				when d.pcianac like '%tandil%' then 15
				when d.pcianac like '%mza%' then 12
				when d.pcianac like '%santi%' then 22
				when d.pcianac like '%neuq%' then 14
				when d.pcianac like '%mis%' then 13
				when d.pcianac like '%cba%' then 1
				else p.id END AS idProvNac,
	      CASE WHEN d.lugarnac='capital federal' THEN 3427
				WHEN d.lugarnac like '%federal%' THEN 3427
			   WHEN d.lugarnac='JOSE C. PAZ' THEN 9199
				WHEN d.lugarnac='JOSE C PAZ' THEN 9199
				WHEN d.lugarnac='LANUS ESTE' THEN 11956
				WHEN d.lugarnac='lanus oeste' THEN 9199
				WHEN d.lugarnac='escobar' THEN 1636
				WHEN d.lugarnac='adrogue' THEN 21681 ---------REVISAR
				WHEN d.lugarnac='LAFERRERE' THEN 8516
				WHEN d.lugarnac='Bernal' THEN 1715
		       WHEN d.lugarnac='FCIO VARELA' THEN 8119
				WHEN d.lugarnac='VILLA TESEI' THEN 21322
				WHEN d.lugarnac='GRAL. RODRIGUEZ' THEN 8380
				WHEN d.lugarnac='VILLA FIORITO' THEN 3821
				WHEN d.lugarnac='MAQUINISTA SAVIO' THEN 14124
				WHEN d.lugarnac='DON ORIONE' THEN 21682 ---------REVISAR
				WHEN d.lugarnac='Villa Celina' THEN 21683  ---------REVISAR
				WHEN d.lugarnac='GRAL RODRIGUEZ' THEN 8380
				WHEN d.lugarnac='BILLINGHURST' THEN 21686-----------revisar
				WHEN d.lugarnac='CAÑUELAS' THEN 21684 -------REVISAR
				WHEN d.lugarnac='SOLANO' THEN 16384
				WHEN d.lugarnac='VILLA MADERO' THEN 933
				WHEN d.lugarnac='ESTEBAN ECHEVERRIA' THEN 14670
				WHEN d.lugarnac='CAP FED' THEN 3427
				WHEN d.lugarnac='EZPELETA' THEN 7981
				WHEN d.lugarnac='INGENIERO BUDGE' THEN 21685  ----------REVISAR
				WHEN d.lugarnac='FCIO. VARELA' THEN 8119
				WHEN d.lugarnac='MTE GRANDE' THEN 14670
				WHEN d.lugarnac='VILLA DORREGO' THEN 4568
				WHEN d.lugarnac='BRANDSEN' THEN 4562
				WHEN d.lugarnac='TRANSRADIO' THEN 11298
				WHEN d.lugarnac='WILLIAM MORRIS' THEN 21687 -------revisar
				WHEN d.lugarnac='SPEGAZZINI' THEN 2571
				WHEN d.lugarnac='ALTE BROWN' THEN 479
				WHEN d.lugarnac='HUDSON' THEN 8620
				WHEN d.lugarnac='G. CATAN' THEN 8472
				WHEN d.lugarnac='CAPILLA DEL SEÑOR' THEN 21688 -------revisar
				WHEN d.lugarnac='CIUDADELA NORTE' THEN 3434
				WHEN d.lugarnac='HURLINGHAN' THEN 8853
				WHEN d.lugarnac='G CATAN' THEN 8472
				WHEN d.lugarnac='ING BUDGE' THEN 21685
				WHEN d.lugarnac='BUDGE' THEN 21685
				WHEN d.lugarnac='VILLA MAIPU' THEN 13986
				WHEN d.lugarnac='R. CALZADA' THEN 17321
				WHEN d.lugarnac='JOSE C.PAZ' THEN 9199
				WHEN d.lugarnac='VILLA DIAMANTE' THEN 11956
				WHEN d.lugarnac='LAVALLOL' THEN 12837
			    WHEN d.lugarnac='LLAVALLOL' THEN 12837
			   WHEN d.lugarnac='GONNET' THEN 14107
		       WHEN d.lugarnac='AMEGHINO' THEN 8122
				WHEN d.lugarnac='TOLOSA' THEN 11298
				WHEN d.lugarnac='BARRIO MATERA' THEN 15540
				WHEN d.lugarnac='G.CATAN' THEN 8472
				WHEN d.lugarnac='VILLA CARAZA' THEN 11956
				WHEN d.lugarnac='CASANOVA' THEN 9019
				WHEN d.lugarnac like '%avell%' THEN 1143
				WHEN d.lugarnac='lanus' THEN 9199
				WHEN d.lugarnac='pergamino' THEN 15795
				WHEN d.lugarnac='lomas de zamora' THEN 12952
				WHEN d.lugarnac='quilmes' THEN 17266
				WHEN d.lugarnac='colon' THEN 3521
				WHEN d.lugarnac='ezeiza' THEN 7980
				WHEN d.lugarnac='LA FERRERE' THEN 8516
				WHEN d.lugarnac='CABA' THEN 3427
				WHEN d.lugarnac='autonoma' THEN 3427
				WHEN d.lugarnac='GRAL.RODRIGUEZ' THEN 8380
				WHEN d.lugarnac='F. VARELA' THEN 8119
				WHEN d.lugarnac='ADOLFO GONZALEZ CHAVES' THEN 139
				WHEN d.lugarnac='PQUE. SAN MARTIN' THEN 15540
				WHEN d.lugarnac='ALTOS DE LAFERRERE' THEN 8516
				WHEN d.lugarnac='ING. BUDGE' THEN 21685
				WHEN d.lugarnac='PACHECO' THEN 8366
				WHEN d.lugarnac='S.A.DE GILES' THEN 18119
				WHEN d.lugarnac='VILLA BONICH' THEN 20893
				WHEN d.lugarnac='R. CASTILLO' THEN 17322
				WHEN d.lugarnac='I. CASANOVA' THEN 9019
				WHEN d.lugarnac='S.A.DE ARECO' THEN 18178
				WHEN d.lugarnac='I.CASANOVA' THEN 9019
				WHEN d.lugarnac='CAP. FED.' THEN 3427
				WHEN d.lugarnac='CAPITAL FEDERAL' THEN 3427
				WHEN d.lugarnac='RINGUELET' THEN 11298
				WHEN d.lugarnac='SAN A. DE PADUA' THEN 18192
				WHEN d.lugarnac='G. LAFERRERE' THEN 8516
				WHEN d.lugarnac='C. SPEGAZZINI' THEN 2571
				WHEN d.lugarnac='EST. ECHEVERRIA' THEN 14670
				WHEN d.lugarnac='ALTE. BROWN' THEN 479
				WHEN d.lugarnac='ING.BUDGE' THEN 21685
				WHEN d.lugarnac='F VARELA' THEN 8119
		       WHEN d.lugarnac= 'TUCUMAN' THEN 18832
		       WHEN d.lugarnac='chaco' THEN 17493
		       WHEN d.lugarnac='ROQUE SAENZ PEÑA' THEN 21689
			   WHEN d.lugarnac='SAENZ PEÑA' THEN 21689
		       WHEN d.lugarnac='CORDOBA' THEN 4539
			   WHEN d.lugarnac='CORDOBA CAPITAL' THEN 4539
			   WHEN d.lugarnac='santa fe capital' THEN 19228
			   WHEN d.lugarnac='GRAL. MADARIAGA' THEN 8356
		       WHEN d.lugarnac='CAPITAL' THEN 3427
		       WHEN d.lugarnac='JUJUY' THEN 19033
		       WHEN d.lugarnac='LAS BREÑAS' THEN 21690
		       WHEN d.lugarnac='CATAMARCA' THEN 18322
		       WHEN d.lugarnac='RAMOS MEJIAS' THEN 17378
		       WHEN d.lugarnac='VTE LOPEZ' THEN 20805
		       WHEN d.lugarnac='MONTERO' THEN 14719
		       WHEN d.lugarnac='GONZALEZ CHAVEZ' THEN 139
			   WHEN d.lugarnac='POLVORINES' THEN 13547
			   WHEN d.lugarnac='CIUDAD AUTONOMA DE BUENOS AIRES' THEN 3427
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
INTO #tempTable
FROM [german-pc\germansql].basesic.dbo.[1Tmdelitosic] d
OUTER APPLY (SELECT TOP 1 * FROM Localidad l  WHERE l.Localidad=d.lugarnac COLLATE Latin1_general_CI_AI  
ORDER BY CASE WHEN Provincia_Id=15 THEN 1 
              WHEN Provincia_id=1 THEN 2 
              ELSE 3 END, Provincia_Id ) dd 
LEFT JOIN Pais AS pa ON d.paisnac=pa.Nacionalidad COLLATE Latin1_general_CI_AI 
LEFT JOIN ClaseEstudiosCursados e ON SUBSTRING(e.Descripcion,1,4)=SUBSTRING(d.estudios,1,4) COLLATE Latin1_general_CI_AI  
LEFT JOIN ClaseEstadoCivil ec ON SUBSTRING(ec.Descripcion,1,3)=SUBSTRING(d.ecivil,1,3) COLLATE Latin1_general_CI_AI 
LEFT JOIN ClaseSexo s ON SUBSTRING(s.Descripcion,1,1)=SUBSTRING(d.sexo,1,1) COLLATE Latin1_general_CI_AI 
LEFT JOIN ClaseTipoDNI doc ON doc.Descripcion=d.tipo COLLATE Latin1_general_CI_AI 
LEFT JOIN Provincia p on d.pcianac=p.Provincia COLLATE Latin1_general_CI_AI  
LEFT JOIN (SELECT d.codbarra, d.localidad, dd.localidad as localidad2, lugarnac, 
      CASE WHEN d.localidad='capital federal' THEN 3427
           WHEN d.localidad='JOSE C. PAZ' THEN 9199
           WHEN d.localidad='JOSE C PAZ' THEN 9199
           WHEN d.localidad='LANUS ESTE' THEN 11956
           WHEN d.localidad='lanus oeste' THEN 9199
           WHEN d.localidad='escobar' THEN 1636
           WHEN d.localidad='adrogue' THEN 21681 ---------REVISAR
           WHEN d.localidad='LAFERRERE' THEN 8516
           WHEN d.localidad='Bernal' THEN 1715
           WHEN d.localidad='FCIO VARELA' THEN 8119
           WHEN d.localidad='VILLA TESEI' THEN 21322
           WHEN d.localidad='GRAL. RODRIGUEZ' THEN 8380
           WHEN d.localidad='VILLA FIORITO' THEN 3821
           WHEN d.localidad='MAQUINISTA SAVIO' THEN 14124
           WHEN d.localidad='DON ORIONE' THEN 21682 ---------REVISAR
           WHEN d.localidad='Villa Celina' THEN 21683  ---------REVISAR
           WHEN d.localidad='GRAL RODRIGUEZ' THEN 8380
           WHEN d.localidad='BILLINGHURST' THEN 21686-----------revisar
           WHEN d.localidad='CAÑUELAS' THEN 21684 -------REVISAR
           WHEN d.localidad='SOLANO' THEN 16384
           WHEN d.localidad='VILLA MADERO' THEN 933
           WHEN d.localidad='ESTEBAN ECHEVERRIA' THEN 14670
           WHEN d.localidad='CAP FED' THEN 3427
           WHEN d.localidad='EZPELETA' THEN 7981
           WHEN d.localidad='INGENIERO BUDGE' THEN 21685  ----------REVISAR
           WHEN d.localidad='FCIO. VARELA' THEN 8119
           WHEN d.localidad='MTE GRANDE' THEN 14670
           WHEN d.localidad='VILLA DORREGO' THEN 4568
           WHEN d.localidad='BRANDSEN' THEN 4562
           WHEN d.localidad='TRANSRADIO' THEN 11298
           WHEN d.localidad='WILLIAM MORRIS' THEN 21687 -------revisar
           WHEN d.localidad='SPEGAZZINI' THEN 2571
           WHEN d.localidad='ALTE BROWN' THEN 479
           WHEN d.localidad='HUDSON' THEN 8620
           WHEN d.localidad='G. CATAN' THEN 8472
           WHEN d.localidad='CAPILLA DEL SEÑOR' THEN 21688 -------revisar
           WHEN d.localidad='CIUDADELA NORTE' THEN 3434
           WHEN d.localidad='HURLINGHAN' THEN 8853
           WHEN d.localidad='G CATAN' THEN 8472
           WHEN d.localidad='ING BUDGE' THEN 21685
           WHEN d.localidad='BUDGE' THEN 21685
           WHEN d.localidad='VILLA MAIPU' THEN 13986
           WHEN d.localidad='R. CALZADA' THEN 17321
           WHEN d.localidad='JOSE C.PAZ' THEN 9199
           WHEN d.localidad='VILLA DIAMANTE' THEN 11956
           WHEN d.localidad='LAVALLOL' THEN 12837
           WHEN d.localidad='LLAVALLOL' THEN 12837
           WHEN d.localidad='GONNET' THEN 14107
           WHEN d.localidad='AMEGHINO' THEN 8122
           WHEN d.localidad='TOLOSA' THEN 11298
           WHEN d.localidad='BARRIO MATERA' THEN 15540
           WHEN d.localidad='G.CATAN' THEN 8472
           WHEN d.localidad='VILLA CARAZA' THEN 11956
           WHEN d.localidad='CASANOVA' THEN 9019
           WHEN d.localidad='LA FERRERE' THEN 8516
           WHEN d.localidad='CABA' THEN 3427
           WHEN d.localidad='GRAL.RODRIGUEZ' THEN 8380
           WHEN d.localidad='F. VARELA' THEN 8119
           WHEN d.localidad='ADOLFO GONZALEZ CHAVES' THEN 139
           WHEN d.localidad='PQUE. SAN MARTIN' THEN 15540
           WHEN d.localidad='ALTOS DE LAFERRERE' THEN 8516
           WHEN d.localidad='ING. BUDGE' THEN 21685
           WHEN d.localidad='PACHECO' THEN 8366
           WHEN d.localidad='S.A.DE GILES' THEN 18119
           WHEN d.localidad='VILLA BONICH' THEN 20893
           WHEN d.localidad='R. CASTILLO' THEN 17322
           WHEN d.localidad='I. CASANOVA' THEN 9019
           WHEN d.localidad='S.A.DE ARECO' THEN 18178
           WHEN d.localidad='I.CASANOVA' THEN 9019
           WHEN d.localidad='CAP. FED.' THEN 3427
           WHEN d.localidad='RINGUELET' THEN 11298
           WHEN d.localidad='SAN A. DE PADUA' THEN 18192
           WHEN d.localidad='G. LAFERRERE' THEN 8516
           WHEN d.localidad='C. SPEGAZZINI' THEN 2571
           WHEN d.localidad='EST. ECHEVERRIA' THEN 14670
           WHEN d.localidad='ALTE. BROWN' THEN 479
           WHEN d.localidad='ING.BUDGE' THEN 21685
           WHEN d.localidad='F VARELA' THEN 8119
           ELSE dd.ID END AS idLocalidad, 
			dd.provincia_id 
FROM [german-pc\germansql].basesic.dbo.[1Tmdelitosic] d
OUTER APPLY (SELECT TOP 1 * FROM Localidad l  WHERE l.Localidad=d.localidad COLLATE Latin1_general_CI_AI  
ORDER BY CASE WHEN Provincia_Id=15 THEN 1 
              WHEN Provincia_id=1 THEN 2 
              ELSE 3 END, Provincia_Id ) dd 
)LOC ON loc.codbarra=d.codbarra
JOIN Autores aut ON aut.codbarra=d.codbarra COLLATE DATABASE_DEFAULT





INSERT INTO Persona(Apellido,  Direccion, DocumentoNumero, Edad, EstudiosCursados, FechaAlta, FechaCreacion, FechaNacimiento, idEstadoCivil, idLocalidad, idNacionalidad, idProvinciaNac, idSexo, idTipoDNI, LugarNacimiento, Madre, Nombre, Padre, Partido, profesion, Telefono, Codbarra)
SELECT apellido, domicilio, docnro, '' as edad, idEstudiosCursados, fecargaop, fecargaop, fenac, idEstadoCivil, idLocalidad, idPaisNac, idProvNac, idSexo, idTipoDNI, idLocNac, madre, nombres, padre, idPartido, profesion,te, CodBarra FROM #tempTable
UPDATE aut set aut.idPersona=p.id FROM Persona p JOIN Autores aut ON p.codbarra=aut.codbarra 

GO
--------------------
--IPP
-------------------
 
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

IF NOT EXISTS(SELECT * FROM sys.columns 
        WHERE [name] = N'CodBarra' AND [object_id] = OBJECT_ID(N'IPP'))
BEGIN
	ALTER TABLE IPP ADD CodBarra VARCHAR(13)
END
GO


INSERT IPP(codbarra, numero,caratula,TipoIPP, ufi, TitularUFI, ResponsableUFI, JuzgadoGarantias, FechaCreacion, FechaUltimaModificacion)
SELECT codbarra, ipp, caratula, 1, ufi, fiscal, fiscal, juzgar,feentlase,getdate() FROM #tempTable 

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
SELECT codbarra,fecha, fecha FROM #tempTable 
GO

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
FROM #tempTable t 
JOIN IPP i ON t.codbarra=i.codbarra COLLATE Latin1_general_CI_AI  
JOIN DescripcionTemporal dt ON t.codbarra=dt.codbarra COLLATE Latin1_general_CI_AI  

UPDATE aut SET aut.idDelito=d.id FROM Delitos d JOIN Autores aut ON d.codbarra=aut.codbarra 

---DAR DE BAJA TODAS LAS COLUMNAS PROVISORIAS CODBARRA DE LAS TABLAS
----AGREGAR CONYUGE A 1TFAMILIA


 ALTER TABLE Autores DROP COLUMN CodBarra
 ALTER TABLE AutoresAlias DROP COLUMN CodBarra
 ALTER TABLE Persona DROP COLUMN CodBarra
 DROP FUNCTION dbo.extraerNros
 --DROP TABLE #tempTable
 GO


--EXEC sp_msforeachtable "ALTER TABLE ? CHECK CONSTRAINT all"

select * from ipp
select * from imputados
select * from #tempTable