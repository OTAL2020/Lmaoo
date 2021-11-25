CREATE TABLE [dbo].[Feature]
(
  [FeatureId]	 INT	NOT NULL	IDENTITY(1,1),
  [Name]		 VARCHAR(50)		NOT NULL,
  [ProjectId]	 INT	NOT NULL,
  [Active]		 INT	DEFAULT '1',

  PRIMARY KEY ([FeatureId]),
  CONSTRAINT [FK_Feature_ProjectId]		FOREIGN KEY ([ProjectId])	REFERENCES [dbo].[Project] ([projectId])
)