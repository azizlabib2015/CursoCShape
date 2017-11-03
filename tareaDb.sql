USE [master]
GO
/****** Object:  Database [Tarea]    Script Date: 03/11/2017 20:54:02 ******/
CREATE DATABASE [Tarea]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Tarea', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Tarea.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Tarea_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Tarea_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Tarea] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Tarea].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Tarea] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Tarea] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Tarea] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Tarea] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Tarea] SET ARITHABORT OFF 
GO
ALTER DATABASE [Tarea] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Tarea] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Tarea] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Tarea] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Tarea] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Tarea] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Tarea] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Tarea] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Tarea] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Tarea] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Tarea] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Tarea] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Tarea] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Tarea] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Tarea] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Tarea] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Tarea] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Tarea] SET RECOVERY FULL 
GO
ALTER DATABASE [Tarea] SET  MULTI_USER 
GO
ALTER DATABASE [Tarea] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Tarea] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Tarea] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Tarea] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Tarea] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Tarea', N'ON'
GO
ALTER DATABASE [Tarea] SET QUERY_STORE = OFF
GO
USE [Tarea]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Tarea]
GO
/****** Object:  Table [dbo].[Tarea]    Script Date: 03/11/2017 20:54:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarea](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](50) NOT NULL,
	[descripcion] [nchar](250) NOT NULL,
	[prioridad] [int] NOT NULL,
	[estado] [int] NOT NULL,
	[asignadoA] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Tarea] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Tarea] SET  READ_WRITE 
GO
