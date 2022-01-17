CREATE PROCEDURE [dbo].[Comment_GetById]
	@CommentId INT
AS
	SET NOCOUNT ON

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