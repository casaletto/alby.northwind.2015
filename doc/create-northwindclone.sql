USE [master]
GO

/****** Object:  Database [NorthwindClone]    Script Date: 04/05/2008 07:51:55 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'NorthwindClone')
DROP DATABASE [NorthwindClone]

/****** Object:  Database [NorthwindClone]    Script Date: 04/05/2008 07:51:26 ******/
CREATE DATABASE [NorthwindClone] ON  PRIMARY 
( NAME = N'NorthwindClone_Data', FILENAME = N'd:\databases\alby.northwind\NorthwindClone.mdf' , SIZE = 3000KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NorthwindClone_Log', FILENAME = N'd:\databases\alby.northwind\NorthwindClone_log.ldf' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
GO

EXEC dbo.sp_dbcmptlevel @dbname=N'NorthwindClone', @new_cmptlevel=90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NorthwindClone].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [NorthwindClone] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NorthwindClone] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NorthwindClone] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NorthwindClone] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NorthwindClone] SET ARITHABORT OFF 
GO
ALTER DATABASE [NorthwindClone] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NorthwindClone] SET AUTO_CREATE_STATISTICS OFF
GO
ALTER DATABASE [NorthwindClone] SET AUTO_SHRINK ON 
GO
ALTER DATABASE [NorthwindClone] SET AUTO_UPDATE_STATISTICS OFF
GO
ALTER DATABASE [NorthwindClone] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NorthwindClone] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NorthwindClone] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NorthwindClone] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NorthwindClone] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NorthwindClone] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NorthwindClone] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NorthwindClone] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NorthwindClone] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NorthwindClone] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NorthwindClone] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NorthwindClone] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NorthwindClone] SET  READ_WRITE 
GO
ALTER DATABASE [NorthwindClone] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NorthwindClone] SET  MULTI_USER 
GO
ALTER DATABASE [NorthwindClone] SET PAGE_VERIFY NONE  
GO
ALTER DATABASE [NorthwindClone] SET DB_CHAINING OFF 
GO

--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
