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

