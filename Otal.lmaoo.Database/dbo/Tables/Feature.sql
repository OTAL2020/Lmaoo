CREATE TABLE [dbo].[Feature]
(
  [FeatureId]	 int	NOT NULL	IDENTITY(1,1),
  [Name]		 varchar(50)	COLLATE utf8mb4_general_ci	NOT NULL,
  [ProjectId]	 int	NOT NULL,
  [Active]		 int	DEFAULT '1',

  PRIMARY KEY ([FeatureId]),
  CONSTRAINT [FK_ProjectId]		FOREIGN KEY ([ProjectId])	REFERENCES [dbo].[Project] ([projectId])
)