--LINKEO DE SERVIDORES--------------
-------------------------------------
USE [master]
GO
EXEC master.dbo.sp_addlinkedserver 
    @server = N'MPBDSIC01', 
    @srvproduct=N'SQL Server' ;
GO

EXEC master.dbo.sp_addlinkedsrvlogin 
    @rmtsrvname = N'MPBDSIC01', 
    @locallogin = NULL , 
    @useself = N'True' ;
GO


EXEC master.dbo.sp_addlinkedserver 
    @server = N'MPBDTEST01', 
    @srvproduct=N'SQL Server' ;
GO

EXEC master.dbo.sp_addlinkedsrvlogin 
    @rmtsrvname = N'MPBDTEST01', 
	@rmtuser= N'UsuarioSIAC',
	@rmtpassword = N'UsuarioSiac',
    @locallogin = NULL , 
    @useself = N'True' ;
GO

SELECT name FROM MPBDSIC01.master.sys.databases ;
GO
