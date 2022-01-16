CREATE PROCEDURE [dbo].[Comment_Delete]
	@CommentId INT
AS
	SET NOCOUNT ON

	DELETE FROM 
		[dbo].[Comment]
	WHERE 
		[CommentId] = @CommentId