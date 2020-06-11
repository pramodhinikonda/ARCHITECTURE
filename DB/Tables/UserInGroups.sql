CREATE TABLE [dbo].[UserInGroups](
	[ID] [uniqueidentifier] NOT NULL,
	[UserGroupID] [uniqueidentifier] NULL,
	[UserID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_UserInGroups] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UserInGroups]  WITH CHECK ADD  CONSTRAINT [FK_UserInGroups_UserGroups] FOREIGN KEY([UserGroupID])
REFERENCES [dbo].[UserGroups] ([ID])
GO

ALTER TABLE [dbo].[UserInGroups] CHECK CONSTRAINT [FK_UserInGroups_UserGroups]
GO

ALTER TABLE [dbo].[UserInGroups]  WITH CHECK ADD  CONSTRAINT [FK_UserInGroups_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO

ALTER TABLE [dbo].[UserInGroups] CHECK CONSTRAINT [FK_UserInGroups_Users]
GO
