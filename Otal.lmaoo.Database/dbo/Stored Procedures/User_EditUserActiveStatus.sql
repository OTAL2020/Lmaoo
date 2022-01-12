CREATE PROCEDURE [dbo].[User_Edit_isActive]
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