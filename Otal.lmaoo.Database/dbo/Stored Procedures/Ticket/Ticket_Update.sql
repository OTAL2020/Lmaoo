CREATE PROCEDURE [dbo].[Ticket_Update]
    @Summary VARCHAR(50),
    @Progress VARCHAR(20),
    @Deadline DATETIME,
	@FeatureId INT,
    @TicketId INT,
    @AssigneeId INT,
    @Active BIT
AS
	SET NOCOUNT ON

    UPDATE 
        [dbo].[Ticket]
    SET
        [Summary] = @Summary,
        [AssigneeId] = @AssigneeId,
        [Progress] = @Progress,
        [Deadline] = @Deadline,
        [FeatureId] = @FeatureId,
        [Updated] = GETUTCDATE()
    WHERE
        [TicketId] = @TicketId

    SELECT * from [dbo].[Ticket] WHERE TicketId = @TicketId