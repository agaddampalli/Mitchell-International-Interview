CREATE DATABASE [MitchellClaimsDb]
GO

USE [MitchellClaimsDb]
GO
/****** Object:  Table [dbo].[causeOfLossCode]    Script Date: 2/14/2016 5:38:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[causeOfLossCode]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[causeOfLossCode](
	[CauseOfLossId] [int] IDENTITY(1,1) NOT NULL,
	[LossCodeType] [nvarchar](50) NULL,
 CONSTRAINT [UK_causeOfLossCode] PRIMARY KEY CLUSTERED 
(
	[CauseOfLossId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[lossInfo]    Script Date: 2/14/2016 5:38:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[lossInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[lossInfo](
	[LossInfoId] [int] IDENTITY(1,1) NOT NULL,
	[CauseOfLossId] [int] NOT NULL,
	[ReportedDate] [datetime] NULL,
	[LossDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_lossInfo] PRIMARY KEY CLUSTERED 
(
	[LossInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[mitchellClaims]    Script Date: 2/14/2016 5:38:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[mitchellClaims]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[mitchellClaims](
	[ClaimNumber] [nvarchar](50) NOT NULL,
	[ClaimantFirstName] [nvarchar](255) NULL,
	[ClaimantLastName] [nvarchar](255) NULL,
	[Status] [int] NOT NULL,
	[LossDate] [datetime] NULL,
	[AssignedAdjusterID] [numeric](18, 0) NULL,
	[LossInfoId] [int] NULL,
 CONSTRAINT [PK_mitchellClaims] PRIMARY KEY CLUSTERED 
(
	[ClaimNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[statusCode]    Script Date: 2/14/2016 5:38:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[statusCode]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[statusCode](
	[StausId] [int] IDENTITY(1,1) NOT NULL,
	[StatusCode] [nvarchar](50) NULL,
 CONSTRAINT [UK_statusCode] PRIMARY KEY CLUSTERED 
(
	[StausId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[vehicleInfo]    Script Date: 2/14/2016 5:38:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[vehicleInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[vehicleInfo](
	[Vin] [nvarchar](50) NOT NULL,
	[ModelYear] [int] NULL,
	[MakeDescription] [nvarchar](255) NULL,
	[ModelDescription] [nvarchar](255) NULL,
	[EngineDescription] [nvarchar](255) NULL,
	[ExteriorColor] [nvarchar](50) NULL,
	[LicPlate] [nvarchar](50) NULL,
	[LicPlateState] [nvarchar](50) NULL,
	[LicPlateExpDate] [datetime] NULL,
	[DamageDescription] [nvarchar](max) NULL,
	[Mileage] [int] NULL,
	[ClaimNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_vehicleInfo] PRIMARY KEY CLUSTERED 
(
	[Vin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_lossInfo_causeOfLossCode]') AND parent_object_id = OBJECT_ID(N'[dbo].[lossInfo]'))
ALTER TABLE [dbo].[lossInfo]  WITH CHECK ADD  CONSTRAINT [FK_lossInfo_causeOfLossCode] FOREIGN KEY([CauseOfLossId])
REFERENCES [dbo].[causeOfLossCode] ([CauseOfLossId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_lossInfo_causeOfLossCode]') AND parent_object_id = OBJECT_ID(N'[dbo].[lossInfo]'))
ALTER TABLE [dbo].[lossInfo] CHECK CONSTRAINT [FK_lossInfo_causeOfLossCode]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_mitchellClaims_lossInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[mitchellClaims]'))
ALTER TABLE [dbo].[mitchellClaims]  WITH CHECK ADD  CONSTRAINT [FK_mitchellClaims_lossInfo] FOREIGN KEY([LossInfoId])
REFERENCES [dbo].[lossInfo] ([LossInfoId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_mitchellClaims_lossInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[mitchellClaims]'))
ALTER TABLE [dbo].[mitchellClaims] CHECK CONSTRAINT [FK_mitchellClaims_lossInfo]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_mitchellClaims_statusCode]') AND parent_object_id = OBJECT_ID(N'[dbo].[mitchellClaims]'))
ALTER TABLE [dbo].[mitchellClaims]  WITH CHECK ADD  CONSTRAINT [FK_mitchellClaims_statusCode] FOREIGN KEY([Status])
REFERENCES [dbo].[statusCode] ([StausId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_mitchellClaims_statusCode]') AND parent_object_id = OBJECT_ID(N'[dbo].[mitchellClaims]'))
ALTER TABLE [dbo].[mitchellClaims] CHECK CONSTRAINT [FK_mitchellClaims_statusCode]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_vehicleInfo_mitchellClaims]') AND parent_object_id = OBJECT_ID(N'[dbo].[vehicleInfo]'))
ALTER TABLE [dbo].[vehicleInfo]  WITH CHECK ADD  CONSTRAINT [FK_vehicleInfo_mitchellClaims] FOREIGN KEY([ClaimNumber])
REFERENCES [dbo].[mitchellClaims] ([ClaimNumber])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_vehicleInfo_mitchellClaims]') AND parent_object_id = OBJECT_ID(N'[dbo].[vehicleInfo]'))
ALTER TABLE [dbo].[vehicleInfo] CHECK CONSTRAINT [FK_vehicleInfo_mitchellClaims]
GO
