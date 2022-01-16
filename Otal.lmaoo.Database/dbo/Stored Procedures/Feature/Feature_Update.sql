CREATE PROCEDURE [dbo].[Feature_Update]
    @Name VARCHAR(50),
    @ProjectId INT,
	@FeatureId INT,
    @Active BIT
AS
	SET NOCOUNT ON

    UPDATE 
        [dbo].[Feature]
    SET
        [Name] = @Name,
        [ProjectId] = @ProjectId,
        [Active] = @Active
    WHERE
        FeatureId = @FeatureId