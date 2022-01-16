CREATE PROCEDURE [dbo].[Feature_Create]
	@Name VARCHAR(50),
    @ProjectId INT
AS
	SET NOCOUNT ON

    INSERT INTO [dbo].[Feature]
    (
        [Name],
        [ProjectId]
    )
    VALUES
    (
        @Name,
        @ProjectId
    )

    SELECT * from [dbo].[Feature] WHERE FeatureId = SCOPE_IDENTITY()