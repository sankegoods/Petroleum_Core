USE [master]
GO
/****** Object:  Database [Petroleum]    Script Date: 2020/7/9 14:14:49 ******/
CREATE DATABASE [Petroleum]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Petroleum', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Petroleum.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Petroleum_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Petroleum_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Petroleum] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Petroleum].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Petroleum] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Petroleum] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Petroleum] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Petroleum] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Petroleum] SET ARITHABORT OFF 
GO
ALTER DATABASE [Petroleum] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Petroleum] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Petroleum] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Petroleum] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Petroleum] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Petroleum] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Petroleum] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Petroleum] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Petroleum] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Petroleum] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Petroleum] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Petroleum] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Petroleum] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Petroleum] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Petroleum] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Petroleum] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Petroleum] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Petroleum] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Petroleum] SET RECOVERY FULL 
GO
ALTER DATABASE [Petroleum] SET  MULTI_USER 
GO
ALTER DATABASE [Petroleum] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Petroleum] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Petroleum] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Petroleum] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Petroleum]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 2020/7/9 14:14:50 ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Actions]    Script Date: 2020/7/9 14:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[url] [nvarchar](200) NULL,
	[NameType] [int] NULL,
	[NonMenu] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Approver]    Script Date: 2020/7/9 14:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Approver](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobCode] [varchar](100) NOT NULL,
	[AreaLeve] [int] NOT NULL,
	[Discrible] [nvarchar](100) NULL,
	[Orders] [int] NOT NULL,
	[ProcessItemId] [int] NULL,
	[ExecuteMethod] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Entrys]    Script Date: 2020/7/9 14:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Entrys](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StaffName] [nvarchar](500) NULL,
	[Sex] [int] NULL,
	[BirthDay] [date] NULL,
	[MaritalStatus] [int] NULL,
	[Height] [decimal](5, 2) NULL,
	[HighestEducation] [int] NULL,
	[Major] [nvarchar](500) NULL,
	[ForeginLanguageAptitude] [nvarchar](500) NULL,
	[IDNumber] [varchar](20) NULL,
	[NativePlace] [nvarchar](500) NULL,
	[Addressd] [nvarchar](500) NULL,
	[Email] [nvarchar](500) NULL,
	[Tel] [char](20) NULL,
	[HaseMedicalHistory] [int] NULL,
	[MedicalHistoryComment] [nvarchar](500) NULL,
	[HobbiesAndSpeciality] [nvarchar](500) NULL,
	[EducationalExperience1StartDate] [date] NULL,
	[EducationalExperience1EndDate] [date] NULL,
	[EducationalExperience1SchoolName] [nvarchar](500) NULL,
	[EducationalExperience1Major] [nvarchar](500) NULL,
	[EducationalExperience1Certificate] [nvarchar](500) NULL,
	[EducationalExperience2StartDate] [date] NULL,
	[EducationalExperience2EndDate] [date] NULL,
	[EducationalExperience2SchoolName] [nvarchar](500) NULL,
	[EducationalExperience2Major] [nvarchar](500) NULL,
	[EducationalExperience2Certificate] [nvarchar](500) NULL,
	[EducationalExperience3StartDate] [date] NULL,
	[EducationalExperience3EndDate] [date] NULL,
	[EducationalExperience3SchoolName] [nvarchar](500) NULL,
	[EducationalExperience3Major] [nvarchar](500) NULL,
	[EducationalExperience3Certificate] [nvarchar](500) NULL,
	[EducationalExperience4StartDate] [date] NULL,
	[EducationalExperience4EndDate] [date] NULL,
	[EducationalExperience4SchoolName] [nvarchar](500) NULL,
	[EducationalExperience4Major] [nvarchar](500) NULL,
	[EducationalExperience4Certificate] [nvarchar](500) NULL,
	[FamilyStatus1Name] [nvarchar](500) NULL,
	[FamilyStatus1Appellation] [nvarchar](500) NULL,
	[FamilyStatus1Company] [nvarchar](500) NULL,
	[FamilyStatus1Tel] [varchar](20) NULL,
	[FamilyStatus2Name] [nvarchar](500) NULL,
	[FamilyStatus2Appellation] [nvarchar](500) NULL,
	[FamilyStatus2Company] [nvarchar](500) NULL,
	[FamilyStatus2Tel] [varchar](20) NULL,
	[EmergencyContactName] [nvarchar](500) NULL,
	[EmergencyContactTel] [varchar](20) NULL,
	[EmergencyContactEelationShipWithMe] [nvarchar](500) NULL,
	[WorkExperience1CompanyName] [nvarchar](500) NULL,
	[WorkExperience1Job] [nvarchar](500) NULL,
	[WorkExperience1StartDate] [date] NULL,
	[WorkExperience1EndDate] [date] NULL,
	[WorkExperience1Pay] [nvarchar](50) NULL,
	[WorkExperience1LeavingReasons] [nvarchar](100) NULL,
	[WorkExperience2CompanyName] [nvarchar](500) NULL,
	[WorkExperience2Job] [nvarchar](500) NULL,
	[WorkExperience2StartDate] [date] NULL,
	[WorkExperience2EndDate] [date] NULL,
	[WorkExperience2Pay] [nvarchar](50) NULL,
	[WorkExperience2LeavingReasons] [nvarchar](100) NULL,
	[WorkExperience3CompanyName] [nvarchar](500) NULL,
	[WorkExperience3Job] [nvarchar](500) NULL,
	[WorkExperience3StartDate] [date] NULL,
	[WorkExperience3EndDate] [date] NULL,
	[WorkExperience3Pay] [nvarchar](50) NULL,
	[WorkExperience3LeavingReasons] [nvarchar](100) NULL,
	[WorkExperience4CompanyName] [nvarchar](500) NULL,
	[WorkExperience4Job] [nvarchar](500) NULL,
	[WorkExperience4StartDate] [date] NULL,
	[WorkExperience4EndDate] [date] NULL,
	[WorkExperience4Pay] [nvarchar](50) NULL,
	[WorkExperience4LeavingReasons] [nvarchar](100) NULL,
	[JobId] [int] NULL,
	[Title] [nvarchar](50) NULL,
	[Organization_Id] [int] NULL,
	[SupervisorComments] [nvarchar](500) NULL,
	[ProbationarySalary] [nvarchar](50) NULL,
	[CorrectSalary] [nvarchar](50) NULL,
	[WorkNumber] [nvarchar](50) NULL,
	[EntryDate] [date] NULL,
	[BirthCertificatePhoto] [nvarchar](200) NULL,
	[RegistrationPhoto] [nvarchar](200) NULL,
	[BankCardNumber] [nvarchar](200) NULL,
	[CreateStaffeId] [nvarchar](200) NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[NoN] [varchar](50) NULL,
	[StaffNo] [nvarchar](100) NULL,
	[IsDel] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job]    Script Date: 2020/7/9 14:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Code] [nvarchar](100) NULL,
	[UpdateTime] [datetime] NULL,
	[CreateTime] [datetime] NULL,
	[IsDel] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeaveOffice]    Script Date: 2020/7/9 14:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LeaveOffice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NoN] [nvarchar](100) NULL,
	[StaffName] [nvarchar](100) NULL,
	[JobId] [int] NULL,
	[LeaveType] [char](1) NULL,
	[ApplyDate] [date] NULL,
	[Reason] [nvarchar](500) NULL,
	[ExplanationHandover] [nvarchar](500) NULL,
	[HandoverSatffId] [nvarchar](50) NULL,
	[ApplyPersonId] [nvarchar](200) NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[isyes] [int] NULL,
	[IsDel] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OilMaterialOrder]    Script Date: 2020/7/9 14:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OilMaterialOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NoN] [nvarchar](100) NOT NULL,
	[ApplyPersonId] [nvarchar](200) NOT NULL,
	[ApplyDate] [date] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[IsDel] [int] NOT NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[IsPanke] [int] NOT NULL,
	[IsLaunch] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OilMaterialOrderDetail]    Script Date: 2020/7/9 14:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OilMaterialOrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[OilSpec] [nvarchar](100) NULL,
	[Volume] [decimal](18, 2) NULL,
	[Surplus] [decimal](18, 2) NULL,
	[DayAvg] [decimal](18, 2) NULL,
	[NeedAmount] [decimal](18, 2) NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[IsDel] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrganizationStructure]    Script Date: 2020/7/9 14:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationStructure](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[Leve] [nvarchar](20) NULL,
	[ParentId] [nvarchar](100) NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[IsDel] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProcessItem]    Script Date: 2020/7/9 14:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProcessItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](100) NOT NULL,
	[Discrible] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProcessStepRecord]    Script Date: 2020/7/9 14:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProcessStepRecord](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Typed] [varchar](50) NULL,
	[RecordRemarks] [nvarchar](500) NULL,
	[OilStation] [int] NULL,
	[OilStationRemark] [nvarchar](100) NULL,
	[ExecutiveDirector] [int] NULL,
	[ExecutiveDirectorRemark] [nvarchar](100) NULL,
	[GeneralManager] [int] NULL,
	[GeneralManagerRemark] [nvarchar](100) NULL,
	[GeneralManagerOfPerson] [int] NULL,
	[GeneralManagerOfPersonRemark] [nvarchar](100) NULL,
	[ChiefInspector] [int] NULL,
	[ChiefInspectorRemark] [nvarchar](100) NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NULL,
	[WhetherToExecute] [int] NOT NULL,
	[NoN] [nvarchar](50) NOT NULL,
	[RefOrderId] [int] NOT NULL,
	[Result] [int] NOT NULL,
	[ExecuteMethod] [nvarchar](400) NULL,
	[Discrible] [nvarchar](400) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 2020/7/9 14:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Code] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleAction]    Script Date: 2020/7/9 14:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleAction](
	[RoleActionID] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[ActionId] [int] NOT NULL,
	[isDelete] [nvarchar](6) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleActionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleResourceModule]    Script Date: 2020/7/9 14:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleResourceModule](
	[RoleId] [uniqueidentifier] NOT NULL,
	[ResourceModuleId] [uniqueidentifier] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Staff]    Script Date: 2020/7/9 14:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Staff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NoN] [nvarchar](500) NULL,
	[Name] [nvarchar](500) NULL,
	[Sex] [char](2) NULL,
	[BirthDay] [date] NULL,
	[NativePlace] [nvarchar](500) NULL,
	[Addressd] [nvarchar](500) NULL,
	[Passwords] [nvarchar](1000) NULL,
	[Email] [nvarchar](50) NULL,
	[Tel] [nvarchar](20) NULL,
	[Statusd] [nvarchar](10) NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[JobId] [int] NULL,
	[RoleId] [int] NULL,
	[OrgID] [int] NULL,
	[IsHSEGroup] [char](2) NULL,
	[IsLaunch] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StaffRole]    Script Date: 2020/7/9 14:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StaffId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[IsDele] [nvarchar](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SystemResourceModule]    Script Date: 2020/7/9 14:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemResourceModule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Code] [nvarchar](500) NULL,
	[Url] [nvarchar](1000) NULL,
	[Typed] [int] NULL,
	[ParentId] [nvarchar](100) NULL,
	[OrderNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Actions] ON 

INSERT [dbo].[Actions] ([Id], [Name], [url], [NameType], [NonMenu]) VALUES (1, N'角色权限', N'/RoleInfo/Index', 3, 1)
INSERT [dbo].[Actions] ([Id], [Name], [url], [NameType], [NonMenu]) VALUES (2, N'员工入职申请', N'/UserInfo/SelectEntrys', 1, 1)
INSERT [dbo].[Actions] ([Id], [Name], [url], [NameType], [NonMenu]) VALUES (3, N'员工离职申请', N'/StaffInfo/LeaveOfficeView', 1, 1)
INSERT [dbo].[Actions] ([Id], [Name], [url], [NameType], [NonMenu]) VALUES (4, N'油料申请', N'/Oilseeds/Index', 1, 1)
INSERT [dbo].[Actions] ([Id], [Name], [url], [NameType], [NonMenu]) VALUES (5, N'组织机构管理', N'/Organisation/Index', 2, 1)
INSERT [dbo].[Actions] ([Id], [Name], [url], [NameType], [NonMenu]) VALUES (6, N'员工基础信息管理', N'/StaffInfo/Index', 2, 1)
INSERT [dbo].[Actions] ([Id], [Name], [url], [NameType], [NonMenu]) VALUES (7, N'职位管理', N'/JobInfo/Index', 2, 1)
INSERT [dbo].[Actions] ([Id], [Name], [url], [NameType], [NonMenu]) VALUES (8, N'用户（员工）角色', N'/StaffInfo/AddRoleInsetStaff', 3, 1)
INSERT [dbo].[Actions] ([Id], [Name], [url], [NameType], [NonMenu]) VALUES (9, N'系统模块资源', N'空', 3, 1)
INSERT [dbo].[Actions] ([Id], [Name], [url], [NameType], [NonMenu]) VALUES (10, N'流程设置', N'/StaffInfo/circuitView', 3, 1)
INSERT [dbo].[Actions] ([Id], [Name], [url], [NameType], [NonMenu]) VALUES (11, N'员工入职审批', N'/UserInfo/EntryAudit', 4, 1)
INSERT [dbo].[Actions] ([Id], [Name], [url], [NameType], [NonMenu]) VALUES (12, N'员工离职审批', N'/StaffInfo/LeavingAudit', 4, 1)
INSERT [dbo].[Actions] ([Id], [Name], [url], [NameType], [NonMenu]) VALUES (13, N'油料申请审批', N'/Oilseeds/ApprovalIndex', 4, 1)
INSERT [dbo].[Actions] ([Id], [Name], [url], [NameType], [NonMenu]) VALUES (14, N'审批权限', N'All', 0, 0)
INSERT [dbo].[Actions] ([Id], [Name], [url], [NameType], [NonMenu]) VALUES (15, N'发起权限', N'All', 0, 0)
SET IDENTITY_INSERT [dbo].[Actions] OFF
SET IDENTITY_INSERT [dbo].[Approver] ON 

INSERT [dbo].[Approver] ([Id], [JobCode], [AreaLeve], [Discrible], [Orders], [ProcessItemId], [ExecuteMethod]) VALUES (1, N'OilStation', 0, N'油站经理', 0, 1, NULL)
INSERT [dbo].[Approver] ([Id], [JobCode], [AreaLeve], [Discrible], [Orders], [ProcessItemId], [ExecuteMethod]) VALUES (2, N'ExecutiveDirector', 1, N'区域主管', 1, 1, NULL)
INSERT [dbo].[Approver] ([Id], [JobCode], [AreaLeve], [Discrible], [Orders], [ProcessItemId], [ExecuteMethod]) VALUES (3, N'FinancialManager', 2, N'区域财务经理', 2, 1, NULL)
INSERT [dbo].[Approver] ([Id], [JobCode], [AreaLeve], [Discrible], [Orders], [ProcessItemId], [ExecuteMethod]) VALUES (4, N'FinancialManager', 3, N'大区财务经理', 3, 1, NULL)
SET IDENTITY_INSERT [dbo].[Approver] OFF
SET IDENTITY_INSERT [dbo].[Job] ON 

INSERT [dbo].[Job] ([Id], [Name], [Code], [UpdateTime], [CreateTime], [IsDel]) VALUES (1, N'油站员工', N'Staff', NULL, CAST(0x0000AB7F018412F0 AS DateTime), 0)
INSERT [dbo].[Job] ([Id], [Name], [Code], [UpdateTime], [CreateTime], [IsDel]) VALUES (2, N'人事员工', N'PersonnelStaff', NULL, CAST(0x0000AB7F018412F2 AS DateTime), 0)
INSERT [dbo].[Job] ([Id], [Name], [Code], [UpdateTime], [CreateTime], [IsDel]) VALUES (3, N'总经理', N'GeneralManager', NULL, CAST(0x0000AB7F018412F5 AS DateTime), 0)
INSERT [dbo].[Job] ([Id], [Name], [Code], [UpdateTime], [CreateTime], [IsDel]) VALUES (4, N'财务经理', N'FinancialManager', NULL, CAST(0x0000AB7F018412FA AS DateTime), 0)
INSERT [dbo].[Job] ([Id], [Name], [Code], [UpdateTime], [CreateTime], [IsDel]) VALUES (5, N'主管', N'ExecutiveDirector', NULL, CAST(0x0000AB7F018412FB AS DateTime), 0)
INSERT [dbo].[Job] ([Id], [Name], [Code], [UpdateTime], [CreateTime], [IsDel]) VALUES (6, N'人事经理', N'PersonnelManager', NULL, CAST(0x0000AB7F018412FB AS DateTime), 0)
INSERT [dbo].[Job] ([Id], [Name], [Code], [UpdateTime], [CreateTime], [IsDel]) VALUES (7, N'油站经理', N'OilStation', NULL, CAST(0x0000AB7F018412FC AS DateTime), 0)
INSERT [dbo].[Job] ([Id], [Name], [Code], [UpdateTime], [CreateTime], [IsDel]) VALUES (8, N'总监', N'ChiefInspector', NULL, CAST(0x0000AB7F01841300 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Job] OFF
SET IDENTITY_INSERT [dbo].[LeaveOffice] ON 

INSERT [dbo].[LeaveOffice] ([Id], [NoN], [StaffName], [JobId], [LeaveType], [ApplyDate], [Reason], [ExplanationHandover], [HandoverSatffId], [ApplyPersonId], [CreateTime], [UpdateTime], [isyes], [IsDel]) VALUES (1, N'20191116', N'王三', 1, N'1', CAST(0xDA400B00 AS Date), N'老板是变态', N'所有工作基本交接完毕', N'涵经理', N'1', CAST(0x0000AB7F018500DF AS DateTime), NULL, 0, N'0')
SET IDENTITY_INSERT [dbo].[LeaveOffice] OFF
SET IDENTITY_INSERT [dbo].[OrganizationStructure] ON 

INSERT [dbo].[OrganizationStructure] ([Id], [Code], [Name], [Leve], [ParentId], [CreateTime], [UpdateTime], [IsDel]) VALUES (1, N'HUBEI', N'湖北省', N'总部', N'0', CAST(0x0000AB7F018500FD AS DateTime), NULL, 0)
INSERT [dbo].[OrganizationStructure] ([Id], [Code], [Name], [Leve], [ParentId], [CreateTime], [UpdateTime], [IsDel]) VALUES (2, N'WUHAN', N'武汉大区', N'大区', N'1', CAST(0x0000AB7F0185010F AS DateTime), NULL, 0)
INSERT [dbo].[OrganizationStructure] ([Id], [Code], [Name], [Leve], [ParentId], [CreateTime], [UpdateTime], [IsDel]) VALUES (3, N'HONGSHAN', N'洪山区', N'区域', N'2', CAST(0x0000AB7F0185013E AS DateTime), NULL, 0)
INSERT [dbo].[OrganizationStructure] ([Id], [Code], [Name], [Leve], [ParentId], [CreateTime], [UpdateTime], [IsDel]) VALUES (4, N'CAIDIAN', N'蔡甸区', N'区域', N'2', CAST(0x0000AB7F01850158 AS DateTime), NULL, 0)
INSERT [dbo].[OrganizationStructure] ([Id], [Code], [Name], [Leve], [ParentId], [CreateTime], [UpdateTime], [IsDel]) VALUES (5, N'HANYANG', N'汉阳区', N'区域', N'2', CAST(0x0000AB7F01850191 AS DateTime), NULL, 0)
INSERT [dbo].[OrganizationStructure] ([Id], [Code], [Name], [Leve], [ParentId], [CreateTime], [UpdateTime], [IsDel]) VALUES (6, N'JINZOU', N'荆州大区', N'大区', N'1', CAST(0x0000AB7F018501C1 AS DateTime), NULL, 0)
SET IDENTITY_INSERT [dbo].[OrganizationStructure] OFF
SET IDENTITY_INSERT [dbo].[ProcessItem] ON 

INSERT [dbo].[ProcessItem] ([Id], [Code], [Discrible]) VALUES (1, N'油料申请审批流程', N'审批油料的')
INSERT [dbo].[ProcessItem] ([Id], [Code], [Discrible]) VALUES (2, N'员工离职审批流程', N'审批离职的')
INSERT [dbo].[ProcessItem] ([Id], [Code], [Discrible]) VALUES (3, N'员工入职审批流程', N'审批入职的')
SET IDENTITY_INSERT [dbo].[ProcessItem] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name], [Code]) VALUES (1, N'油站员工', N'Staff')
INSERT [dbo].[Role] ([Id], [Name], [Code]) VALUES (2, N'人事员工', N'PersonnelStaff')
INSERT [dbo].[Role] ([Id], [Name], [Code]) VALUES (3, N'总经理', N'GeneralManager')
INSERT [dbo].[Role] ([Id], [Name], [Code]) VALUES (4, N'财务经理', N'FinancialManager')
INSERT [dbo].[Role] ([Id], [Name], [Code]) VALUES (5, N'主管', N'ExecutiveDirector')
INSERT [dbo].[Role] ([Id], [Name], [Code]) VALUES (6, N'人事经理', N'PersonnelManager')
INSERT [dbo].[Role] ([Id], [Name], [Code]) VALUES (7, N'超级用户', N'SuperUser')
INSERT [dbo].[Role] ([Id], [Name], [Code]) VALUES (8, N'系统维护员', N'SystemMaintainer')
INSERT [dbo].[Role] ([Id], [Name], [Code]) VALUES (9, N'查看所有功能', N'AllFunctions')
INSERT [dbo].[Role] ([Id], [Name], [Code]) VALUES (10, N'日常管理员', N'DailyManager')
INSERT [dbo].[Role] ([Id], [Name], [Code]) VALUES (11, N'油站经理', N'StationManager')
INSERT [dbo].[Role] ([Id], [Name], [Code]) VALUES (12, N'基础信息维护员', N'BasicInformationMaintainer')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[RoleAction] ON 

INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (1, 7, 1, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (2, 7, 2, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (3, 7, 3, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (4, 7, 4, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (5, 7, 5, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (6, 7, 6, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (7, 7, 7, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (8, 7, 8, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (9, 7, 9, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (10, 7, 10, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (11, 7, 11, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (12, 7, 12, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (13, 7, 13, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (14, 5, 1, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (15, 5, 4, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (16, 5, 5, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (17, 5, 7, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (18, 5, 8, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (19, 5, 10, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (20, 5, 9, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (21, 5, 11, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (22, 5, 13, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (23, 5, 12, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (24, 6, 2, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (25, 6, 3, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (26, 6, 5, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (27, 6, 6, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (28, 6, 7, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (29, 6, 8, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (30, 6, 9, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (31, 6, 11, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (32, 6, 12, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (33, 11, 4, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (34, 11, 6, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (35, 11, 7, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (36, 11, 8, N'true')
INSERT [dbo].[RoleAction] ([RoleActionID], [RoleId], [ActionId], [isDelete]) VALUES (37, 1, 1, N'false')
SET IDENTITY_INSERT [dbo].[RoleAction] OFF
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([Id], [NoN], [Name], [Sex], [BirthDay], [NativePlace], [Addressd], [Passwords], [Email], [Tel], [Statusd], [CreateTime], [UpdateTime], [JobId], [RoleId], [OrgID], [IsHSEGroup], [IsLaunch]) VALUES (1, N'1', N'渊贰', N'男', CAST(0xC1210B00 AS Date), N'湖北', N'湖北武汉', N'123456', N'953298392@qq.com', N'13165647115', N'1', CAST(0x0000AB7F0184F35C AS DateTime), CAST(0x0000000000000000 AS DateTime), 8, 7, 1, N'1 ', 1)
INSERT [dbo].[Staff] ([Id], [NoN], [Name], [Sex], [BirthDay], [NativePlace], [Addressd], [Passwords], [Email], [Tel], [Statusd], [CreateTime], [UpdateTime], [JobId], [RoleId], [OrgID], [IsHSEGroup], [IsLaunch]) VALUES (2, N'张三', N'张三', N'男', CAST(0xC1210B00 AS Date), N'北京', N'北京', N'123456', N'953298392@qq.com', N'13165647115', N'1', CAST(0x0000AB7F0184F35F AS DateTime), CAST(0x0000000000000000 AS DateTime), 5, 5, 1, N'1 ', 1)
INSERT [dbo].[Staff] ([Id], [NoN], [Name], [Sex], [BirthDay], [NativePlace], [Addressd], [Passwords], [Email], [Tel], [Statusd], [CreateTime], [UpdateTime], [JobId], [RoleId], [OrgID], [IsHSEGroup], [IsLaunch]) VALUES (3, N'王五', N'王五', N'男', CAST(0xC1210B00 AS Date), N'上海', N'上海', N'123456', N'953298392@qq.com', N'13165647115', N'1', CAST(0x0000AB7F0184F35F AS DateTime), CAST(0x0000000000000000 AS DateTime), 6, 6, 1, N'1 ', 1)
INSERT [dbo].[Staff] ([Id], [NoN], [Name], [Sex], [BirthDay], [NativePlace], [Addressd], [Passwords], [Email], [Tel], [Statusd], [CreateTime], [UpdateTime], [JobId], [RoleId], [OrgID], [IsHSEGroup], [IsLaunch]) VALUES (4, N'斛蓝', N'斛蓝', N'男', CAST(0xC1210B00 AS Date), N'杭州', N'杭州', N'123456', N'953298392@qq.com', N'13165647115', N'1', CAST(0x0000AB7F0184F360 AS DateTime), CAST(0x0000000000000000 AS DateTime), 3, 3, 1, N'1 ', 1)
INSERT [dbo].[Staff] ([Id], [NoN], [Name], [Sex], [BirthDay], [NativePlace], [Addressd], [Passwords], [Email], [Tel], [Statusd], [CreateTime], [UpdateTime], [JobId], [RoleId], [OrgID], [IsHSEGroup], [IsLaunch]) VALUES (5, N'二胖', N'二胖', N'男', CAST(0xC1210B00 AS Date), N'甘肃', N'甘肃', N'123456', N'953298392@qq.com', N'13165647115', N'1', CAST(0x0000AB7F0184F360 AS DateTime), CAST(0x0000000000000000 AS DateTime), 7, 11, 1, N'1 ', 1)
INSERT [dbo].[Staff] ([Id], [NoN], [Name], [Sex], [BirthDay], [NativePlace], [Addressd], [Passwords], [Email], [Tel], [Statusd], [CreateTime], [UpdateTime], [JobId], [RoleId], [OrgID], [IsHSEGroup], [IsLaunch]) VALUES (6, N'枫华', N'枫华', N'女', CAST(0xC1210B00 AS Date), N'甘肃', N'甘肃', N'123456', N'953298392@qq.com', N'13165647115', N'1', CAST(0x0000AB7F0184F361 AS DateTime), CAST(0x0000000000000000 AS DateTime), 1, 1, 1, N'1 ', 1)
SET IDENTITY_INSERT [dbo].[Staff] OFF
SET IDENTITY_INSERT [dbo].[StaffRole] ON 

INSERT [dbo].[StaffRole] ([Id], [StaffId], [RoleId], [IsDele]) VALUES (1, 1, 7, N'true')
INSERT [dbo].[StaffRole] ([Id], [StaffId], [RoleId], [IsDele]) VALUES (2, 2, 5, N'true')
INSERT [dbo].[StaffRole] ([Id], [StaffId], [RoleId], [IsDele]) VALUES (3, 3, 6, N'true')
INSERT [dbo].[StaffRole] ([Id], [StaffId], [RoleId], [IsDele]) VALUES (4, 4, 3, N'true')
INSERT [dbo].[StaffRole] ([Id], [StaffId], [RoleId], [IsDele]) VALUES (5, 5, 11, N'true')
INSERT [dbo].[StaffRole] ([Id], [StaffId], [RoleId], [IsDele]) VALUES (6, 1, 1, N'false')
SET IDENTITY_INSERT [dbo].[StaffRole] OFF
ALTER TABLE [dbo].[OilMaterialOrder] ADD  DEFAULT ((0)) FOR [IsPanke]
GO
ALTER TABLE [dbo].[OilMaterialOrder] ADD  DEFAULT ((0)) FOR [IsLaunch]
GO
USE [master]
GO
ALTER DATABASE [Petroleum] SET  READ_WRITE 
GO
