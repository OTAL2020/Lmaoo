CREATE PROCEDURE [dbo].[Comment_Update]
    @Content VARCHAR(255),
    @CommentId INT
AS
	SET NOCOUNT ON

    UPDATE 
        [dbo].[Comment]
    SET
        [Content] = @Content
    WHERE
        [CommentId] = @CommentId