--========================================================================================================================================

CREATE TABLE [dbo].[sgMovie](
[Id] [int] IDENTITY(1,1) NOT NULL,
[Name] [nvarchar](250) NOT NULL,
[Aliace] [nvarchar](max) NOT NULL,
[ProductionYear] [int] NULL,
[Genre] [int] NULL,
[GenreType] [int] NULL,
[Country] [int] NULL,
[Studio] [nvarchar](250) NULL,
[Director] [nvarchar](250) NULL,
[Score] [int] NULL,
[ProductionType] [int] NULL,
[SerieName] [nvarchar](250) NULL,
[SerieSeason] [int] NULL,
[SerieEpisode] [int] NULL,
[DescriptionShort] [nvarchar](max) NULL,
[DescriptionLong] [nvarchar](max) NULL
) ON [PRIMARY]
GO

--========================================================================================================================================

CREATE TABLE [dbo].[SgActor](
[Id] [int] IDENTITY(1,1) NOT NULL,
[Name] [nvarchar](250) NOT NULL,
[Aliace] [nvarchar](max) NOT NULL,
[Gender] [int] NULL,
[BornCountry] [int] NULL,
[BornYear] [int] NULL,
[Race] [int] NULL,
[FaceType] [int] NULL,
[BodyType] [int] NULL,
[ActivityType] [int] NULL,
[DescriptionShort] [nvarchar](max) NULL,
[DescriptionLong] [nvarchar](max) NULL,
[Score] [int] NULL
) ON [PRIMARY]
GO
--========================================================================================================================================
CREATE TABLE [dbo].[SgLinkActorMovie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ActorId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
 CONSTRAINT [PK_SgLinkActorMovie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_SgLinkActorMovie_Actorid]    Script Date: 27.12.2015 16:53:15 ******/
CREATE NONCLUSTERED INDEX [IX_SgLinkActorMovie_Actorid] ON [dbo].[SgLinkActorMovie]
(
	[ActorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SgLinkActorMovie_MovieId]    Script Date: 27.12.2015 16:53:26 ******/
CREATE NONCLUSTERED INDEX [IX_SgLinkActorMovie_MovieId] ON [dbo].[SgLinkActorMovie]
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
--========================================================================================================================================
CREATE TABLE [dbo].[SgImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ObjectType] [int] NOT NULL,
	[ObjectId] [int] NOT NULL,
	[ImageId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ImagePath] varbinary(MAX) NOT NULL
 CONSTRAINT [PK_SgImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
--========================================================================================================================================

CREATE TABLE [dbo].[SgClip](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SetType] [int] NOT NULL,
	[SetId] [int] NOT NULL,
	[Path] [nvarchar](255) NULL,
	[OldFileName] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL
 CONSTRAINT [PK_SgClip] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
--========================================================================================================================================

CREATE TABLE [dbo].[SgLinkClipRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClipId] [int] NOT NULL,
	[ActorId] [int] NOT NULL,	
	[RoleType] [int] NOT NULL
 CONSTRAINT [PK_SgLinkClipRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_SgLinkActorMovie_Actorid]    Script Date: 27.12.2015 16:53:15 ******/
CREATE NONCLUSTERED INDEX [IX_SgLinkClipRole_Actorid] ON [dbo].[SgLinkClipRole]
(
	[ActorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SgLinkActorMovie_MovieId]    Script Date: 27.12.2015 16:53:26 ******/
CREATE NONCLUSTERED INDEX [IX_SgLinkClipRole_ClipId] ON [dbo].[SgLinkClipRole]
(
	[ClipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO