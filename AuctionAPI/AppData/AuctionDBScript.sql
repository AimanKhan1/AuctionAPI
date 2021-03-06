USE [master]
GO
/****** Object:  Database [AuctionDB]    Script Date: 08/22/2021 11:34:11 PM ******/
CREATE DATABASE [AuctionDB]
GO
USE [AuctionDB]
GO
/****** Object:  Table [dbo].[AutoBidding]    Script Date: 08/22/2021 11:34:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AutoBidding](
	[AutoBiddingId] [int] IDENTITY(1,1) NOT NULL,
	[ItemBiddingId] [int] NOT NULL,
	[UserId] [int] NULL,
	[IsAutoBidding] [bit] NULL,
 CONSTRAINT [PK_AutoBidding] PRIMARY KEY CLUSTERED 
(
	[AutoBiddingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AutoBiddingAmount]    Script Date: 08/22/2021 11:34:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AutoBiddingAmount](
	[AutoBiddingAmountId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[MaxBidAmount] [decimal](18, 0) NULL,
 CONSTRAINT [PK_AutoBiddingAmount_1] PRIMARY KEY CLUSTERED 
(
	[AutoBiddingAmountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 08/22/2021 11:34:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[Image] [nvarchar](100) NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemBidding]    Script Date: 08/22/2021 11:34:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemBidding](
	[ItemBiddingId] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[CurrentPrice] [decimal](18, 0) NULL,
	[IsBidding] [bit] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Auction] PRIMARY KEY CLUSTERED 
(
	[ItemBiddingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemBiddingHistory]    Script Date: 08/22/2021 11:34:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemBiddingHistory](
	[ItemBiddingHistoryId] [int] IDENTITY(1,1) NOT NULL,
	[ItemBiddingId] [int] NULL,
	[UserId] [int] NULL,
	[BidPrice] [decimal](18, 0) NULL,
	[BidTime] [datetime] NULL,
 CONSTRAINT [PK_AuctionHistory] PRIMARY KEY CLUSTERED 
(
	[ItemBiddingHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AutoBidding] ON 

INSERT [dbo].[AutoBidding] ([AutoBiddingId], [ItemBiddingId], [UserId], [IsAutoBidding]) VALUES (1, 1, 1, 1)
INSERT [dbo].[AutoBidding] ([AutoBiddingId], [ItemBiddingId], [UserId], [IsAutoBidding]) VALUES (2, 1, 2, 1)
INSERT [dbo].[AutoBidding] ([AutoBiddingId], [ItemBiddingId], [UserId], [IsAutoBidding]) VALUES (3, 2, 2, 1)
SET IDENTITY_INSERT [dbo].[AutoBidding] OFF
SET IDENTITY_INSERT [dbo].[AutoBiddingAmount] ON 

INSERT [dbo].[AutoBiddingAmount] ([AutoBiddingAmountId], [UserId], [MaxBidAmount]) VALUES (1, 1, CAST(10 AS Decimal(18, 0)))
INSERT [dbo].[AutoBiddingAmount] ([AutoBiddingAmountId], [UserId], [MaxBidAmount]) VALUES (2, 2, CAST(19 AS Decimal(18, 0)))
INSERT [dbo].[AutoBiddingAmount] ([AutoBiddingAmountId], [UserId], [MaxBidAmount]) VALUES (3, 3, CAST(500 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[AutoBiddingAmount] OFF
SET IDENTITY_INSERT [dbo].[Item] ON 

INSERT [dbo].[Item] ([ItemId], [ItemName], [Description], [Image], [Price], [CreatedOn], [CreatedBy]) VALUES (1, N'Sand Timer', N'Antiques Era Wooden And Brass 5 Minutes Sand Timer Hour Glass Clock Home Decor Ideal For Exercise, Tea Making', N'Sand Timer.jpg', CAST(150 AS Decimal(18, 0)), CAST(N'2021-08-18T15:00:10.533' AS DateTime), 1)
INSERT [dbo].[Item] ([ItemId], [ItemName], [Description], [Image], [Price], [CreatedOn], [CreatedBy]) VALUES (2, N'Telephone Landline', N'Antique Vintage Telephone Set Landline Rotary Dial Telephone Landline', N'Telephone Landline.jpg', CAST(320 AS Decimal(18, 0)), CAST(N'2021-08-18T15:00:10.533' AS DateTime), 1)
INSERT [dbo].[Item] ([ItemId], [ItemName], [Description], [Image], [Price], [CreatedOn], [CreatedBy]) VALUES (3, N'European Horse', N'eCraftIndia Antique Finish European Horse Cart Brass Showpiece', N'European Horse.jpg', CAST(205 AS Decimal(18, 0)), CAST(N'2021-08-18T15:00:10.533' AS DateTime), 1)
INSERT [dbo].[Item] ([ItemId], [ItemName], [Description], [Image], [Price], [CreatedOn], [CreatedBy]) VALUES (4, N'Alarm Clock', N'SAPPHIRE Twin Bell Alarm Clock – Perfect for Heavy Sleepers – Loud Bell Alarm – Sweep Movement (Shine)', N'Alarm Clock.jpg', CAST(155 AS Decimal(18, 0)), CAST(N'2021-08-18T15:00:10.533' AS DateTime), 1)
INSERT [dbo].[Item] ([ItemId], [ItemName], [Description], [Image], [Price], [CreatedOn], [CreatedBy]) VALUES (5, N'Crystal Pyramid', N'Reiki Crystal Products Vastu / Feng Shui Crystal Pyramid For Positive Energy And Vastu Correction.Good Luck & Prosperity', N'Crystal Pyramid.jpg', CAST(325 AS Decimal(18, 0)), CAST(N'2021-08-18T15:00:10.533' AS DateTime), 1)
INSERT [dbo].[Item] ([ItemId], [ItemName], [Description], [Image], [Price], [CreatedOn], [CreatedBy]) VALUES (6, N'Musical Set', N'Tootpado Musical Set Desk Organiser - Set of 4 (Veena-Harmonium-2 Tablas) (1d227) - Pen Stand, Card Holder, Paper Weight', N'Musical Set.jpg', CAST(199 AS Decimal(18, 0)), CAST(N'2021-08-18T15:00:10.533' AS DateTime), 1)
INSERT [dbo].[Item] ([ItemId], [ItemName], [Description], [Image], [Price], [CreatedOn], [CreatedBy]) VALUES (7, N'Door Knocker', N'Two Moustaches Victorian Style Brass Door Knocker (Standard Size, Antique Brown)', N'Door Knocker.jpg', CAST(75 AS Decimal(18, 0)), CAST(N'2021-08-18T15:00:10.533' AS DateTime), 1)
INSERT [dbo].[Item] ([ItemId], [ItemName], [Description], [Image], [Price], [CreatedOn], [CreatedBy]) VALUES (8, N'Metal Bird Cages', N'M-PLUS Gold Color Metal Bird Cages Shadow Lamp Tea Light Candle Holder Stand Antique Items for Home Decoration with Flower Vine (Pack of 1)', N'Metal Bird Cages.jpg', CAST(183 AS Decimal(18, 0)), CAST(N'2021-08-18T15:00:10.533' AS DateTime), 1)
INSERT [dbo].[Item] ([ItemId], [ItemName], [Description], [Image], [Price], [CreatedOn], [CreatedBy]) VALUES (9, N'World Globe', N'Globeskart Educational/Antique Globe with Brass Antique Arc and Base / World Globe / Home Decor / 8 inches (Ruff Off White)', N'World Globe.jpg', CAST(299 AS Decimal(18, 0)), CAST(N'2021-08-18T15:00:10.533' AS DateTime), 1)
INSERT [dbo].[Item] ([ItemId], [ItemName], [Description], [Image], [Price], [CreatedOn], [CreatedBy]) VALUES (10, N'Fountain Pen', N'GOLD LEAF Jinhao New Golden Dragon Red Crystal Eyes Fountain Pen with Push in Style Ink Converter', N'Fountain Pen.jpg', CAST(560 AS Decimal(18, 0)), CAST(N'2021-08-18T15:00:10.533' AS DateTime), 1)
INSERT [dbo].[Item] ([ItemId], [ItemName], [Description], [Image], [Price], [CreatedOn], [CreatedBy]) VALUES (11, N'Royal Wine Glass', N'Antique Golden Royal Wine Glass, Surahi and Tray Set, Pure Brass Handicraft, Showpiece and Home Decor', N'Royal Wine Glass.jpg', CAST(423 AS Decimal(18, 0)), CAST(N'2021-08-18T15:00:10.533' AS DateTime), 1)
INSERT [dbo].[Item] ([ItemId], [ItemName], [Description], [Image], [Price], [CreatedOn], [CreatedBy]) VALUES (12, N'Aladdin Chirag', N'Shripad Steel Home Brass Decorative Aladdin Chirag Model Miniature, 9cm x 10cm, Golden, 1 Model', N'Aladdin Chirag.jpg', CAST(116 AS Decimal(18, 0)), CAST(N'2021-08-18T15:00:10.533' AS DateTime), 1)
INSERT [dbo].[Item] ([ItemId], [ItemName], [Description], [Image], [Price], [CreatedOn], [CreatedBy]) VALUES (13, N'Jewellery Box', N'Jewellery Box for Women Wooden Flip Flap Flower Carved Design Handmade Gift, 8 inches', N'Jewellery Box.jpg', CAST(499 AS Decimal(18, 0)), CAST(N'2021-08-18T15:00:10.533' AS DateTime), 1)
INSERT [dbo].[Item] ([ItemId], [ItemName], [Description], [Image], [Price], [CreatedOn], [CreatedBy]) VALUES (14, N'Real Vintage Diary', N'Jenuine leather handmade real vintage diary with 2 flap for bound diary _travel notebook, journal, creative writing, plane handmade paper (7×5inches)', N'Real Vintage Diary.jpg', CAST(249 AS Decimal(18, 0)), CAST(N'2021-08-18T15:00:10.533' AS DateTime), 1)
INSERT [dbo].[Item] ([ItemId], [ItemName], [Description], [Image], [Price], [CreatedOn], [CreatedBy]) VALUES (15, N'Kissing Duck Showpiece', N'Webelkart Aluminium Pair Of Kissing Duck Showpiece, 11 IN, Gold, Multi, 2 Piece', N'Kissing Duck Showpiece.jpg', CAST(349 AS Decimal(18, 0)), CAST(N'2021-08-18T15:00:10.533' AS DateTime), 1)
INSERT [dbo].[Item] ([ItemId], [ItemName], [Description], [Image], [Price], [CreatedOn], [CreatedBy]) VALUES (16, N'Golfer Showpiece', N'Two Moustaches Brass Golfer Showpiece Figurine Black Figurine Standard, Black & Golden, 1 Piece', N'Golfer Showpiece.jpg', CAST(115 AS Decimal(18, 0)), CAST(N'2021-08-18T15:00:10.533' AS DateTime), 1)
INSERT [dbo].[Item] ([ItemId], [ItemName], [Description], [Image], [Price], [CreatedOn], [CreatedBy]) VALUES (17, N'Glass Bottle Ship', N'SHRUN CRAFT ND BEAUTY Glass Bottle Ship Inside Bottle Showpiece Gift Item , 8 inch, Multicolour(8 Inch, Glass)', N'Glass Bottle Ship.jpg', CAST(275 AS Decimal(18, 0)), CAST(N'2021-08-18T15:00:10.533' AS DateTime), 1)
INSERT [dbo].[Item] ([ItemId], [ItemName], [Description], [Image], [Price], [CreatedOn], [CreatedBy]) VALUES (18, N'Tortoise On Plate', N'Trendy Crafts Metal Feng Shui Tortoise On Plate Showpiece (Golden, Diameter:5.5 Inch)', N'Tortoise On Plate.jpg', CAST(225 AS Decimal(18, 0)), CAST(N'2021-08-18T15:00:10.533' AS DateTime), 1)
INSERT [dbo].[Item] ([ItemId], [ItemName], [Description], [Image], [Price], [CreatedOn], [CreatedBy]) VALUES (19, N'Magnifying Glass', N'Paramount Antique Brass Magnifying Glass Vintage Table Top Decorative Gift Item', N'Magnifying Glass.jpg', CAST(99 AS Decimal(18, 0)), CAST(N'2021-08-18T15:00:10.533' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Item] OFF
SET IDENTITY_INSERT [dbo].[ItemBidding] ON 

INSERT [dbo].[ItemBidding] ([ItemBiddingId], [ItemId], [StartTime], [EndTime], [CurrentPrice], [IsBidding], [Status]) VALUES (1, 1, CAST(N'2021-08-18T20:11:06.367' AS DateTime), CAST(N'2021-08-24T15:00:10.533' AS DateTime), CAST(6 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[ItemBidding] ([ItemBiddingId], [ItemId], [StartTime], [EndTime], [CurrentPrice], [IsBidding], [Status]) VALUES (2, 2, CAST(N'2021-08-18T20:11:06.367' AS DateTime), CAST(N'2021-08-19T15:00:10.533' AS DateTime), CAST(4 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[ItemBidding] ([ItemBiddingId], [ItemId], [StartTime], [EndTime], [CurrentPrice], [IsBidding], [Status]) VALUES (3, 3, CAST(N'2021-08-18T20:11:06.367' AS DateTime), CAST(N'2021-08-21T15:00:10.533' AS DateTime), CAST(145 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[ItemBidding] ([ItemBiddingId], [ItemId], [StartTime], [EndTime], [CurrentPrice], [IsBidding], [Status]) VALUES (4, 4, CAST(N'2021-08-18T20:11:06.367' AS DateTime), CAST(N'2021-08-19T15:00:10.533' AS DateTime), CAST(120 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[ItemBidding] ([ItemBiddingId], [ItemId], [StartTime], [EndTime], [CurrentPrice], [IsBidding], [Status]) VALUES (5, 5, CAST(N'2021-08-18T20:11:06.367' AS DateTime), CAST(N'2021-08-20T15:00:10.533' AS DateTime), CAST(55 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[ItemBidding] ([ItemBiddingId], [ItemId], [StartTime], [EndTime], [CurrentPrice], [IsBidding], [Status]) VALUES (6, 6, CAST(N'2021-08-18T20:11:06.367' AS DateTime), CAST(N'2021-08-19T15:00:10.533' AS DateTime), CAST(199 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[ItemBidding] ([ItemBiddingId], [ItemId], [StartTime], [EndTime], [CurrentPrice], [IsBidding], [Status]) VALUES (7, 7, CAST(N'2021-08-18T20:11:06.367' AS DateTime), CAST(N'2021-08-19T15:00:10.533' AS DateTime), CAST(75 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[ItemBidding] ([ItemBiddingId], [ItemId], [StartTime], [EndTime], [CurrentPrice], [IsBidding], [Status]) VALUES (8, 8, CAST(N'2021-08-18T20:11:06.367' AS DateTime), CAST(N'2021-08-20T15:00:10.533' AS DateTime), CAST(183 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[ItemBidding] ([ItemBiddingId], [ItemId], [StartTime], [EndTime], [CurrentPrice], [IsBidding], [Status]) VALUES (9, 9, CAST(N'2021-08-18T20:11:06.367' AS DateTime), CAST(N'2021-08-21T15:00:10.533' AS DateTime), CAST(95 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[ItemBidding] ([ItemBiddingId], [ItemId], [StartTime], [EndTime], [CurrentPrice], [IsBidding], [Status]) VALUES (10, 10, CAST(N'2021-08-18T20:11:06.367' AS DateTime), CAST(N'2021-08-20T15:00:10.533' AS DateTime), CAST(105 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[ItemBidding] ([ItemBiddingId], [ItemId], [StartTime], [EndTime], [CurrentPrice], [IsBidding], [Status]) VALUES (11, 11, CAST(N'2021-08-18T20:11:06.367' AS DateTime), CAST(N'2021-08-20T15:00:10.533' AS DateTime), CAST(125 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[ItemBidding] ([ItemBiddingId], [ItemId], [StartTime], [EndTime], [CurrentPrice], [IsBidding], [Status]) VALUES (12, 12, CAST(N'2021-08-18T20:11:06.367' AS DateTime), CAST(N'2021-08-24T15:00:10.533' AS DateTime), CAST(116 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[ItemBidding] ([ItemBiddingId], [ItemId], [StartTime], [EndTime], [CurrentPrice], [IsBidding], [Status]) VALUES (13, 13, CAST(N'2021-08-18T20:11:06.367' AS DateTime), CAST(N'2021-08-19T15:00:10.533' AS DateTime), CAST(185 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[ItemBidding] ([ItemBiddingId], [ItemId], [StartTime], [EndTime], [CurrentPrice], [IsBidding], [Status]) VALUES (14, 14, CAST(N'2021-08-18T20:11:06.367' AS DateTime), CAST(N'2021-08-22T15:00:10.533' AS DateTime), CAST(79 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[ItemBidding] ([ItemBiddingId], [ItemId], [StartTime], [EndTime], [CurrentPrice], [IsBidding], [Status]) VALUES (15, 15, CAST(N'2021-08-18T20:11:06.367' AS DateTime), CAST(N'2021-08-19T15:00:10.533' AS DateTime), CAST(75 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[ItemBidding] ([ItemBiddingId], [ItemId], [StartTime], [EndTime], [CurrentPrice], [IsBidding], [Status]) VALUES (16, 16, CAST(N'2021-08-18T20:11:06.367' AS DateTime), CAST(N'2021-08-24T15:00:10.533' AS DateTime), CAST(115 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[ItemBidding] ([ItemBiddingId], [ItemId], [StartTime], [EndTime], [CurrentPrice], [IsBidding], [Status]) VALUES (17, 17, CAST(N'2021-08-18T20:11:06.367' AS DateTime), CAST(N'2021-08-21T15:00:10.533' AS DateTime), CAST(275 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[ItemBidding] ([ItemBiddingId], [ItemId], [StartTime], [EndTime], [CurrentPrice], [IsBidding], [Status]) VALUES (18, 18, CAST(N'2021-08-18T20:11:06.367' AS DateTime), CAST(N'2021-08-20T15:00:10.533' AS DateTime), CAST(225 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[ItemBidding] ([ItemBiddingId], [ItemId], [StartTime], [EndTime], [CurrentPrice], [IsBidding], [Status]) VALUES (19, 19, CAST(N'2021-08-18T20:11:06.367' AS DateTime), CAST(N'2021-08-24T15:00:10.533' AS DateTime), CAST(99 AS Decimal(18, 0)), 1, 1)
SET IDENTITY_INSERT [dbo].[ItemBidding] OFF
SET IDENTITY_INSERT [dbo].[ItemBiddingHistory] ON 

INSERT [dbo].[ItemBiddingHistory] ([ItemBiddingHistoryId], [ItemBiddingId], [UserId], [BidPrice], [BidTime]) VALUES (1, 1, 1, CAST(4 AS Decimal(18, 0)), CAST(N'2021-08-22T23:05:13.400' AS DateTime))
INSERT [dbo].[ItemBiddingHistory] ([ItemBiddingHistoryId], [ItemBiddingId], [UserId], [BidPrice], [BidTime]) VALUES (2, 1, 1, CAST(5 AS Decimal(18, 0)), CAST(N'2021-08-22T23:08:55.343' AS DateTime))
INSERT [dbo].[ItemBiddingHistory] ([ItemBiddingHistoryId], [ItemBiddingId], [UserId], [BidPrice], [BidTime]) VALUES (3, 1, 1, CAST(5 AS Decimal(18, 0)), CAST(N'2021-08-22T23:12:31.803' AS DateTime))
INSERT [dbo].[ItemBiddingHistory] ([ItemBiddingHistoryId], [ItemBiddingId], [UserId], [BidPrice], [BidTime]) VALUES (4, 1, 2, CAST(6 AS Decimal(18, 0)), CAST(N'2021-08-22T23:13:29.380' AS DateTime))
SET IDENTITY_INSERT [dbo].[ItemBiddingHistory] OFF
/****** Object:  Index [IX_Auction]    Script Date: 08/22/2021 11:34:12 PM ******/
CREATE NONCLUSTERED INDEX [IX_Auction] ON [dbo].[ItemBidding]
(
	[ItemBiddingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Item] ADD  CONSTRAINT [DF_Item_CreatedOn]  DEFAULT (getutcdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[ItemBidding]  WITH CHECK ADD  CONSTRAINT [FK_ItemBidding_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([ItemId])
GO
ALTER TABLE [dbo].[ItemBidding] CHECK CONSTRAINT [FK_ItemBidding_Item]
GO
ALTER TABLE [dbo].[ItemBiddingHistory]  WITH CHECK ADD  CONSTRAINT [FK_ItemBiddingHistory_ItemBidding] FOREIGN KEY([ItemBiddingId])
REFERENCES [dbo].[ItemBidding] ([ItemBiddingId])
GO
ALTER TABLE [dbo].[ItemBiddingHistory] CHECK CONSTRAINT [FK_ItemBiddingHistory_ItemBidding]
GO
/****** Object:  StoredProcedure [dbo].[GetAutoBiddingAmount]    Script Date: 08/22/2021 11:34:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Log-1 :: Aiman Aslam, 21-Aug-2021, Get Auto Bidding Max Amount
-- =============================================
CREATE PROCEDURE [dbo].[GetAutoBiddingAmount]
	@UserId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT MaxBidAmount From AutoBiddingAmount 
	WHERE UserId = @UserId
END
GO
/****** Object:  StoredProcedure [dbo].[GetItemBiddingHistory]    Script Date: 08/22/2021 11:34:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
--Log-1 :: Aiman Aslam, 19-Aug-2021, Get all bidding history of particular item
-- =============================================
CREATE PROCEDURE [dbo].[GetItemBiddingHistory] 
	@ItemBiddingId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
		IBH.ItemBiddingId, 
		I.ItemName,
		IBH.UserId,
		IBH.BidPrice,
		IBH.BidTime
	FROM ItemBiddingHistory IBH
	INNER JOIN ItemBidding IB ON IB.ItemBiddingId = IBH.ItemBiddingId
	INNER JOIN Item I ON I.ItemId = IB.ItemId

	WHERE IBH.ItemBiddingId = @ItemBiddingId
END
GO
/****** Object:  StoredProcedure [dbo].[GetItemById]    Script Date: 08/22/2021 11:34:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
--Log-1 :: Aiman Aslam, 19-Aug-2021, Get Item Detail By Id
-- =============================================       
CREATE PROCEDURE [dbo].[GetItemById]          
	@ItemBiddingId int      
AS        
       
    
BEGIN   
	-- bidding false when time expire       
	IF ISNULL((SELECT EndTime From ItemBidding WHERE ItemBiddingId = @ItemBiddingId), GETDATE()) > GETDATE() 
		UPDATE ItemBidding SET IsBidding = 0 WHERE ItemBiddingId = @ItemBiddingId

	SELECT 
		IB.ItemBiddingId
		,IB.ItemId
		,ItemName
		,Description
		,Image
		,Price AS StatingPrice
		,StartTime
		,EndTime
		,CurrentPrice
		,IsBidding
		,AB.IsAutoBidding

	FROM ItemBidding IB
	INNER JOIN Item ON Item.ItemId = IB.ItemId
	INNER JOIN AutoBidding AB ON AB.ItemBiddingId = IB.ItemBiddingId
	WHERE IB.IsBidding = 1
	AND IB.ItemBiddingId = @ItemBiddingId
END     
GO
/****** Object:  StoredProcedure [dbo].[GetItems]    Script Date: 08/22/2021 11:34:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
--Log-1 :: Aiman Aslam, 19-Aug-2021, Get List Of Items
-- =============================================        
CREATE PROCEDURE [dbo].[GetItems]   
 @ItemName NVARCHAR(100) = NULL,          
 @Description NVARCHAR(1000) = NULL,          
 @Skip INT,          
 @Take INT,
 @Order BIT = 0 -- desc         
AS        
       
    
BEGIN          
  ;WITH _rows AS (
  
	SELECT 
		ItemBiddingId
		,IB.ItemId
		,ItemName
		,[Description]
		,[Image]
		,Price AS StatingPrice
		,StartTime
		,EndTime
		,CurrentPrice
		,IsBidding

	FROM ItemBidding IB
	INNER JOIN Item ON Item.ItemId = IB.ItemId
	WHERE IB.IsBidding = 1
  
	AND (@ItemName IS NULL OR ItemName LIKE '%'+@ItemName+'%')     
	AND (@Description IS NULL OR Description LIKE '%'+@Description+'%')     
	)          
		SELECT           
			(SELECT COUNT(_rows.ItemId) FROM _rows )  AS [Count],           
		* FROM _rows          
		ORDER BY 
		CASE WHEN @Order = 0 THEN _rows.CurrentPrice END DESC,
		CASE WHEN @Order = 1 THEN _rows.CurrentPrice END          
		OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY          
          
          
END     
GO
/****** Object:  StoredProcedure [dbo].[ProcessAutoBidding]    Script Date: 08/22/2021 11:34:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
--Log-1 :: Aiman Aslam, 21-Aug-2021, Process Auto Bidding for Users
-- =============================================
CREATE PROCEDURE [dbo].[ProcessAutoBidding] 
	@ItemBiddingId INT,
	@UserId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- checking for other users that have autobidding ON
	IF EXISTS(SELECT 1 FROM AutoBidding WHERE UserId != @UserId AND ItemBiddingId = @ItemBiddingId AND IsAutoBidding = 1)
	BEGIN
		--auto bidding start
		DECLARE @BidderId INT,
				@AutoBiddingItemCount INT,
				@MaxBidAmount DECIMAL(18,2),
				@BidAmount DECIMAL(18,2),
				@ItemCurrentPrice DECIMAL(18,2)

		-- getting all users that have autobidding ON except current user
		SELECT UserId 
		INTO #Table FROM AutoBidding
		WHERE UserId != @UserId AND ItemBiddingId = @ItemBiddingId AND IsAutoBidding = 1

		-- looping through for all users
		WHILE exists (SELECT * FROM #Table)
		BEGIN
			-- getting respective user Id and his bid amount
			SET @BidderId = (SELECT TOP 1 UserId FROM #Table ORDER BY UserId ASC)
			SET @MaxBidAmount = ISNULL((SELECT MaxBidAmount FROM AutoBiddingAmount WHERE UserId = @BidderId),0)

			SET @AutoBiddingItemCount = (SELECT COUNT(*) FROM AutoBidding WHERE UserId = @BidderId AND IsAutoBidding = 1)
			SET @BidAmount = @MaxBidAmount/@AutoBiddingItemCount
			SET @ItemCurrentPrice = ISNULL((SELECT CurrentPrice FROM ItemBidding WHERE ItemBiddingId = @ItemBiddingId), 0)

			IF @BidAmount > 0 AND @BidAmount > @ItemCurrentPrice
				BEGIN
					INSERT INTO ItemBiddingHistory
					(
						ItemBiddingId
						,UserId
						,BidPrice
						,BidTime
					)
					VALUES
					(
						@ItemBiddingId
						,@UserId
						,@ItemCurrentPrice + 1
						,GETDATE()
					)

					UPDATE ItemBidding SET CurrentPrice = CurrentPrice + 1
					WHERE ItemBiddingId = @ItemBiddingId

					Update AutoBiddingAmount SET MaxBidAmount = MaxBidAmount - 1 WHERE UserId = @BidderId

					EXEC ProcessAutoBidding @ItemBiddingId, @BidderId
				END
			ELSE
				BEGIN
					UPDATE AutoBidding SET IsAutoBidding = 0 WHERE UserId = @BidderId
				END

			delete #Table WHERE UserId = @BidderId

		END

		DROP Table #Table
	END

END
GO
/****** Object:  StoredProcedure [dbo].[ProcessBidding]    Script Date: 08/22/2021 11:34:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
--Log-1 :: Aiman Aslam, 19-Aug-2021, Process bidding
--Log-2 :: Aiman Aslam, 20-Aug-2021, Call AutoBidding Functionality
-- =============================================
CREATE PROCEDURE [dbo].[ProcessBidding]
	@ItemBiddingId INT,
	@UserId INT,
	@BidPrice DECIMAL(18,2),
	@IsAutoBidding BIT = 0
AS
--DECLARE @ItemBiddingId INT = 1,
--	@UserId INT = 2,
--	@BidPrice DECIMAL(18,2) = 134,
--	@IsAutoBidding BIT = 1
BEGIN
	BEGIN TRY
		-- SET NOCOUNT ON added to prevent extra result sets FROM
		-- Interfering with SELECT statements.
		--SET NOCOUNT ON;
		--BEGIN TRAN trans
			INSERT INTO ItemBiddingHistory
			(
				ItemBiddingId
				,UserId
				,BidPrice
				,BidTime
			)
			VALUES
			(
				@ItemBiddingId
				,@UserId
				,@BidPrice
				,GETDATE()
			)

			--updating latest price in ItemBidding table
			UPDATE ItemBidding SET CurrentPrice = @BidPrice
			WHERE ItemBiddingId = @ItemBiddingId

			IF @IsAutoBidding = 1
			BEGIN
				IF EXISTS (SELECT 1 FROM AutoBidding WHERE UserId = @UserId AND ItemBiddingId = @ItemBiddingId)
					UPDATE AutoBidding SET IsAutoBidding = 1
					WHERE UserId = @UserId AND ItemBiddingId = @ItemBiddingId
				ELSE
					INSERT INTO AutoBidding (ItemBiddingId, UserId, IsAutoBidding)
					VALUES(@ItemBiddingId, @UserId, 1)
			END


			--EXEC ProcessAutoBidding @ItemBiddingId, @UserId

			Select @@RowCount
		--COMMIT TRAN trans
	END TRY
	BEGIN CATCH
		--ROLLBACK TRANSACTION trans
		SELECT
		ERROR_NUMBER() AS ErrorNumber,
		ERROR_STATE() AS ErrorState,
		ERROR_SEVERITY() AS ErrorSeverity,
		ERROR_PROCEDURE() AS ErrorProcedure,
		ERROR_LINE() AS ErrorLine,
		ERROR_MESSAGE() AS ErrorMessage;
	END CATCH;

END
GO
/****** Object:  StoredProcedure [dbo].[SaveAutoBiddingAmount]    Script Date: 08/22/2021 11:34:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Log-1 :: Aiman Aslam, 21-Aug-2021, Save Auto Bidding Max Amount
-- =============================================
CREATE PROCEDURE [dbo].[SaveAutoBiddingAmount]
	@UserId INT,
	@MaxBidAmount DECIMAL(18,2)
AS
BEGIN
	
	IF EXISTS(SELECT 1 FROM AutoBiddingAmount WHERE UserId = @UserId)
	BEGIN
		UPDATE AutoBiddingAmount SET MaxBidAmount = @MaxBidAmount
		WHERE UserId = @UserId
	END
	ELSE
	BEGIN
		INSERT INTO AutoBiddingAmount
		(
			UserId,
			MaxBidAmount
		)
		VALUES
		(
			@UserId,
			@MaxBidAmount
		)
	END
	SELECT @@ROWCOUNT
END
GO
USE [master]
GO
ALTER DATABASE [AuctionDB] SET  READ_WRITE 
GO
