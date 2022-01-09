# Azure Function für IBAN-Erstellung / Validierung

## Start

Die Funktion kann mit `func start` gestartet werden und lauscht dann auf folgenden URLs:

`CreateIban: [GET,POST] http://localhost:7071/api/iban/CreateIban`

`ValidateIban: [GET] http://localhost:7071/api/iban/ValidateIban`

Der Route-Prefix `api/iban` wird in der `host.json` gesetzt und dient dafür, später einfaches Routing mit einem Reverse Proxy nutzen zu können, siehe Projekt `51-yarp-iban`.

## Tests

Es sind beispielhaft zwei xUnit-Tests im Projekt `iban-azcs-test` definiert.