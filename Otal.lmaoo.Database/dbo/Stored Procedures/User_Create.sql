CREATE PROCEDURE [dbo].[User_Create]
	@Forename	as NVARCHAR(30),
	@Surname	as NVARCHAR(30),
	@Username	as NVARCHAR(15),
	@Password	as NVARCHAR(255)

AS
	SET NOCOUNT ON

	INSERT INTO [dbo].[User]
	(
		[Forename],
		[Surname],
		[Username],
		[Password]
	)
	VALUES
	(
		@Forename,
		@Surname,
		@Username,
		@Password
	)
