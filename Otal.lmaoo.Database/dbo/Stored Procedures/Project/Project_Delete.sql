CREATE PROCEDURE [dbo].[Project_Delete]
	@ProjectId INT
AS
	SET NOCOUNT ON

    UPDATE 
        [dbo].[Project]
    SET
        [Active] = 0
    WHERE
        [ProjectId] = @ProjectId