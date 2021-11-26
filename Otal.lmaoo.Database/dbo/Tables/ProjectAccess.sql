CREATE TABLE [dbo].[ProjectAccess] (
  [ProjectAccessId]		INT			NOT NULL	IDENTITY(1,1),
  [UserId]				INT			NOT NULL,
  [ProjectId]			INT			NOT NULL,
  [ManagerAccess]		BIT			NOT NULL	DEFAULT '0',

  CONSTRAINT [PK_ProjectAccess_ProjectAccessId] PRIMARY KEY ([ProjectAccessId]),

  CONSTRAINT [FK_ProjectAccess_ProjectId] FOREIGN KEY ([ProjectId])	REFERENCES [dbo].[Project] ([projectId]),
  CONSTRAINT [FK_ProjectAccess_UserId] FOREIGN KEY ([userId]) REFERENCES [dbo].[User] ([UserId])
)