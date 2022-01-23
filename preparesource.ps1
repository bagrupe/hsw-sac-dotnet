$location = Get-Location

. $PSScriptRoot/clean.ps1

Set-Location $PSScriptRoot
Remove-Item $PSScriptRoot/../hsw-sac-dotnet.zip
& zip -r $PSScriptRoot/../hsw-sac-dotnet.zip . -x '*.git*' -x '*.DS_Store*'
Set-Location $location