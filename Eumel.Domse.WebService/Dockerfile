#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Eumel.Domse.WebService/Eumel.Domse.WebService.csproj", "Eumel.Domse.WebService/"]
RUN dotnet restore "Eumel.Domse.WebService/Eumel.Domse.WebService.csproj"
COPY . .
WORKDIR "/src/Eumel.Domse.WebService"
RUN dotnet build "Eumel.Domse.WebService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Eumel.Domse.WebService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Eumel.Domse.WebService.dll"]