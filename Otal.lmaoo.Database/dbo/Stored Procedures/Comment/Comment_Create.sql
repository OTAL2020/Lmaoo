CREATE PROCEDURE [dbo].[Comment_Create]
	@Content VARCHAR(255),
    @TicketId INT,
    @UserId INT
AS
	SET NOCOUNT ON

    INSERT INTO [dbo].[Comment]
    (
	    [Content],
        [TicketId],
        [UserId]
    )
    VALUES
    (
    	@Content,
        @TicketId,
        @UserId
    )

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
        c.[CommentId] = SCOPE_IDENTITY()