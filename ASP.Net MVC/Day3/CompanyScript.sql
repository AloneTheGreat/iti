USE [master]
GO
/****** Object:  Database [Company]    Script Date: 3/31/2020 12:38:02 PM ******/
CREATE DATABASE [Company]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Company', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Company.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Company_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Company_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Company] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Company].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Company] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Company] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Company] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Company] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Company] SET ARITHABORT OFF 
GO
ALTER DATABASE [Company] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Company] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Company] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Company] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Company] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Company] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Company] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Company] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Company] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Company] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Company] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Company] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Company] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Company] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Company] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Company] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Company] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Company] SET RECOVERY FULL 
GO
ALTER DATABASE [Company] SET  MULTI_USER 
GO
ALTER DATABASE [Company] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Company] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Company] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Company] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Company] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Company', N'ON'
GO
ALTER DATABASE [Company] SET QUERY_STORE = OFF
GO
USE [Company]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 3/31/2020 12:38:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/31/2020 12:38:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[SupplierID] [int] NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 3/31/2020 12:38:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierPhone]    Script Date: 3/31/2020 12:38:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierPhone](
	[SupplierID] [int] NOT NULL,
	[Phone] [char](11) NOT NULL,
 CONSTRAINT [PK_SupplierPhone] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC,
	[Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [Name]) VALUES (1, N'Noodels')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (2, N'Chocolate')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (3, N'Yougert')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [Name], [CategoryID], [SupplierID], [Price]) VALUES (1, N'Indoomi', 1, 3, 4.5)
INSERT [dbo].[Product] ([ID], [Name], [CategoryID], [SupplierID], [Price]) VALUES (2, N'Smoth Chocolate Milk', 2, 2, 5)
INSERT [dbo].[Product] ([ID], [Name], [CategoryID], [SupplierID], [Price]) VALUES (4, N'Strawbary Yougert', 3, 1, 2)
INSERT [dbo].[Product] ([ID], [Name], [CategoryID], [SupplierID], [Price]) VALUES (5, N'productNew', 1, 1, 200)
INSERT [dbo].[Product] ([ID], [Name], [CategoryID], [SupplierID], [Price]) VALUES (6, N'whatever', 2, 2, 5)
INSERT [dbo].[Product] ([ID], [Name], [CategoryID], [SupplierID], [Price]) VALUES (8, N'Elmaleka', 1, 3, 10)
INSERT [dbo].[Product] ([ID], [Name], [CategoryID], [SupplierID], [Price]) VALUES (9, N'Salsa', 2, 3, 5)
INSERT [dbo].[Product] ([ID], [Name], [CategoryID], [SupplierID], [Price]) VALUES (10, N'productTest', 1, 1, 90)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([ID], [Name], [Address]) VALUES (1, N'Gohina', N'Egypt')
INSERT [dbo].[Supplier] ([ID], [Name], [Address]) VALUES (2, N'Galaxy', N'UK')
INSERT [dbo].[Supplier] ([ID], [Name], [Address]) VALUES (3, N'Kiloogs', N'Egypt')
SET IDENTITY_INSERT [dbo].[Supplier] OFF
INSERT [dbo].[SupplierPhone] ([SupplierID], [Phone]) VALUES (1, N'12345678912')
INSERT [dbo].[SupplierPhone] ([SupplierID], [Phone]) VALUES (1, N'23456789012')
INSERT [dbo].[SupplierPhone] ([SupplierID], [Phone]) VALUES (2, N'22334455667')
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Supplier]
GO
ALTER TABLE [dbo].[SupplierPhone]  WITH CHECK ADD  CONSTRAINT [FK_SupplierPhone_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([ID])
GO
ALTER TABLE [dbo].[SupplierPhone] CHECK CONSTRAINT [FK_SupplierPhone_Supplier]
GO
ALTER TABLE [dbo].[SupplierPhone]  WITH CHECK ADD  CONSTRAINT [CK_SupplierPhone] CHECK  ((len([Phone])=(11)))
GO
ALTER TABLE [dbo].[SupplierPhone] CHECK CONSTRAINT [CK_SupplierPhone]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SupplierPhone', @level2type=N'CONSTRAINT',@level2name=N'CK_SupplierPhone'
GO
USE [master]
GO
ALTER DATABASE [Company] SET  READ_WRITE 
GO
