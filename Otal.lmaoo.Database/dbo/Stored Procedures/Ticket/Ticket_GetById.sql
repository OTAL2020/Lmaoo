CREATE PROCEDURE [dbo].[Ticket_GetById]
	@TicketId INT
AS
	SET NOCOUNT ON

    SELECT 
        t.[TicketId],
        t.[Summary],
        t.[Created],
        t.[Updated],
        t.[Progress],
        t.[ReporterId],
        t.[AssigneeId], 
        CONCAT(u.forename, ' ' ,u.surname) AS ReporterName, 
        u.[Username] AS ReporterUsername, 
        CONCAT(u2.forename, ' ' ,u2.surname) AS AssigneeName, 
        u2.[Username] AS AssigneeUsername
    FROM [dbo].[Ticket] t
        INNER JOIN [dbo].[User] u ON u.userId = t.[ReporterId]
        INNER JOIN [dbo].[User] u2 ON u2.userId = t.[AssigneeId]
    WHERE 
        t.[TicketId] = @TicketId