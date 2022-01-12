CREATE PROCEDURE [dbo].[User_UpdateUser]
	@UserId INT,
	@Username VARCHAR,
	@Forename VARCHAR,
	@Surename VARCHAR,
	@Level SMALLINT,
	@IsActive SMALLINT
AS
	SET NOCOUNT ON

	UPDATE [User]
	  SET [Username] = @Username,
	  [Forename] = @Forename,
	  [Surname] = @Surename,
	  [Level] = @Level,
	  [IsActive] = @IsActive
	FROM 
	  [dbo].[User]
	WHERE
	  [UserId] = @UserId
