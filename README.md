# Galaxy.Net7 Import EDSM data dumps

## Getting started

### Prerequisites
- Download Visual Studio 2022 Community from https://visualstudio.microsoft.com/downloads/
- Install .NET desktop delevopment
- Install Data storage and processing

- Download SQL Server Express from https://www.microsoft.com/en-us/sql-server/sql-server-downloads
- Make sure you install the localDB

## Create the four databases eddb1-4. 
A LocalDB database can max be 10Gb, hence we need more than one database to store the 75 million systems.
- Run the script `.\Galaxy.Net7\src\eddb\dbo\Scripts\CreateDB.sql` for each database, do a search and replace 
for each new database eddb1 - eddb4

## Build the Galaxy.Net7 solution
- Open the solution [Galaxy.Net7.sln](src\Galaxy.Net7.sln) in VS 2022 and create a release build
- Import the scripts using this line:
	`& "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\Extensions\Microsoft\SQLDB\DAC\SqlPackage.exe" 
	/Sourcefile:.\Galaxy.Net7\src\eddb\bin\Release\eddb.dacpac /TargetDatabaseName:eddb1 
	/TargetServerName:"(localdb)\MSSQLLocalDB" /Action:Publish`
- Make sure you write the full path to the /Sourcefile (.\Galaxy.Net7\src\eddb\bin\Release\eddb.dacpac)
- Do a search and replace for eddb1 to the next database name and do a build
- Import the .dacpac replacing the /TargetDatabaseName with the new name
- You may have to import the view `.\Galaxy.Net7\src\eddb\dbo\Views\vwSystems.sql` in each database

## Importing the EDSM Nightly dump
- Download https://www.edsm.net/dump/systemsWithCoordinates.json.gz
- Unzip it
- Split the json into four json files using .\Galaxy.Net7\src\Split-Systems. Change fileName accordingly
- Import each json file using:
	`.\ImportEdsmSystems.exe -SystemsZipfile "D:\data\EDSM-Dumps\systemsWithCoordinates.json.gz" -ExpandSystemName "D:\data\EDSM-Dumps\systemsWithCoordinates.json.chunk2.json" -InitialCatalog eddb1`
- Remember to change InitialCatalog accordingly
- You can create four separate PowerShell prompts and do a parallel import, speeding up the process

## Run the tests
- Run the tests in `.\Galaxy.Net7\src\EDGalaxyTests\EddbTests.cs`

## You're done :-)
- Examine the methods in `.\Galaxy.Net7\src\EDGalaxy\Eddb.cs` to view the current functionality








