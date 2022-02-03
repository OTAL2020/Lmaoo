CREATE PROCEDURE [dbo].[User_Delete]
	@UserId INT
AS
	SET NOCOUNT ON

	UPDATE [User] SET
		[IsActive] = 0
	FROM 
		[dbo].[User]
	WHERE
		[UserId] = @UserId
