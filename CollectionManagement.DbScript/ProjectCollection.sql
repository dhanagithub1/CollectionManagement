--USE [master]
--GO
--/****** Object:  Database [Collection]    Script Date: 8/1/2018 2:46:12 PM ******/
--CREATE DATABASE [Collection]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'Collection', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Collection.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
-- LOG ON 
--( NAME = N'Collection_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Collection_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
--GO
--ALTER DATABASE [Collection] SET COMPATIBILITY_LEVEL = 120
--GO
--IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
--begin
--EXEC [Collection].[dbo].[sp_fulltext_database] @action = 'enable'
--end
--GO
--ALTER DATABASE [Collection] SET ANSI_NULL_DEFAULT OFF 
--GO
--ALTER DATABASE [Collection] SET ANSI_NULLS OFF 
--GO
--ALTER DATABASE [Collection] SET ANSI_PADDING OFF 
--GO
--ALTER DATABASE [Collection] SET ANSI_WARNINGS OFF 
--GO
--ALTER DATABASE [Collection] SET ARITHABORT OFF 
--GO
--ALTER DATABASE [Collection] SET AUTO_CLOSE OFF 
--GO
--ALTER DATABASE [Collection] SET AUTO_SHRINK OFF 
--GO
--ALTER DATABASE [Collection] SET AUTO_UPDATE_STATISTICS ON 
--GO
--ALTER DATABASE [Collection] SET CURSOR_CLOSE_ON_COMMIT OFF 
--GO
--ALTER DATABASE [Collection] SET CURSOR_DEFAULT  GLOBAL 
--GO
--ALTER DATABASE [Collection] SET CONCAT_NULL_YIELDS_NULL OFF 
--GO
--ALTER DATABASE [Collection] SET NUMERIC_ROUNDABORT OFF 
--GO
--ALTER DATABASE [Collection] SET QUOTED_IDENTIFIER OFF 
--GO
--ALTER DATABASE [Collection] SET RECURSIVE_TRIGGERS OFF 
--GO
--ALTER DATABASE [Collection] SET  DISABLE_BROKER 
--GO
--ALTER DATABASE [Collection] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
--GO
--ALTER DATABASE [Collection] SET DATE_CORRELATION_OPTIMIZATION OFF 
--GO
--ALTER DATABASE [Collection] SET TRUSTWORTHY OFF 
--GO
--ALTER DATABASE [Collection] SET ALLOW_SNAPSHOT_ISOLATION OFF 
--GO
--ALTER DATABASE [Collection] SET PARAMETERIZATION SIMPLE 
--GO
--ALTER DATABASE [Collection] SET READ_COMMITTED_SNAPSHOT OFF 
--GO
--ALTER DATABASE [Collection] SET HONOR_BROKER_PRIORITY OFF 
--GO
--ALTER DATABASE [Collection] SET RECOVERY SIMPLE 
--GO
--ALTER DATABASE [Collection] SET  MULTI_USER 
--GO
--ALTER DATABASE [Collection] SET PAGE_VERIFY CHECKSUM  
--GO
--ALTER DATABASE [Collection] SET DB_CHAINING OFF 
--GO
--ALTER DATABASE [Collection] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
--GO
--ALTER DATABASE [Collection] SET TARGET_RECOVERY_TIME = 0 SECONDS 
--GO
--ALTER DATABASE [Collection] SET DELAYED_DURABILITY = DISABLED 
--GO
--USE [Collection]
--GO
--/****** Object:  Table [dbo].[CollectionTransaction]    Script Date: 8/1/2018 2:46:13 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--SET ANSI_PADDING ON
--GO
CREATE TABLE [dbo].[CollectionTransaction](
	[CollectionTransactionId] [bigint] IDENTITY(1,1) NOT NULL,
	[TransactionId] [varchar](50) NULL,
	[TransactionStatus] [int] NULL,
	[ApplicantName] [varchar](100) NULL,
	[MobileNumber] [varchar](50) NULL,
	[Address] [varchar](500) NULL,
	[AadhaarNumber] [varchar](20) NULL,
	[PanNumber] [varchar](20) NULL,
	[ApplicantGSTNumber] [varchar](100) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ChequeNumber] [varchar](50) NULL,
	[DDNumber] [varchar](50) NULL,
	[BankName] [varchar](50) NULL,
	[BankAddress] [varchar](100) NULL,
 CONSTRAINT [PK_CollectionTransaction] PRIMARY KEY CLUSTERED 
(
	[CollectionTransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 8/1/2018 2:46:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [bigint] IDENTITY(1,1) NOT NULL,
	[DepartmentNameEnglish] [varchar](50) NULL,
	[DepartmentNameMarathi] [varchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_dbo.Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 8/1/2018 2:46:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Service]    Script Date: 8/1/2018 2:46:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Service](
	[ServiceId] [bigint] IDENTITY(1,1) NOT NULL,
	[ServiceNameEnglish] [varchar](50) NULL,
	[ServiceNameMarathi] [varchar](50) NULL,
	[FunctionCode] [varchar](50) NULL,
	[ObjectCode] [varchar](20) NULL,
	[DepartmentId] [bigint] NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TransactionService]    Script Date: 8/1/2018 2:46:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TransactionService](
	[TransactionServiceId] [bigint] IDENTITY(1,1) NOT NULL,
	[CollectionTransactionId] [bigint] NULL,
	[ServiceId] [bigint] NULL,
	[Rate] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
	[Remarks] [varchar](500) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
 CONSTRAINT [PK_TransactionService] PRIMARY KEY CLUSTERED 
(
	[TransactionServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 8/1/2018 2:46:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[MobileNumber] [varchar](20) NULL,
	[EmailAddress] [varchar](50) NULL,
	[RoleId] [int] NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](500) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Service]  WITH NOCHECK ADD  CONSTRAINT [FK_Service_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_Department]
GO
ALTER TABLE [dbo].[TransactionService]  WITH NOCHECK ADD  CONSTRAINT [FK_TransactionService_CollectionTransaction] FOREIGN KEY([CollectionTransactionId])
REFERENCES [dbo].[CollectionTransaction] ([CollectionTransactionId])
GO
ALTER TABLE [dbo].[TransactionService] CHECK CONSTRAINT [FK_TransactionService_CollectionTransaction]
GO
ALTER TABLE [dbo].[TransactionService]  WITH NOCHECK ADD  CONSTRAINT [FK_TransactionService_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([ServiceId])
GO
ALTER TABLE [dbo].[TransactionService] CHECK CONSTRAINT [FK_TransactionService_Service]
GO
ALTER TABLE [dbo].[User]  WITH NOCHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
--GO
--USE [master]
--GO
--ALTER DATABASE [Collection] SET  READ_WRITE 
--GO
