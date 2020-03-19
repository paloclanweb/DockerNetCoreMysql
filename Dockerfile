# Stage 1
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /usr/src/build
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /usr/src/app

# Stage 2
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
ARG URL_PORT
WORKDIR /usr/src/app
ENV NUGET_XMLDOC_MODE skip
ENV ASPNETCORE_URLS http://*:${URL_PORT}
COPY ./publish .
ENTRYPOINT ["dotnet", "API.dll"]