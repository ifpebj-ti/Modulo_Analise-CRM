FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine-arm64v8 AS build-env

WORKDIR /app

COPY Modelo.Analise.Api/*.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish Modelo.Analise.Api/Modelo.Analise.Api.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine-arm64v8
WORKDIR /app
COPY --from=build-env /app/out .


ENTRYPOINT ["dotnet", "Modulo.Analise.Api.dll"]
