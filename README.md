# SQL Server Querying in C#

## Use

Data stored in relational databases in SQL can be retrieved and used in your C# application. This project aims to provide a solid template for retreiving, manipulating, and pushing data to an SQL server directly from the .NET application. There are two modes: Demo and interface mode. The former allows for a demo of the main SQL functions and the latter provides a terminal for your server to manipulate data.

## Dependencies & Installation

* Install Docker for desktop to have access to the server GUI

* This project uses a docker-based 2017 SQL server. To run:
```sh
brew install docker
sudo docker pull microsoft/mssql-server-linux:2017-latest
docker run -e "HOMEBREW_NO_ENV_FILTERING=1" -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password" -p 1433:1433 -d microsoft/mssql-server-linux
```
* ASP.NET for macOS:
https://docs.microsoft.com/en-us/dotnet/core/install/macos
