CREATE TABLE [dbo].[Users](
	[ID] [uniqueidentifier] NOT NULL,
	[CutomerID] [uniqueidentifier] NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](150) NULL,
	[ActivationStatus] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK__User__3214EC2744C21FF4] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Customers] FOREIGN KEY([CutomerID])
REFERENCES [dbo].[Customers] ([ID])
GO

ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Customers]
GO