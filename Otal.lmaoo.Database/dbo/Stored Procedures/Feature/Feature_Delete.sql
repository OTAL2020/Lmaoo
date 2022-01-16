CREATE PROCEDURE [dbo].[Feature_Delete]
	@FeatureId INT
AS
	SET NOCOUNT ON

    UPDATE 
        [dbo].[Feature]
    SET
        [Active] = 0
    WHERE
        FeatureId = @FeatureId