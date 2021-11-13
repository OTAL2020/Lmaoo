CREATE PROCEDURE [dbo].[User_GetByUsername]
	@Username VARCHAR
AS
	SET NOCOUNT ON

	SELECT
	  [UserId],
	  [Username],
	  [Password],
	  [Forename],
	  [Surname],
	  [Level],
	  [IsActive],
	  [Picture]
	FROM 
	  [dbo].[User]
	WHERE
	  [Username] = @Username
