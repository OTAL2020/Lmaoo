CREATE PROCEDURE [dbo].[Project_DeleteAccess]
	@ProjectId INT
AS
	SET NOCOUNT ON

	DELETE FROM 
		[dbo].[ProjectAccess] 
	WHERE 
		[ProjectId] = @ProjectId