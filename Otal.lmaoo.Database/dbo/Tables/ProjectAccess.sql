CREATE TABLE [dbo].[ProjectAccess] (
  [projectAccessId]		int			NOT NULL	IDENTITY(1,1),
  [userId]				int			NOT NULL,
  [projectId]			int			NOT NULL,
  [allowAccess]			BIT			NOT NULL	DEFAULT '0',
  [managerAccess]		BIT			NOT NULL	DEFAULT '0',

  PRIMARY KEY ([projectAccessId]),

  CONSTRAINT [FK_ProjectAccess_ProjectId]	FOREIGN KEY ([ProjectId])	REFERENCES [dbo].[Project] ([projectId]),
  CONSTRAINT [FK_ProjectAccess_UserId]		FOREIGN KEY ([userId])		REFERENCES [dbo].[User] ([UserId])
)