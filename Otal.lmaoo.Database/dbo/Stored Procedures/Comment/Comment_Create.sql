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

    SELECT * from [dbo].[Comment] WHERE CommentId = SCOPE_IDENTITY()