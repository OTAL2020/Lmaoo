CREATE PROCEDURE [dbo].[User_GetByActive]
	@IsActive BIT
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