CREATE TABLE [dbo].[ProjectAccess] (
  [projectAccessId]		int			NOT NULL	IDENTITY(1,1),
  [projectAccessId]		INT			NOT NULL	IDENTITY(1,1),
  [userId]				INT			NOT NULL,
  [projectId]			INT			NOT NULL,
  [managerAccess]		BIT			NOT NULL	DEFAULT '0',

  PRIMARY KEY ([projectAccessId]),

  CONSTRAINT [FK_ProjectAccess_ProjectId]	FOREIGN KEY ([ProjectId])	REFERENCES [dbo].[Project] ([projectId]),
  CONSTRAINT [FK_ProjectAccess_UserId]		FOREIGN KEY ([userId])		REFERENCES [dbo].[User] ([UserId])
)