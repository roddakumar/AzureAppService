# Use official .NET SDK image to build and publish the app
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AppService/AppService.csproj", "."]
RUN dotnet restore "AppService/AppService.csproj"
COPY . .
WORKDIR "/src/AppService"
RUN dotnet build "AppService.csproj" -c Release -o /app/build
RUN dotnet publish "AppService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AppService.dll"]
