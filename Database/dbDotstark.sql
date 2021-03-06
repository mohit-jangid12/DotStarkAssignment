USE [DbDotStark]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 9/28/2021 11:45:51 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
DROP TABLE [dbo].[Products]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/28/2021 11:45:51 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type in (N'U'))
DROP TABLE [dbo].[__EFMigrationsHistory]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/28/2021 11:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 9/28/2021 11:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductID] [nvarchar](max) NULL,
	[ProductName] [nvarchar](max) NULL,
	[StockAvailable] [bigint] NOT NULL,
	[Is_Active] [bit] NOT NULL,
	[Is_Delete] [bit] NOT NULL,
	[Created_At] [datetime2](7) NOT NULL,
	[Updated_At] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210922152035_init_migration', N'2.1.14-servicing-32113')
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ID], [ProductID], [ProductName], [StockAvailable], [Is_Active], [Is_Delete], [Created_At], [Updated_At]) VALUES (1, N'B3A5E8D8-A618-4811-B429-E2DFB8A5ABB8', N'Cars', 5, 1, 0, CAST(N'2021-09-27T19:25:03.4277607' AS DateTime2), CAST(N'2021-09-27T19:25:05.6268056' AS DateTime2))
INSERT [dbo].[Products] ([ID], [ProductID], [ProductName], [StockAvailable], [Is_Active], [Is_Delete], [Created_At], [Updated_At]) VALUES (2, N'918C32DC-13BD-4053-BBF7-C294D1491117', N'Bikes', 10, 1, 0, CAST(N'2021-09-27T19:25:58.6325665' AS DateTime2), CAST(N'2021-09-27T19:25:58.6325666' AS DateTime2))
INSERT [dbo].[Products] ([ID], [ProductID], [ProductName], [StockAvailable], [Is_Active], [Is_Delete], [Created_At], [Updated_At]) VALUES (3, N'8FF1B431-CD3A-4ACE-8FF8-14B333E6A979', N'SuperCars', 2, 1, 0, CAST(N'2021-09-27T19:26:22.9835630' AS DateTime2), CAST(N'2021-09-27T19:26:22.9835631' AS DateTime2))
INSERT [dbo].[Products] ([ID], [ProductID], [ProductName], [StockAvailable], [Is_Active], [Is_Delete], [Created_At], [Updated_At]) VALUES (4, N'A8B59A55-E0B5-4E67-BC9E-4291F41BC411', N'Trucks', 1, 1, 0, CAST(N'2021-09-27T19:26:34.2508545' AS DateTime2), CAST(N'2021-09-27T19:26:34.2508546' AS DateTime2))
INSERT [dbo].[Products] ([ID], [ProductID], [ProductName], [StockAvailable], [Is_Active], [Is_Delete], [Created_At], [Updated_At]) VALUES (5, N'DD175277-FDC8-4242-91C2-567DCB1A7F83', N'Tempo', 0, 1, 0, CAST(N'2021-09-27T19:26:41.0063154' AS DateTime2), CAST(N'2021-09-27T19:26:41.0063156' AS DateTime2))
INSERT [dbo].[Products] ([ID], [ProductID], [ProductName], [StockAvailable], [Is_Active], [Is_Delete], [Created_At], [Updated_At]) VALUES (6, N'DC00A8B3-6F2E-4F3B-AC84-413C4230D9BA', N'BiCycle', 0, 1, 0, CAST(N'2021-09-27T20:04:17.4319550' AS DateTime2), CAST(N'2021-09-27T20:04:17.4320671' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
