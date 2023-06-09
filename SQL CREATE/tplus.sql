USE [master]
GO

/****** Object:  Database [T_PLUS]    Script Date: 09.04.2023 21:15:16 ******/
CREATE DATABASE [T_PLUS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'T_PLUS', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\T_PLUS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'T_PLUS_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\T_PLUS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [T_PLUS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [T_PLUS] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [T_PLUS] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [T_PLUS] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [T_PLUS] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [T_PLUS] SET ARITHABORT OFF 
GO

ALTER DATABASE [T_PLUS] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [T_PLUS] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [T_PLUS] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [T_PLUS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [T_PLUS] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [T_PLUS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [T_PLUS] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [T_PLUS] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [T_PLUS] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [T_PLUS] SET  ENABLE_BROKER 
GO

ALTER DATABASE [T_PLUS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [T_PLUS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [T_PLUS] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [T_PLUS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [T_PLUS] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [T_PLUS] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [T_PLUS] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [T_PLUS] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [T_PLUS] SET  MULTI_USER 
GO

ALTER DATABASE [T_PLUS] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [T_PLUS] SET DB_CHAINING OFF 
GO

ALTER DATABASE [T_PLUS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [T_PLUS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [T_PLUS] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [T_PLUS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [T_PLUS] SET QUERY_STORE = OFF
GO

ALTER DATABASE [T_PLUS] SET  READ_WRITE 
GO

