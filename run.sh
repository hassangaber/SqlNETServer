#!/bin/bash

echo "Setting up Docker enviroment..."
brew install docker
sudo docker pull microsoft/mssql-server-linux:2017-latest
docker run -e "HOMEBREW_NO_ENV_FILTERING=1" -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password" -p 1433:1433 -d microsoft/mssql-server-linux

dotnet run