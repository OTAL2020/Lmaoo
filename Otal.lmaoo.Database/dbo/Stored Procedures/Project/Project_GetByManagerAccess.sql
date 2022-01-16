CREATE PROCEDURE [dbo].[Project_GetByManagerAccess]
	@ProjectId INT
AS
	SET NOCOUNT ON

    SELECT 
        p.[ProjectId],
        p.[Name],
        p.[Status],
        p.[Active],
        p.[OwnerId]
    FROM [dbo].[Project] p
        INNER JOIN [dbo].[ProjectAccess] pa ON pa.[ProjectId] = p.[ProjectId]
    WHERE 
        p.[ProjectId] = @ProjectId AND 
        [Active] = 1 AND
        pa.ManagerAccess = 1