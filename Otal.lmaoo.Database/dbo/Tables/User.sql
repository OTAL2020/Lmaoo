CREATE TABLE [dbo].[User]
(
  [UserId]		INT				NOT NULL	IDENTITY,
  [Username]	VARCHAR(15)		NOT NULL,
  [Password]	VARCHAR(255)	NOT NULL,
  [Forename]	VARCHAR(30)		NOT NULL,
  [Surname]		VARCHAR(30)		NOT NULL,
  [Level]		SMALLINT		NOT NULL	DEFAULT '1',
  [IsActive]	BIT				NOT NULL	DEFAULT '1',
  [Picture]		VARCHAR(100)	NOT NULL	DEFAULT '/Images/avatar.jpg'

  PRIMARY KEY ([UserId])
);