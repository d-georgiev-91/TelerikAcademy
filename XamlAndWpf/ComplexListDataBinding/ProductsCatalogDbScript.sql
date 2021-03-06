USE [master]
GO
/****** Object:  Database [ProductsCatalog]    Script Date: 11.9.2013 г. 21:03:48 ******/
CREATE DATABASE [ProductsCatalog]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProductsCatalog', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ProductsCatalog.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProductsCatalog_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ProductsCatalog_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProductsCatalog] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProductsCatalog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProductsCatalog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProductsCatalog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProductsCatalog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProductsCatalog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProductsCatalog] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProductsCatalog] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProductsCatalog] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ProductsCatalog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProductsCatalog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProductsCatalog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProductsCatalog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProductsCatalog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProductsCatalog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProductsCatalog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProductsCatalog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProductsCatalog] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProductsCatalog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProductsCatalog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProductsCatalog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProductsCatalog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProductsCatalog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProductsCatalog] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProductsCatalog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProductsCatalog] SET RECOVERY FULL 
GO
ALTER DATABASE [ProductsCatalog] SET  MULTI_USER 
GO
ALTER DATABASE [ProductsCatalog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProductsCatalog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProductsCatalog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProductsCatalog] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProductsCatalog', N'ON'
GO
USE [ProductsCatalog]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11.9.2013 г. 21:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 11.9.2013 г. 21:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ModelName] [nvarchar](50) NOT NULL,
	[ModelNumber] [int] NOT NULL,
	[UnitCost] [money] NOT NULL,
	[Description] [nvarchar](300) NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (1, N'Phones')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (2, N'Computers')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [ModelName], [ModelNumber], [UnitCost], [Description], [CategoryId]) VALUES (1, N'AcerTravlemate5550', 41411, 5505.0000, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc venenatis fermentum urna ut aliquet. Phasellus imperdiet rhoncus nibh vitae tincidunt. Integer fringilla mi ante, accumsan rutrum mi volutpat sit amet. Vestibulum ligula dolor, congue non fringilla nec, auctor in metus.', 2)
INSERT [dbo].[Products] ([ProductId], [ModelName], [ModelNumber], [UnitCost], [Description], [CategoryId]) VALUES (2, N'Comodore64', 15211, 100.0000, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc venenatis fermentum urna ut aliquet. Phasellus imperdiet rhoncus nibh vitae tincidunt. Integer fringilla mi ante, accumsan rutrum mi volutpat sit amet. Vestibulum ligula dolor, congue non fringilla nec, auctor in metus.', 2)
INSERT [dbo].[Products] ([ProductId], [ModelName], [ModelNumber], [UnitCost], [Description], [CategoryId]) VALUES (3, N'SamsungAce2', 41521, 512512.0000, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc venenatis fermentum urna ut aliquet. Phasellus imperdiet rhoncus nibh vitae tincidunt. Integer fringilla mi ante, accumsan rutrum mi volutpat sit amet. Vestibulum ligula dolor, congue non fringilla nec, auctor in metus.', 1)
INSERT [dbo].[Products] ([ProductId], [ModelName], [ModelNumber], [UnitCost], [Description], [CategoryId]) VALUES (4, N' MotorolaC640', 12455, 214.0000, NULL, 1)
INSERT [dbo].[Products] ([ProductId], [ModelName], [ModelNumber], [UnitCost], [Description], [CategoryId]) VALUES (5, N'HP5005', 41241, 3000.0000, NULL, 2)
SET IDENTITY_INSERT [dbo].[Products] OFF
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
USE [master]
GO
ALTER DATABASE [ProductsCatalog] SET  READ_WRITE 
GO
