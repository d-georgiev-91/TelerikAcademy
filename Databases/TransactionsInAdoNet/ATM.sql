CREATE DATABASE [ATM]
GO
USE [ATM]
GO
/****** Object:  Table [dbo].[CardAccounts]    Script Date: 24.7.2013 г. 18:45:20 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CardAccounts](
	[CardAccountId] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [char](10) NOT NULL,
	[CardPIN] [char](4) NOT NULL,
	[CardCash] [money] NULL,
 CONSTRAINT [PK_CardAccounts] PRIMARY KEY CLUSTERED 
(
	[CardAccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TransactionsHistory]    Script Date: 24.7.2013 г. 18:45:20 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionsHistory](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL,
	[CardAccountId] [int] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[Ammount] [money] NOT NULL,
 CONSTRAINT [PK_TransactionsHistory] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CardAccounts] ON 

GO
INSERT [dbo].[CardAccounts] ([CardAccountId], [CardNumber], [CardPIN], [CardCash]) VALUES (6, N'9792110867', N'1234', 42211874.0000)
GO
INSERT [dbo].[CardAccounts] ([CardAccountId], [CardNumber], [CardPIN], [CardCash]) VALUES (8, N'5168714218', N'1234', 23141.0000)
GO
INSERT [dbo].[CardAccounts] ([CardAccountId], [CardNumber], [CardPIN], [CardCash]) VALUES (9, N'6964743462', N'1234', 132.0000)
GO
INSERT [dbo].[CardAccounts] ([CardAccountId], [CardNumber], [CardPIN], [CardCash]) VALUES (14, N'7354763122', N'4321', NULL)
GO
INSERT [dbo].[CardAccounts] ([CardAccountId], [CardNumber], [CardPIN], [CardCash]) VALUES (15, N'1775592183', N'4321', NULL)
GO
INSERT [dbo].[CardAccounts] ([CardAccountId], [CardNumber], [CardPIN], [CardCash]) VALUES (16, N'5765782165', N'1234', 10.0000)
GO
SET IDENTITY_INSERT [dbo].[CardAccounts] OFF
GO
SET IDENTITY_INSERT [dbo].[TransactionsHistory] ON 

GO
INSERT [dbo].[TransactionsHistory] ([TransactionId], [CardAccountId], [TransactionDate], [Ammount]) VALUES (1, 6, CAST(0x0000A2050131A246 AS DateTime), 321.0000)
GO
INSERT [dbo].[TransactionsHistory] ([TransactionId], [CardAccountId], [TransactionDate], [Ammount]) VALUES (2, 6, CAST(0x0000A2050131A8C4 AS DateTime), 321.0000)
GO
INSERT [dbo].[TransactionsHistory] ([TransactionId], [CardAccountId], [TransactionDate], [Ammount]) VALUES (3, 6, CAST(0x0000A2050131AAAF AS DateTime), 321.0000)
GO
INSERT [dbo].[TransactionsHistory] ([TransactionId], [CardAccountId], [TransactionDate], [Ammount]) VALUES (4, 6, CAST(0x0000A2050131AC4F AS DateTime), 321.0000)
GO
INSERT [dbo].[TransactionsHistory] ([TransactionId], [CardAccountId], [TransactionDate], [Ammount]) VALUES (5, 6, CAST(0x0000A2050131ADF3 AS DateTime), 321.0000)
GO
SET IDENTITY_INSERT [dbo].[TransactionsHistory] OFF
GO
/****** Object:  Index [UK_CardAccounts_CardNumber]    Script Date: 24.7.2013 г. 18:45:20 ч. ******/
ALTER TABLE [dbo].[CardAccounts] ADD  CONSTRAINT [UK_CardAccounts_CardNumber] UNIQUE NONCLUSTERED 
(
	[CardAccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TransactionsHistory]  WITH CHECK ADD  CONSTRAINT [FK_TransactionsHistory_CardAccounts] FOREIGN KEY([CardAccountId])
REFERENCES [dbo].[CardAccounts] ([CardAccountId])
GO
ALTER TABLE [dbo].[TransactionsHistory] CHECK CONSTRAINT [FK_TransactionsHistory_CardAccounts]
GO
