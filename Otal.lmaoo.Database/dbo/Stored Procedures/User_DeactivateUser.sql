CREATE PROCEDURE [dbo].[User_DeactivateUser]
	@UserId INT,
	@IsActive SMALLINT
AS
	SET NOCOUNT ON

	UPDATE [User]
	  SET [IsActive] = @IsActive
	FROM 
	  [dbo].[User]
	WHERE
	  [UserId] = @UserId