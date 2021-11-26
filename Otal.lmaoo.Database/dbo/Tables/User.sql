CREATE TABLE [dbo].[User]
(
  [UserId]		INT				NOT NULL	IDENTITY(1,1),
  [Username]	NVARCHAR(15)	NOT NULL,
  [Password]	NVARCHAR(255)	NOT NULL,
  [Forename]	NVARCHAR(30)	NOT NULL,
  [Surname]		NVARCHAR(30)	NOT NULL,
  [Level]		SMALLINT		NOT NULL	DEFAULT '1',
  [IsActive]	BIT				NOT NULL	DEFAULT '1',
  [Picture]		VARCHAR(100)	NOT NULL	DEFAULT '~/img/avatar.jpg'

  CONSTRAINT [PK_User_UserId]	PRIMARY KEY ([UserId])
);