CREATE PROCEDURE [dbo].[Project_Create]
	@Name VARCHAR(50),
    @ProjectId INT
AS
	SET NOCOUNT ON

    INSERT INTO [dbo].[Project]
    (
        [Name],
        [ProjectId]
    )
    VALUES
    (
        @Name,
        @ProjectId
    )

    SELECT * from [dbo].[Project] WHERE ProjectId = SCOPE_IDENTITY()