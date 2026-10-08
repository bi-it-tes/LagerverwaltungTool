# Lagerverwaltungstool

## Voraussetzungen

Folgende Programme müssen installiert sein:

* Docker Desktop (muss gestartet sein)
* .NET SDK 10

## Anwendung starten

### 1. Datenbank starten

Im Projektordner ausführen:

```bash
docker compose up -d
```

Dadurch werden die Docker-Container für die Datenbank (MariaDB) und phpMyAdmin gestartet. Beim ersten Start dauert es einen Moment, bis die Datenbank bereit ist.

### 2. Datenbank-Tabellen erstellen

Beim ersten Start einmalig ausführen (im Ordner mit der Datei `LagerverwaltungTool.csproj`):

```bash
dotnet tool install --global dotnet-ef
dotnet ef database update
```

Dadurch werden die Tabellen erstellt. Die Testdaten werden beim Start der Anwendung automatisch eingefügt.

### 3. Anwendung starten

In einem zweiten Terminal in den Ordner mit der Datei `LagerverwaltungTool.csproj` wechseln und ausführen:

```bash
dotnet run
```

### 4. Anwendung öffnen

Im Browser öffnen: http://localhost:5236

(Falls die Adresse abweicht, steht die richtige im Terminal.)


## Datenbank kontrollieren (optional)

phpMyAdmin: http://localhost:8088

## Anwendung beenden

Im Terminal der Anwendung: `Ctrl + C`

Datenbank stoppen:

```bash
docker compose down
```