#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ShurimaEmperor.Api.Summoners/ShurimaEmperor.Api.Summoners.csproj", "ShurimaEmperor.Api.Summoners/"]
RUN dotnet restore "ShurimaEmperor.Api.Summoners/ShurimaEmperor.Api.Summoners.csproj"
COPY . .
WORKDIR "/src/ShurimaEmperor.Api.Summoners"
RUN dotnet build "ShurimaEmperor.Api.Summoners.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShurimaEmperor.Api.Summoners.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShurimaEmperor.Api.Summoners.dll"]
