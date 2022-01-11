CREATE PROCEDURE [dbo].[User_GetByactive]
	@IsActive INT
AS
	SET NOCOUNT ON

	SELECT
	  [UserId],
	  [Username],
	  [Forename],
	  [Surname],
	  [Level],
	  [IsActive]
	FROM 
	  [dbo].[User]
	WHERE
	  [IsActive] = @IsActive
