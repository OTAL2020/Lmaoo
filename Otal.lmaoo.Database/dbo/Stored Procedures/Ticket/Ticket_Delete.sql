CREATE PROCEDURE [dbo].[Ticket_Delete]
	@TicketId INT
AS
	SET NOCOUNT ON

    UPDATE 
        [dbo].[Ticket]
    SET
        [Active] = 0
    WHERE
        [TicketId] = @TicketId