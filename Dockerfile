FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MyMongoApi.csproj", "./"]
RUN dotnet restore "MyMongoApi.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "MyMongoApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyMongoApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyMongoApi.dll"]
