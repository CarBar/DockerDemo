## Docker Demo 1 : Cli

### Start dotnet container and build a webapi template in it.
1. mkdir Demo1
1. cd Demo1
1. docker run -p 8000:80 -v ${PWD}:/app -e "ASPNETCORE_URLS=http://+:80" -it --rm microsoft/dotnet
1. cd app
1. dotnet new webapi
1. dotnet restore
1. dotnet run
1. Browse http://localhost:8000/api/values