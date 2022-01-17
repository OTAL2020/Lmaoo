CREATE PROCEDURE [dbo].[Feature_GetInactiveByProjectId]
	@ProjectId INT
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
		[ProjectId] = @ProjectId AND
		[Active] = 0