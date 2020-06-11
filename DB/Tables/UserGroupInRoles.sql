CREATE TABLE [dbo].[UserGroupInRoles](
	[ID] [uniqueidentifier] NOT NULL,
	[UserGroupID] [uniqueidentifier] NULL,
	[RoleID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_UserGroupInRoles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UserGroupInRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserGroupInRoles_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([ID])
GO

ALTER TABLE [dbo].[UserGroupInRoles] CHECK CONSTRAINT [FK_UserGroupInRoles_Roles]
GO

ALTER TABLE [dbo].[UserGroupInRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserGroupInRoles_UserGroups] FOREIGN KEY([UserGroupID])
REFERENCES [dbo].[UserGroups] ([ID])
GO

ALTER TABLE [dbo].[UserGroupInRoles] CHECK CONSTRAINT [FK_UserGroupInRoles_UserGroups]
GO