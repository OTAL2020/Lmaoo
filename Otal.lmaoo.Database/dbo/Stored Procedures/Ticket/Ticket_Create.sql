CREATE PROCEDURE [dbo].[Ticket_Create]
	@Summary VARCHAR(50),
    @FeatureId INT,
    @ReporterId INT
AS
	SET NOCOUNT ON

    INSERT INTO [dbo].[Ticket]
    (
        [Summary],
        [FeatureId],
        [ReporterId]
    )
    VALUES
    (
        @Summary,
        @FeatureId,
        @ReporterId
    )

    SELECT * from [dbo].[Ticket] WHERE TicketId = SCOPE_IDENTITY()