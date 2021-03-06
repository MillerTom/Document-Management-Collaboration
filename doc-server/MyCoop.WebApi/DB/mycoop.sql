USE [master]
GO
/****** Object:  Database [mycoop]    Script Date: 09.10.2014 1:24:27 ******/
CREATE DATABASE [mycoop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'mycoop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS2\MSSQL\DATA\mycoop.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'mycoop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS2\MSSQL\DATA\mycoop_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [mycoop] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [mycoop].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [mycoop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [mycoop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [mycoop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [mycoop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [mycoop] SET ARITHABORT OFF 
GO
ALTER DATABASE [mycoop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [mycoop] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [mycoop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [mycoop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [mycoop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [mycoop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [mycoop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [mycoop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [mycoop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [mycoop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [mycoop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [mycoop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [mycoop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [mycoop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [mycoop] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [mycoop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [mycoop] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [mycoop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [mycoop] SET RECOVERY FULL 
GO
ALTER DATABASE [mycoop] SET  MULTI_USER 
GO
ALTER DATABASE [mycoop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [mycoop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [mycoop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [mycoop] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [mycoop]
GO
/****** Object:  StoredProcedure [dbo].[DeleteBusinessProcess]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteBusinessProcess]
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    delete from dbo.AttributeBusinessProcesses
	where BusinessProcessId = @id;

	delete from dbo.BusinessProcesses
	where Id = @id;

END


GO
/****** Object:  StoredProcedure [dbo].[DeleteComponent]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteComponent]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE dbo.DocumentTemplates
	SET ComponentId = NULL
	WHERE ComponentId = @id;

	delete from dbo.Components
	where Id = @id;

END

GO
/****** Object:  StoredProcedure [dbo].[DeleteDocumentTemplate]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteDocumentTemplate]
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    delete from dbo.WorkspaceDocumentTemplates
	where DocumentTemplateId = @id;

	delete from dbo.DocumentTemplates
	where Id = @id;

END

GO
/****** Object:  StoredProcedure [dbo].[DeleteGroup]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteGroup]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    delete from dbo.UserGroups
	where groupId = @id;

	delete from dbo.Groups
	where Id = @id;
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteIncident]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteIncident]
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    delete from dbo.IncidentOrgUnits
	where IncidentId = @id;

	delete from dbo.IncidentUsers
	where IncidentId = @id;

	delete from dbo.Incidents
	where Id = @id;

END



GO
/****** Object:  StoredProcedure [dbo].[DeleteOrgUnit]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteOrgUnit]
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    delete from dbo.IncidentOrgUnits
	where OrgUnitId = @id;

	delete from dbo.OrgUnitUserPermissions
	where OrgUnitId = @id;

	delete from dbo.OrgUnitGroupPermissions
	where OrgUnitId = @id;

	delete from dbo.BusinessProcessAttributes
	where EXISTS(SELECT 1 FROM dbo.BusinessProcesses WHERE OrgUnitId = @id);

	delete from dbo.BusinessProcesses
	where OrgUnitId = @id;

	delete from dbo.OrgUnits
	where ParentId = @id;

	delete from dbo.OrgUnits
	where Id = @id;
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUser]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from dbo.UserGroups
	where userId = @id;

	delete from dbo.Users
	where Id = @id;
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteWorkspaceTemplate]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteWorkspaceTemplate]
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE dbo.OrgUnits
	SET WorkspaceTemplateId = NULL
	WHERE WorkspaceTemplateId = @id;

    delete from dbo.WorkspaceDocumentTemplates
	where WorkspaceTemplateId = @id;

	delete from dbo.WorkspaceTemplateComponents
	where WorkspaceTemplateId = @id;

	delete from dbo.WorkspaceTemplates
	where Id = @id;
END

GO
/****** Object:  Table [dbo].[AttributeBusinessProcesses]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttributeBusinessProcesses](
	[BusinessProcessId] [int] NOT NULL,
	[AttributeId] [int] NOT NULL,
	[CreationTime] [datetime2](7) NULL,
 CONSTRAINT [PK_AttributeBusinessProcesses] PRIMARY KEY CLUSTERED 
(
	[BusinessProcessId] ASC,
	[AttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AttributeTypes]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttributeTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AttributeTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BusinessProcessAttributes]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessProcessAttributes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[AttributeTypeId] [int] NOT NULL,
 CONSTRAINT [PK_BusinessProcessAttributes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BusinessProcesses]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessProcesses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[OrgUnitId] [int] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Lat] [float] NOT NULL,
	[Lng] [float] NOT NULL,
 CONSTRAINT [PK_BusinessProcesses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Components]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Components](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Components] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DocumentTemplates]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentTemplates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Reference] [nvarchar](max) NOT NULL,
	[Purpose] [nvarchar](max) NOT NULL,
	[PagesCount] [int] NOT NULL,
	[Link] [nvarchar](max) NOT NULL,
	[ComponentId] [int] NULL,
 CONSTRAINT [PK_DocumentTemplates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Groups]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ModificationTime] [datetime2](7) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[ModifiedByUserId] [int] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IncidentOrgUnits]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IncidentOrgUnits](
	[IncidentId] [int] NOT NULL,
	[OrgUnitId] [int] NOT NULL,
	[CreationTime] [datetime2](7) NULL,
 CONSTRAINT [PK_IncidentOrgUnits] PRIMARY KEY CLUSTERED 
(
	[IncidentId] ASC,
	[OrgUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Incidents]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incidents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Lat] [float] NOT NULL,
	[Lng] [float] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Type] [int] NOT NULL,
	[Priority] [int] NOT NULL,
	[FacilityType] [int] NOT NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[Duration] [bigint] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IncidentUsers]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IncidentUsers](
	[IncidentId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[CreationTime] [datetime2](7) NULL,
 CONSTRAINT [PK_IncidentUsers] PRIMARY KEY CLUSTERED 
(
	[IncidentId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrgUnitGroupPermissions]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgUnitGroupPermissions](
	[OrgUnitId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[PermissionLevelId] [int] NOT NULL,
 CONSTRAINT [PK_OrgUnitGroupPermissions] PRIMARY KEY CLUSTERED 
(
	[OrgUnitId] ASC,
	[GroupId] ASC,
	[PermissionLevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrgUnits]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgUnits](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[ModificationTime] [datetime2](7) NOT NULL,
	[OwnerId] [int] NOT NULL,
	[ParentId] [int] NULL,
	[Lat] [float] NOT NULL,
	[Lng] [float] NOT NULL,
	[WorkspaceTemplateId] [int] NULL,
 CONSTRAINT [PK_OrgUnits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrgUnitUserPermissions]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgUnitUserPermissions](
	[OrgUnitId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[PermissionLevelId] [int] NOT NULL,
 CONSTRAINT [PK_OrgUnitUserPermissions] PRIMARY KEY CLUSTERED 
(
	[OrgUnitId] ASC,
	[UserId] ASC,
	[PermissionLevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PermissionLevels]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionLevels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PermissionLevels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reports]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Reports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CreatedById] [int] NOT NULL,
	[ModifiedById] [int] NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[ModificationTime] [datetime2](7) NOT NULL,
	[ReportLayout] [varbinary](max) NULL,
	[DataSourceType] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Reports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SysEvents]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Time] [datetime2](7) NOT NULL,
	[Summary] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Type] [int] NOT NULL,
	[UserId] [int] NULL,
	[TransactionId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_SysEvents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserGroups]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroups](
	[UserId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_UserGroups] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[TypeId] [int] NOT NULL,
	[PermissionLevelId] [int] NOT NULL,
	[LastAcitve] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkspaceDocumentTemplates]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkspaceDocumentTemplates](
	[WorkspaceTemplateId] [int] NOT NULL,
	[DocumentTemplateId] [int] NOT NULL,
	[CreationTime] [datetime2](7) NULL,
 CONSTRAINT [PK_WorkspaceDocumentTemplates] PRIMARY KEY CLUSTERED 
(
	[WorkspaceTemplateId] ASC,
	[DocumentTemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkspaceTemplateComponents]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkspaceTemplateComponents](
	[WorkspaceTemplateId] [int] NOT NULL,
	[ComponentId] [int] NOT NULL,
	[CreationTime] [datetime2](7) NULL,
 CONSTRAINT [PK_WorkspaceTemplateComponents] PRIMARY KEY CLUSTERED 
(
	[WorkspaceTemplateId] ASC,
	[ComponentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkspaceTemplates]    Script Date: 09.10.2014 1:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkspaceTemplates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[ModificationTime] [datetime2](7) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[ModifiedByUserId] [int] NOT NULL,
 CONSTRAINT [PK_WorkspaceTemplates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[AttributeBusinessProcesses] ([BusinessProcessId], [AttributeId], [CreationTime]) VALUES (3, 4, CAST(0x0751453EDC70FA380B AS DateTime2))
INSERT [dbo].[AttributeBusinessProcesses] ([BusinessProcessId], [AttributeId], [CreationTime]) VALUES (3, 5, CAST(0x076E933EDC70FA380B AS DateTime2))
INSERT [dbo].[AttributeBusinessProcesses] ([BusinessProcessId], [AttributeId], [CreationTime]) VALUES (3, 9, CAST(0x07FD6892BF59F8380B AS DateTime2))
INSERT [dbo].[AttributeBusinessProcesses] ([BusinessProcessId], [AttributeId], [CreationTime]) VALUES (3, 10, CAST(0x07C26E85BF59F8380B AS DateTime2))
INSERT [dbo].[AttributeBusinessProcesses] ([BusinessProcessId], [AttributeId], [CreationTime]) VALUES (3, 22, CAST(0x0760F586BF59F8380B AS DateTime2))
INSERT [dbo].[AttributeBusinessProcesses] ([BusinessProcessId], [AttributeId], [CreationTime]) VALUES (4, 3, CAST(0x07D083231B62F8380B AS DateTime2))
INSERT [dbo].[AttributeBusinessProcesses] ([BusinessProcessId], [AttributeId], [CreationTime]) VALUES (4, 9, CAST(0x07747A54FB5EF8380B AS DateTime2))
INSERT [dbo].[AttributeBusinessProcesses] ([BusinessProcessId], [AttributeId], [CreationTime]) VALUES (4, 12, CAST(0x07FBC89B6862F8380B AS DateTime2))
INSERT [dbo].[AttributeBusinessProcesses] ([BusinessProcessId], [AttributeId], [CreationTime]) VALUES (4, 15, CAST(0x07FBC89B6862F8380B AS DateTime2))
INSERT [dbo].[AttributeBusinessProcesses] ([BusinessProcessId], [AttributeId], [CreationTime]) VALUES (4, 26, CAST(0x07C138BB6862F8380B AS DateTime2))
INSERT [dbo].[AttributeBusinessProcesses] ([BusinessProcessId], [AttributeId], [CreationTime]) VALUES (5, 3, CAST(0x0790417B0761F8380B AS DateTime2))
INSERT [dbo].[AttributeBusinessProcesses] ([BusinessProcessId], [AttributeId], [CreationTime]) VALUES (5, 9, CAST(0x07CFDD7B0761F8380B AS DateTime2))
INSERT [dbo].[AttributeBusinessProcesses] ([BusinessProcessId], [AttributeId], [CreationTime]) VALUES (5, 11, CAST(0x07CFDD7B0761F8380B AS DateTime2))
INSERT [dbo].[AttributeBusinessProcesses] ([BusinessProcessId], [AttributeId], [CreationTime]) VALUES (5, 23, CAST(0x0790417B0761F8380B AS DateTime2))
INSERT [dbo].[AttributeBusinessProcesses] ([BusinessProcessId], [AttributeId], [CreationTime]) VALUES (5, 25, CAST(0x07EC2B7C0761F8380B AS DateTime2))
INSERT [dbo].[AttributeBusinessProcesses] ([BusinessProcessId], [AttributeId], [CreationTime]) VALUES (6, 4, CAST(0x074B4C08F360F8380B AS DateTime2))
INSERT [dbo].[AttributeBusinessProcesses] ([BusinessProcessId], [AttributeId], [CreationTime]) VALUES (6, 13, CAST(0x071FB007F360F8380B AS DateTime2))
INSERT [dbo].[AttributeBusinessProcesses] ([BusinessProcessId], [AttributeId], [CreationTime]) VALUES (6, 15, CAST(0x07382508F360F8380B AS DateTime2))
INSERT [dbo].[AttributeBusinessProcesses] ([BusinessProcessId], [AttributeId], [CreationTime]) VALUES (6, 22, CAST(0x071CFA09F360F8380B AS DateTime2))
INSERT [dbo].[AttributeBusinessProcesses] ([BusinessProcessId], [AttributeId], [CreationTime]) VALUES (6, 24, CAST(0x0779C108F360F8380B AS DateTime2))
INSERT [dbo].[AttributeBusinessProcesses] ([BusinessProcessId], [AttributeId], [CreationTime]) VALUES (6, 25, CAST(0x071CFA09F360F8380B AS DateTime2))
SET IDENTITY_INSERT [dbo].[AttributeTypes] ON 

INSERT [dbo].[AttributeTypes] ([Id], [Name]) VALUES (1, N'Staffing')
INSERT [dbo].[AttributeTypes] ([Id], [Name]) VALUES (2, N'Application')
INSERT [dbo].[AttributeTypes] ([Id], [Name]) VALUES (3, N'Vendor')
INSERT [dbo].[AttributeTypes] ([Id], [Name]) VALUES (4, N'Vital Record')
INSERT [dbo].[AttributeTypes] ([Id], [Name]) VALUES (5, N'Hardware')
SET IDENTITY_INSERT [dbo].[AttributeTypes] OFF
SET IDENTITY_INSERT [dbo].[BusinessProcessAttributes] ON 

INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (3, N'Adam', N'Phone; Title; Email', 1)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (4, N'Bob', N'Phone; Title; Email', 1)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (5, N'Charlie', N'Phone; Title; Email', 1)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (6, N'David', N'Phone; Title; Email', 1)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (7, N'Application1', N'', 2)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (8, N'Application2', N'', 2)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (9, N'Application3', N'', 2)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (10, N'Application4', N'', 2)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (11, N'Application5', N'', 2)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (12, N'Vendor1', N'', 3)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (13, N'Vendor1', N'', 3)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (14, N'Vendor3', N'', 3)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (15, N'Vendor4', N'', 3)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (16, N'Vendor5', N'', 3)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (17, N'Vital Record 1', N'', 4)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (18, N'Vital Record 2', N'', 4)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (19, N'Vital Record 3', N'', 4)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (20, N'Vital Record 4', N'', 4)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (21, N'Vital Record 5', N'', 4)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (22, N'Hardware1', N'', 5)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (23, N'Hardware2', N'', 5)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (24, N'Hardware3', N'', 5)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (25, N'Hardware4', N'', 5)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (26, N'Hardware5', N'', 5)
INSERT [dbo].[BusinessProcessAttributes] ([Id], [Name], [Description], [AttributeTypeId]) VALUES (27, N'Test', N'test', 2)
SET IDENTITY_INSERT [dbo].[BusinessProcessAttributes] OFF
SET IDENTITY_INSERT [dbo].[BusinessProcesses] ON 

INSERT [dbo].[BusinessProcesses] ([Id], [Name], [Description], [OrgUnitId], [Address], [Lat], [Lng]) VALUES (3, N'Operations', N'Facilitating the stand up and operations of new functions. Provide operational direction and advice to Executives. Manage key communication channels.', 1028, N'Lansing, MI, USA', 42.732535, -84.55553470000001)
INSERT [dbo].[BusinessProcesses] ([Id], [Name], [Description], [OrgUnitId], [Address], [Lat], [Lng]) VALUES (4, N'Contact Management', N'Management of CRM and keeping information up to date.', 1028, N'Northeast USA, Southeast Asia, Australia, Brazil', 0, 0)
INSERT [dbo].[BusinessProcesses] ([Id], [Name], [Description], [OrgUnitId], [Address], [Lat], [Lng]) VALUES (5, N'Inventory Managment - Warehouse', N'Use of Inventory Management System.', 1028, N'Lansing, MI, USA', 42.732535, -84.55553470000001)
INSERT [dbo].[BusinessProcesses] ([Id], [Name], [Description], [OrgUnitId], [Address], [Lat], [Lng]) VALUES (6, N'Warehouse Flood', N'There is a flood of any kind in the Warehouse.', 1028, N'Worldwide', 0, 0)
INSERT [dbo].[BusinessProcesses] ([Id], [Name], [Description], [OrgUnitId], [Address], [Lat], [Lng]) VALUES (12, N'Operations', N'Facilitating the stand up and operations of new functions. Provide operational direction and advice to Executives. Manage key communication channels.', 1028, N'Lansing, MI, USA', 42.732535, -84.55553470000001)
INSERT [dbo].[BusinessProcesses] ([Id], [Name], [Description], [OrgUnitId], [Address], [Lat], [Lng]) VALUES (14, N'Contact Management', N'Management of CRM and keeping information up to date.', 1028, N'Northeast USA, Southeast Asia, Australia, Brazil', 0, 0)
INSERT [dbo].[BusinessProcesses] ([Id], [Name], [Description], [OrgUnitId], [Address], [Lat], [Lng]) VALUES (17, N'Test', N'Test', 1028, N'asd', 0, 0)
SET IDENTITY_INSERT [dbo].[BusinessProcesses] OFF
SET IDENTITY_INSERT [dbo].[Components] ON 

INSERT [dbo].[Components] ([Id], [Name]) VALUES (1, N'BIA')
INSERT [dbo].[Components] ([Id], [Name]) VALUES (4, N'BCP')
INSERT [dbo].[Components] ([Id], [Name]) VALUES (5, N'RA')
SET IDENTITY_INSERT [dbo].[Components] OFF
SET IDENTITY_INSERT [dbo].[DocumentTemplates] ON 

INSERT [dbo].[DocumentTemplates] ([Id], [Name], [Reference], [Purpose], [PagesCount], [Link], [ComponentId]) VALUES (13, N'Business Continuity Context Requirements and Scope', N'MC04001', N'To set out the organisational context of the BCMS. It describes what the organisation does, how it does it, what factors influence the way it operates and the reasons for the definition of the scope of the BCMS', 9, N'/Content/DocumentTemplates/COOPPlanTemplate_8e12c38b-e042-471d-a6cf-5927e5ee4092.doc', 1)
INSERT [dbo].[DocumentTemplates] ([Id], [Name], [Reference], [Purpose], [PagesCount], [Link], [ComponentId]) VALUES (14, N'Legal and Regulatory Requirements Procedure', N'MC04002', N'Describes how the applicable legal and regulatory requirements relevant to the BCMS will be identified, accessed, assessed, documented, maintained and communicated', 5, N'/Content/DocumentTemplates/Final_COOP_Completed_Example_v1_a3cce349-64db-44f4-9712-917c75bec098.doc', 4)
INSERT [dbo].[DocumentTemplates] ([Id], [Name], [Reference], [Purpose], [PagesCount], [Link], [ComponentId]) VALUES (15, N'Business Continuity Policy', N'MC05001', N'The Business Continuity policy acts as the root “Quality Manual” of the Business Continuity Management System (BCMS) and must be approved by Top Management (defined as the “person or group of people who direct and control the organisation at the highest level”) as evidence of their commitment', 10, N'/Content/DocumentTemplates/coop_plan_template_instructions_57ae12dc-4b43-45e2-afaa-5b1363884674.doc', 4)
INSERT [dbo].[DocumentTemplates] ([Id], [Name], [Reference], [Purpose], [PagesCount], [Link], [ComponentId]) VALUES (16, N'Roles Responsibilities and Authorities', N'MC05002', N'To define the roles, responsibilities and authorities within the BCMS', 2, N'/Content/DocumentTemplates/major_disaster_requests_4608eb85-4beb-4d67-8f5c-f3c7007eeabd.doc', 5)
INSERT [dbo].[DocumentTemplates] ([Id], [Name], [Reference], [Purpose], [PagesCount], [Link], [ComponentId]) VALUES (18, N'iuhihiuh', N'iiojoij', N'iuhiuhuih', 1, N'/Content/DocumentTemplates/test_967ea417-6eba-43d2-8bf4-7e5a1771e091.docx', 1)
INSERT [dbo].[DocumentTemplates] ([Id], [Name], [Reference], [Purpose], [PagesCount], [Link], [ComponentId]) VALUES (19, N'iuhihiuh', N'iiojoij', N'iuhiuhuih', 1, N'/Content/DocumentTemplates/test_679903aa-0ab9-4ac3-adff-83f89ec70b07.docx', 1)
SET IDENTITY_INSERT [dbo].[DocumentTemplates] OFF
SET IDENTITY_INSERT [dbo].[Groups] ON 

INSERT [dbo].[Groups] ([Id], [Name], [Description], [ModificationTime], [CreationTime], [ModifiedByUserId], [CreatedByUserId]) VALUES (4, N'Engineering', N'Technical guys', CAST(0x07608CB8FB2913390B AS DateTime2), CAST(0x070E2D703D5BDA380B AS DateTime2), 8, 1)
INSERT [dbo].[Groups] ([Id], [Name], [Description], [ModificationTime], [CreationTime], [ModifiedByUserId], [CreatedByUserId]) VALUES (5, N'Sales', N'Includes marketing', CAST(0x075C5B309AA610390B AS DateTime2), CAST(0x070DF2E91A5CDA380B AS DateTime2), 10, 1)
INSERT [dbo].[Groups] ([Id], [Name], [Description], [ModificationTime], [CreationTime], [ModifiedByUserId], [CreatedByUserId]) VALUES (7, N'Security', N'Another description', CAST(0x0786B9E94C96F5380B AS DateTime2), CAST(0x073788FE588BDB380B AS DateTime2), 8, 8)
INSERT [dbo].[Groups] ([Id], [Name], [Description], [ModificationTime], [CreationTime], [ModifiedByUserId], [CreatedByUserId]) VALUES (8, N'IT Tech', N'Technical Staff', CAST(0x0773F9A112A9DB380B AS DateTime2), CAST(0x0773F9A112A9DB380B AS DateTime2), 8, 8)
SET IDENTITY_INSERT [dbo].[Groups] OFF
SET IDENTITY_INSERT [dbo].[Incidents] ON 

INSERT [dbo].[Incidents] ([Id], [Name], [Lat], [Lng], [Address], [Type], [Priority], [FacilityType], [StartTime], [Duration], [Description]) VALUES (2, N'Sample incident', 42.3584308, -71.0597732, N'Boston', 3, 2, 3, CAST(0x070000000000F2380B AS DateTime2), 25200000, N'123123')
INSERT [dbo].[Incidents] ([Id], [Name], [Lat], [Lng], [Address], [Type], [Priority], [FacilityType], [StartTime], [Duration], [Description]) VALUES (3, N'Worcester Fire Depot', 42.2625932, -71.8022934, N'worchester, massachusetts', 1, 1, 1, CAST(0x07800C6F4596F5380B AS DateTime2), 0, N'Explosions were heard.')
INSERT [dbo].[Incidents] ([Id], [Name], [Lat], [Lng], [Address], [Type], [Priority], [FacilityType], [StartTime], [Duration], [Description]) VALUES (4, N'New York City Train Derail', 40.7127837, -74.005941300000018, N'new york city, ny', 2, 3, 2, CAST(0x0780E719A597F5380B AS DateTime2), 0, N'Test')
INSERT [dbo].[Incidents] ([Id], [Name], [Lat], [Lng], [Address], [Type], [Priority], [FacilityType], [StartTime], [Duration], [Description]) VALUES (5, N'dasd', 15.882092606338151, 120.223388671875, N'asd', 1, 2, 1, CAST(0x0700D586722C13390B AS DateTime2), 0, N'asdasd')
INSERT [dbo].[Incidents] ([Id], [Name], [Lat], [Lng], [Address], [Type], [Priority], [FacilityType], [StartTime], [Duration], [Description]) VALUES (6, N'vasja', 77.55, 5.2, N'qwrqw', 1, 1, 1, CAST(0x070000000000000000 AS DateTime2), 100000, N'twetw')
SET IDENTITY_INSERT [dbo].[Incidents] OFF
INSERT [dbo].[OrgUnitGroupPermissions] ([OrgUnitId], [GroupId], [PermissionLevelId]) VALUES (1027, 4, 1)
INSERT [dbo].[OrgUnitGroupPermissions] ([OrgUnitId], [GroupId], [PermissionLevelId]) VALUES (1029, 4, 4)
SET IDENTITY_INSERT [dbo].[OrgUnits] ON 

INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng], [WorkspaceTemplateId]) VALUES (1020, N'Company 123', N'22182', CAST(0x072AC07BE3A6E1380B AS DateTime2), CAST(0x070035E08F45FA380B AS DateTime2), 8, NULL, 38.9457197, -77.297978199999989, 2)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng], [WorkspaceTemplateId]) VALUES (1027, N'Marketing', N'Boston', CAST(0x07AE4B2C9B47EE380B AS DateTime2), CAST(0x075FB1540995F5380B AS DateTime2), 8, 1020, 42.3584308, -71.0597732, 1)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng], [WorkspaceTemplateId]) VALUES (1028, N'Engineering', N'Boston', CAST(0x07AFCDA40948EE380B AS DateTime2), CAST(0x07626378FEA7FB380B AS DateTime2), 8, 1020, 42.3584308, -71.0597732, 3)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng], [WorkspaceTemplateId]) VALUES (1029, N'Design', N'Boston', CAST(0x0711F1629248EE380B AS DateTime2), CAST(0x077D90456BBCFA380B AS DateTime2), 8, 1034, 42.3584308, -71.0597732, 3)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng], [WorkspaceTemplateId]) VALUES (1030, N'Recovery', N'salisbury, md', CAST(0x0774CE640698F5380B AS DateTime2), CAST(0x0766D4648CBCFA380B AS DateTime2), 8, 1020, 38.3606736, -75.599369200000012, 1)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng], [WorkspaceTemplateId]) VALUES (1034, N'Sample', N'asd', CAST(0x07005E51587AFA380B AS DateTime2), CAST(0x07005E51587AFA380B AS DateTime2), 8, 1029, 24.6983639, -77.795267500000023, 2)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng], [WorkspaceTemplateId]) VALUES (1035, N'Rodette Sandbox', N'Herndon VA', CAST(0x07515336F7ABFA380B AS DateTime2), CAST(0x07B02CD776BCFA380B AS DateTime2), 8, 1020, 0, 0, 1)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng], [WorkspaceTemplateId]) VALUES (1036, N'Sales', N'New York City, NY', CAST(0x07A2579CB5BCFA380B AS DateTime2), CAST(0x07A83470C97F0C390B AS DateTime2), 8, 1027, 0, 0, 1)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng], [WorkspaceTemplateId]) VALUES (1037, N'New sandbox', N'reston, VA', CAST(0x07BEB21B6004FB380B AS DateTime2), CAST(0x078A8060D68F10390B AS DateTime2), 8, 1030, 0, 0, 1)
INSERT [dbo].[OrgUnits] ([Id], [Name], [Address], [CreationTime], [ModificationTime], [OwnerId], [ParentId], [Lat], [Lng], [WorkspaceTemplateId]) VALUES (1038, N'Chris Sandbox', N'Reston, VA', CAST(0x07108E321392FB380B AS DateTime2), CAST(0x07F10443A39D11390B AS DateTime2), 8, 1035, 0, 0, 1)
SET IDENTITY_INSERT [dbo].[OrgUnits] OFF
INSERT [dbo].[OrgUnitUserPermissions] ([OrgUnitId], [UserId], [PermissionLevelId]) VALUES (1027, 1, 1)
INSERT [dbo].[OrgUnitUserPermissions] ([OrgUnitId], [UserId], [PermissionLevelId]) VALUES (1027, 8, 1)
INSERT [dbo].[OrgUnitUserPermissions] ([OrgUnitId], [UserId], [PermissionLevelId]) VALUES (1028, 1, 1)
INSERT [dbo].[OrgUnitUserPermissions] ([OrgUnitId], [UserId], [PermissionLevelId]) VALUES (1029, 1, 1)
SET IDENTITY_INSERT [dbo].[PermissionLevels] ON 

INSERT [dbo].[PermissionLevels] ([Id], [Name]) VALUES (1, N'System Administrator')
INSERT [dbo].[PermissionLevels] ([Id], [Name]) VALUES (2, N'Workspace Administrator')
INSERT [dbo].[PermissionLevels] ([Id], [Name]) VALUES (3, N'Contributor')
INSERT [dbo].[PermissionLevels] ([Id], [Name]) VALUES (4, N'Approver')
INSERT [dbo].[PermissionLevels] ([Id], [Name]) VALUES (5, N'Browser')
SET IDENTITY_INSERT [dbo].[PermissionLevels] OFF
SET IDENTITY_INSERT [dbo].[Reports] ON 

INSERT [dbo].[Reports] ([Id], [Name], [Description], [CreatedById], [ModifiedById], [CreationTime], [ModificationTime], [ReportLayout], [DataSourceType]) VALUES (1, N'fdhgds', N'dsgsg', 1, 1, CAST(0x0700000000001A390B AS DateTime2), CAST(0x0700000000001A390B AS DateTime2), NULL, N'dfg')
INSERT [dbo].[Reports] ([Id], [Name], [Description], [CreatedById], [ModifiedById], [CreationTime], [ModificationTime], [ReportLayout], [DataSourceType]) VALUES (2, N'vasja', N'twetw', 1, 1, CAST(0x0773C0714BB319390B AS DateTime2), CAST(0x0773C0714BB319390B AS DateTime2), NULL, N'data')
SET IDENTITY_INSERT [dbo].[Reports] OFF
SET IDENTITY_INSERT [dbo].[SysEvents] ON 

INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20131, CAST(0x07B4562C1FA819390B AS DateTime2), N'/api/user/current 200 OK', N'Content-Type: application/json; charset=utf-8

{"id":1,"email":"mr.gusev.k@gmail.com","firstName":"Johnny","lastName":"Carson","lastAcitve":"2014-08-05T00:00:00","permissionLevelId":1}', 3, 1, N'7f2526b9-b930-4c16-a160-efff7e238e66')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20132, CAST(0x07AA55271FA819390B AS DateTime2), N'/api/user/current', N'ip: 95.153.189.172
Connection: Keep-Alive
Accept: application/json, text/plain, */*
Accept-Encoding: gzip, deflate, sdch
Accept-Language: ru-RU, ru; q=0.8, en-US; q=0.6, en; q=0.4, nb; q=0.2
Cookie: _session_id=8596914022d2a6778ac3ff4d82e008b1; connect.sid=s%3AKvEQ7f829RMfIIRpDARyaG7h_6MK3LSw.4HoLD2PlMRsp%2BoKxp65BfVYl6bysyZEqgwkBdH4LVlw; id=nqfxplMVmkY4JuUa0kI3VQ==; __AntiXsrfToken=4a3147d73e9840519734f7d149cf2183
Host: mycoopdev.cloudapp.net
Referer: http://localhost/admin/
User-Agent: Mozilla/5.0 (Macintosh; Intel Mac OS X 10_9_5) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.124 Safari/537.36
X-Forwarded-For: ::1
X-Forwarded-Host: localhost
X-Forwarded-Server: Kirills-MacBook-Pro.local
', 3, 1, N'7f2526b9-b930-4c16-a160-efff7e238e66')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20133, CAST(0x07C2787A0AB119390B AS DateTime2), N'/sign/in', N'ip: ::1
Cache-Control: no-cache
Connection: Keep-Alive
Accept: */*
Accept-Encoding: gzip, deflate
Accept-Language: ru, en-US; q=0.7, en; q=0.3
Cookie: id=nqfxplMVmkY4JuUa0kI3VQ==
Host: localhost:60564
Referer: http://localhost:60564/Clients/index.html
User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko
X-Requested-With: XMLHttpRequest
DNT: 1
', 3, 1, N'a4100184-99bb-4f87-92dc-e7fe54f5580c')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20134, CAST(0x0786F0D70BB119390B AS DateTime2), N'Success', N'Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko', 4, 1, N'a4100184-99bb-4f87-92dc-e7fe54f5580c')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20135, CAST(0x07DC03150CB119390B AS DateTime2), N'/sign/in 200 OK', N'Content-Type: application/json; charset=utf-8

{"id":1}', 3, 1, N'a4100184-99bb-4f87-92dc-e7fe54f5580c')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20136, CAST(0x078107DE0FB119390B AS DateTime2), N'/report', N'ip: ::1
Connection: Keep-Alive
Accept: */*
Accept-Encoding: gzip, deflate
Accept-Language: ru, en-US; q=0.7, en; q=0.3
Cookie: id=nqfxplMVmkY4JuUa0kI3VQ==
Host: localhost:60564
Referer: http://localhost:60564/Clients/index.html
User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko
X-Requested-With: XMLHttpRequest
DNT: 1
', 3, 1, N'c5c4174d-2bee-473f-a7fa-1cb1e87625bf')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20137, CAST(0x0756C9EB0FB119390B AS DateTime2), N'/report 200 OK', N'Content-Type: application/json; charset=utf-8

[]', 3, 1, N'c5c4174d-2bee-473f-a7fa-1cb1e87625bf')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20138, CAST(0x07436BAE12B119390B AS DateTime2), N'/report', N'ip: ::1
Cache-Control: no-cache
Connection: Keep-Alive
Accept: */*
Accept-Encoding: gzip, deflate
Accept-Language: ru, en-US; q=0.7, en; q=0.3
Cookie: id=nqfxplMVmkY4JuUa0kI3VQ==
Host: localhost:60564
Referer: http://localhost:60564/Clients/index.html
User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko
X-Requested-With: XMLHttpRequest
DNT: 1
', 3, 1, N'3d5d6229-741c-41d1-9b5f-e60b99b483e2')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20139, CAST(0x07024EB312B119390B AS DateTime2), N'Begin AddReport', N'{"Name":"vasja","Description":"twetw","CreatedBy":0,"ModifiedBy":0,"DataSourceType":"data"}', 2, 1, N'3d5d6229-741c-41d1-9b5f-e60b99b483e2')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20140, CAST(0x077E2D2413B119390B AS DateTime2), N'Api Exception', N'
---Unable to update the EntitySet ''Reports'' because it has a DefiningQuery and no <InsertFunction> element exists in the <ModificationFunctionMapping> element to support the current operation.---


---Unable to update the EntitySet ''Reports'' because it has a DefiningQuery and no <InsertFunction> element exists in the <ModificationFunctionMapping> element to support the current operation.---
   at System.Data.Entity.SqlServer.SqlGen.DmlSqlGenerator.ExpressionTranslator.Visit(DbScanExpression expression)
   at System.Data.Entity.Core.Common.CommandTrees.DbScanExpression.Accept(DbExpressionVisitor visitor)
   at System.Data.Entity.SqlServer.SqlGen.DmlSqlGenerator.GenerateInsertSql(DbInsertCommandTree tree, SqlGenerator sqlGenerator, List`1& parameters, Boolean generateReturningSql, Boolean upperCaseKeywords, Boolean createParameters)
   at System.Data.Entity.SqlServer.SqlGen.SqlGenerator.GenerateSql(DbCommandTree tree, SqlVersion sqlVersion, List`1& parameters, CommandType& commandType, HashSet`1& paramsToForceNonUnicode)
   at System.Data.Entity.SqlServer.SqlProviderServices.CreateCommand(DbProviderManifest providerManifest, DbCommandTree commandTree)
   at System.Data.Entity.SqlServer.SqlProviderServices.CreateDbCommandDefinition(DbProviderManifest providerManifest, DbCommandTree commandTree)
   at System.Data.Entity.Core.Common.DbProviderServices.CreateDbCommandDefinition(DbProviderManifest providerManifest, DbCommandTree commandTree, DbInterceptionContext interceptionContext)
   at System.Data.Entity.Core.Common.DbProviderServices.CreateCommandDefinition(DbCommandTree commandTree, DbInterceptionContext interceptionContext)
   at System.Data.Entity.Core.Common.DbProviderServices.CreateCommand(DbCommandTree commandTree, DbInterceptionContext interceptionContext)
   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.CreateCommand(DbModificationCommandTree commandTree)
   at System.Data.Entity.Core.Mapping.Update.Internal.DynamicUpdateCommand.CreateCommand(Dictionary`2 identifierValues)
   at System.Data.Entity.Core.Mapping.Update.Internal.DynamicUpdateCommand.<ExecuteAsync>d__0.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.<UpdateAsync>d__0.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Objects.ObjectContext.<ExecuteInTransactionAsync>d__3d`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesToStoreAsync>d__39.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.SqlServer.DefaultSqlExecutionStrategy.<ExecuteAsyncImplementation>d__9`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesInternalAsync>d__31.MoveNext()
', 1, 1, N'3d5d6229-741c-41d1-9b5f-e60b99b483e2')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20141, CAST(0x074E014F36B119390B AS DateTime2), N'/report', N'ip: ::1
Connection: Keep-Alive
Accept: */*
Accept-Encoding: gzip, deflate
Accept-Language: ru, en-US; q=0.7, en; q=0.3
Cookie: id=nqfxplMVmkY4JuUa0kI3VQ==
Host: localhost:60564
Referer: http://localhost:60564/Clients/index.html
User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko
X-Requested-With: XMLHttpRequest
DNT: 1
', 3, 1, N'59d1b053-fd73-4721-a277-296535f2ecf9')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20142, CAST(0x07FC470537B119390B AS DateTime2), N'/report 200 OK', N'Content-Type: application/json; charset=utf-8

[]', 3, 1, N'59d1b053-fd73-4721-a277-296535f2ecf9')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20143, CAST(0x07960E8A39B119390B AS DateTime2), N'/report', N'ip: ::1
Cache-Control: no-cache
Connection: Keep-Alive
Accept: */*
Accept-Encoding: gzip, deflate
Accept-Language: ru, en-US; q=0.7, en; q=0.3
Cookie: id=nqfxplMVmkY4JuUa0kI3VQ==
Host: localhost:60564
Referer: http://localhost:60564/Clients/index.html
User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko
X-Requested-With: XMLHttpRequest
DNT: 1
', 3, 1, N'f6784936-886e-44aa-8ba6-9607bf2a5a6d')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20144, CAST(0x0734208B39B119390B AS DateTime2), N'Begin AddReport', N'{"Name":"vasja","Description":"twetw","CreatedBy":0,"ModifiedBy":0,"DataSourceType":"data"}', 2, 1, N'f6784936-886e-44aa-8ba6-9607bf2a5a6d')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20145, CAST(0x070E50F839B119390B AS DateTime2), N'Api Exception', N'
---Unable to update the EntitySet ''Reports'' because it has a DefiningQuery and no <InsertFunction> element exists in the <ModificationFunctionMapping> element to support the current operation.---


---Unable to update the EntitySet ''Reports'' because it has a DefiningQuery and no <InsertFunction> element exists in the <ModificationFunctionMapping> element to support the current operation.---
   at System.Data.Entity.SqlServer.SqlGen.DmlSqlGenerator.ExpressionTranslator.Visit(DbScanExpression expression)
   at System.Data.Entity.Core.Common.CommandTrees.DbScanExpression.Accept(DbExpressionVisitor visitor)
   at System.Data.Entity.SqlServer.SqlGen.DmlSqlGenerator.GenerateInsertSql(DbInsertCommandTree tree, SqlGenerator sqlGenerator, List`1& parameters, Boolean generateReturningSql, Boolean upperCaseKeywords, Boolean createParameters)
   at System.Data.Entity.SqlServer.SqlGen.SqlGenerator.GenerateSql(DbCommandTree tree, SqlVersion sqlVersion, List`1& parameters, CommandType& commandType, HashSet`1& paramsToForceNonUnicode)
   at System.Data.Entity.SqlServer.SqlProviderServices.CreateCommand(DbProviderManifest providerManifest, DbCommandTree commandTree)
   at System.Data.Entity.SqlServer.SqlProviderServices.CreateDbCommandDefinition(DbProviderManifest providerManifest, DbCommandTree commandTree)
   at System.Data.Entity.Core.Common.DbProviderServices.CreateDbCommandDefinition(DbProviderManifest providerManifest, DbCommandTree commandTree, DbInterceptionContext interceptionContext)
   at System.Data.Entity.Core.Common.DbProviderServices.CreateCommandDefinition(DbCommandTree commandTree, DbInterceptionContext interceptionContext)
   at System.Data.Entity.Core.Common.DbProviderServices.CreateCommand(DbCommandTree commandTree, DbInterceptionContext interceptionContext)
   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.CreateCommand(DbModificationCommandTree commandTree)
   at System.Data.Entity.Core.Mapping.Update.Internal.DynamicUpdateCommand.CreateCommand(Dictionary`2 identifierValues)
   at System.Data.Entity.Core.Mapping.Update.Internal.DynamicUpdateCommand.<ExecuteAsync>d__0.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.<UpdateAsync>d__0.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Objects.ObjectContext.<ExecuteInTransactionAsync>d__3d`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesToStoreAsync>d__39.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.SqlServer.DefaultSqlExecutionStrategy.<ExecuteAsyncImplementation>d__9`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesInternalAsync>d__31.MoveNext()
', 1, 1, N'f6784936-886e-44aa-8ba6-9607bf2a5a6d')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20146, CAST(0x0760D22CD3B119390B AS DateTime2), N'/report', N'ip: ::1
Connection: Keep-Alive
Accept: */*
Accept-Encoding: gzip, deflate
Accept-Language: ru, en-US; q=0.7, en; q=0.3
Cookie: id=nqfxplMVmkY4JuUa0kI3VQ==
Host: localhost:60564
Referer: http://localhost:60564/Clients/index.html
User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko
X-Requested-With: XMLHttpRequest
DNT: 1
', 3, 1, N'fdaee842-db2e-4e8e-8b9d-1b76f1b7f0c4')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20147, CAST(0x07B7E2E5D3B119390B AS DateTime2), N'/report 200 OK', N'Content-Type: application/json; charset=utf-8

[]', 3, 1, N'fdaee842-db2e-4e8e-8b9d-1b76f1b7f0c4')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20148, CAST(0x07E2600AD7B119390B AS DateTime2), N'/report', N'ip: ::1
Cache-Control: no-cache
Connection: Keep-Alive
Accept: */*
Accept-Encoding: gzip, deflate
Accept-Language: ru, en-US; q=0.7, en; q=0.3
Cookie: id=nqfxplMVmkY4JuUa0kI3VQ==
Host: localhost:60564
Referer: http://localhost:60564/Clients/index.html
User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko
X-Requested-With: XMLHttpRequest
DNT: 1
', 3, 1, N'41b2c863-92e2-401b-b3ba-f61e9d6585af')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20149, CAST(0x079F990BD7B119390B AS DateTime2), N'Begin AddReport', N'{"Name":"vasja","Description":"twetw","CreatedBy":0,"ModifiedBy":0,"DataSourceType":"data"}', 2, 1, N'41b2c863-92e2-401b-b3ba-f61e9d6585af')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20150, CAST(0x0762D765D7B119390B AS DateTime2), N'Api Exception', N'
---Unable to update the EntitySet ''Reports'' because it has a DefiningQuery and no <InsertFunction> element exists in the <ModificationFunctionMapping> element to support the current operation.---


---Unable to update the EntitySet ''Reports'' because it has a DefiningQuery and no <InsertFunction> element exists in the <ModificationFunctionMapping> element to support the current operation.---
   at System.Data.Entity.SqlServer.SqlGen.DmlSqlGenerator.ExpressionTranslator.Visit(DbScanExpression expression)
   at System.Data.Entity.Core.Common.CommandTrees.DbScanExpression.Accept(DbExpressionVisitor visitor)
   at System.Data.Entity.SqlServer.SqlGen.DmlSqlGenerator.GenerateInsertSql(DbInsertCommandTree tree, SqlGenerator sqlGenerator, List`1& parameters, Boolean generateReturningSql, Boolean upperCaseKeywords, Boolean createParameters)
   at System.Data.Entity.SqlServer.SqlGen.SqlGenerator.GenerateSql(DbCommandTree tree, SqlVersion sqlVersion, List`1& parameters, CommandType& commandType, HashSet`1& paramsToForceNonUnicode)
   at System.Data.Entity.SqlServer.SqlProviderServices.CreateCommand(DbProviderManifest providerManifest, DbCommandTree commandTree)
   at System.Data.Entity.SqlServer.SqlProviderServices.CreateDbCommandDefinition(DbProviderManifest providerManifest, DbCommandTree commandTree)
   at System.Data.Entity.Core.Common.DbProviderServices.CreateDbCommandDefinition(DbProviderManifest providerManifest, DbCommandTree commandTree, DbInterceptionContext interceptionContext)
   at System.Data.Entity.Core.Common.DbProviderServices.CreateCommandDefinition(DbCommandTree commandTree, DbInterceptionContext interceptionContext)
   at System.Data.Entity.Core.Common.DbProviderServices.CreateCommand(DbCommandTree commandTree, DbInterceptionContext interceptionContext)
   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.CreateCommand(DbModificationCommandTree commandTree)
   at System.Data.Entity.Core.Mapping.Update.Internal.DynamicUpdateCommand.CreateCommand(Dictionary`2 identifierValues)
   at System.Data.Entity.Core.Mapping.Update.Internal.DynamicUpdateCommand.<ExecuteAsync>d__0.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.<UpdateAsync>d__0.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Objects.ObjectContext.<ExecuteInTransactionAsync>d__3d`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesToStoreAsync>d__39.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.SqlServer.DefaultSqlExecutionStrategy.<ExecuteAsyncImplementation>d__9`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesInternalAsync>d__31.MoveNext()
', 1, 1, N'41b2c863-92e2-401b-b3ba-f61e9d6585af')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20151, CAST(0x074CC52AFCB119390B AS DateTime2), N'/report', N'ip: ::1
Connection: Keep-Alive
Accept: */*
Accept-Encoding: gzip, deflate
Accept-Language: ru, en-US; q=0.7, en; q=0.3
Cookie: id=nqfxplMVmkY4JuUa0kI3VQ==
Host: localhost:60564
Referer: http://localhost:60564/Clients/index.html
User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko
X-Requested-With: XMLHttpRequest
DNT: 1
', 3, 1, N'76a618b4-e7b5-4768-8c62-726f78c709dd')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20152, CAST(0x0770E834FDB119390B AS DateTime2), N'/report 200 OK', N'Content-Type: application/json; charset=utf-8

[{"id":1,"name":"fdhgds","description":"dsgsg","creationTime":"2014-10-09T00:00:00","modificationTime":"2014-10-09T00:00:00","createdBy":{"id":1,"firstName":"Johnny","lastName":"Carson"},"modifiedBy":{"id":1,"firstName":"Johnny","lastName":"Carson"},"dataSourceType":"dfg"}]', 3, 1, N'76a618b4-e7b5-4768-8c62-726f78c709dd')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20153, CAST(0x076A276105B219390B AS DateTime2), N'/report', N'ip: ::1
Cache-Control: no-cache
Connection: Keep-Alive
Accept: */*
Accept-Encoding: gzip, deflate
Accept-Language: ru, en-US; q=0.7, en; q=0.3
Cookie: id=nqfxplMVmkY4JuUa0kI3VQ==
Host: localhost:60564
Referer: http://localhost:60564/Clients/index.html
User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko
X-Requested-With: XMLHttpRequest
DNT: 1
', 3, 1, N'ea2a9c41-32a7-4ae5-9168-a89268581b5c')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20154, CAST(0x0724606205B219390B AS DateTime2), N'Begin AddReport', N'{"Name":"vasja","Description":"twetw","CreatedBy":0,"ModifiedBy":0,"DataSourceType":"data"}', 2, 1, N'ea2a9c41-32a7-4ae5-9168-a89268581b5c')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20155, CAST(0x079D12BD05B219390B AS DateTime2), N'Api Exception', N'
---Unable to update the EntitySet ''Reports'' because it has a DefiningQuery and no <InsertFunction> element exists in the <ModificationFunctionMapping> element to support the current operation.---


---Unable to update the EntitySet ''Reports'' because it has a DefiningQuery and no <InsertFunction> element exists in the <ModificationFunctionMapping> element to support the current operation.---
   at System.Data.Entity.SqlServer.SqlGen.DmlSqlGenerator.ExpressionTranslator.Visit(DbScanExpression expression)
   at System.Data.Entity.Core.Common.CommandTrees.DbScanExpression.Accept(DbExpressionVisitor visitor)
   at System.Data.Entity.SqlServer.SqlGen.DmlSqlGenerator.GenerateInsertSql(DbInsertCommandTree tree, SqlGenerator sqlGenerator, List`1& parameters, Boolean generateReturningSql, Boolean upperCaseKeywords, Boolean createParameters)
   at System.Data.Entity.SqlServer.SqlGen.SqlGenerator.GenerateSql(DbCommandTree tree, SqlVersion sqlVersion, List`1& parameters, CommandType& commandType, HashSet`1& paramsToForceNonUnicode)
   at System.Data.Entity.SqlServer.SqlProviderServices.CreateCommand(DbProviderManifest providerManifest, DbCommandTree commandTree)
   at System.Data.Entity.SqlServer.SqlProviderServices.CreateDbCommandDefinition(DbProviderManifest providerManifest, DbCommandTree commandTree)
   at System.Data.Entity.Core.Common.DbProviderServices.CreateDbCommandDefinition(DbProviderManifest providerManifest, DbCommandTree commandTree, DbInterceptionContext interceptionContext)
   at System.Data.Entity.Core.Common.DbProviderServices.CreateCommandDefinition(DbCommandTree commandTree, DbInterceptionContext interceptionContext)
   at System.Data.Entity.Core.Common.DbProviderServices.CreateCommand(DbCommandTree commandTree, DbInterceptionContext interceptionContext)
   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.CreateCommand(DbModificationCommandTree commandTree)
   at System.Data.Entity.Core.Mapping.Update.Internal.DynamicUpdateCommand.CreateCommand(Dictionary`2 identifierValues)
   at System.Data.Entity.Core.Mapping.Update.Internal.DynamicUpdateCommand.<ExecuteAsync>d__0.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.<UpdateAsync>d__0.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Objects.ObjectContext.<ExecuteInTransactionAsync>d__3d`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesToStoreAsync>d__39.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.SqlServer.DefaultSqlExecutionStrategy.<ExecuteAsyncImplementation>d__9`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesInternalAsync>d__31.MoveNext()
', 1, 1, N'ea2a9c41-32a7-4ae5-9168-a89268581b5c')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20156, CAST(0x0727291F18B219390B AS DateTime2), N'Begin AddReport', N'{"Name":"vasja","Description":"twetw","CreatedBy":0,"ModifiedBy":0,"DataSourceType":"data"}', 2, 1, N'f88db977-2c40-4549-8e6e-879a5b7e6193')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20157, CAST(0x070C021F18B219390B AS DateTime2), N'/report', N'ip: ::1
Cache-Control: no-cache
Connection: Keep-Alive
Accept: */*
Accept-Encoding: gzip, deflate
Accept-Language: ru, en-US; q=0.7, en; q=0.3
Cookie: id=nqfxplMVmkY4JuUa0kI3VQ==
Host: localhost:60564
Referer: http://localhost:60564/Clients/index.html
User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko
X-Requested-With: XMLHttpRequest
DNT: 1
', 3, 1, N'f88db977-2c40-4549-8e6e-879a5b7e6193')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20158, CAST(0x07DF289037B219390B AS DateTime2), N'Api Exception', N'
---Unable to update the EntitySet ''Reports'' because it has a DefiningQuery and no <InsertFunction> element exists in the <ModificationFunctionMapping> element to support the current operation.---


---Unable to update the EntitySet ''Reports'' because it has a DefiningQuery and no <InsertFunction> element exists in the <ModificationFunctionMapping> element to support the current operation.---
   at System.Data.Entity.SqlServer.SqlGen.DmlSqlGenerator.ExpressionTranslator.Visit(DbScanExpression expression)
   at System.Data.Entity.Core.Common.CommandTrees.DbScanExpression.Accept(DbExpressionVisitor visitor)
   at System.Data.Entity.SqlServer.SqlGen.DmlSqlGenerator.GenerateInsertSql(DbInsertCommandTree tree, SqlGenerator sqlGenerator, List`1& parameters, Boolean generateReturningSql, Boolean upperCaseKeywords, Boolean createParameters)
   at System.Data.Entity.SqlServer.SqlGen.SqlGenerator.GenerateSql(DbCommandTree tree, SqlVersion sqlVersion, List`1& parameters, CommandType& commandType, HashSet`1& paramsToForceNonUnicode)
   at System.Data.Entity.SqlServer.SqlProviderServices.CreateCommand(DbProviderManifest providerManifest, DbCommandTree commandTree)
   at System.Data.Entity.SqlServer.SqlProviderServices.CreateDbCommandDefinition(DbProviderManifest providerManifest, DbCommandTree commandTree)
   at System.Data.Entity.Core.Common.DbProviderServices.CreateDbCommandDefinition(DbProviderManifest providerManifest, DbCommandTree commandTree, DbInterceptionContext interceptionContext)
   at System.Data.Entity.Core.Common.DbProviderServices.CreateCommandDefinition(DbCommandTree commandTree, DbInterceptionContext interceptionContext)
   at System.Data.Entity.Core.Common.DbProviderServices.CreateCommand(DbCommandTree commandTree, DbInterceptionContext interceptionContext)
   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.CreateCommand(DbModificationCommandTree commandTree)
   at System.Data.Entity.Core.Mapping.Update.Internal.DynamicUpdateCommand.CreateCommand(Dictionary`2 identifierValues)
   at System.Data.Entity.Core.Mapping.Update.Internal.DynamicUpdateCommand.<ExecuteAsync>d__0.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.<UpdateAsync>d__0.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Objects.ObjectContext.<ExecuteInTransactionAsync>d__3d`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesToStoreAsync>d__39.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.SqlServer.DefaultSqlExecutionStrategy.<ExecuteAsyncImplementation>d__9`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesInternalAsync>d__31.MoveNext()
', 1, 1, N'f88db977-2c40-4549-8e6e-879a5b7e6193')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20159, CAST(0x07B1A06F4BB219390B AS DateTime2), N'/report/1', N'ip: ::1
Cache-Control: no-cache
Connection: Keep-Alive
Accept: */*
Accept-Encoding: gzip, deflate
Accept-Language: ru, en-US; q=0.7, en; q=0.3
Cookie: id=nqfxplMVmkY4JuUa0kI3VQ==
Host: localhost:60564
Referer: http://localhost:60564/Clients/index.html
User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko
X-Requested-With: XMLHttpRequest
DNT: 1
', 3, 1, N'e8dc16ce-7f9a-441c-90df-f155eaf036cf')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20160, CAST(0x07E415704BB219390B AS DateTime2), N'Begin DeleteReport Id: 1', N'', 2, 1, N'e8dc16ce-7f9a-441c-90df-f155eaf036cf')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20161, CAST(0x07D839CD4BB219390B AS DateTime2), N'Api Exception', N'
---Unable to update the EntitySet ''Reports'' because it has a DefiningQuery and no <DeleteFunction> element exists in the <ModificationFunctionMapping> element to support the current operation.---


---Unable to update the EntitySet ''Reports'' because it has a DefiningQuery and no <DeleteFunction> element exists in the <ModificationFunctionMapping> element to support the current operation.---
   at System.Data.Entity.SqlServer.SqlGen.DmlSqlGenerator.ExpressionTranslator.Visit(DbScanExpression expression)
   at System.Data.Entity.Core.Common.CommandTrees.DbScanExpression.Accept(DbExpressionVisitor visitor)
   at System.Data.Entity.SqlServer.SqlGen.DmlSqlGenerator.GenerateDeleteSql(DbDeleteCommandTree tree, SqlGenerator sqlGenerator, List`1& parameters, Boolean upperCaseKeywords, Boolean createParameters)
   at System.Data.Entity.SqlServer.SqlGen.SqlGenerator.GenerateSql(DbCommandTree tree, SqlVersion sqlVersion, List`1& parameters, CommandType& commandType, HashSet`1& paramsToForceNonUnicode)
   at System.Data.Entity.SqlServer.SqlProviderServices.CreateCommand(DbProviderManifest providerManifest, DbCommandTree commandTree)
   at System.Data.Entity.SqlServer.SqlProviderServices.CreateDbCommandDefinition(DbProviderManifest providerManifest, DbCommandTree commandTree)
   at System.Data.Entity.Core.Common.DbProviderServices.CreateDbCommandDefinition(DbProviderManifest providerManifest, DbCommandTree commandTree, DbInterceptionContext interceptionContext)
   at System.Data.Entity.Core.Common.DbProviderServices.CreateCommandDefinition(DbCommandTree commandTree, DbInterceptionContext interceptionContext)
   at System.Data.Entity.Core.Common.DbProviderServices.CreateCommand(DbCommandTree commandTree, DbInterceptionContext interceptionContext)
   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.CreateCommand(DbModificationCommandTree commandTree)
   at System.Data.Entity.Core.Mapping.Update.Internal.DynamicUpdateCommand.CreateCommand(Dictionary`2 identifierValues)
   at System.Data.Entity.Core.Mapping.Update.Internal.DynamicUpdateCommand.<ExecuteAsync>d__0.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.<UpdateAsync>d__0.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Objects.ObjectContext.<ExecuteInTransactionAsync>d__3d`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesToStoreAsync>d__39.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.SqlServer.DefaultSqlExecutionStrategy.<ExecuteAsyncImplementation>d__9`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesInternalAsync>d__31.MoveNext()
', 1, 1, N'e8dc16ce-7f9a-441c-90df-f155eaf036cf')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20162, CAST(0x07B8D81AAAB219390B AS DateTime2), N'/incident', N'ip: ::1
Cache-Control: no-cache
Connection: Keep-Alive
Accept: */*
Accept-Encoding: gzip, deflate
Accept-Language: ru, en-US; q=0.7, en; q=0.3
Cookie: id=nqfxplMVmkY4JuUa0kI3VQ==
Host: localhost:60564
Referer: http://localhost:60564/Clients/index.html
User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko
X-Requested-With: XMLHttpRequest
DNT: 1
', 3, 1, N'0bb29d85-5991-4def-818d-38539932b6d5')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20163, CAST(0x07B8D81AAAB219390B AS DateTime2), N'Begin AddIncident', N'{"Name":"vasja","Location":{"Lat":77.55,"Lng":5.2,"Address":"qwrqw"},"Type":1,"Priority":1,"FacilityType":1,"StartTime":"\/Date(-62135596800000)\/","Duration":100000,"Description":"twetw"}', 2, 1, N'0bb29d85-5991-4def-818d-38539932b6d5')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20164, CAST(0x0777B616ABB219390B AS DateTime2), N'End AddIncident Id: 6', N'', 2, 1, N'0bb29d85-5991-4def-818d-38539932b6d5')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20165, CAST(0x073AA927ABB219390B AS DateTime2), N'/incident 200 OK', N'Content-Type: application/json; charset=utf-8

{"id":6}', 3, 1, N'0bb29d85-5991-4def-818d-38539932b6d5')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20166, CAST(0x07ACE3B1B1B219390B AS DateTime2), N'/report', N'ip: ::1
Connection: Keep-Alive
Accept: */*
Accept-Encoding: gzip, deflate
Accept-Language: ru, en-US; q=0.7, en; q=0.3
Cookie: id=nqfxplMVmkY4JuUa0kI3VQ==
Host: localhost:60564
Referer: http://localhost:60564/Clients/index.html
User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko
X-Requested-With: XMLHttpRequest
DNT: 1
', 3, 1, N'cba55ed2-cd60-48d7-801f-1e425f1269c4')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20167, CAST(0x074AB905B2B219390B AS DateTime2), N'/report 200 OK', N'Content-Type: application/json; charset=utf-8

[{"id":1,"name":"fdhgds","description":"dsgsg","creationTime":"2014-10-09T00:00:00","modificationTime":"2014-10-09T00:00:00","createdBy":{"id":1,"firstName":"Johnny","lastName":"Carson"},"modifiedBy":{"id":1,"firstName":"Johnny","lastName":"Carson"},"dataSourceType":"dfg"}]', 3, 1, N'cba55ed2-cd60-48d7-801f-1e425f1269c4')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20168, CAST(0x07FC4CC6BAB219390B AS DateTime2), N'/report/1', N'ip: ::1
Cache-Control: no-cache
Connection: Keep-Alive
Accept: */*
Accept-Encoding: gzip, deflate
Accept-Language: ru, en-US; q=0.7, en; q=0.3
Cookie: id=nqfxplMVmkY4JuUa0kI3VQ==
Host: localhost:60564
Referer: http://localhost:60564/Clients/index.html
User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko
X-Requested-With: XMLHttpRequest
DNT: 1
', 3, 1, N'3dc1813e-2841-497b-8b0c-4e35e813969a')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20169, CAST(0x0740C2C6BAB219390B AS DateTime2), N'Begin DeleteReport Id: 1', N'', 2, 1, N'3dc1813e-2841-497b-8b0c-4e35e813969a')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20170, CAST(0x07C6ED1FBBB219390B AS DateTime2), N'Api Exception', N'
---Unable to update the EntitySet ''Reports'' because it has a DefiningQuery and no <DeleteFunction> element exists in the <ModificationFunctionMapping> element to support the current operation.---


---Unable to update the EntitySet ''Reports'' because it has a DefiningQuery and no <DeleteFunction> element exists in the <ModificationFunctionMapping> element to support the current operation.---
   at System.Data.Entity.SqlServer.SqlGen.DmlSqlGenerator.ExpressionTranslator.Visit(DbScanExpression expression)
   at System.Data.Entity.Core.Common.CommandTrees.DbScanExpression.Accept(DbExpressionVisitor visitor)
   at System.Data.Entity.SqlServer.SqlGen.DmlSqlGenerator.GenerateDeleteSql(DbDeleteCommandTree tree, SqlGenerator sqlGenerator, List`1& parameters, Boolean upperCaseKeywords, Boolean createParameters)
   at System.Data.Entity.SqlServer.SqlGen.SqlGenerator.GenerateSql(DbCommandTree tree, SqlVersion sqlVersion, List`1& parameters, CommandType& commandType, HashSet`1& paramsToForceNonUnicode)
   at System.Data.Entity.SqlServer.SqlProviderServices.CreateCommand(DbProviderManifest providerManifest, DbCommandTree commandTree)
   at System.Data.Entity.SqlServer.SqlProviderServices.CreateDbCommandDefinition(DbProviderManifest providerManifest, DbCommandTree commandTree)
   at System.Data.Entity.Core.Common.DbProviderServices.CreateDbCommandDefinition(DbProviderManifest providerManifest, DbCommandTree commandTree, DbInterceptionContext interceptionContext)
   at System.Data.Entity.Core.Common.DbProviderServices.CreateCommandDefinition(DbCommandTree commandTree, DbInterceptionContext interceptionContext)
   at System.Data.Entity.Core.Common.DbProviderServices.CreateCommand(DbCommandTree commandTree, DbInterceptionContext interceptionContext)
   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.CreateCommand(DbModificationCommandTree commandTree)
   at System.Data.Entity.Core.Mapping.Update.Internal.DynamicUpdateCommand.CreateCommand(Dictionary`2 identifierValues)
   at System.Data.Entity.Core.Mapping.Update.Internal.DynamicUpdateCommand.<ExecuteAsync>d__0.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.<UpdateAsync>d__0.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Objects.ObjectContext.<ExecuteInTransactionAsync>d__3d`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesToStoreAsync>d__39.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.SqlServer.DefaultSqlExecutionStrategy.<ExecuteAsyncImplementation>d__9`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesInternalAsync>d__31.MoveNext()
', 1, 1, N'3dc1813e-2841-497b-8b0c-4e35e813969a')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20171, CAST(0x07CEF5884BB319390B AS DateTime2), N'Begin AddReport', N'{"Name":"vasja","Description":"twetw","CreatedBy":0,"ModifiedBy":0,"DataSourceType":"data"}', 2, 1, N'f325aac0-e713-4b12-b440-0a825bf87eff')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20172, CAST(0x07CEF5884BB319390B AS DateTime2), N'/report', N'ip: ::1
Cache-Control: no-cache
Connection: Keep-Alive
Accept: */*
Accept-Encoding: gzip, deflate
Accept-Language: ru, en-US; q=0.7, en; q=0.3
Cookie: id=nqfxplMVmkY4JuUa0kI3VQ==
Host: localhost:60564
Referer: http://localhost:60564/Clients/index.html
User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko
X-Requested-With: XMLHttpRequest
DNT: 1
', 3, 1, N'f325aac0-e713-4b12-b440-0a825bf87eff')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20173, CAST(0x07AA8F2D4CB319390B AS DateTime2), N'End AddReport Id: 2', N'', 2, 1, N'f325aac0-e713-4b12-b440-0a825bf87eff')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20174, CAST(0x079EA93E4CB319390B AS DateTime2), N'/report 200 OK', N'Content-Type: application/json; charset=utf-8

{"id":2}', 3, 1, N'f325aac0-e713-4b12-b440-0a825bf87eff')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20175, CAST(0x076C205B4DB319390B AS DateTime2), N'Begin AddReport', N'{"Name":"vasja","Description":"twetw","CreatedBy":0,"ModifiedBy":0,"DataSourceType":"data"}', 2, 1, N'0af94ed0-183d-4b08-8cd8-ea7ad2cc1384')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20176, CAST(0x076C205B4DB319390B AS DateTime2), N'/report', N'ip: ::1
Cache-Control: no-cache
Connection: Keep-Alive
Accept: */*
Accept-Encoding: gzip, deflate
Accept-Language: ru, en-US; q=0.7, en; q=0.3
Cookie: id=nqfxplMVmkY4JuUa0kI3VQ==
Host: localhost:60564
Referer: http://localhost:60564/Clients/index.html
User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko
X-Requested-With: XMLHttpRequest
DNT: 1
', 3, 1, N'0af94ed0-183d-4b08-8cd8-ea7ad2cc1384')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20177, CAST(0x07DDE35B4DB319390B AS DateTime2), N'End AddReport Id: 3', N'', 2, 1, N'0af94ed0-183d-4b08-8cd8-ea7ad2cc1384')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20178, CAST(0x07090B5C4DB319390B AS DateTime2), N'/report 200 OK', N'Content-Type: application/json; charset=utf-8

{"id":3}', 3, 1, N'0af94ed0-183d-4b08-8cd8-ea7ad2cc1384')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20179, CAST(0x077818F950B319390B AS DateTime2), N'/report/3', N'ip: ::1
Cache-Control: no-cache
Connection: Keep-Alive
Accept: */*
Accept-Encoding: gzip, deflate
Accept-Language: ru, en-US; q=0.7, en; q=0.3
Cookie: id=nqfxplMVmkY4JuUa0kI3VQ==
Host: localhost:60564
Referer: http://localhost:60564/Clients/index.html
User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko
X-Requested-With: XMLHttpRequest
DNT: 1
', 3, 1, N'b928b8aa-9cec-4ebb-b8bf-b87e9c583c30')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20180, CAST(0x07B38DF950B319390B AS DateTime2), N'Begin DeleteReport Id: 3', N'', 2, 1, N'b928b8aa-9cec-4ebb-b8bf-b87e9c583c30')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20181, CAST(0x07AF1D5B51B319390B AS DateTime2), N'End DeleteReport Id: 3', N'', 2, 1, N'b928b8aa-9cec-4ebb-b8bf-b87e9c583c30')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20182, CAST(0x07C6445B51B319390B AS DateTime2), N'/report/3 200 OK', N'', 3, 1, N'b928b8aa-9cec-4ebb-b8bf-b87e9c583c30')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20183, CAST(0x07BC365F53B319390B AS DateTime2), N'/report', N'ip: ::1
Connection: Keep-Alive
Accept: */*
Accept-Encoding: gzip, deflate
Accept-Language: ru, en-US; q=0.7, en; q=0.3
Cookie: id=nqfxplMVmkY4JuUa0kI3VQ==
Host: localhost:60564
Referer: http://localhost:60564/Clients/index.html
User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko
X-Requested-With: XMLHttpRequest
DNT: 1
', 3, 1, N'15da88f2-7695-4bb8-891d-e767c788fb67')
INSERT [dbo].[SysEvents] ([Id], [Time], [Summary], [Description], [Type], [UserId], [TransactionId]) VALUES (20184, CAST(0x0782E17653B319390B AS DateTime2), N'/report 200 OK', N'Content-Type: application/json; charset=utf-8

[{"id":1,"name":"fdhgds","description":"dsgsg","creationTime":"2014-10-09T00:00:00","modificationTime":"2014-10-09T00:00:00","createdBy":{"id":1,"firstName":"Johnny","lastName":"Carson"},"modifiedBy":{"id":1,"firstName":"Johnny","lastName":"Carson"},"dataSourceType":"dfg"},{"id":2,"name":"vasja","description":"twetw","creationTime":"2014-10-08T21:23:26.4892019","modificationTime":"2014-10-08T21:23:26.4892019","createdBy":{"id":1,"firstName":"Johnny","lastName":"Carson"},"modifiedBy":{"id":1,"firstName":"Johnny","lastName":"Carson"},"dataSourceType":"data"}]', 3, 1, N'15da88f2-7695-4bb8-891d-e767c788fb67')
SET IDENTITY_INSERT [dbo].[SysEvents] OFF
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreationTime]) VALUES (1, 4, CAST(0x077E079D945EDA380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreationTime]) VALUES (1, 5, CAST(0x07384219B192DA380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreationTime]) VALUES (1, 7, CAST(0x07CE5E8F908EDB380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreationTime]) VALUES (7, 5, CAST(0x075163BA4396DB380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreationTime]) VALUES (8, 4, CAST(0x073CC9454A6FDA380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreationTime]) VALUES (8, 7, CAST(0x07F043C8768BDB380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreationTime]) VALUES (9, 4, CAST(0x07CB3B44EC2913390B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreationTime]) VALUES (10, 4, CAST(0x07D622C1FC2913390B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreationTime]) VALUES (11, 4, CAST(0x07585106FEA4DB380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreationTime]) VALUES (12, 4, CAST(0x077BC95E79A8DB380B AS DateTime2))
INSERT [dbo].[UserGroups] ([UserId], [GroupId], [CreationTime]) VALUES (12, 7, CAST(0x0769A25E79A8DB380B AS DateTime2))
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (1, N'tomamiller@gmail.com', N'Johnny', N'Carson', N'0ad0c86f73998b52a047127cff79d27e', 1, 1, CAST(0x070000000000D9380B AS DateTime2))
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (7, N'testuser@testuser.com', N'Tammy', N'Blooms', N'1e5e87bd07d5f42098176c65b1104855', 0, 1, CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (8, N'tmiller@google.com', N'Tom', N'Miller', N'95efb63a9bb3fec658354a879b34501b', 0, 1, CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (9, N'mycoopdev@gmail.com', N'James', N'Smith', N'202400f12056bfa3117fce28d79a23d4', 0, 3, CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (10, N'jcoop@google.com', N'James', N'Cahit', N'977aab2f2dca35f5b4161ba930f173e9', 0, 3, CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (11, N'jcash@google.com', N'Johnny', N'Cash', N'e88a17b2fb4c317a0ce295f44356a92a', 0, 3, CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (12, N'jw@google.com', N'Wishbone', N'Johnson', N'325a3d5566f9c90c0c8e3c84f495500c', 0, 1, CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Password], [TypeId], [PermissionLevelId], [LastAcitve]) VALUES (13, N'test@test.com', N'Tester', N'Data', N'e5ce8c46df27f2fe00ae50883f14b397', 0, 2, CAST(0x070000000000000000 AS DateTime2))
SET IDENTITY_INSERT [dbo].[Users] OFF
INSERT [dbo].[WorkspaceDocumentTemplates] ([WorkspaceTemplateId], [DocumentTemplateId], [CreationTime]) VALUES (1, 13, CAST(0x0753F1150845EE380B AS DateTime2))
INSERT [dbo].[WorkspaceDocumentTemplates] ([WorkspaceTemplateId], [DocumentTemplateId], [CreationTime]) VALUES (1, 15, CAST(0x07DF13180845EE380B AS DateTime2))
INSERT [dbo].[WorkspaceDocumentTemplates] ([WorkspaceTemplateId], [DocumentTemplateId], [CreationTime]) VALUES (1, 16, CAST(0x07A6E8190845EE380B AS DateTime2))
INSERT [dbo].[WorkspaceDocumentTemplates] ([WorkspaceTemplateId], [DocumentTemplateId], [CreationTime]) VALUES (2, 13, CAST(0x072717340C45EE380B AS DateTime2))
INSERT [dbo].[WorkspaceDocumentTemplates] ([WorkspaceTemplateId], [DocumentTemplateId], [CreationTime]) VALUES (2, 15, CAST(0x072717340C45EE380B AS DateTime2))
INSERT [dbo].[WorkspaceDocumentTemplates] ([WorkspaceTemplateId], [DocumentTemplateId], [CreationTime]) VALUES (3, 13, CAST(0x0725E5891245EE380B AS DateTime2))
INSERT [dbo].[WorkspaceDocumentTemplates] ([WorkspaceTemplateId], [DocumentTemplateId], [CreationTime]) VALUES (3, 14, CAST(0x07E7BFA5C82D13390B AS DateTime2))
INSERT [dbo].[WorkspaceDocumentTemplates] ([WorkspaceTemplateId], [DocumentTemplateId], [CreationTime]) VALUES (3, 15, CAST(0x071B25ACC82D13390B AS DateTime2))
INSERT [dbo].[WorkspaceDocumentTemplates] ([WorkspaceTemplateId], [DocumentTemplateId], [CreationTime]) VALUES (3, 16, CAST(0x076610881245EE380B AS DateTime2))
SET IDENTITY_INSERT [dbo].[WorkspaceTemplates] ON 

INSERT [dbo].[WorkspaceTemplates] ([Id], [Name], [CreationTime], [ModificationTime], [CreatedByUserId], [ModifiedByUserId]) VALUES (1, N'Sample workspace template', CAST(0x070000000000E5380B AS DateTime2), CAST(0x0779CFC40745EE380B AS DateTime2), 1, 1)
INSERT [dbo].[WorkspaceTemplates] ([Id], [Name], [CreationTime], [ModificationTime], [CreatedByUserId], [ModifiedByUserId]) VALUES (2, N'Test workspace template', CAST(0x072312A39F9FE5380B AS DateTime2), CAST(0x07A3ADFE0B45EE380B AS DateTime2), 1, 1)
INSERT [dbo].[WorkspaceTemplates] ([Id], [Name], [CreationTime], [ModificationTime], [CreatedByUserId], [ModifiedByUserId]) VALUES (3, N'Sample workspace 23', CAST(0x07B2C07DBA00E8380B AS DateTime2), CAST(0x07BC0F3EC82D13390B AS DateTime2), 1, 8)
SET IDENTITY_INSERT [dbo].[WorkspaceTemplates] OFF
ALTER TABLE [dbo].[AttributeBusinessProcesses]  WITH CHECK ADD  CONSTRAINT [FK_AttributeBusinessProcesses_BusinessProcessAttributes] FOREIGN KEY([AttributeId])
REFERENCES [dbo].[BusinessProcessAttributes] ([Id])
GO
ALTER TABLE [dbo].[AttributeBusinessProcesses] CHECK CONSTRAINT [FK_AttributeBusinessProcesses_BusinessProcessAttributes]
GO
ALTER TABLE [dbo].[AttributeBusinessProcesses]  WITH CHECK ADD  CONSTRAINT [FK_AttributeBusinessProcesses_BusinessProcesses] FOREIGN KEY([BusinessProcessId])
REFERENCES [dbo].[BusinessProcesses] ([Id])
GO
ALTER TABLE [dbo].[AttributeBusinessProcesses] CHECK CONSTRAINT [FK_AttributeBusinessProcesses_BusinessProcesses]
GO
ALTER TABLE [dbo].[BusinessProcessAttributes]  WITH CHECK ADD  CONSTRAINT [FK_BusinessProcessAttributes_AttributeTypes] FOREIGN KEY([AttributeTypeId])
REFERENCES [dbo].[AttributeTypes] ([Id])
GO
ALTER TABLE [dbo].[BusinessProcessAttributes] CHECK CONSTRAINT [FK_BusinessProcessAttributes_AttributeTypes]
GO
ALTER TABLE [dbo].[BusinessProcesses]  WITH CHECK ADD  CONSTRAINT [FK_BusinessProcesses_OrgUnits] FOREIGN KEY([OrgUnitId])
REFERENCES [dbo].[OrgUnits] ([Id])
GO
ALTER TABLE [dbo].[BusinessProcesses] CHECK CONSTRAINT [FK_BusinessProcesses_OrgUnits]
GO
ALTER TABLE [dbo].[DocumentTemplates]  WITH CHECK ADD  CONSTRAINT [FK_DocumentTemplates_Components] FOREIGN KEY([ComponentId])
REFERENCES [dbo].[Components] ([Id])
GO
ALTER TABLE [dbo].[DocumentTemplates] CHECK CONSTRAINT [FK_DocumentTemplates_Components]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Users] FOREIGN KEY([ModifiedByUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Users]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Users1] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Users1]
GO
ALTER TABLE [dbo].[IncidentOrgUnits]  WITH CHECK ADD  CONSTRAINT [FK_IncidentOrgUnits_Incidents] FOREIGN KEY([IncidentId])
REFERENCES [dbo].[Incidents] ([Id])
GO
ALTER TABLE [dbo].[IncidentOrgUnits] CHECK CONSTRAINT [FK_IncidentOrgUnits_Incidents]
GO
ALTER TABLE [dbo].[IncidentOrgUnits]  WITH CHECK ADD  CONSTRAINT [FK_IncidentOrgUnits_OrgUnits] FOREIGN KEY([OrgUnitId])
REFERENCES [dbo].[OrgUnits] ([Id])
GO
ALTER TABLE [dbo].[IncidentOrgUnits] CHECK CONSTRAINT [FK_IncidentOrgUnits_OrgUnits]
GO
ALTER TABLE [dbo].[IncidentUsers]  WITH CHECK ADD  CONSTRAINT [FK_IncidentUsers_Incidents] FOREIGN KEY([IncidentId])
REFERENCES [dbo].[Incidents] ([Id])
GO
ALTER TABLE [dbo].[IncidentUsers] CHECK CONSTRAINT [FK_IncidentUsers_Incidents]
GO
ALTER TABLE [dbo].[IncidentUsers]  WITH CHECK ADD  CONSTRAINT [FK_IncidentUsers_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[IncidentUsers] CHECK CONSTRAINT [FK_IncidentUsers_Users]
GO
ALTER TABLE [dbo].[OrgUnitGroupPermissions]  WITH CHECK ADD  CONSTRAINT [FK_OrgUnitGroupPermissions_Groups] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO
ALTER TABLE [dbo].[OrgUnitGroupPermissions] CHECK CONSTRAINT [FK_OrgUnitGroupPermissions_Groups]
GO
ALTER TABLE [dbo].[OrgUnitGroupPermissions]  WITH CHECK ADD  CONSTRAINT [FK_OrgUnitGroupPermissions_OrgUnits] FOREIGN KEY([OrgUnitId])
REFERENCES [dbo].[OrgUnits] ([Id])
GO
ALTER TABLE [dbo].[OrgUnitGroupPermissions] CHECK CONSTRAINT [FK_OrgUnitGroupPermissions_OrgUnits]
GO
ALTER TABLE [dbo].[OrgUnitGroupPermissions]  WITH CHECK ADD  CONSTRAINT [FK_OrgUnitGroupPermissions_PermissionLevels] FOREIGN KEY([PermissionLevelId])
REFERENCES [dbo].[PermissionLevels] ([Id])
GO
ALTER TABLE [dbo].[OrgUnitGroupPermissions] CHECK CONSTRAINT [FK_OrgUnitGroupPermissions_PermissionLevels]
GO
ALTER TABLE [dbo].[OrgUnits]  WITH CHECK ADD  CONSTRAINT [FK_OrgUnits_OrgUnits] FOREIGN KEY([ParentId])
REFERENCES [dbo].[OrgUnits] ([Id])
GO
ALTER TABLE [dbo].[OrgUnits] CHECK CONSTRAINT [FK_OrgUnits_OrgUnits]
GO
ALTER TABLE [dbo].[OrgUnits]  WITH CHECK ADD  CONSTRAINT [FK_OrgUnits_Users] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[OrgUnits] CHECK CONSTRAINT [FK_OrgUnits_Users]
GO
ALTER TABLE [dbo].[OrgUnits]  WITH CHECK ADD  CONSTRAINT [FK_OrgUnits_WorkspaceTemplates] FOREIGN KEY([WorkspaceTemplateId])
REFERENCES [dbo].[WorkspaceTemplates] ([Id])
GO
ALTER TABLE [dbo].[OrgUnits] CHECK CONSTRAINT [FK_OrgUnits_WorkspaceTemplates]
GO
ALTER TABLE [dbo].[OrgUnitUserPermissions]  WITH CHECK ADD  CONSTRAINT [FK_OrgUnitUserPermissions_OrgUnits] FOREIGN KEY([OrgUnitId])
REFERENCES [dbo].[OrgUnits] ([Id])
GO
ALTER TABLE [dbo].[OrgUnitUserPermissions] CHECK CONSTRAINT [FK_OrgUnitUserPermissions_OrgUnits]
GO
ALTER TABLE [dbo].[OrgUnitUserPermissions]  WITH CHECK ADD  CONSTRAINT [FK_OrgUnitUserPermissions_PermissionLevels] FOREIGN KEY([PermissionLevelId])
REFERENCES [dbo].[PermissionLevels] ([Id])
GO
ALTER TABLE [dbo].[OrgUnitUserPermissions] CHECK CONSTRAINT [FK_OrgUnitUserPermissions_PermissionLevels]
GO
ALTER TABLE [dbo].[OrgUnitUserPermissions]  WITH CHECK ADD  CONSTRAINT [FK_OrgUnitUserPermissions_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[OrgUnitUserPermissions] CHECK CONSTRAINT [FK_OrgUnitUserPermissions_Users]
GO
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_Reports_Users] FOREIGN KEY([CreatedById])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_Reports_Users]
GO
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_Reports_Users1] FOREIGN KEY([ModifiedById])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_Reports_Users1]
GO
ALTER TABLE [dbo].[SysEvents]  WITH CHECK ADD  CONSTRAINT [FK_SysEvents_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[SysEvents] CHECK CONSTRAINT [FK_SysEvents_Users]
GO
ALTER TABLE [dbo].[UserGroups]  WITH CHECK ADD  CONSTRAINT [FK_UserGroups_Groups] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO
ALTER TABLE [dbo].[UserGroups] CHECK CONSTRAINT [FK_UserGroups_Groups]
GO
ALTER TABLE [dbo].[UserGroups]  WITH CHECK ADD  CONSTRAINT [FK_UserGroups_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserGroups] CHECK CONSTRAINT [FK_UserGroups_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_PermissionLevels] FOREIGN KEY([PermissionLevelId])
REFERENCES [dbo].[PermissionLevels] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_PermissionLevels]
GO
ALTER TABLE [dbo].[WorkspaceDocumentTemplates]  WITH CHECK ADD  CONSTRAINT [FK_WorkspaceDocumentTemplates_DocumentTemplates] FOREIGN KEY([DocumentTemplateId])
REFERENCES [dbo].[DocumentTemplates] ([Id])
GO
ALTER TABLE [dbo].[WorkspaceDocumentTemplates] CHECK CONSTRAINT [FK_WorkspaceDocumentTemplates_DocumentTemplates]
GO
ALTER TABLE [dbo].[WorkspaceDocumentTemplates]  WITH CHECK ADD  CONSTRAINT [FK_WorkspaceDocumentTemplates_WorkspaceTemplates] FOREIGN KEY([WorkspaceTemplateId])
REFERENCES [dbo].[WorkspaceTemplates] ([Id])
GO
ALTER TABLE [dbo].[WorkspaceDocumentTemplates] CHECK CONSTRAINT [FK_WorkspaceDocumentTemplates_WorkspaceTemplates]
GO
ALTER TABLE [dbo].[WorkspaceTemplateComponents]  WITH CHECK ADD  CONSTRAINT [FK_WorkspaceTemplateComponents_Components] FOREIGN KEY([ComponentId])
REFERENCES [dbo].[Components] ([Id])
GO
ALTER TABLE [dbo].[WorkspaceTemplateComponents] CHECK CONSTRAINT [FK_WorkspaceTemplateComponents_Components]
GO
ALTER TABLE [dbo].[WorkspaceTemplateComponents]  WITH CHECK ADD  CONSTRAINT [FK_WorkspaceTemplateComponents_WorkspaceTemplates] FOREIGN KEY([WorkspaceTemplateId])
REFERENCES [dbo].[WorkspaceTemplates] ([Id])
GO
ALTER TABLE [dbo].[WorkspaceTemplateComponents] CHECK CONSTRAINT [FK_WorkspaceTemplateComponents_WorkspaceTemplates]
GO
ALTER TABLE [dbo].[WorkspaceTemplates]  WITH CHECK ADD  CONSTRAINT [FK_WorkspaceTemplates_Users] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[WorkspaceTemplates] CHECK CONSTRAINT [FK_WorkspaceTemplates_Users]
GO
ALTER TABLE [dbo].[WorkspaceTemplates]  WITH CHECK ADD  CONSTRAINT [FK_WorkspaceTemplates_Users1] FOREIGN KEY([ModifiedByUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[WorkspaceTemplates] CHECK CONSTRAINT [FK_WorkspaceTemplates_Users1]
GO
USE [master]
GO
ALTER DATABASE [mycoop] SET  READ_WRITE 
GO
