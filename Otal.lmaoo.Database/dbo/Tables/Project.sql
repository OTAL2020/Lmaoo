CREATE TABLE [dbo].[Project] 
(
  [ProjectId]	INT			NOT NULL	IDENTITY,
  [Name]		VARCHAR(20) NOT NULL,
  [Status]		VARCHAR(20) NOT NULL,
  [Owner]		INT			NOT NULL,
  [Active]		BIT			NOT NULL	DEFAULT	('1'),

  CONSTRAINT [PK_Project_ProjectId]	PRIMARY KEY ([ProjectId]),
  CONSTRAINT [FK_Project_UserId] FOREIGN KEY ([Owner]) REFERENCES [dbo].[User] ([UserId])
)