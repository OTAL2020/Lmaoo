CREATE TABLE [dbo].[User]
(
  [UserId] int NOT NULL IDENTITY,
  [Username] varchar(15) NOT NULL,
  [Password] varchar(255) NOT NULL,
  [Forename] varchar(30) NOT NULL,
  [Surname] varchar(30) NOT NULL,
  [Level] SMALLINT NOT NULL DEFAULT '1',
  [IsActive] smallint NOT NULL DEFAULT '1',
  [Picture] varchar(50) NOT NULL DEFAULT '/Images/avatar.jpg'
  PRIMARY KEY ([UserId])
);