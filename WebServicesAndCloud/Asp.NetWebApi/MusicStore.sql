USE [MusicStore]
GO
/****** Object:  Table [dbo].[Albums]    Script Date: 11.8.2013 г. 18:48:01 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Albums](
	[AlbumId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Year] [int] NOT NULL,
	[Producer] [nvarchar](50) NULL,
 CONSTRAINT [PK_Albums] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AlbumsArtists]    Script Date: 11.8.2013 г. 18:48:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlbumsArtists](
	[AlbumId] [int] NOT NULL,
	[ArtistId] [int] NOT NULL,
 CONSTRAINT [PK_AlbumsArtists] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC,
	[ArtistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Artists]    Script Date: 11.8.2013 г. 18:48:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artists](
	[ArtistId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateOfBirth] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Artists] PRIMARY KEY CLUSTERED 
(
	[ArtistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Songs]    Script Date: 11.8.2013 г. 18:48:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Songs](
	[SongId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Year] [int] NOT NULL,
	[Genre] [nvarchar](50) NOT NULL,
	[AlbumId] [int] NULL,
 CONSTRAINT [PK_Songs] PRIMARY KEY CLUSTERED 
(
	[SongId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SongsArtists]    Script Date: 11.8.2013 г. 18:48:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SongsArtists](
	[SongId] [int] NOT NULL,
	[ArtistID] [int] NOT NULL,
 CONSTRAINT [PK_SongsArtists] PRIMARY KEY CLUSTERED 
(
	[SongId] ASC,
	[ArtistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Albums] ON 

INSERT [dbo].[Albums] ([AlbumId], [Title], [Year], [Producer]) VALUES (1, N'Bleach', 1989, N'Jack Endino')
INSERT [dbo].[Albums] ([AlbumId], [Title], [Year], [Producer]) VALUES (2, N'Dangerous and Moving', 2005, N'Martin Kierszenbaum')
INSERT [dbo].[Albums] ([AlbumId], [Title], [Year], [Producer]) VALUES (3, N'Nqma takyv Album', 1989, N'Pesho')
INSERT [dbo].[Albums] ([AlbumId], [Title], [Year], [Producer]) VALUES (4, N'Nqma takyv Album', 1989, N'Pesho')
INSERT [dbo].[Albums] ([AlbumId], [Title], [Year], [Producer]) VALUES (5, N'Nqma takyv Album', 1989, N'Pesho')
INSERT [dbo].[Albums] ([AlbumId], [Title], [Year], [Producer]) VALUES (6, N'Nqma takyv Album', 1989, N'Pesho')
SET IDENTITY_INSERT [dbo].[Albums] OFF
INSERT [dbo].[AlbumsArtists] ([AlbumId], [ArtistId]) VALUES (1, 1)
INSERT [dbo].[AlbumsArtists] ([AlbumId], [ArtistId]) VALUES (2, 2)
INSERT [dbo].[AlbumsArtists] ([AlbumId], [ArtistId]) VALUES (6, 1002)
SET IDENTITY_INSERT [dbo].[Artists] ON 

INSERT [dbo].[Artists] ([ArtistId], [Name], [DateOfBirth]) VALUES (1, N'Nirvana', CAST(0x7C200000 AS SmallDateTime))
INSERT [dbo].[Artists] ([ArtistId], [Name], [DateOfBirth]) VALUES (2, N'Tatu', CAST(0x92F40000 AS SmallDateTime))
INSERT [dbo].[Artists] ([ArtistId], [Name], [DateOfBirth]) VALUES (1002, N'Ivana', CAST(0x6B010000 AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[Artists] OFF
SET IDENTITY_INSERT [dbo].[Songs] ON 

INSERT [dbo].[Songs] ([SongId], [Title], [Year], [Genre], [AlbumId]) VALUES (1, N'Blew', 1989, N'Grunge', 1)
INSERT [dbo].[Songs] ([SongId], [Title], [Year], [Genre], [AlbumId]) VALUES (3, N'Floyd the Barber', 1989, N'Grunge', 1)
INSERT [dbo].[Songs] ([SongId], [Title], [Year], [Genre], [AlbumId]) VALUES (4, N'About a Girl', 1989, N'Grunge', 1)
INSERT [dbo].[Songs] ([SongId], [Title], [Year], [Genre], [AlbumId]) VALUES (5, N'All About Us', 2005, N'Pop', 2)
INSERT [dbo].[Songs] ([SongId], [Title], [Year], [Genre], [AlbumId]) VALUES (6, N'Loves Me Not', 2005, N'Pop', 2)
INSERT [dbo].[Songs] ([SongId], [Title], [Year], [Genre], [AlbumId]) VALUES (7, N'Perfect Enemy', 2005, N'Pop', 2)
INSERT [dbo].[Songs] ([SongId], [Title], [Year], [Genre], [AlbumId]) VALUES (8, N'Shopskata Salata', 1998, N'Pop-Folk', NULL)
INSERT [dbo].[Songs] ([SongId], [Title], [Year], [Genre], [AlbumId]) VALUES (9, N'Shampansko i sylzi', 1942, N'Chalga', 6)
INSERT [dbo].[Songs] ([SongId], [Title], [Year], [Genre], [AlbumId]) VALUES (10, N'Ubiec na liubov', 2004, N'Chalga', 6)
INSERT [dbo].[Songs] ([SongId], [Title], [Year], [Genre], [AlbumId]) VALUES (11, N'Prashka kysam az', 1989, N'Chalga', 6)
SET IDENTITY_INSERT [dbo].[Songs] OFF
INSERT [dbo].[SongsArtists] ([SongId], [ArtistID]) VALUES (1, 1)
INSERT [dbo].[SongsArtists] ([SongId], [ArtistID]) VALUES (3, 1)
INSERT [dbo].[SongsArtists] ([SongId], [ArtistID]) VALUES (4, 1)
INSERT [dbo].[SongsArtists] ([SongId], [ArtistID]) VALUES (5, 2)
INSERT [dbo].[SongsArtists] ([SongId], [ArtistID]) VALUES (6, 2)
INSERT [dbo].[SongsArtists] ([SongId], [ArtistID]) VALUES (7, 2)
INSERT [dbo].[SongsArtists] ([SongId], [ArtistID]) VALUES (8, 2)
ALTER TABLE [dbo].[AlbumsArtists]  WITH CHECK ADD  CONSTRAINT [FK_AlbumsArtists_Albums] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Albums] ([AlbumId])
GO
ALTER TABLE [dbo].[AlbumsArtists] CHECK CONSTRAINT [FK_AlbumsArtists_Albums]
GO
ALTER TABLE [dbo].[AlbumsArtists]  WITH CHECK ADD  CONSTRAINT [FK_AlbumsArtists_Artists] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artists] ([ArtistId])
GO
ALTER TABLE [dbo].[AlbumsArtists] CHECK CONSTRAINT [FK_AlbumsArtists_Artists]
GO
ALTER TABLE [dbo].[Songs]  WITH CHECK ADD  CONSTRAINT [FK_Songs_Albums] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Albums] ([AlbumId])
GO
ALTER TABLE [dbo].[Songs] CHECK CONSTRAINT [FK_Songs_Albums]
GO
ALTER TABLE [dbo].[SongsArtists]  WITH CHECK ADD  CONSTRAINT [FK_SongsArtists_Artists] FOREIGN KEY([ArtistID])
REFERENCES [dbo].[Artists] ([ArtistId])
GO
ALTER TABLE [dbo].[SongsArtists] CHECK CONSTRAINT [FK_SongsArtists_Artists]
GO
ALTER TABLE [dbo].[SongsArtists]  WITH CHECK ADD  CONSTRAINT [FK_SongsArtists_Songs] FOREIGN KEY([SongId])
REFERENCES [dbo].[Songs] ([SongId])
GO
ALTER TABLE [dbo].[SongsArtists] CHECK CONSTRAINT [FK_SongsArtists_Songs]
GO
