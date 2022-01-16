CREATE PROCEDURE [dbo].[Project_CreateAccess]
    @ProjectId INT,
    @UserId INT,
    @ManagerAccess INT
AS
	SET NOCOUNT ON

    INSERT INTO [dbo].[ProjectAccess]
    (
        [ProjectId],
        [UserId],
        [ManagerAccess]
    )
    VALUES
    (
        @ProjectId,
        @UserId,
        @ManagerAccess
    )