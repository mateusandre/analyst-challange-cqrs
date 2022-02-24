#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
RUN apt-get update -qq && apt-get -y install nodejs tzdata
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Web.UI/Web.UI.csproj", "src/Web.UI/"]
COPY ["src/Infra/Infra.csproj", "src/Infra/"]
COPY ["src/Domain/Domain.csproj", "src/Domain/"]
COPY ["src/Application/Application.csproj", "src/Application/"]
RUN dotnet restore "src/Web.UI/Web.UI.csproj"
COPY . .
WORKDIR "/src/src/Web.UI"
RUN dotnet build "Web.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.UI.dll"]
