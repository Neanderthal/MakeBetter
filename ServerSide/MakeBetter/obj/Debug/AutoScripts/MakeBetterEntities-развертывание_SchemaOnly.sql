SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Body] [nvarchar](500) COLLATE Cyrillic_General_CI_AS NULL,
	[TaskId] [uniqueidentifier] NULL,
	[UserId] [uniqueidentifier] NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[TaskId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[State] [tinyint] NULL,
	[ShortDescription] [nvarchar](140) COLLATE Cyrillic_General_CI_AS NULL,
	[Description] [nvarchar](500) COLLATE Cyrillic_General_CI_AS NULL,
	[UseId] [uniqueidentifier] NULL,
	[TaskType] [int] NULL,
	[DateAdded] [datetime] NULL,
	[DurationMinutes] [int] NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Email] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[NickName] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NULL,
	[Rating] [int] NULL,
	[KloutId] [nchar](15) COLLATE Cyrillic_General_CI_AS NULL,
	[DnaId] [nchar](15) COLLATE Cyrillic_General_CI_AS NULL,
	[PasswordHash] [nchar](200) COLLATE Cyrillic_General_CI_AS NULL,
	[VKId] [nchar](50) COLLATE Cyrillic_General_CI_AS NULL,
	[FacebookId] [nchar](50) COLLATE Cyrillic_General_CI_AS NULL,
	[GoogleId] [nchar](50) COLLATE Cyrillic_General_CI_AS NULL,
	[Banned] [bit] NULL,
	[Phone] [nchar](15) COLLATE Cyrillic_General_CI_AS NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersInTask](
	[UsersInTaskId] [bigint] IDENTITY(1,1) NOT NULL,
	[TaskId] [uniqueidentifier] NULL,
	[UserId] [uniqueidentifier] NULL,
	[AllowedByOwner] [bit] NULL,
	[Rating] [tinyint] NULL,
	[Comment] [nvarchar](140) COLLATE Cyrillic_General_CI_AS NULL,
	[FinalHelperAgreement] [bit] NULL
)

GO
ALTER TABLE [dbo].[Comment] ADD  CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE [dbo].[Task] ADD  CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE [dbo].[UsersInTask] ADD  CONSTRAINT [PK_UsersInTask] PRIMARY KEY CLUSTERED 
(
	[UsersInTaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE [dbo].[Task] ADD  CONSTRAINT [DF_Task_TaskId]  DEFAULT (newid()) FOR [TaskId]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_UserId]  DEFAULT (newid()) FOR [UserId]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Task] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Task] ([TaskId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Task]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_User]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_User] FOREIGN KEY([UseId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_User]
GO
ALTER TABLE [dbo].[UsersInTask]  WITH CHECK ADD  CONSTRAINT [FK_UsersInTask_Task] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Task] ([TaskId])
GO
ALTER TABLE [dbo].[UsersInTask] CHECK CONSTRAINT [FK_UsersInTask_Task]
GO
ALTER TABLE [dbo].[UsersInTask]  WITH CHECK ADD  CONSTRAINT [FK_UsersInTask_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UsersInTask] CHECK CONSTRAINT [FK_UsersInTask_User]
GO
