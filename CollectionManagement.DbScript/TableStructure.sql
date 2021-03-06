USE [CollectionManagement]
GO
/****** Object:  Table [dbo].[CollectionTransaction]    Script Date: 8/2/2018 10:56:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  Table [dbo].[Department]    Script Date: 8/2/2018 10:56:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Role]    Script Date: 8/2/2018 10:56:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Service]    Script Date: 8/2/2018 10:56:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ServiceId] [bigint] IDENTITY(1,1) NOT NULL,
	[ServiceNameEnglish] [varchar](50) NULL,
	[ServiceNameMarathi] [varchar](50) NULL,
	[FunctionCode] [varchar](50) NULL,
	[ObjectCode] [varchar](20) NULL,
	[DepartmentId] [bigint] NULL,
	[Remarks] [varchar](500) NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionService]    Script Date: 8/2/2018 10:56:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[User]    Script Date: 8/2/2018 10:56:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [RoleName], [CreatedOn], [CreatedBy]) VALUES (1, N'Admin', CAST(N'2018-08-02T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Role] ([RoleId], [RoleName], [CreatedOn], [CreatedBy]) VALUES (2, N'Department User', CAST(N'2018-08-02T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Role] ([RoleId], [RoleName], [CreatedOn], [CreatedBy]) VALUES (3, N'Collection User', CAST(N'2018-08-02T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [MobileNumber], [EmailAddress], [RoleId], [UserName], [Password], [CreatedOn], [CreatedBy], [IsActive]) VALUES (1, N'System', N'Admin', N'9087654321', N'systemadmin@gmail.com', 1, N'sadmin', N'123456', CAST(N'2018-08-02T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [MobileNumber], [EmailAddress], [RoleId], [UserName], [Password], [CreatedOn], [CreatedBy], [IsActive]) VALUES (2, N'Collection', N'User', N'9078456123', N'collectionuser@gmail.com', 3, N'coluser', N'123456', CAST(N'2018-08-02T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [MobileNumber], [EmailAddress], [RoleId], [UserName], [Password], [CreatedOn], [CreatedBy], [IsActive]) VALUES (3, N'Department', N'User', N'9032145698', N'departmentuser@gmail.com', 2, N'deptuser', N'123456', CAST(N'2018-08-02T00:00:00.000' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
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
GO
