CREATE PROCEDURE [dbo].[Project_GetById]
	@ProjectId INT
AS
	SET NOCOUNT ON

    SELECT 
        [ProjectId],
        [Name],
        [Status],
        [Active],
        [OwnerId]
    FROM 
        [dbo].[Project]
    WHERE 
        [ProjectId] = @ProjectId AND 
        [Active] = 1