# hsw-sac-dotnet

# Hochschule Weserbergland - Skalierbare Anwendungen in der Cloud - .net

Siehe https://www.hsw-hameln.de/studienangebote/duales-studium/programm/wirtschaftsinformatik-bsc/

## Installation

Es muss die aktuelle Version des .net SDK (6.0.100 oder neuer) installiert sein.

Für die Azure Functions müssen die aktuellen Azure Function Tools (v4) installiert sein.

## Build / Clean

Mit dem Powershell-Skript `build.ps1` können alle Projekte in diesem Workspace gebaut und mit `clean.ps1` entsprechend bereinigt werden. 
Falls es Probleme beim Laden in der IDE/Editor gibt, ist es sinnvoll die Projekte über das Skript zu bauen.

## Versionierung

Da dieses Projekt die Basis für die Vorlesung ist, wird es nicht gesondert versioniert. Die zur Verfügung gestellten Workspaces sind jeweils zum Zeitpunkt der Vorlesung synchron, können zwischen den Semestern aber asynchron sein.