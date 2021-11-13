CREATE PROCEDURE [dbo].[User_GetByUsername]
	@Username NVARCHAR(15)
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
