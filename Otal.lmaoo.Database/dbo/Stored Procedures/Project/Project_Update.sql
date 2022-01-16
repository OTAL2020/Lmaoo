CREATE PROCEDURE [dbo].[Project_Update]
    @Name VARCHAR(50),
    @Status VARCHAR(20),
    @ProjectId INT
AS
	SET NOCOUNT ON

    UPDATE 
        [dbo].[Project]
    SET
        [Name] = @Name,
        [Status] = @Status
    WHERE
        [ProjectId] = @ProjectId

    SELECT * FROM [dbo].[Project] WHERE [ProjectId] = @ProjectId