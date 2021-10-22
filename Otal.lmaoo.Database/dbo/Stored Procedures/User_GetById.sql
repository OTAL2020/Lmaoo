CREATE PROCEDURE [dbo].[User_GetById]
	@UserId INT
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
	  [UserId] = @UserId
