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

    SELECT 
        c.[CommentId],
        c.[Content],
        c.[Created],
        c.[TicketId],
        u.[UserId],
        u.[Forename],
        u.[Surname],
        u.[Picture]
    FROM 
        [dbo].[Comment] c
        INNER JOIN [dbo].[User] u ON u.[UserId] = c.[UserId] 
    WHERE 
        c.[CommentId] = @CommentId