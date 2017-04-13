## Docker Demo 1 : Cli

### Start dotnet container and build a webapi template in it.
1. mkdir Demo1
1. cd Demo1
1. docker run -p 8000:5000 -v ${PWD}:/app -e "ASPNETCORE_URLS=http://+:5000" -it --rm microsoft/dotnet
1. cd app
1. dotnet new webapi
1. dotnet restore
1. dotnet run
1. http://localhost:8000/api/values

### Make a dockerfile to start this container.
1. Dockerfile

    ```yml
    FROM microsoft/dotnet

    WORKDIR /app

    COPY . .

    RUN ["dotnet", "restore"]
    RUN ["dotnet", "build"]

    EXPOSE 5000/tcp
    ENV ASPNETCORE_URLS http://*:5000

    ENTRYPOINT ["dotnet", "run"]
    ```

1. `docker build -t carbar/awesome:dockerdemo .`
1. `docker run -d -p 8000:5000 -t awecome_api:dockerdemo`
1. http://localhost:8000/api/values

### Building a database
1. `docker create -v /var/opt/mssql --name awesomesql microsoft/mssql-server-linux /bin/true`
1. `docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Test@123' -p 1433:1433 --volumes-from awesomesql -d --name awesome_sql microsoft/mssql-server-linux`
1. Connect to (local)
1. Create **AwesomeData**
1. Create some data

    ```sql
    CREATE TABLE AwesomeWords (
        id int IDENTITY(1,1) PRIMARY KEY,
        word varchar(256)
    );

    GO

    INSERT INTO [dbo].[AwesomeWords]
              ([word])
        VALUES
              ('Awesome'),
              ('Great'),
              ('Fabulous'),
              ('Spectacular')

    GO
    ```

### Building a network
1. `docker network create --driver bridge awesome_network`
1. Use --net=<name of network> in your docker run commands to add containers to the network.

### Docker-Compose

```yml

```