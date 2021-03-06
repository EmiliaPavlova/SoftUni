USE [master]
GO
/****** Object:  Database [DataModelingHW]    Script Date: 28.6.2015 г. 23:40:13 ч. ******/
CREATE DATABASE [DataModelingHW]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DataModelingHW', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DataModelingHW.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DataModelingHW_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DataModelingHW_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DataModelingHW] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DataModelingHW].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DataModelingHW] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DataModelingHW] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DataModelingHW] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DataModelingHW] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DataModelingHW] SET ARITHABORT OFF 
GO
ALTER DATABASE [DataModelingHW] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DataModelingHW] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DataModelingHW] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DataModelingHW] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DataModelingHW] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DataModelingHW] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DataModelingHW] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DataModelingHW] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DataModelingHW] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DataModelingHW] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DataModelingHW] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DataModelingHW] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DataModelingHW] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DataModelingHW] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DataModelingHW] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DataModelingHW] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DataModelingHW] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DataModelingHW] SET RECOVERY FULL 
GO
ALTER DATABASE [DataModelingHW] SET  MULTI_USER 
GO
ALTER DATABASE [DataModelingHW] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DataModelingHW] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DataModelingHW] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DataModelingHW] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DataModelingHW] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DataModelingHW', N'ON'
GO
USE [DataModelingHW]
GO
/****** Object:  Table [dbo].[Answers]    Script Date: 28.6.2015 г. 23:40:13 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nchar](10) NULL,
	[QuestionId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 28.6.2015 г. 23:40:13 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Questions]    Script Date: 28.6.2015 г. 23:40:13 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[CategoryId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuestionTags]    Script Date: 28.6.2015 г. 23:40:13 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionTags](
	[TagId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tags]    Script Date: 28.6.2015 г. 23:40:13 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 28.6.2015 г. 23:40:13 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Votes]    Script Date: 28.6.2015 г. 23:40:13 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Votes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Value] [int] NOT NULL,
	[AnswerId] [int] NOT NULL,
 CONSTRAINT [PK_Votes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Questions] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([Id])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Questions]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Users]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Categories]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Users]
GO
ALTER TABLE [dbo].[QuestionTags]  WITH CHECK ADD  CONSTRAINT [FK_QuestionTags_Questions] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([Id])
GO
ALTER TABLE [dbo].[QuestionTags] CHECK CONSTRAINT [FK_QuestionTags_Questions]
GO
ALTER TABLE [dbo].[QuestionTags]  WITH CHECK ADD  CONSTRAINT [FK_QuestionTags_Tags] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([Id])
GO
ALTER TABLE [dbo].[QuestionTags] CHECK CONSTRAINT [FK_QuestionTags_Tags]
GO
ALTER TABLE [dbo].[Votes]  WITH CHECK ADD  CONSTRAINT [FK_Votes_Answers] FOREIGN KEY([AnswerId])
REFERENCES [dbo].[Answers] ([Id])
GO
ALTER TABLE [dbo].[Votes] CHECK CONSTRAINT [FK_Votes_Answers]
GO
ALTER TABLE [dbo].[Votes]  WITH CHECK ADD  CONSTRAINT [FK_Votes_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Votes] CHECK CONSTRAINT [FK_Votes_Users]
GO
USE [master]
GO
ALTER DATABASE [DataModelingHW] SET  READ_WRITE 
GO
