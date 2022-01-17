CREATE PROCEDURE [dbo].[Feature_GetById]
	@FeatureId INT
AS
	SET NOCOUNT ON

	SELECT
		[FeatureId],
		[Name],
		[ProjectId],
		[Active]
	FROM
		[dbo].[Feature]
	WHERE
		[FeatureId] = @FeatureId