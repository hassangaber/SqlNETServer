# SQL Server Querying in C#

## 1 Use & Goals

Data stored in SQL relational databases can be retrieved and used in your C# application. This project aims to provide a solid template for retreiving, manipulating, and pushing data to an SQL server directly from the .NET application. There are two modes: Demo and interface mode.

#### Demo mode
Loads test data to a database "SampleDB" and logins into the SQL server allowing the user to preform data querying and manipulation.

#### Interface mode
Allows the user to load a fully-functional interface for a user to preform any commmand in SQL through the C# enviroment.

## 2 Dependencies & Installation

* Install Docker for desktop to have access to the server GUI

* This project uses a docker-based 2017 SQL server. To run:
```sh
brew install docker
sudo docker pull microsoft/mssql-server-linux:2017-latest
docker run -e "HOMEBREW_NO_ENV_FILTERING=1" -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password" -p 1433:1433 -d microsoft/mssql-server-linux
```
The above commands are also in `run.sh`, check next section
(**NOTICE**: Please change the above password to your preference in `run.sh`)
* ASP.NET for macOS:
https://docs.microsoft.com/en-us/dotnet/core/install/macos

## 3 Running the application
To run the application you can clone the project from github and run the bash script in the main directory.

```sh
git clone https://github.com/hassangaber/SqlNETServer SQLTest
cd ~/SQLTest
chmod u+x run.sh
./run.sh
```
After running the above commands all you will need to do is `./run.sh` to start up the application AND set up the docker enviroment.