CREATE PROCEDURE [dbo].[User_Update]
	@UserId		as INT,
	@Username	as NVARCHAR(15),
	@Forename	as NVARCHAR(30),
	@Surname	as NVARCHAR(30),
	@Level		as INT,
	@IsActive	as SMALLINT
AS
	SET NOCOUNT ON

	UPDATE [User]
		SET [Username] = @Username,
		[Forename] = @Forename,
		[Surname] = @Surname,
		[Level] = @Level,
		[IsActive] = @IsActive
	FROM 
		[dbo].[User]
	WHERE
		[UserId] = @UserId

	SELECT * FROM [dbo].[User] WHERE [UserId] = @UserId
