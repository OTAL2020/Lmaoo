$currentDirectory = Get-Location
$SQLServer = "localhost"
$db3 = "master"

Write-Output $currentDirectory

Invoke-Sqlcmd -ServerInstance $SQLServer -Username "SA" -Password "IntegrationTest123!" -Database $db3 -InputFile "$($currentDirectory)\Otal.lmaoo.Database_Create.sql"