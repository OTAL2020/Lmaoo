CREATE PROCEDURE [dbo].[Project_GetByOwnerId]
	@UserId INT
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
        [OwnerId] = @UserId AND 
        [Active] = 1