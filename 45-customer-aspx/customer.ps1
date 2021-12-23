$baseUrl = "http://localhost:8080/api"

$response = invoke-restmethod -Method POST -Uri "$($baseUrl)/customer" -Body "{`"name`":`"Test1`", `"address`":`"Address1`", `"iban`":`"DE75888888880000012345`"}" -ContentType "application/json" -ResponseHeadersVariable "headers" -StatusCodeVariable "status" -SkipHttpErrorCheck
Write-Host "Status" $status
$response = invoke-restmethod -Method POST -Uri "$($baseUrl)/customer" -Body "{`"name`":`"Test2`", `"address`":`"Address2`", `"iban`":`"DE75888888880000012345`"}" -ContentType "application/json" -ResponseHeadersVariable "headers" -StatusCodeVariable "status" -SkipHttpErrorCheck
Write-Host "Status" $status
$response = invoke-restmethod -Method POST -Uri "$($baseUrl)/customer" -Body "{`"name`":`"Test3`", `"address`":`"Address3`", `"iban`":`"DE75888888880000012345`"}" -ContentType "application/json" -ResponseHeadersVariable "headers" -StatusCodeVariable "status" -SkipHttpErrorCheck
Write-Host "Status" $status
$response = invoke-restmethod -Method POST -Uri "$($baseUrl)/customer" -Body "{`"name`":`"Test4`", `"address`":`"Address4`", `"iban`":`"DE75888888880000012345`"}" -ContentType "application/json" -ResponseHeadersVariable "headers" -StatusCodeVariable "status" -SkipHttpErrorCheck
Write-Host "Status" $status
$response = invoke-restmethod -Method POST -Uri "$($baseUrl)/customer" -Body "{`"name`":`"Test5`", `"address`":`"Address5`", `"iban`":`"DE75888888880000012346`"}" -ContentType "application/json" -ResponseHeadersVariable "headers" -StatusCodeVariable "status" -SkipHttpErrorCheck
Write-Host "Status" $status
