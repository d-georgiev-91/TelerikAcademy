USE [master]
GO
/****** Object:  Database [MultiLanguageDictionaryDB]    Script Date: 13.7.2013 г. 18:25:17 ч. ******/
CREATE DATABASE [MultiLanguageDictionaryDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MultiLanguageDictionaryDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\MultiLanguageDictionaryDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MultiLanguageDictionaryDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\MultiLanguageDictionaryDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MultiLanguageDictionaryDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET RECOVERY FULL 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET  MULTI_USER 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MultiLanguageDictionaryDB', N'ON'
GO
USE [MultiLanguageDictionaryDB]
GO
/****** Object:  Table [dbo].[Explanations]    Script Date: 13.7.2013 г. 18:25:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Explanations](
	[ExplanationId] [int] IDENTITY(1,1) NOT NULL,
	[ExplanationText] [ntext] NOT NULL,
	[LanguageId] [int] NOT NULL,
 CONSTRAINT [PK_Explanations] PRIMARY KEY CLUSTERED 
(
	[ExplanationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Languages]    Script Date: 13.7.2013 г. 18:25:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[LanguageId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 13.7.2013 г. 18:25:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[WordId] [int] IDENTITY(1,1) NOT NULL,
	[Word] [nvarchar](100) NOT NULL,
	[LanguageId] [int] NOT NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[WordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordsExplanations]    Script Date: 13.7.2013 г. 18:25:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordsExplanations](
	[WordId] [int] NOT NULL,
	[ExplanationdId] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordsSynonyms]    Script Date: 13.7.2013 г. 18:25:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordsSynonyms](
	[WordId] [int] NOT NULL,
	[SynonymId] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordsTranslationWords]    Script Date: 13.7.2013 г. 18:25:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordsTranslationWords](
	[WordId] [int] NOT NULL,
	[TranslationWordId] [int] NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Explanations]  WITH CHECK ADD  CONSTRAINT [FK_Explanations_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([LanguageId])
GO
ALTER TABLE [dbo].[Explanations] CHECK CONSTRAINT [FK_Explanations_Languages]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([LanguageId])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Languages]
GO
ALTER TABLE [dbo].[WordsExplanations]  WITH CHECK ADD  CONSTRAINT [FK_WordsExplanations_Explanations] FOREIGN KEY([ExplanationdId])
REFERENCES [dbo].[Explanations] ([ExplanationId])
GO
ALTER TABLE [dbo].[WordsExplanations] CHECK CONSTRAINT [FK_WordsExplanations_Explanations]
GO
ALTER TABLE [dbo].[WordsExplanations]  WITH CHECK ADD  CONSTRAINT [FK_WordsExplanations_Words] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([WordId])
GO
ALTER TABLE [dbo].[WordsExplanations] CHECK CONSTRAINT [FK_WordsExplanations_Words]
GO
ALTER TABLE [dbo].[WordsSynonyms]  WITH CHECK ADD  CONSTRAINT [FK_WordsSynonyms_Words] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([WordId])
GO
ALTER TABLE [dbo].[WordsSynonyms] CHECK CONSTRAINT [FK_WordsSynonyms_Words]
GO
ALTER TABLE [dbo].[WordsSynonyms]  WITH CHECK ADD  CONSTRAINT [FK_WordsSynonyms_Words1] FOREIGN KEY([SynonymId])
REFERENCES [dbo].[Words] ([WordId])
GO
ALTER TABLE [dbo].[WordsSynonyms] CHECK CONSTRAINT [FK_WordsSynonyms_Words1]
GO
ALTER TABLE [dbo].[WordsTranslationWords]  WITH CHECK ADD  CONSTRAINT [FK_WordsTranslationWords_Words] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([WordId])
GO
ALTER TABLE [dbo].[WordsTranslationWords] CHECK CONSTRAINT [FK_WordsTranslationWords_Words]
GO
ALTER TABLE [dbo].[WordsTranslationWords]  WITH CHECK ADD  CONSTRAINT [FK_WordsTranslationWords_Words1] FOREIGN KEY([TranslationWordId])
REFERENCES [dbo].[Words] ([WordId])
GO
ALTER TABLE [dbo].[WordsTranslationWords] CHECK CONSTRAINT [FK_WordsTranslationWords_Words1]
GO
USE [master]
GO
ALTER DATABASE [MultiLanguageDictionaryDB] SET  READ_WRITE 
GO
