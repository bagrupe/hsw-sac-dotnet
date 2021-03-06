$location = Get-Location

Set-Location "$PSScriptRoot/11-helloworld"

& dotnet restore
& dotnet build

Set-Location "$PSScriptRoot/12-datatypes"

& dotnet restore
& dotnet build

Set-Location "$PSScriptRoot/21-rot13"

& dotnet restore
& dotnet build

Set-Location "$PSScriptRoot/31-linq"

& dotnet restore
& dotnet build

Set-Location "$PSScriptRoot/41-iban-azure/iban-azcs"

& dotnet restore
& dotnet build

Set-Location "$PSScriptRoot/41-iban-azure/iban-azcs-test"

& dotnet restore
& dotnet build

Set-Location "$PSScriptRoot/42-iban-aspx"

& dotnet restore
& dotnet build

Set-Location "$PSScriptRoot/43-iban-client"

& dotnet restore
& dotnet build

Set-Location "$PSScriptRoot/44-iban-console"

& dotnet restore
& dotnet build

Set-Location "$PSScriptRoot/45-customer-aspx"

& dotnet restore
& dotnet build

Set-Location "$PSScriptRoot/51-yarp-iban"

& dotnet restore
& dotnet build

Set-Location "$PSScriptRoot/52-yarp-customer"

& dotnet restore
& dotnet build

Set-Location "$PSScriptRoot/53-metrics"

& dotnet restore
& dotnet build

Set-Location $location