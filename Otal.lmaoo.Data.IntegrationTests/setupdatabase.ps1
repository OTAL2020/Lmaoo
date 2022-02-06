$SQLServer = "localhost"
$Username = "SA"
$Password = "IntegrationTest123!"
$db3 = "master"
$currentDirectory = Get-Location
$scriptName = "Otal.lmaoo.Database_Create.sql"
$script = "$currentDirectory\$scriptName"

try
{
	Invoke-Sqlcmd -ServerInstance $SQLServer -Username $Username -Password $Password -Database $db3 -InputFile $script
	#Invoke-Sqlcmd -ServerInstance $SQLServer -Database $db3 -InputFile "$($currentDirectory)\Otal.lmaoo.Database_Create.sql"
	Write-Output "Script ran"
}
catch
{
	Write-Output "Something went wrong"
}